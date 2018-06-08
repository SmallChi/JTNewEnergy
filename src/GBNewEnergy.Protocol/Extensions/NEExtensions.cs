using System;
using System.IO;
using System.Linq;
using System.Text;

namespace GBNewEnergy.Protocol.Extensions
{
    public static class NEExtensions
    {
        /// <summary>
        /// 日期限制于2000年
        /// </summary>
        private const int DateLimitYear = 2000;

        public static DateTime ReadDateTimeLittle(this byte[] read,int offset, int len)
        {
            return new DateTime(
                read[offset] + DateLimitYear,
                read[++offset],
                read[++offset],
                read[++offset],
                read[++offset],
                read[++offset]);
        }

        public static ushort ReadUShortH2LLittle(this byte[] read, int offset, int len)
        {
            int result = 0;
            for (int i = offset; i < offset + len; i++)
            {
                result += read[i] * (int)Math.Pow(256, len + offset - i - 1);
            }
            return (ushort)result;
        }

        public static string ReadStringLittle(this byte[] read, int offset, int len,Encoding coding)
        {
            return coding.GetString(read, offset, len).Trim('\0');
        }

        public static string ReadStringLittle(this byte[] read, int offset, int len)
        {
            return Encoding.ASCII.GetString(read, offset, len).Trim('\0');
        }

        public static void WriteLittle(this byte[] write,string str, int offset, Encoding coding)
        {
            byte[] strByte = coding.GetBytes(str);
            Array.Copy(strByte, 0, write, offset, strByte.Length);
        }

        public static void WriteLittle(this byte[] write, string str, int offset)
        {
            byte[] strByte = Encoding.ASCII.GetBytes(str);
            Array.Copy(strByte, 0, write, offset, strByte.Length);
        }

        public static void WriteLittle(this byte[] write,int data ,int offset,int len)
        {
            int n = 1;
            for (int i = 0; i < len; i++)
            {
                write[offset] = (byte)(data >> 8 * (len - n));
                n++;
                offset++;
            }
        }

        public static void WriteLittle(this byte[] write, ushort data, int offset, int len)
        {
            int n = 1;
            for (int i = 0; i < len; i++)
            {
                write[offset] = (byte)(data >> 8 * (len - n));
                n++;
                offset++;
            }
        }

        public static void WriteLittle(this byte[] write, byte[] bytes, int offset, int len)
        {
            Array.Copy(bytes, 0, write, offset, len);
        }

        public static void WriteLittle(this byte[] write, DateTime date, int offset,int len)
        {
            write[offset] = (byte)(date.Year - DateLimitYear);
            write[++offset] = (byte)date.Month;
            write[++offset] = (byte)date.Day;
            write[++offset] = (byte)date.Hour;
            write[++offset] = (byte)date.Minute;
            write[++offset] = (byte)date.Second;
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
