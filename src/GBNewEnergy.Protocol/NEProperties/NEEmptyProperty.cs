using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties
{
    /// <summary>
    /// 空包属性
    /// </summary>
    public class NEEmptyProperty : INEProperties
    {
        public string VIN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
