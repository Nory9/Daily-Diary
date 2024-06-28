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

        public void read_Diary() { 
        string path= "../../../mydiary.txt";
            string dairy = File.ReadAllText(path);
            Console.WriteLine(dairy);


        }
    
    }

  }


