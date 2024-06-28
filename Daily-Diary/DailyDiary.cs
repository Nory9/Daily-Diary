using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Daily_Diary
{
    public class DailyDiary
    {
        Entry entry = new Entry();

        public void Diary_Manager() {
            Console.WriteLine("Wellcode to our Diary Manager where you can access the diary content ,write a new enteries, delete an entery,search for enteries and get total numbers of enteries! \n\n lets get started!");
            Console.WriteLine(" Enter 1 to get all enteries\n Enter 2 to write a new entery\n 3 to delete an entery \n Enter 4 to get total number of enteries");
            string userChoose = "";
            userChoose=Console.ReadLine();
            if (validInput(userChoose))
            {
                //switch



            }
            else {
                Console.WriteLine("You entered an invalid input please try again!");
            }
        
        }

        public bool validInput(string userChoose) { 
      
            if (userChoose != "1" && userChoose != "2" && userChoose != "3" && userChoose != "4") 
            return false;
            else 
                return true;
        
        }
        public string Read_path() { 
        string path= "../../../mydiary.txt";
            string dairy = File.ReadAllText(path);
            return path;
        }
        public void Read_Diary()
        {
            string path = "../../../mydiary.txt";
            string dairy = File.ReadAllText(path);
              Console.WriteLine(dairy);
        }

        public void Write_Diary() { 
        
            string date= entry.dateEntry();
            string content= entry.contentEntryMethod();
            string path=Read_path();
            File.AppendAllText(path, "\n\n"+date+"\n");
            File.AppendAllText(path, content+"\n\n");
            Read_Diary();
        }

        public string Delete_entry() {
            // 1. let user enter an entry 
            // 2. search for entry
            //3. delete it!
            Console.WriteLine("to delete an existing entry please enter the date: ");
           string date= entry.dateEntry();
            return date;
        }

        public void Search_entry()
        {
            string date = Delete_entry().Trim();  
            string path=Read_path();
            List<string> entries = new List<string>(File.ReadAllLines(path));
            int ii = 0;
            int n= entries.Count;
            for (int i = 0; i < n; i++)
            {
                entries[i] = entries[i].Trim();
            }
            if (entries.Contains(date))
            {
                ii = entries.IndexOf(date);
                entries.RemoveAt(ii);
                entries.RemoveAt(ii);
                entries.RemoveAt(ii);
                File.WriteAllLines(path, entries);
                  Read_Diary();
            }
            else 
                Console.WriteLine($"{date} you entered dosent exist!! try again");
        }
           
     

        
    
    }

  }


