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
        }

        public async void Edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPage(plan));
        }

        //I used this because binding wasn't updating
        public void OnAppear(object sender, EventArgs e)
        {
            title.Text = plan.title;
            desc.Text = plan.description;
            time.Text = plan.time.ToString();
            priority.Text = plan.priority;
        }
    }
}