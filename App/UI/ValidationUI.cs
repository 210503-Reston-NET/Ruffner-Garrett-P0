using System;
using System.Text.RegularExpressions;
using Service;
namespace UI
{
    public class ValidationUI: IValidationUI
    {
        public string ValidationPrompt(string prompt, Func<string, bool> validate){
            string response;
            bool valid = false;
            do{
                Console.Clear();
                if(valid){
                    Console.WriteLine("Invalid Entry");
                }
               Console.WriteLine(prompt);
               response = Console.ReadLine();
               valid = true;
            }while(!validate(response));
            return response;

        }
    }
}
    //     public string ValidateString(string prompt)
    //    {
    //         string response;
    //         do{
    //             Console.WriteLine(prompt);
    //             response = Console.ReadLine();
    //         }while(String.IsNullOrWhiteSpace(response));

    //         return response;
    //     }

    //     public int ValitdateInt(string prompt)
    //     {
    //         int response;
    //         string temp;
    //         do{
    //             Console.WriteLine(prompt);
    //            temp = Console.ReadLine();
    //         }while(Int32.TryParse(temp,out response));
    //         return response;
    //     }

        // public bool ValidateCityName(string input)
        // {
        //     ValidationService vl = new ValidationService();
        //     return vl.ValidateCityName(input);
        // }

        // public bool ValidatePersonName(string input)
        // {
        //     ValidationService vl = new ValidationService();
        //     return vl.ValidatePersonName(input);
        // }
