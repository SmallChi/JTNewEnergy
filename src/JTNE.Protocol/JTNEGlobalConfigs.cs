using System;
using System.Text;

namespace JTNE.Protocol
{
    /// <summary>
    /// 
    /// </summary>
    public class JTNEGlobalConfigs
    {
        private static readonly Lazy<JTNEGlobalConfigs> instance = new Lazy<JTNEGlobalConfigs>(() => new JTNEGlobalConfigs());

        private JTNEGlobalConfigs()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding = Encoding.UTF8;
        }
        /// <summary>
        /// 字符串编码
        /// </summary>
        public Encoding Encoding { get; }

        /// <summary>
        /// 
        /// </summary>
        public static JTNEGlobalConfigs Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}
