namespace P2P.WellKnown
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    /// <summary>
    /// FormatterHelper 序列化，反序列化消息的帮助类
    /// </summary>
    public class FormatterHelper
    {
        public static object Deserialize(byte[] buffer)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream(buffer, 0, buffer.Length, false);
            object obj2 = formatter.Deserialize(serializationStream);
            serializationStream.Close();
            return obj2;
        }

        public static byte[] Serialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream(0x2800);
            formatter.Serialize(serializationStream, obj);
            serializationStream.Seek(0L, SeekOrigin.Begin);
            byte[] buffer = new byte[(int) serializationStream.Length];
            serializationStream.Read(buffer, 0, buffer.Length);
            serializationStream.Close();
            return buffer;
        }
    }
}

