using System;
using System.Collections.Generic;
using System.Linq;

namespace app1
{
    class student
    {
        public string Name;

        public int ID;

        public string Department;

        public  string ToString()
        {
            return this.Name + "\n" + this.ID+ "\n" + this.Department;
        }
    }
   
    class Program
    {
        public static void Main()
        {
            List<student> studentobj1 = new List<student>();
            for (int i = 10; i > 0; i--)
            {
                student obj1 = new student();
                obj1.Name = "gokul";
                obj1.ID = i;
                obj1.Department = "CSE";
                studentobj1.Add(obj1);
                Console.WriteLine(obj1.ToString());
                
            }
            
        }
	}
}
