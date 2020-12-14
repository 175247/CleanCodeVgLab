using System;

namespace CleanCodeLab3.Utilities
{
    public class Helpers
    {
        public void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public int GetCustomerSelection(int maxInputAllowed)
        {
            int customerChoice = 0;

            try
            {
                customerChoice = Int32.Parse(Console.ReadLine());
                ValidateUserInput(customerChoice, maxInputAllowed);
                return customerChoice;
            }
            catch (Exception e)
            {
                PrintToConsole(e.Message);
                PrintToConsole("Försök igen.");
                customerChoice = GetCustomerSelection(maxInputAllowed);
            }

            return customerChoice;
        }

        public void ValidateUserInput(int userInput, int maxInputAllowed)
        {
            if (userInput <= 0
                || userInput > maxInputAllowed)
            {
                PrintToConsole("Felaktig inmatning. Försök igen.");

                GetCustomerSelection(maxInputAllowed);
            }
        }
    }
}
