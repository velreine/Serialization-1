using System;
using System.IO;
using System.Runtime.Serialization;

namespace Serialization_1
{

    public enum PacketType
    {
        CLIENT_AUTH_LOGIN_BEGIN,
        SERVER_AUTH_LOGIN_RESPONSE,
        FIELD_03,
        FIELD_04,
        FIELD_05,
        FIELD_06,
        FIELD_07,
        FIELD_08,
        FIELD_09,
        FIELD_10

    };





    [Serializable()]
    public class Packet : MemoryStream , ISerializable
    {

        public string Sender;
        public int Age;
        public int TypeID;
        public PacketType Type { get { return (PacketType)TypeID; } }
        public int Length { get { return this.Payload.Length; } }
        public byte[] Payload;



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Sender", Sender, typeof(string));
            info.AddValue("Age", Age, typeof(int));
            info.AddValue("Length", Length, typeof(int));
            info.AddValue("TypeID", TypeID, typeof(int));

            int num = 0;
            foreach (byte b in Payload)
            {
                string key = "_data" + Convert.ToString(num);
                info.AddValue(key, b, typeof(byte));
                num++;

            }


        }

        public Packet(SerializationInfo info, StreamingContext context)
        {
            this.Sender = (string)info.GetValue("Sender", typeof(string));
            this.Age = (int)info.GetValue("Age", typeof(int));
            this.TypeID = (int)info.GetValue("TypeID", typeof(int));
            int payloadLength = (int)info.GetValue("Length", typeof(int));
            byte[] data = new byte[payloadLength];

            for (int i = 0; i < payloadLength; i++)
            {
                data[i] = (byte)info.GetValue("_data" + i, typeof(byte));
            }

            this.Payload = data;


        }

        public Packet(string name, int age, byte[] payload)
        {
            this.Sender = name;
            this.Age = age;
            this.Payload = payload;

        }


        public void Serialize(System.Net.Sockets.NetworkStream stream, Packet obj)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(stream, obj);
            

        }

        public Packet Deserialize(System.Net.Sockets.NetworkStream stream)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (Packet)(bf.Deserialize(stream));

        }

        public override string ToString()
        {
            return "Name: " + Sender + " Age: " + Convert.ToString(Age);
        }

       


    }
}
