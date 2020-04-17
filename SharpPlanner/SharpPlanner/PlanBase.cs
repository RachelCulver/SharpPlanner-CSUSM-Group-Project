using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SharpPlanner
{
    public sealed class PlanBase
    {
        private static PlanBase instance = null;
        public ObservableCollection<Plan> plans;
        
        private PlanBase()
        {
            plans = new ObservableCollection<Plan>();
        }

        public void OnStart()
        {
            plans.Clear();
            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plans.txt");
            if (File.Exists(file))
            {
                string[] _plans = File.ReadAllLines(file);
                foreach(string plan in _plans)
                {
                    string[] split = plan.Split(' ');
                    Random random = new Random(DateTime.Now.Millisecond);
                    CalendarInlineEvent ev = new CalendarInlineEvent()
                    {
                        StartTime = DateTime.Parse(split[2] + " " + split[3]),
                        EndTime = DateTime.Parse(split[2] + " " + split[3]).AddSeconds(1),
                        Subject = split[0],
                        Color = Globals.calendarColors[(int)Math.Round(random.NextDouble() * Globals.calendarColors.Length)]
                    };
                    plans.Add(new Plan(split[0], split[1], DateTime.Parse(split[2] + " " + split[3]), split[4],ev));
                    CalendarEvents.GetInstance().Add(ev);
                }
            }
        }

        public void Save()
        {

            string content = "";
            foreach (Plan p in plans)
            {
                content += p.title + " " + p.description + " " + p.time.ToLongTimeString() + " " + p.priority + "\n";
            }
            Debug.WriteLine(plans.Count);
            Debug.WriteLine(content);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "plans.txt"), content);
        }
        
        public static PlanBase GetInstance()
        {
            if(instance == null)
            {
                instance = new PlanBase();
            }
            return instance;
        }

        public void Add(Plan p)
        {
            plans.Add(p);
            Save();
        }

        //For removing a plan
        public void Remove(Plan p)
        {
            p.Destroy();
            plans.Remove(p);
            Save();
        }
    }
}
