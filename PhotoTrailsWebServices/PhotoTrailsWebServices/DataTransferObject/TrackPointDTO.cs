using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PhotoTrailsWebServices.DataTransferObject
{
    [DataContract]
    public class TrackPointDTO
    {
        [DataMember]
        public decimal id { get; set; }

        [DataMember]
        public int order { get; set; }

        [DataMember]
        public decimal latitude { get; set; }

        [DataMember]
        public decimal longitude { get; set; }

        [DataMember]
        public short? elevation { get; set; }

        [DataMember]
        public DateTime? date_time { get; set; }
    }
}