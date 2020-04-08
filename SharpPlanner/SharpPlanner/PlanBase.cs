using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }
    }
}
