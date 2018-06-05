using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Exceptions
{
    public class NEException:Exception
    {
        public NEException(ErrorCode errorCode) : base(errorCode.ToString())
        {
            this.ErrorCode = errorCode;
        }

        public NEException(ErrorCode errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }


        public ErrorCode ErrorCode { get; }
    }
}
