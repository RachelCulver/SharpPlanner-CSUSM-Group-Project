using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace SharpPlanner
{
  
    public class Plan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime time { get; set; }
        public string priority { get; set; }



        //private string _title = "";
        //public string title {
        //    get
        //    {
        //        return _title;
        //    }
        //    set
        //    {
        //        _title = value;
        //        OnPropertyChanged("title");
        //    }
        //}
        //private string _description = "";
        //public string description
        //{
        //    get
        //    {
        //        return _description;
        //    }
        //    set
        //    {
        //        _description = value;
        //        OnPropertyChanged("description");
        //    }
        //}
        //private DateTime _time;
        //public DateTime time
        //{
        //    get
        //    {
        //        return _time;
        //    }
        //    set
        //    {
        //        _time = value;
        //        OnPropertyChanged("time");
        //    }
        //}
        //private string _priority = "";
        //public string priority
        //{
        //    get
        //    {
        //        return _priority;
        //    }
        //    set
        //    {
        //        _priority = value;
        //        OnPropertyChanged("priority");
        //    }
        //}

        //public Plan(string _title, string _description, DateTime _time, string _priority)
        //{
        //    title = _title;
        //    description = _description;
        //    time = _time;
        //    priority = _priority;

        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName] string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
