using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* WorldPacket : ByteBuffer
 * 
 * Methods::
 * GetOpcode() const
 * GetOpcodeName() const 
 * Initialize(uint 16 opcode, size_t newres = 200)
 * SetOpcode(uint16 opcode)
 * 
 * 
 * Constructors::
 * WorldPacket()
 * WorldPacket(const WorldPacket & packet)
 * WorldPacket(uint16 opcode, size_t res = 200)
 * 
 * Vars::
 * m_opcode
 * 
 * */
/* ByteBuffer
 * 
 * 
 * Methods::
 * 
 * append(const ByteBuffer &buffer)
 * append(const char * src, size_t cnt)
 * append(const std::string &str)
 * append(const uint8 * src, size_t cnt)
 * append<T>(const T * src, size_t cnt)
 * append<T>(T value)
 * appendPackGUID(uint64 guid)
 * appendPackXYZ(float x, float y, float z)
 * clear()
 * contents() const
 * empty() const
 * hexlike() const
 * print_storage() const
 * put(size_t pos, const uint8 * src, size_t cnt)
 * put<T>(size_t pos, T value)
 * read(uint8 * dest, size_t len)
 * read<T>()
 * read<T>(size_t pos) const
 * read_skip(size_t skip)
 * read_skip<T>()
 * readPackGUID()
 * reserve(size_t ressize)
 * resize(size_t newsize)
 * rpos() const
 * size() const
 * textlike() const
 * wpos() const
 * wpos(size_t wpos_)
 * 
 * 
 * 
 * 
 * Constructors:::
 * 
 * ByteBuffer()
 * ByteBuffer(const ByteBuffer & buf)
 * ByteBuffer(size_t res)
 *
 * Variables::
 * 
 * DEFAULT_SIZE
 * _rpos
 * _storage
 * _wpos
 *
 * Overloaded operators::: 
 * 
 * []
 * <<
 * >>
 *
 */









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
