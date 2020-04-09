﻿using System;
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
        private string firstTitle, firstDesc;

		public EditPage (Plan _plan)
		{
            plan = _plan;
            firstTitle = plan.title;
            firstDesc = plan.description;
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

            await Navigation.PopAsync();
        }

        public async void Cancel(object sender, EventArgs e)
        {
            plan.title = firstTitle;
            plan.description = firstDesc;
            await Navigation.PopAsync();
        }
    }
}