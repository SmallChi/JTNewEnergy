using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Exceptions
{
    public class NEException:Exception
    {
        public NEException(NEErrorCode errorCode) : base(errorCode.ToString())
        {
            this.ErrorCode = errorCode;
        }

        public NEException(NEErrorCode errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }


        public NEErrorCode ErrorCode { get; }
    }
}
