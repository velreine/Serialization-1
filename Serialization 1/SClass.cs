using System;
using System.Runtime.Serialization;

namespace Serialization_1
{
    [Serializable()]
    public class Packet : ISerializable
    {

        public string Name;
        public int Age;
        public int Length { get { return this.Payload.Length; } }
        public byte[] Payload;



        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name, typeof(string));
            info.AddValue("Age", Age, typeof(int));
            info.AddValue("Length", Length, typeof(int));

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
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.Age = (int)info.GetValue("Age", typeof(int));

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
            this.Name = name;
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
            return "Name: " + Name + " Age: " + Convert.ToString(Age);
        }

       


    }
}
