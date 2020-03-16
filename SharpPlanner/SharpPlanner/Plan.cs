using System;
using System.Collections.Generic;
using System.Text;

namespace SharpPlanner
{
    public enum Priority
    {
        VERY_LOW, LOW, NORMAL, HIGH, VERY_HIGH
    }
    public class Plan
    {
        public string title;
        public string description;
        public DateTime time;
        public Priority priority;

        public Plan(string _title, string _description, DateTime _time, Priority _priority)
        {
            title = _title;
            description = _description;
            time = _time;
            priority = _priority;
        }

    }
}
