using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PhotoTrailsWebServices.DataTransferObject
{
    [DataContract]
    public class TrailDTO
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public TimeSpan duration { get; set; }

        [DataMember]
        public List<TrackPointDTO> trackpoints { get; set; }
    }
}