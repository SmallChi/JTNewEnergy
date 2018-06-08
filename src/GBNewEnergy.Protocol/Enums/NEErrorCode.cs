using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Enums
{
    public enum NEErrorCode
    {
        /// <summary>
        /// 开始标识错误
        /// </summary>
        BeginFlagError = 1001,
        /// <summary>
        /// BCC校验错误
        /// </summary>
        BCCCodeError = 1002,
        /// <summary>
        /// 登入流水号错误
        /// </summary>
        LoginSerialNoError=1003
    }
}
