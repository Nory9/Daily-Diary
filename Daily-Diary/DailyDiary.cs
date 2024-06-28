using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Daily_Diary
{
    public class DailyDiary
    {
        Entry entry = new Entry();
        string path = "../../../mydiary.txt";
        public void Diary_Manager() {
            string path = Read_path();
            List<string> entries = new List<string>(File.ReadAllLines(path));
            Console.WriteLine("Wellcode to our Diary Manager where you can access the diary content ,write a new enteries, delete an entery,search for enteries and get total numbers of enteries! \n\n lets get started!");
            Console.WriteLine(" Enter 1 to get all enteries\n Enter 2 to write a new entery\n 3 to delete an entery \n Enter 4 to get total number of enteries");
            string userChoose = "";
            userChoose=Console.ReadLine();
            if (validInput(userChoose))
            {
                //switch
                switch (userChoose)
                {
                    case "1":
                        {
                            Print_Diary();
                        }
                        break;

                    case "2":
                        {
                            Write_Diary();
                        }
                        break;
                    case "3": {
                            
                            List<string> list = Search_entry(entries);
                            string date = Get_entry();
                            bool after_delete= Delete_entry(list, date);
                            if (after_delete != false) {
                                Print_Diary();
                            }

                        }
                        break;

                        case "4": { 
                            int total =Get_count(entries);
                            Console.WriteLine($"Total number of lines is {total}");
                        } 
                        break;

                
                
                }



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
        public string  Read_Diary()
        {
            string path = "../../../mydiary.txt";
            string dairy = File.ReadAllText(path);
          //    Console.WriteLine(dairy);
            return dairy;
        }
        public void Print_Diary()
        {
            string path = "../../../mydiary.txt";
            string dairy = File.ReadAllText(path);
             Console.WriteLine(dairy);
           
        }

        public void Write_Diary() { 
        
            string date= entry.dateEntry();
            string content= entry.contentEntryMethod();
            string path=Read_path();
            File.AppendAllText(path, date+"\n");
            File.AppendAllText(path, content+"\n");
            Print_Diary();
        }

        public bool Delete_entry(List<string> entries, string date)
        {
            int ii = 0;
            //int n = entries.Count;
            if (entries.Contains(date))
            {
                ii = entries.IndexOf(date);
                entries.RemoveAt(ii);
                entries.RemoveAt(ii);
                
                File.WriteAllLines(path, entries);
                Read_Diary();
            }
            else
            {
                Console.WriteLine($"{date} Dosent exist in the diary!! please try again");
                return false;
            }

            return true;
        }
        public string Get_entry() {
            string date = entry.dateEntry();
            return date;
        }

        public List<string> Search_entry(List<string> entries)
        {
           
           // List<string> entries = new List<string>(File.ReadAllLines(path));
            int ii = 0;
            int n= entries.Count;
            for (int i = 0; i < n; i++)
            {
                entries[i] = entries[i].Trim();
            }
           return entries;
        }


        public int Get_count(List<string> entries) {
            int total =entries.Count;
            return total;
        }
    }

  }


