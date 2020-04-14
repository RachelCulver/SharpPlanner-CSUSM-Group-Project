using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Plan plan;

        public ManagePlanPage(Plan _plan)
        {
            plan = _plan;
            InitializeComponent();
            BindingContext = plan;
        }

        public async void Edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPage(plan));
        }

        public void OnAppear(object sender, EventArgs e)
        {
            if(plan.time.CompareTo(DateTime.Now) > 0)
            {
                time.TextColor = Color.Green;
            }
            else
            {
                time.TextColor = Color.Red;
            }
            List<String> priorities = Globals.priorities.ToList<String>();
            priority.TextColor = Globals.priorityColors[priorities.IndexOf(plan.priority)];
        }
        
    }
}