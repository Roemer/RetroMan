using System;

namespace RetroMan.Core
{
    public class Logger
    {
        private static volatile Logger instance;
        private static object syncRoot = new Object();
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
            set { instance = value; }
        }

        public event Action<LogEntry> OnLog;

        public void Add(LogType logType, string message, params object[] strParams)
        {
            // Crete the Log Object
            LogEntry entry = new LogEntry(logType, String.Format(message, strParams));

            // Fire the Event if needed
            Action<LogEntry> evnt = OnLog;
            if (evnt != null)
            {
                OnLog(entry);
            }
        }
    }
}
