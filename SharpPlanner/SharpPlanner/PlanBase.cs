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
                    plans.Add(new Plan(split[0], split[1], DateTime.Parse(split[2] + " " + split[3]), split[4]));
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
            plans.Remove(p);
            Save();
        }
    }
}
