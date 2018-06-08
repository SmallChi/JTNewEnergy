using GBNewEnergy.Protocol.Exceptions;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 车辆登入
    /// </summary>
    public class NELogoutUpStream : NEBodies
    {
        public NELogoutUpStream(byte[] buffer) : base(buffer)
        {
            CurrentDateTime = buffer.ReadDateTimeLittle(0, 6);
            LoginNum = buffer.ReadUShortH2LLittle(6, 2);
        }

        public NELogoutUpStream(string vin) : base(vin)
        {
            (ushort LoginNum, DateTime ExpirationTime) temp;
            if (LoginNumDict.TryGetValue(vin, out temp))
            {
                LoginNum = temp.LoginNum;
            }
            else
            {
                throw new NEException(Enums.ErrorCode.LoginSerialNoError, "Must Dependency NELoginUpStream Class.");
            }
            ToBuffer();
        }

        public override void ToBuffer()
        {
            Buffer = new byte[8];
            Buffer.WriteLittle(CurrentDateTime, 0, 6);
            Buffer.WriteLittle(LoginNum, 6, 2);
        }
    }
}
