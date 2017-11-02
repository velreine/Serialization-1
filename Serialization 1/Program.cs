using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_1
{
    class Program
    {
        static void Main(string[] args)
        {



           

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream("C:\\Users\\Velreine\\Desktop\\seri2.txt", FileMode.Create);


            byte[] data = { (byte)10, (byte)11, (byte)12 };
            Packet myclass = new Packet("Erik", 24, data);

            bf.Serialize(fs, myclass);

            fs.Close();

            int CC;

            FileStream fs2 = new FileStream("C:\\Users\\Velreine\\Desktop\\seri2.txt", FileMode.Open);

            Packet desi;

            desi = (Packet)bf.Deserialize(fs2);

            Console.WriteLine(desi.ToString());

            byte[] newdata = desi.Payload;

            Console.ReadKey();


        
            
        }








    }
}
