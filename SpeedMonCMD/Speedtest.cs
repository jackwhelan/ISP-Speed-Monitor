using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedMonCMD
{
    class Speedtest
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public string tod { get; set; }
        public string ip { get; set; }
        public string server { get; set; }
        public double server_distance { get; set; }
        public double ping { get; set; }
        public double down { get; set; }
        public double up { get; set; }

        public Speedtest(int year, int month, int day, int hour, int minute, string tod, string ip, string server, double server_distance, double ping, double down, double up)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.tod = tod;
            this.ip = ip;
            this.server = server;
            this.server_distance = server_distance;
            this.ping = ping;
            this.down = down;
            this.up = up;
        }

        public Speedtest(int year, int month, int day, int hour, int minute, string tod)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.tod = tod;
        }

        public string toString()
        {
            return "Test Date: " + this.day + "/" + this.month + "/" + this.year + "\n" +
                    "Test Time: " + this.hour + ":" + this.minute + "" + this.tod + "\n" +
                    "Public IP: " + this.ip + "\n" +
                    "Test Server: " + this.server + "\n" +
                    "Test Server Distance (km): " + this.server_distance + "\n" +
                    "Ping (ms): " + this.ping + "\n" +
                    "Download Speed (mbit/s): " + this.down + "\n" +
                    "Upload Speed (mbit/s): " + this.up + "\n\n";
        }

        public string getDate()
        {
            return this.day.ToString() + "/" + this.month.ToString() + "/" + this.year.ToString();
        }

        public string getTime()
        {
            string hour, minute;

            if (this.hour < 10)
            {
                hour = "0" + this.hour.ToString();
            }
            else
            {
                hour = this.hour.ToString();
            }

            if (this.minute < 10)
            {
                minute = "0" + this.minute.ToString();
            }
            else
            {
                minute = this.minute.ToString();
            }

            return hour + ":" + minute + this.tod;
        }
    }
}
