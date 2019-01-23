using JTNE.Protocol.Interfaces;
using JTNE.Protocol.Internal;
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
            DeviceMsgSNDistributed = new DefaultDeviceMsgSNDistributedImpl();
            PlatformMsgSNDistributed = new DefaultPlatformMsgSNDistributedImpl();
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
        /// 设备流水号
        /// </summary>
        public IDeviceMsgSNDistributed DeviceMsgSNDistributed { get; private set; }
        /// <summary>
        /// 平台流水号
        /// </summary>
        public IPlatformMsgSNDistributed PlatformMsgSNDistributed { get; private set; }
        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        public bool SkipCRCCode { get; private set; }
        /// <summary>
        /// 注册自定义消息
        /// </summary>
        /// <typeparam name="TJTNEBodies"></typeparam>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public JTNEGlobalConfigs Register_CustomMsgId<TJTNEBodies>(byte customMsgId)
               where TJTNEBodies : JTNEBodies
        {
            JTNEMsgIdFactory.SetMap<TJTNEBodies>(customMsgId);
            return instance.Value;
        }
        /// <summary>
        /// 重写消息
        /// </summary>
        /// <typeparam name="TJTNEBodies"></typeparam>
        /// <param name="overwriteMsgId"></param>
        /// <returns></returns>
        public JTNEGlobalConfigs Overwrite_MsgId<TJTNEBodies>(byte overwriteMsgId)
               where TJTNEBodies : JTNEBodies
        {
            JTNEMsgIdFactory.ReplaceMap<TJTNEBodies>(overwriteMsgId);
            return instance.Value;
        }
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
        /// <summary>
        /// 设置设备流水号
        /// </summary>
        /// <param name="deviceMsgSNDistributed"></param>
        /// <returns></returns>
        public JTNEGlobalConfigs SetDeviceMsgSNDistributed(IDeviceMsgSNDistributed deviceMsgSNDistributed)
        {
            instance.Value.DeviceMsgSNDistributed = deviceMsgSNDistributed;
            return instance.Value;
        }
        /// <summary>
        /// 设置平台流水号
        /// </summary>
        /// <param name="platformMsgSNDistributed"></param>
        /// <returns></returns>
        public JTNEGlobalConfigs SetPlatformMsgSNDistributed(IPlatformMsgSNDistributed platformMsgSNDistributed)
        {
            instance.Value.PlatformMsgSNDistributed = platformMsgSNDistributed;
            return instance.Value;
        }
    }
}
