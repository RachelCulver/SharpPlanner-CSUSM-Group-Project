using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Syncfusion.SfCalendar.XForms;

namespace SharpPlanner
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void CreateEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePlanPage());
        }

        public async void Open_Calendar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calendar());
        }
    }
}
