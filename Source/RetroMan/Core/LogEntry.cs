using System;

namespace RetroMan.Core
{
    public class LogEntry
    {
        public DateTime Time { get; private set; }
        public string Message { get; private set; }
        public LogType Type { get; private set; }

        public LogEntry(LogType type, string message)
        {
            Time = DateTime.Now;
            Type = type;
            Message = message;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} - {2}", Time, Type, Message);
        }
    }
}
