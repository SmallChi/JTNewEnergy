using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    public interface INEParameter
    {
        /// <summary>
        /// 车架号
        /// </summary>
        string VIN { get; set; }
    }
}
