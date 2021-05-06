using System;
namespace UI
{
    public class ValidationService: IValidationService
    {
       public string ValidateString(string prompt)
       {
           string response;
           do{
               Console.WriteLine(prompt);
               response = Console.ReadLine();
           }while(String.IsNullOrWhiteSpace(response));

           return response;
        }

        public int ValitdateInt(string prompt)
        {
            int response;
            string temp;
            do{
                Console.WriteLine(prompt);
               temp = Console.ReadLine();
            }while(Int32.TryParse(temp,out response));
            return response;
        }
    }
}