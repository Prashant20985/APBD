using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial11.Models
{
    public class StudentBase : ComponentBase
    {
        public List<Student> students = new List<Student>();
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(4000);

            students.Add(new Student
            {
                Avatar = "Avatar\\Image1.png",
                FirstName = "Shawn",
                LastName = "Letaio",
                Birthdate = new DateTime(1999, 05, 8),
                Studies = "MBA"
            });
            students.Add(new Student
            {
                Avatar = "Avatar\\Image1.png",
                FirstName = "Anne",
                LastName = "Smith",
                Birthdate = new DateTime(1990, 06, 1),
                Studies = "Information Technoogy"

            });
            students.Add(new Student
            {
                Avatar = "Avatar\\Image1.png",
                FirstName = "John",
                LastName = "Moxley",
                Birthdate = new DateTime(1996, 08, 5),
                Studies = "Economics"
            });
            students.Add(new Student
            {
                Avatar = "Avatar\\Image1.png",
                FirstName = "Mark",
                LastName = "Parrera",
                Birthdate = new DateTime(1997, 01, 7),
                Studies = "Gastronomy"
            });
            students.Add(new Student
            {
                Avatar = "Avatar\\Image1.png",
                FirstName = "Lenus",
                LastName = "Mendonsa",
                Birthdate = new DateTime(1991, 03, 9),
                Studies = "Medical"

            });
        }

        public bool isSortedAscending;
        public void SortTable(string columnName)
        {

            if (isSortedAscending)
            {
                students = students.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            else
            {
                students = students.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
            }
            isSortedAscending = !isSortedAscending;
        }
        public string SetSortIcon(string columnName)
        {
            if (isSortedAscending)
            {
                return "fa-sort-up";
            }
            else
            {
                return "fa-sort-down";
            }
        }
    }
}
