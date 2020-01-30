using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace SpeedMonCMD
{
    class Control
    {
        static void Main(string[] args)
        {
            // Scenario:
            // A Jenkins job builds, running a speedtest and storing the results in a timestamped log file.
            // All the currently existing log files are added to zip archive and uploaded to the location
            // specified in the "source" string variable.

            // This Program's Role:
            // This program downloads the data.zip file and unzips it. It then processes the logs and stores
            // the data from each log in a "Speedtest" object. These objects will be used for analysis of the
            // speedtest data.

            // Specifying the directory to fetch the data.zip from and where to download it to.
            // N.B. The source and fileName are determined by the Jenkins job "ISP Speed Monitor".
            ArrayList tests = new ArrayList();
            string destination = @"C:\Users\jackw\Desktop\Logs\";
            string source = "https://jackwhelan.dev/archive/";
            string fileName = "data.zip";

            // Deleting all old files in the Log directory.
            DirectoryInfo d = new DirectoryInfo("C:\\Users\\jackw\\Desktop\\Logs");
            foreach (FileInfo file in d.GetFiles())
            {
                file.Delete();
            }

            // Creating a WebClient object to download the data.
            using (var client = new WebClient())
            {
                client.DownloadFile(source + fileName, destination + fileName);
            }

            // Unzipping the data.zip file.
            ZipFile.ExtractToDirectory(destination + fileName, destination);

            // Storing the logs in Speedtest objects.
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
                tests.Add(current);
            }

            // Looping through the speedtest objects and printing the date.
            foreach (Speedtest test in tests)
            {
                Console.WriteLine(test.getTime() + " | " + test.getDate());
            }
        }
    }
}
