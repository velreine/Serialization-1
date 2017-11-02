using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Serialization_1
{
    class Crypto
    {


        public struct KeyPair
        {
            public string pubkey;
            public string prikey;
              
        };



        public KeyPair GenerateKeys(string path, bool bFile = true)
        {



            if (path.Length < 0) return new KeyPair();

            

            try
            {

                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);

                string privatekey = rsa.ToXmlString(true);
                string publickey = rsa.ToXmlString(false);


                if (bFile) { 
                FileStream fs = new FileStream(path + "pub.key", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(publickey);
                sw.Close();

                FileStream fs2 = new FileStream(path + "pri.key", FileMode.Create);
                StreamWriter sw2 = new StreamWriter(fs2);
                sw2.Write(privatekey);
                sw2.Close();
                }



                KeyPair kp;
                kp.prikey = privatekey;
                kp.pubkey = publickey;

                return kp;

            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR::: " + e.Message);
            }





            // If nothing else return default.
            return new KeyPair();

        }

        



    }
}
