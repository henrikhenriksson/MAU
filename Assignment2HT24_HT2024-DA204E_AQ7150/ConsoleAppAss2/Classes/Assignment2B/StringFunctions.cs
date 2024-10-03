using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAss2.Classes.Assignment2B
{
    internal class StringFunctions
    {

        public void Start()
        {
            
            
            Console.Title = "String Functions (Assignment 2B)";
            Console.WriteLine("++++++++++++ String Functions +++++++++++");
            string messagePrompt = "Write a text with any number of characters and press Enter.\nAlternatively, you can copy and paste a text into this window";
            string inputMessage = Utility.ReadInput(messagePrompt);
            Console.WriteLine($"\n{stringLength(inputMessage)}");
           
            
        }

        private string stringLength(string inputMessage)
        {
            return $"{inputMessage.ToUpper()} Number of Chars: {inputMessage.Length}";
        }



    }
}
