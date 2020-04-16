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
	public partial class CreatePlanPage : ContentPage
	{
        private TabbedPage tabbedPage;

		public CreatePlanPage (TabbedPage tPage)
        {
            tabbedPage = tPage;
            BindingContext = this;
            InitializeComponent ();
        }

        public void OnAppear(object sender, EventArgs e)
        {
            EntryTitle.Text = "";
            EntryDesc.Text = "";
            CalendarDate.Date = DateTime.Today;
            CalendarDate.MinimumDate = DateTime.Today;
            CalendarTime.Time = DateTime.Now.TimeOfDay;
            PriorityPicker.ItemsSource = new List<string>(Globals.priorities);
            PriorityPicker.SelectedIndex = 2;
        }

        public void CreateEvent(object sender, EventArgs e)
        {
            if (EntryTitle.Text == "")
            {
                EntryTitle.Focus();
                return;
            }else if(EntryDesc.Text == "")
            {
                EntryDesc.Focus();
                return;
            }

            DateTime dateAndTime = new DateTime(CalendarDate.Date.Year, CalendarDate.Date.Month, CalendarDate.Date.Day,
                CalendarTime.Time.Hours, CalendarTime.Time.Minutes, 0);
            
            PlanBase.GetInstance().Add(new Plan(EntryTitle.Text, EntryDesc.Text, dateAndTime, (string) PriorityPicker.SelectedItem));
            tabbedPage.CurrentPage = tabbedPage.Children[0];
        }

        public void Cancel(object sender, EventArgs e)
        {
            tabbedPage.CurrentPage = tabbedPage.Children[0];
        }
	}
}