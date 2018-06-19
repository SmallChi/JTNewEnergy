using System;
using System.Collections.Generic;
using System.Text;
using GBNewEnergy.Protocol.Enums;

namespace GBNewEnergy.Protocol.NEProperties.NEUploadProperties
{
    /// <summary>
    /// 车辆位置数据
    /// </summary>
    public class NEUploadVehiclePositionProperty : NEUploadPropertyBase
    {
        public override NEInfoType NEInfoType => NEInfoType.车辆位置数据;
        /// <summary>
        /// 定位状态
        /// 0位：0：有效定位；1：无效定位（当数据通信正常，而不能获取定位信息时，发送最后一次有效定位信息，并将定位状态置为无效。）
        /// 1位：0：北纬；1：南纬
        /// 2位：0：东经；1：西经
        /// 3-7位：保留
        /// </summary>
        public byte PositioStatus { get; set; }
        /// <summary>
        /// 经度
        /// 以度位单位的经度值乘以10^6，精确到百万分之一度
        /// </summary>
        public double Lng { get; set; }
        /// <summary>
        /// 纬度
        /// 以度位单位的纬度值乘以10^6，精确到百万分之一度
        /// </summary>
        public double Lat { get; set; }
    }
}
