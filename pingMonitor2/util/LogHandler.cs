using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pingMonitor2
{
    public class LogHandler
    {
        string dirPath = Environment.SpecialFolder.MyDocuments.ToString();
        string dateFormat = "yyyy-MM-dd";
        List<LogEntry> entries;

        public LogHandler()
        {
            this.entries = getAllEntries();
        }

        public void writeEntryToLog(LogEntry entry)
        {
            string fileToday = DateTime.Now.ToString(dateFormat) + "-pmLog.txt";
            string path = System.IO.Path.Combine(dirPath, fileToday);
            StreamWriter sw;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            sw = new StreamWriter(path,true);
            sw.WriteLine(entry.printLog());
            sw.Close();
        }        

        public List<LogEntry> getLogEntriesByDay(DateTime day)
        {
            string d = day.ToString(dateFormat);
            return getLogEntriesByDay(d);
        }

        public List<LogEntry> getLogEntriesByDay(string day)
        {
            List<LogEntry> entries = new List<LogEntry>();
            if (Directory.Exists(dirPath))
            {
                string path = System.IO.Path.Combine(dirPath, day, ".txt");
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        LogEntry l = new LogEntry(line);
                        entries.Add(l);
                    }
                    sr.Close();
                }
            }
            return entries;
        }

        public List<LogEntry> getLogEntriesByHost(string host)
        {
            List<LogEntry> entries = new List<LogEntry>();
            if (Directory.Exists(dirPath))
            {
                string[] logFiles = Directory.GetFiles(dirPath);
                for (int i = 0; i < logFiles.Count(); i++)
                {
                    string day = System.IO.Path.GetFileName(logFiles[i]).Substring(0,10);
                    Debug.WriteLine("getLogByHost FileName: " + day);
                    entries.AddRange(getLogEntriesByDayAndHost(host, day));
                }
            }
            return entries;
        }

        public List<LogEntry> getLogEntriesByDayAndHost(string host, DateTime day)
        {
            string d = day.ToString(dateFormat);
            return getLogEntriesByDayAndHost(host, d);
        }

        public List<LogEntry> getLogEntriesByDayAndHost(string host, string day)
        {
            List<LogEntry> entries = new List<LogEntry>();
            if (Directory.Exists(dirPath))
            {
                string fileName = constructFileName(day);
                string path = System.IO.Path.Combine(dirPath, fileName);
                if (File.Exists(path))
                {
                    string line;
                    StreamReader sr = new StreamReader(path);
                    while ((line = sr.ReadLine()) != null)
                    {
                        LogEntry l = new LogEntry(line);
                        if (l.host.Equals(host) && l.date.ToString(dateFormat).Equals(day))
                        {
                            entries.Add(l);
                        }
                    }
                    sr.Close();
                }
            }
            return entries;
        }

        public List<LogEntry> getAllEntries()
        {
            List<LogEntry> entries = new List<LogEntry>();
            if (Directory.Exists(dirPath))
            {
                string[] files = Directory.GetFiles(dirPath);
                for (int i = 0; i < files.Count(); i++)
                {
                    string day = files[i].Substring(0, 10);
                    entries.AddRange(getLogEntriesByDay(day));
                }
            }
            return entries;
        }

        public List<string> getDays()
        {
            List<string> days = new List<string>();
            if (Directory.Exists(dirPath))
            {
                foreach (string file in Directory.GetFiles(dirPath))
                {
                    string d = System.IO.Path.GetFileName(file).Substring(0, 10);
                    if (!days.Contains(d))
                    {
                        days.Add(d);
                    }
                }
            }
            return days;
        }

        public List<string> getHosts()
        {
            List<string> hosts = new List<string>();
            if (Directory.Exists(dirPath))
            {
                foreach (string file in Directory.GetFiles(dirPath))
                {
                    string line;
                    StreamReader sr = new StreamReader(file);
                    while ((line = sr.ReadLine()) != null)
                    {
                        string tmpHost = line.Split(';')[1];
                        if (!hosts.Contains(tmpHost))
                        {
                            hosts.Add(tmpHost);
                        }
                    }
                    sr.Close();
                }
            }
            return hosts;
        }

        

        public string constructFileName(string date)
        {
            return date + "-pmLog.txt";
        }
    }
}
