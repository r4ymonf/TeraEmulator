using System.Text;
using System.Security.Cryptography;

namespace Network.Client
{
    public class RpAuth : ARecvPacket
    {
        protected string AccountName;
        protected string Session;

        public override void Read()
        {
			ReadH(); //unk1
			ReadH(); //unk2
			int length = ReadH();
			ReadB(5); //unk3
			ReadD(); //unk4
			AccountName = ReadS(); //AccountName

            Session = "0x" + GenerateMD5(AccountName) + (AccountName.Length + 1);
        }

        public override void Process()
        {
            Communication.Logic.AccountLogic.TryAuthorize(Connection, AccountName, Session);
        }

        public string GenerateMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}