using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    public abstract class NEUploadPropertyBase
    {
        public abstract NEInfoType NEInfoType { get; }
    }
}
