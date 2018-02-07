using System;
using System.Collections.Generic;

namespace farstone
{
    public class GetInput
    {
        public static int GetInt()
        {
            // showField is unbuilt
            string input = Console.ReadLine();
                if(int.TryParse(input, out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                    return GetInt();
                }
        }
    }
}