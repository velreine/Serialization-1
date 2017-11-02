using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Serialization_1
{
    public class PacketHandler
    {
        // IDictionary<PacketType, Action<Type>> _PacketHandlers = new Dictionary<PacketType, Action<Type>>()
        IDictionary<PacketType, Action<Packet>> _PacketHandlers = new Dictionary<PacketType, Action<Packet>>()
        {

            {PacketType.CLIENT_AUTH_LOGIN_BEGIN, Packet => {

                Crypto c = new Crypto();
                Crypto.KeyPair kp = c.GenerateKeys("", false);

                // Call a packet builder 
                
                
                /* Packet logic */} },
            {PacketType.SERVER_AUTH_LOGIN_RESPONSE, Packet => { /* Packet logic*/ } },
            {PacketType.FIELD_03, Packet => { /* Packet logic */ } },
            {PacketType.FIELD_04, Packet => { /* Packet logic */ } }

        };



        public void HandlePacket(Packet packet)
        {


            _PacketHandlers[packet.Type](packet);
        }

  


    }
}
