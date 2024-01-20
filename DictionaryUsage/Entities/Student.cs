using DictionaryUsage.Abstractions;
using DictionaryUsage.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryUsage.Entities
{
    public class Student : User, IStudent
    {
        public string StudentNo { get; set; }
        public byte AbsenceCount { get; set; }
        public byte Grade { get; set; }

        public Student() { }
        public Student(string userName, string password, bool isActive, string studentNo, byte absenceCount, byte grade) : base(userName, password, isActive)
        {
            StudentNo = studentNo;
            AbsenceCount = absenceCount;
            Grade = grade;
        }
    }
}
