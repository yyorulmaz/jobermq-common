using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JoberMQ.Common.Helpers
{
    public class ByteHelper
    {

        //public static byte[] ObjectToByteArray(object obj)
        //{
        //    if (obj == null)
        //        return null;

        //    if (obj is bool)
        //    {
        //        bool booleanValue = (bool)obj;
        //        return BitConverter.GetBytes(booleanValue);
        //    }

        //    BinaryFormatter bf = new BinaryFormatter();
        //    MemoryStream ms = new MemoryStream();
        //    bf.Serialize(ms, obj);

        //    return ms.ToArray();
        //}

        //public static object ByteArrayToObject(byte[] arrBytes)
        //{
        //    if (arrBytes == null || arrBytes.Length == 0)
        //        return null;

        //    object obj = null;

        //    using (MemoryStream memStream = new MemoryStream(arrBytes))
        //    {
        //        BinaryFormatter binForm = new BinaryFormatter();
        //        obj = binForm.Deserialize(memStream);
        //    }

        //    return obj;
        //}



        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }
        public static object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            object obj = binForm.Deserialize(memStream);


            return obj;
        }

        //public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        imageIn.Save(ms, imageIn.RawFormat);
        //        return ms.ToArray();
        //    }
        //}
    }
}
