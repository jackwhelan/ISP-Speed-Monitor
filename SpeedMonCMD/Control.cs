using System;
using System.IO;

namespace SpeedMonCMD
{
    class Control
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo("C:\\Users\\jackw\\Desktop\\Logs");
            FileInfo[] Files = d.GetFiles("*.log");
            foreach (FileInfo file in Files)
            {
                bool isPM;
                if (file.Name.Split("_")[5].Contains("PM"))
                {
                    isPM = true;
                }
                else
                {
                    isPM = false;
                }
                Speedtest current = new Speedtest(System.Convert.ToInt32(file.Name.Split("_")[0]), System.Convert.ToInt32(file.Name.Split("_")[1]), System.Convert.ToInt32(file.Name.Split("_")[2]), System.Convert.ToInt32(file.Name.Split("_")[3]), System.Convert.ToInt32(file.Name.Split("_")[4]), isPM);
                Console.WriteLine(current.getDate() + " | " + current.getTime());
            }
        }
    }
}
