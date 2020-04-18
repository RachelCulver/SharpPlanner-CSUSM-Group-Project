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
	public partial class EditPage : ContentPage
	{
        public Plan plan;
        private string firstTitle, firstDesc, firstPriority;
        private DateTime firstTime;

		public EditPage (Plan _plan)
		{
            plan = _plan;
            firstTitle = plan.title;
            firstDesc = plan.description;
            firstTime = plan.time;
            firstPriority = plan.priority;
			InitializeComponent ();
            BindingContext = plan;
            CalendarDate.Date = plan.time.Date;
            CalendarTime.Time = plan.time.TimeOfDay;
            List<string> priorities = new List<string>(Globals.priorities);
            PriorityPicker.ItemsSource = priorities;
            PriorityPicker.SelectedItem = plan.priority;
        }

        public async void Save(object sender, EventArgs e)
        {
            if (EntryTitle.Text == "")
            {
                EntryTitle.Focus();
            }
            else if (EntryDesc.Text == "")
            {
                EntryDesc.Focus();
            }

            DateTime dateAndTime = new DateTime(CalendarDate.Date.Year, CalendarDate.Date.Month, CalendarDate.Date.Day,
                CalendarTime.Time.Hours, CalendarTime.Time.Minutes, 0);

            plan.time = dateAndTime;
            plan.priority = (string) PriorityPicker.SelectedItem;

            firstTitle = plan.title;
            firstDesc = plan.description;
            firstTime = plan.time;
            firstPriority = plan.priority;

            await Navigation.PopAsync();
        }

        public async void Cancel(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("ALERT", "Are you sure you want to cancel? Any changes made will not be saved.", "NO", "YES");

            
            
            if (!res) await Navigation.PopAsync();// If they answer YES... meaning they do want to cancel, then go back
        }

        public void OnDisappear(object sender, EventArgs e)
        {
            plan.title = firstTitle;
            plan.description = firstDesc;
            plan.time = firstTime;
            plan.priority = firstPriority;
        }
    }
}