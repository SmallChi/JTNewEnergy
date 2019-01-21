using JTNE.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Exceptions
{
    public class JTNEException:Exception
    {
        public JTNEException(JTNEErrorCode errorCode) : base(errorCode.ToString())
        {
            this.ErrorCode = errorCode;
        }

        public JTNEException(JTNEErrorCode errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public JTNEErrorCode ErrorCode { get; }
    }
}
