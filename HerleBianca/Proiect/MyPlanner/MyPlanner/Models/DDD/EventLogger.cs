﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlanner.Models.DDD
{
    public interface IEventLogger
    {
        public void Log(string message);
        public List<string> GetSessionEvents();
    }
    public class EventLogger : IEventLogger
    {
        public List<string> session_events;
        public EventLogger()
        {
            session_events = new List<string>();
        }
        public void Log(string message)
        {
            session_events.Add(message);
        }
        public List<string> GetSessionEvents()
        {
            return session_events;
        }
    }
}
