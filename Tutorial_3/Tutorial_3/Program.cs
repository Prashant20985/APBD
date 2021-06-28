using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tutorial_3.Models;
using Tutorial_3.Services;

namespace Tutorial_3
{
    public class Program
    {
        public static string filePath = "StudentData/Student.csv";

        public static void Main(string[] args)
        {
            
            var fileInfo = new FileInfo(filePath);
            using (var streamReader = new StreamReader(fileInfo.OpenRead()))
            {
                string line = null;
                while (null != (line = streamReader.ReadLine()))
                {
                    string[] stud = line.Split(",");
                    var student = new Student()
                    {
                        FirstName = stud[0],
                        Surname = stud[1],
                        Index = stud[2],
                        Birthdate = DateTime.Parse(stud[3]),
                        Study = stud[4],
                        Mode = stud[5],
                        Email = stud[6],
                        FatherName = stud[7],
                        MotherName = stud[8]
                    };
                    StudentDbService.students.Add(student);
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
