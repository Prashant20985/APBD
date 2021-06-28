using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tutorial2.Support
{
    [Serializable]
    public class University
    {

        [JsonPropertyName("Author")]
        public String Author
        {
            get; set;
        }


        [JsonPropertyName("CreatedAt")]
        public string CreatedAt
        {
            get; set;
        }

        [JsonPropertyName("Student")]
        public List<Student> Students
        {
            get; set;
        }

        public List<ActiveStudy> activeStudies
        {
            get
            {
                var course = new Dictionary<string, ActiveStudy>();
                Students.ForEach(delegate (Student s)
                {
                    if (course.ContainsKey(s.CourseName.name))
                    {
                        course[s.CourseName.name].NumberOfStudents += 1;
                    }
                    else
                    {
                        course.Add(s.CourseName.name, new ActiveStudy(s.CourseName.name));
                    }
                });
                return new List<ActiveStudy>(course.Values);
            }
            set
            {
                activeStudies = value;
            }
        }


    }
}


