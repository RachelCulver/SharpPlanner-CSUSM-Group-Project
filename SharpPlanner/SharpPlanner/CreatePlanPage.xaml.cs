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

		public CreatePlanPage ()
        {
            BindingContext = this;
            InitializeComponent ();
            CalendarDate.Date = DateTime.Today;
            CalendarDate.MinimumDate = DateTime.Today;
            CalendarTime.Time = DateTime.Now.TimeOfDay;
            PriorityPicker.ItemsSource = new List<string>(Globals.priorities);
            PriorityPicker.SelectedIndex = 2;
        }

        async void CreateEvent(object sender, EventArgs e)
        {
            if (EntryTitle.Text == "")
            {
                EntryTitle.Focus();
            }else if(EntryDesc.Text == "")
            {
                EntryDesc.Focus();
            }

            DateTime dateAndTime = new DateTime(CalendarDate.Date.Year, CalendarDate.Date.Month, CalendarDate.Date.Day,
                CalendarTime.Time.Hours, CalendarTime.Time.Minutes, 0);

            //PlanBase.GetInstance().Add(new Plan(EntryTitle.Text, EntryDesc.Text, dateAndTime, (Priority) PriorityPicker.SelectedIndex));
            await App.Database.SaveItemAsync((Plan)BindingContext);
            await Navigation.PopAsync();
        }

        public async void Cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
	}
}