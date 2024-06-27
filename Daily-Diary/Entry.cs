using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    internal class Entry
    {
       private string date;
       private string content;

        string Content {
            get; set;
        }string Date {
            get; set;
        }
        public string dateEntry() {
            string DateonlyString="";
            bool flag = false;
            while (!flag)
            {
                try
                {
                    string day, month, year;
                    Console.WriteLine("Enter the day: ");
                    day = Console.ReadLine();
                    Console.WriteLine("Enter the month: ");
                    month = Console.ReadLine();
                    Console.WriteLine("Enter the year: ");
                    year = Console.ReadLine();
                    var parsedDate = DateTime.Parse($"{year}-{month}-{day}");
                    var Dateonly = DateOnly.FromDateTime(parsedDate);
                    Date= Dateonly.ToString("yyyy-MM-dd");
                    DateonlyString = Dateonly.ToString("yyyy-MM-dd");
                   // Console.WriteLine(DateonlyString);
                    flag = true;
                }

                catch
                {
                    Console.WriteLine("the date you entered is invalid!  please try again and make sure the format is year-month-day");

                }
            }
            return Date;  
        }

        public string contentEntryMethod() {
            string contentInput = "";
            Console.WriteLine("Enter the content you want to add to your dairy: ");
            contentInput= Console.ReadLine();
            while (contentInput == "")
            {
                Console.WriteLine("you didnt enter any contect!! please trt again and dont leave it empty");
                contentInput = Console.ReadLine();
                Content = contentInput;
            }
            Content = contentInput;
          //  Console.WriteLine(Content);
            return Content;
        }


    }
}
