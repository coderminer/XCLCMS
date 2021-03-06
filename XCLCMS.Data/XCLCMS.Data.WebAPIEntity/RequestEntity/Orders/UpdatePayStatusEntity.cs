﻿using System;
using System.Runtime.Serialization;

namespace XCLCMS.Data.WebAPIEntity.RequestEntity.Orders
{
    [Serializable]
    [DataContract]
    public class UpdatePayStatusEntity
    {
        [DataMember]
        public long OrderID { get; set; }

        [DataMember]
        public long FK_MerchantID { get; set; }

        [DataMember]
        public string PayStatus { get; set; }

        [DataMember]
        public int Version { get; set; }
    }
}