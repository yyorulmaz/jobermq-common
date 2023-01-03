using JoberMQ.Library.Helpers;
using JoberMQ.Library.Method.Abstraction;
using JoberMQ.Library.Method.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace JoberMQ.Library.Method.Implementation.Default
{
    public class DfMethod : IMethod
    {
        public async Task<MethodReturnModel<byte[]>> MethodRun(Expression<Action> methodCall)
            => await MethodRunner(MethodProperty(methodCall));
        public async Task<MethodReturnModel<byte[]>> MethodRun(MethodPropertyModel methodProperty)
            => await MethodRunner(methodProperty);
        public async Task<MethodReturnModel<byte[]>> MethodRun(string methodPropertyJson)
            => await MethodRunner(MethodPropertyDeserialize(methodPropertyJson));
        private async Task<MethodReturnModel<byte[]>> MethodRunner(MethodPropertyModel methodProperty)
        {
            var returnData = new MethodReturnModel<byte[]>();

            try
            {
                var assembly = Assembly.Load(new AssemblyName(methodProperty.MethodAssemblyName));

                Type type;
                if (methodProperty.IsChildClass == false)
                    type = assembly.GetType(methodProperty.MethodNamespaceName + "." + methodProperty.MethodClassName);
                else
                    type = assembly.GetType(methodProperty.MethodNamespaceName);


                //MethodInfo methodInfo = type.GetMethod(methodProperty.MethodName);
                MethodInfo methodInfo;
                try
                {
                    methodInfo = type.GetMethod(methodProperty.MethodName);
                }
                catch (Exception)
                {
                    methodInfo = type.GetMethod(methodProperty.MethodName, Type.EmptyTypes);

                }


                object instance = Activator.CreateInstance(type);

                object[] setParameter = new object[methodProperty.ParemeterValues.Count];
                for (int i = 0; i < methodProperty.ParemeterValues.Count; i++)
                {
                    var propertyAssembly = Assembly.Load(new AssemblyName(methodProperty.ParemeterValues[i].ParameterAssemblyName));
                    var propertyType = propertyAssembly.GetType(methodProperty.ParemeterValues[i].ParameterTypeFullName);
                    setParameter[i] = JsonConvert.DeserializeObject(methodProperty.ParemeterValues[i].ParameterValue, propertyType);
                }






                Type typeAsync = typeof(AsyncStateMachineAttribute);
                var isAsync = (AsyncStateMachineAttribute)methodInfo.GetCustomAttribute(typeAsync);

                if (isAsync == null)
                {
                    var rtrnDt = (object)methodInfo.Invoke(instance, setParameter);

                    if (rtrnDt != null)
                    {
                        var rtrnTyp = rtrnDt.GetType();
                        returnData.TypeFullName = rtrnTyp.FullName;
                        returnData.Data = ByteHelper.ObjectToByteArray(rtrnDt);
                        returnData.StatusCode = "0";
                    }
                    else
                    {
                        returnData.TypeFullName = null;
                        returnData.Data = null;
                        returnData.StatusCode = "0";
                    }
                }
                else
                {
                    var task = (Task)methodInfo.Invoke(instance, setParameter);
                    if (task != null)
                    {
                        await task.ConfigureAwait(false);
                        var resultProperty = task.GetType().GetProperty("Result");


                        var rtrnDt = resultProperty.GetValue(task);
                        var rtrnTyp = rtrnDt.GetType();

                        if (rtrnDt != null)
                        {
                            returnData.TypeFullName = rtrnTyp.FullName;

                            if (returnData.TypeFullName == "System.Threading.Tasks.VoidTaskResult")
                                returnData.Data = null;
                            else
                                returnData.Data = ByteHelper.ObjectToByteArray(rtrnDt);

                            returnData.StatusCode = "0";
                        }
                        else
                        {
                            returnData.TypeFullName = null;
                            returnData.Data = null;
                            returnData.StatusCode = "0";
                        }

                    }
                }


                #region ARSIVE
                //try
                //{
                //    var task = (Task)methodInfo.Invoke(instance, setParameter);
                //    if (task != null)
                //    {
                //        await task.ConfigureAwait(false);
                //        var resultProperty = task.GetType().GetProperty("Result");

                //        // bu sonucu bazı durumlarda dönmemiz gerekecek
                //        var rtrnDt = resultProperty.GetValue(task);
                //        var rtrnTyp = rtrnDt.GetType();

                //        if (rtrnDt != null)
                //        {
                //            returnData.Type = rtrnTyp.FullName;
                //            returnData.Data = ByteHelper.ObjectToByteArray(rtrnDt);
                //            returnData.StatusCode = "0";
                //        }
                //        else
                //        {
                //            returnData.Type = null;
                //            returnData.Data = null;
                //            returnData.StatusCode = "0";
                //        }

                //    }

                //}
                //catch (Exception)
                //{
                //    //methodInfo.Invoke(instance, setParameter);

                //    var rtrnDt = (object)methodInfo.Invoke(instance, setParameter);
                //    var rtrnTyp = rtrnDt.GetType();

                //    if (rtrnDt != null)
                //    {
                //        returnData.Type = rtrnTyp.FullName;
                //        returnData.Data = ByteHelper.ObjectToByteArray(rtrnDt);
                //        returnData.StatusCode = "0";
                //    }
                //    else
                //    {
                //        returnData.Type = null;
                //        returnData.Data = null;
                //        returnData.StatusCode = "0";
                //    }
                //}
                #endregion

            }
            catch (Exception ex)
            {
                returnData.IsOperationSuccess = false;
                returnData.Data = null;
                returnData.StatusCode = "1";
                returnData.Message = ex.Message;
            }

            return returnData;
        }



        public MethodPropertyModel MethodProperty(Expression<Action> methodCall)
        {
            var methodProperty = new MethodPropertyModel();
            var callExpression = methodCall.Body as MethodCallExpression;

            methodProperty.MethodAssemblyName = callExpression.Method.DeclaringType.Assembly.GetName().Name;


            // buna gerek olmayabilir sadece aşağıdaki kod yeterli olabilir.
            // methodProperty.MethodNamespaceName = callExpression.Method.DeclaringType.FullName;
            if (callExpression.Method.DeclaringType.FullName.IndexOf("+", 0, callExpression.Method.DeclaringType.FullName.Length - 1) == -1)
            {
                methodProperty.MethodNamespaceName = callExpression.Method.DeclaringType.Namespace;
                methodProperty.IsChildClass = false;
            }
            else
            {
                methodProperty.MethodNamespaceName = callExpression.Method.DeclaringType.FullName;
                methodProperty.IsChildClass = true;
            }
            // ----------------------------------------------------------------

            methodProperty.MethodClassName = callExpression.Method.DeclaringType.Name;
            methodProperty.MethodName = callExpression.Method.Name;
            methodProperty.ParemeterValues = GetExpressionParameterValues2(methodCall);

            return methodProperty;
        }
        public string MethodPropertySerialize(Expression<Action> methodCall)
            => JsonConvert.SerializeObject(MethodProperty(methodCall));
        public string MethodPropertySerialize(MethodPropertyModel methodProperty)
            => JsonConvert.SerializeObject(methodProperty);
        public MethodPropertyModel MethodPropertyDeserialize(string methodPropertyJson)
            => JsonConvert.DeserializeObject<MethodPropertyModel>(methodPropertyJson);



        public object[] GetExpressionParameterTypes(LambdaExpression methodCall)
        {
            var callExpression = methodCall.Body as MethodCallExpression;
            var arguments = callExpression.Arguments;

            object[] objts = new object[arguments.Count];

            for (int i = 0; i < arguments.Count; i++)
                objts[i] = arguments[i].Type;

            return objts;
        }
        public Type[] GetExpressionParameterTypes2(LambdaExpression methodCall)
        {
            var callExpression = methodCall.Body as MethodCallExpression;
            var arguments = callExpression.Arguments;

            Type[] typs = new Type[arguments.Count];

            for (int i = 0; i < arguments.Count; i++)
                typs[i] = arguments[i].Type;

            return typs;
        }
        public object[] GetExpressionParameterValues(LambdaExpression methodCall)
        {
            var callExpression = methodCall.Body as MethodCallExpression;
            var arguments = callExpression.Arguments;

            object[] objts = new object[arguments.Count];

            for (int i = 0; i < arguments.Count; i++)
                objts[i] = Expression.Lambda(arguments[i]).Compile().DynamicInvoke();

            return objts;
        }
        public List<MethodParameterModel> GetExpressionParameterValues2(LambdaExpression methodCall)
        {
            var methodParameters = new List<MethodParameterModel>();
            var callExpression = methodCall.Body as MethodCallExpression;
            var arguments = callExpression.Arguments;

            foreach (var item in arguments)
            {
                var methodParameter = new MethodParameterModel();
                methodParameter.ParameterAssemblyName = item.Type.Assembly.FullName;
                methodParameter.ParameterTypeFullName = item.Type.FullName;
                methodParameter.ParameterValue = JsonConvert.SerializeObject(Expression.Lambda(item).Compile().DynamicInvoke());

                methodParameters.Add(methodParameter);
            }

            return methodParameters;
        }
    }
}
