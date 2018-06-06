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
    }
}
