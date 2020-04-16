﻿using System;
using System.Collections.Generic;
using System.Text;

using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SharpPlanner
{
    class CalendarEvents
    {
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();

        public CalendarEvents()
        {
            // Create events 
            CalendarInlineEvent event1 = new CalendarInlineEvent()
            {
                StartTime = DateTime.Today.AddHours(9),
                EndTime = DateTime.Today.AddHours(10),
                Subject = "Meeting",
                Color = Color.Green
            };

            CalendarInlineEvent event2 = new CalendarInlineEvent()
            {
                StartTime = DateTime.Today.AddHours(11),
                EndTime = DateTime.Today.AddHours(12),
                Subject = "Planning",
                Color = Color.Fuchsia
            };

            // Add events into a CalendarInlineEvents collection
            CalendarInlineEvents.Add(event1);
            CalendarInlineEvents.Add(event2);
        }
    }
}

