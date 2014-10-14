using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimGame.View
{
    public static class Display
    {
        public static void show(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Asks user for input between the lower and upper bounds supplied
        /// </summary>
        /// <param name="lowerBound">lower bound range inclusive</param>
        /// <param name="upperBound">upper bound range inclusive</param>
        /// <returns>user selection</returns> 
        public static int PromptForInt(string question, int lowerBound, int upperBound)
        {
            int line = -1;

            Console.Write(question);

            while (IsValidChoice(line, upperBound, lowerBound))
            {
                int.TryParse(Console.ReadLine(), out line);
                if (IsValidChoice(line, upperBound, lowerBound))
                {
                    show(line + " is an invalid selection, please try again.");
                    line = -1;
                }
            }
            return line;
        }

        private static bool IsValidChoice(int selection, int upper, int lower)
        {
            return (selection < lower || selection > upper);
        }

        /// <summary>
        /// Asks user for a boolean input of y/n
        /// </summary>
        /// <param name="question">question supplied to ask</param>
        /// <returns>bool value</returns>
        public static bool PromptForBool(string question)
        {
            string questionAnswer = null;
            bool returnBool = false;

            while (questionAnswer == null)
            {
                Console.Write(question + " y/n: ");
                questionAnswer = Console.ReadLine().ToUpper();
                if(questionAnswer.Length > 0)
                    returnBool = questionAnswer.Substring(0, 1) == "Y" ? true : false; 
            }
            return returnBool;
        }
    }
}
