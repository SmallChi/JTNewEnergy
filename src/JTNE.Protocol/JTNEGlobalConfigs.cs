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
            SkipCRCCode = false;
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

        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        public bool SkipCRCCode { get; private set; }

        /// <summary>
        /// 设置跳过校验码
        /// 场景：测试的时候，可能需要手动改数据，所以测试的时候有用
        /// </summary>
        /// <param name="skipCRCCode"></param>
        /// <returns></returns>
        public JTNEGlobalConfigs SetSkipCRCCode(bool skipCRCCode)
        {
            instance.Value.SkipCRCCode = skipCRCCode;
            return instance.Value;
        }
    }
}
