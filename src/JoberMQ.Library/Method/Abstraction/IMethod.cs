using JoberMQ.Library.Method.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JoberMQ.Library.Method.Abstraction
{
    public interface IMethod
    {
        Task<MethodReturnModel<byte[]>> MethodRun(Expression<Action> methodCall);
        Task<MethodReturnModel<byte[]>> MethodRun(MethodPropertyModel methodProperty);
        Task<MethodReturnModel<byte[]>> MethodRun(string methodPropertyJson);


        MethodPropertyModel MethodProperty(Expression<Action> methodCall);
        string MethodPropertySerialize(MethodPropertyModel methodProperty);
        string MethodPropertySerialize(Expression<Action> methodCall);
        MethodPropertyModel MethodPropertyDeserialize(string methodPropertyJson);


        object[] GetExpressionParameterTypes(LambdaExpression methodCall);
        Type[] GetExpressionParameterTypes2(LambdaExpression methodCall);
        object[] GetExpressionParameterValues(LambdaExpression methodCall);
        List<MethodParameterModel> GetExpressionParameterValues2(LambdaExpression methodCall);
    }
}
