﻿using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace SharpPlanner
{
    //had to implement the interface INotifyPropertyChanged in order to update data across pages
    public class Plan : INotifyPropertyChanged, IComparable<Plan>
    {
        private string _title = "";
        public string title {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("title");
            }
        }
        private string _description = "";
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }
        private DateTime _time;
        public DateTime time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged("time");
            }
        }
        private string _priority = "";
        public string priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
                OnPropertyChanged("priority");
            }
        }

        private CalendarInlineEvent hook;

        public Plan(string _title, string _description, DateTime _time, string _priority, CalendarInlineEvent ev)
        {
            title = _title;
            description = _description;
            time = _time;
            priority = _priority;
            hook = ev;

        }

        public void Destroy()
        {
            CalendarEvents.GetInstance().CalendarInlineEvents.Remove(hook);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int CompareTo(Plan other)
        {
            if(PlanBase.GetInstance().sortMode == 0)
            {
                return time.CompareTo(other.time);
            }
            List<string> priorities = new List<String>(Globals.priorities);
            return -priorities.IndexOf(priority).CompareTo(priorities.IndexOf(other.priority));
        }
    }
}
