using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9
{
    internal class Student
    {
        private string name;
        private string surname;
        private string recordbookname;

        public Student(string name, string surname, string bookname)
        {
            this.name = name;
            this.surname = surname;
            this.recordbookname = bookname;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bookname { get; set; }


        public string getName()
        {
            return name;
        }   

        public string getSurname()
        {
            return surname;
        }

        public string getRecordBookName()
        {
            return recordbookname;
        }



    }
}
