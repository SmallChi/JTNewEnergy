using System;
using System.IO;
using System.Linq;

namespace GBNewEnergy.Protocol.Extensions
{
    public static class BinaryExtensions
    {

        /// <summary>
        /// 从高位到低位转成int
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static int ToIntH2L(this byte[] bytes, int offset, int len)
        {
            int result = 0;
            for (int i = offset; i < offset + len; i++)
            {
                result += bytes[i] * (int)Math.Pow(256, len + offset - i - 1);
            }
            return result;
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="separator">默认 " "</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes,string  separator=" ")
        {
            return string.Join(separator, bytes.Select(s => s.ToString("X2")));
        }

        /// <summary>
        /// 16进制字符串转16进制数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static byte[] ToHexBytes(this string hexString, string separator = " ")
        {
            return hexString.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToByte(s, 16)).ToArray();
        }
    }
}
