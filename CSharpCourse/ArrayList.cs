using System;
using System.Collections;

namespace CSharpCourse
{
    class ArrayLists
    {

        static void Main(String[] args)
        {
            ArrayList a = new ArrayList();

            //We need to use 'Add' to add element in the array list
            a.Add("Hello");
            a.Add("World");
            a.Add("Apple");
            a.Add("Orange");

            Console.WriteLine(a[1]);

            //From arrylist 'a' the 'Hello' word will save in the 'item' varriable and the 'item' is decalred as 'String'
            foreach (String item in a)
            
            {
                Console.WriteLine(item);
            }
            //This will return 'true' because the 'a' has 'Hello'
            Console.WriteLine(a.Contains("Hello"));
            Console.WriteLine("After sorting");
            
            //below 'Sort();' will sort the list in alphabetical order
            //This method only availble in 'ArrayList' not only in Array
            a.Sort();

            foreach (String item in a)

            {
                Console.WriteLine(item);
            }
        }
    }
} 