using System;
using System.Collections.Generic;
using System.Text;

namespace Account_Registration
{
    internal class StudentInfoClass
    {
        public delegate string DelegateText();
        public delegate long DelegateNumber();

        public static string FirstName = string.Empty;
        public static string LastName = string.Empty;
        public static string MiddleName = string.Empty;
        public static string Address = string.Empty;
        public static string Program = string.Empty;
        public static long Age = 0;
        public static long ContactNo = 0;
        public static long StudentNo = 0;

        public static string GetFirstName() => FirstName;
        public static string GetLastName() => LastName;
        public static string GetMiddleName() => MiddleName;
        public static string GetAddress() => Address;
        public static string GetProgram() => Program;
        public static long GetAge() => Age;
        public static long GetContactNo() => ContactNo;
        public static long GetStudentNo() => StudentNo;
    }
}
