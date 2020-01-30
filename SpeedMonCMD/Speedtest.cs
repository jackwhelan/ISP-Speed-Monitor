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
        public bool isPM { get; set; }
        public string ip { get; set; }
        public string server { get; set; }
        public float server_distance { get; set; }
        public float ping { get; set; }
        public float down { get; set; }
        public float up { get; set; }

        public Speedtest(int year, int month, int day, int hour, int minute, bool isPM, string ip, string server, float server_distance, float ping, float down, float up)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.isPM = isPM;
            this.ip = ip;
            this.server = server;
            this.server_distance = server_distance;
            this.ping = ping;
            this.down = down;
            this.up = up;
        }

        public Speedtest(int year, int month, int day, int hour, int minute, bool isPM)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.hour = hour;
            this.minute = minute;
            this.isPM = isPM;
            this.ip = ip;
            this.server = server;
            this.server_distance = server_distance;
            this.ping = ping;
            this.down = down;
            this.up = up;
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

            if (this.isPM)
            {
                return hour + ":" + minute + "PM";
            }
            else
            {
                return hour + ":" + minute + "AM";
            }
        }
    }
}
