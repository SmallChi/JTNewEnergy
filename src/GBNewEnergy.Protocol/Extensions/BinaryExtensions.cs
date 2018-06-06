using System;
using System.IO;
using System.Linq;
using System.Text;

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
        /// 字符串到字节数组
        /// </summary>
        /// <param name="data"></param>
        /// <param name="coding"></param>
        public static byte[] ToBytes(this string data, Encoding coding)
        {
            return coding.GetBytes(data);
        }

        /// <summary>
        /// 字符串到字节数组
        /// </summary>
        /// <param name="data"></param>
        public static byte[] ToBytes(this string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }

        /// <summary>
        /// 整型到字节数组
        /// </summary>
        /// <param name="data">int数据</param>
        /// <param name="len">int填入长度</param>
        public static byte[] ToBytes(this int data, int len)
        {
            byte[] bytes = new byte[len];
            int n = 1;
            for (int i = 0; i < len; i++)
            {
                bytes[i] = (byte)(data >> 8 * (len - n));
                n++;
            }
            return bytes;
        }

        /// <summary>
        /// 异或
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="offset"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte ToXor(this byte[] buf, int offset, int len)
        {
            byte result = buf[offset];
            for (int i = offset + 1; i < offset + len; i++)
            {
                result = (byte)(result ^ buf[i]);
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
