using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharpPlanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagePlanPage : ContentPage
    {
        public string PlanTitle { get; set; }
        private Plan plan;

        public ManagePlanPage(Plan _plan)
        {
            plan = _plan;
            PlanTitle = plan.title;
            InitializeComponent();
            BindingContext = this;
        }
    }
}