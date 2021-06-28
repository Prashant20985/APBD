using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tutorial2.Support
{
    public class Student
    {
        [JsonPropertyName("indexnumber")]
        public string indexnumber { get; set; }

        [JsonPropertyName("fname")]
        public string FirstName { get; set; }

        [JsonPropertyName("lname")]
        public string LastName { get; set; }

        [JsonPropertyName("birthdate")]
        public string BirthDate { get; set; }

        [JsonPropertyName("email")]
        public string email{get; set;}

        [JsonPropertyName("mothersName")]
        public string MothersName { get; set; }

        [JsonPropertyName("fathersName")]
        public string FatherName { get; set; }

        [JsonPropertyName("Studies")]
        public Studies CourseName { get; set; }

    }
}
