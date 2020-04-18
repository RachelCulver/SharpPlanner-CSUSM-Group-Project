using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace SharpPlanner
{
    public sealed class PlanBase
    {
        private static PlanBase instance = null;
        public ObservableCollection<Plan> plans;
        private string separator = "\t";
        
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
                    Debug.WriteLine(plan);
                    string[] sepArray = new string[] { separator };
                    string[] split = plan.Split(sepArray, 5, StringSplitOptions.None);

                    if (split.Length < 4) continue;

                    Random random = new Random(DateTime.Now.Millisecond);
                    CalendarInlineEvent ev = new CalendarInlineEvent()
                    {
                        StartTime = DateTime.ParseExact(split[2], "MM/dd/yyyy HH:mm tt", new CultureInfo("en-US")),
                        EndTime = DateTime.ParseExact(split[2], "MM/dd/yyyy HH:mm tt", new CultureInfo("en-US")).AddSeconds(1),
                        Subject = split[0],
                        Color = Globals.calendarColors[(int)Math.Round(random.NextDouble() * Globals.calendarColors.Length)]
                    };
                    plans.Add(new Plan(split[0], split[1], DateTime.ParseExact(split[2], "MM/dd/yyyy HH:mm tt", new CultureInfo("en-US")), split[3],ev));
                    CalendarEvents.GetInstance().Add(ev);
                }
            }
        }

        public void Save()
        {

            string content = "";
            foreach (Plan p in plans)
            {
                content += p.title + separator + p.description + separator + p.time.ToString("MM/dd/yyyy HH:mm tt") + separator + p.priority + "\n";
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
