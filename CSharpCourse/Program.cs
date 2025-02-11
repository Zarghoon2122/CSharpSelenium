using System;

using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    //obj folder, stores compile files
    //bin, stores all exxcecutable files 

    class Program : Inheritance
    // you write the class name of the parent class which is 'Inheritance' infornt of this child class 'Program' and then you access
    // All the methods from parent class in this class.
    {
        static void Main(string[] args)

            //Static data type
        {
            var classessAndMethods = new ClassesAndMethods();
            Console.WriteLine("Hello world");
            int a = 4;
            //Double c = 3.12;
            Console.WriteLine("number is " +  a);

            String name = "Ahmad";

            Console.WriteLine("Name is" + name);

            //Dynamic data type

            var age = 25;
            Console.WriteLine("Age is" +  age);
            // age = "Hello world"; == you can not change the data type after you use the var method

            // var and dynamic are dynamic data type

            dynamic height = 5.6;
            Console.WriteLine("Height is " +  height);

            height = "Hello";
            Console.WriteLine("Height is " + height);

            classessAndMethods.getData();
        }
    }
}
