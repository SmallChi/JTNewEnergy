using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.UpStream
{
    public class NELogoutUpStream : NEBodies
    {
        protected NELogoutUpStream(byte[] buffer) : base(buffer)
        {
        }

        protected NELogoutUpStream(string vin) : base(vin)
        {
            (ushort LoginNum, DateTime ExpirationTime) temp;
            if (LoginNumDict.TryGetValue(vin, out temp))
            {
                LoginNum = temp.LoginNum;
            }
        }

        public override void ToBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
