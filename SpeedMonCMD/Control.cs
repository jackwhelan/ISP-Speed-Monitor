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
                // If log is less than 400 bytes (something is wrong, so delete the log.)
                if (file.Length < 400)
                {
                    file.Delete();
                }
                else
                {
                    string tod;
                    if (file.Name.Split("_")[5].Contains("PM"))
                    {
                        tod = "PM";
                    }
                    else
                    {
                        tod = "AM";
                    }
                    Speedtest current = new Speedtest(Convert.ToInt32(file.Name.Split("_")[0]), Convert.ToInt32(file.Name.Split("_")[1]), Convert.ToInt32(file.Name.Split("_")[2]), Convert.ToInt32(file.Name.Split("_")[3]), Convert.ToInt32(file.Name.Split("_")[4]), tod);

                    // FILE PARSING HERE

                    using (StreamReader sr = file.OpenText())
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line.Contains("Testing from") && line.Contains("(") && line.Contains(")"))
                            {
                                current.ip = "";
                                for (int start = line.IndexOf("(") + 1; line[start] != ')'; start++)
                                {
                                    current.ip = current.ip + line[start];
                                }
                            }
                            if (line.Contains("Hosted by") && line.Contains("ms"))
                            {
                                current.server = "";
                                string server_distance = "";
                                string ping = "";
                                for (int start = line.IndexOf("y") + 2; line[start] != '('; start++)
                                {
                                    current.server = current.server + line[start];
                                }
                                for (int start = line.IndexOf("[") + 1; line[start] != ' '; start++)
                                {
                                    server_distance = server_distance + line[start];
                                    current.server_distance = Convert.ToDouble(server_distance);
                                }
                                for (int start = line.IndexOf(": ") + 2; line[start] != ' '; start++)
                                {
                                    ping = ping + line[start];
                                    current.ping = Convert.ToDouble(ping);
                                }
                            }
                            if (line.Contains("Download") && line.Contains("Mbit/s"))
                            {
                                string speed = "";
                                for (int start = line.IndexOf(": ") + 2; line[start] != ' '; start++)
                                {
                                    speed = speed + line[start];
                                    current.down = Convert.ToDouble(speed);
                                }
                            }
                            if (line.Contains("Upload") && line.Contains("Mbit/s"))
                            {
                                string speed = "";
                                for (int start = line.IndexOf(": ") + 2; line[start] != ' '; start++)
                                {
                                    speed = speed + line[start];
                                    current.up = Convert.ToDouble(speed);
                                }
                            }
                        }
                    }

                    tests.Add(current);
                }

                foreach (Speedtest test in tests)
                {
                    Console.Write(test.toString());
                }
            }
        }
    }
}
