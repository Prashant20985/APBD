using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Tutorial2.Support;

namespace Tutorial2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : "./Data/dane.csv";
            var dataFormat = args.Length > 0 ? args[2] : "json";
            var dest_path = args.Length > 0 ? args[1] : $"result.{dataFormat}";
            var list = new List<Student>();
            var university = new List<University>();

            FileInfo fInfo = new FileInfo(path);

            try
            {


                if (!fInfo.Exists)
                    throw new FileNotFoundException("File not Found");

                using (StreamReader stream = new StreamReader(fInfo.OpenRead()))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] student = line.Split(',');

                        if (student.Length != 9)
                        {
                            File.AppendAllText("./log.txt", $"Wrong Information");
                        }

                        Student st = new Student
                        {
                            indexnumber = "s" + student[4],
                            FirstName = student[0],
                            LastName = student[1],
                            BirthDate = student[5],
                            email = student[6],
                            MothersName = student[7],
                            FatherName = student[8],
                            CourseName = new Studies
                            {
                                name = student[2],
                                mode = student[3]

                            }
                        };

                        University uni = new University
                        {
                            Author = "Prashant Sharma/ s20985 ",
                            CreatedAt = DateTime.Now.ToString("dd.MM.yyyy"),
                            Students = list
                        };

                        list.Add(st);
                        university.Add(uni);
                    }
                }
            }
            catch(FileNotFoundException )
            {
                File.AppendAllText("./log.txt","Cannot Find File");
            }

    
            string jsonString = JsonSerializer.Serialize(university);
            File.WriteAllText(dest_path, jsonString);
        }
    } }


