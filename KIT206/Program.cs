using System;
using System.Globalization;

namespace KIT206
{
    class Program
    {
        static void Main(string[] args)
        {
            Meeting test = new Meeting();
            test.SetMeetingID(5);
            Console.WriteLine(test.Meeting_ID);
            

        }
    }
}

