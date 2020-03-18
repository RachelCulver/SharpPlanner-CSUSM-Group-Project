using System;
using System.Collections.Generic;
using System.Text;

namespace SharpPlanner
{
    public sealed class PlanBase
    {
        private static PlanBase instance = null;
        private List<Plan> plans;
        
        private PlanBase()
        {
            plans = new List<Plan>();
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
