using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tutorial2.Support
{
    public  class Studies
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("mode")]
        public string mode { get; set; }

  
    }
}
