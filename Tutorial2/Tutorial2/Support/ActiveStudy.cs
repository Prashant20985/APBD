using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tutorial2.Support
{
    public class ActiveStudy
    {
        public ActiveStudy(string name)
        {
            this.name = name;
        }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("numberOfStudents")]
        public int NumberOfStudents { get; set; }
    }
}
