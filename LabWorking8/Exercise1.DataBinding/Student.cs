using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DataBinding
{
    public class Student
    {

        public string StudentName { get; set; }

        public bool IsEnrolled { get; set; }

        public Student(string name, bool ch)
        {
            StudentName = name;
            IsEnrolled = ch;
        }

        public override string ToString()
        {
            return StudentName + "\tРегистрация: " + IsEnrolled + "\n";
        }

        public string FullStudentData
        {
            get { return StudentName + "\t" + IsEnrolled; }
        }
        // или тоже самое, но с помощью синтаксиса лямбда выражения:
        // public string FullStudentData => StudentName + "\t" + IsEnrolled;
    }

    public class StudentList : ObservableCollection<Student>
    {
        public StudentList() /*: base()*/
        {
            Add(new Student("Lorin Kanev", true));
            Add(new Student("Ivan Petrov", true));
            Add(new Student("Sergey Masov", false));
            Add(new Student("Tais Frolova", true));
            Add(new Student("Elena Diva", false));
        }
    }
}

