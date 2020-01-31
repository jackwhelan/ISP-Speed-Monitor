# ISP Performance Monitor
This program works in conjunction with a job on my Jenkins server.
The Jenkins job runs a speed test every hour using [Speedtest CLI](https://www.speedtest.net/apps/cli)
provided by Ookla. These speed tests are saved to log files with a bash script. Each time
a new log file is created by this script, it's added to a zip archive and uploaded to my web server.
This C# program downloads the zip archive of logs from my web server, unzips it and parses
the logs into objects that data analysis can be carried out on.

The purpose of this project is to provide a visualization of my internet's performance over
time, updating constantly with the latest speed tests running on my Jenkins server. The
reason I want to do this is because I have a history of internet problems and being let down
by my ISP. This project will allow me to compare the actual performance of my internet service
to that which is advertised by my ISP.

### Bash (via Jenkins)
- [x] Create a Jenkins job to run speed tests every hour.
- [x] Store the created speed tests in log files.
- [x] Every time a new log is created, add it to the zip archive.
- [x] Automatically upload the zip archive every time it changes.

### C#
- [x] Download the log zip archive from my web server.
- [x] Unzip the archive and store the log file info for iteration.
- [x] Error check for invalid log files.
- [x] Create "Speedtest" objects from the log files, storing their timestamp from filename.
- [x] Parse log files, splicing relevant data and converting it to operable datatypes for analysis.
- [x] Store parsed data in Speedtest objects mentioned earlier.
- [ ] Create methods for calculating Mean, Median, Mode, Standard Deviation etc..
- [ ] Plot the data on a graph.