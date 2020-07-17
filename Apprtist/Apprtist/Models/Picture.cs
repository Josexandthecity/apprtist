using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apprtist.Models
{
    public partial class Picture
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
