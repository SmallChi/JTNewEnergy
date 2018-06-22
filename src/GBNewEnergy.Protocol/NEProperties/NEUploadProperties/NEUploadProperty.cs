using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 上报信息
    /// </summary>
    public class NEUploadProperty : INEProperties
    {
        public string VIN { get ; set; }

        public NEUploadProperty(params NEUploadPropertyBase[] NEUploadPropertyBase)
        {
            if (NEUploadPropertyBase != null)
            {
                NEUploadPropertys = NEUploadPropertyBase.ToList();
            }
        }

        public List<NEUploadPropertyBase> NEUploadPropertys { get; set; }
    }
}
