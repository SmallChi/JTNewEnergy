using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Response
{
    public class NELoginDownStream : NEBodies
    {
        protected NELoginDownStream(byte[] buffer) : base(buffer)
        {
        }

        protected NELoginDownStream(string vin) : base(vin)
        {

        }

        public override void ToBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
