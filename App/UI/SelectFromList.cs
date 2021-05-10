using System.Collections.Generic;
using System;
using Service;
using StoreModels;
namespace UI
{
    public class SelectFromList : ISelectFromList
    {
        public List<Object> objects { get; set; }
        public SelectFromList(List<Object> objects){
            this.objects = objects;
            
        }

        public Object Start()
        {
            string input;
            do{
                Console.Clear();
                Console.WriteLine("Choose From List:");
                Console.WriteLine("[0] Cancel Selection");
                int i = 1;
                foreach (object item in this.objects)
                {
                    Console.WriteLine("[{0}] {1}", i++, item.ToString());
                }
               Console.WriteLine("Enter Your Selection:");
               input = Console.ReadLine();
               if(input == "0"){
                   return null;
               }
            }while(!ValidationService.ValidateIntWithinRange(input, 1, this.objects.Count));

           int selection = int.Parse(input);
           Object retVal =  objects[selection-1];
           return retVal;
            
        }
    }
}