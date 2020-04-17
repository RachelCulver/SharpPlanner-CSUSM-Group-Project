using System;
using System.Collections.Generic;
using System.Text;

using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SharpPlanner
{
    public class CalendarEvents
    {
        private static CalendarEvents instance = null;
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();

        private CalendarEvents()
        {
            // Create events 
            /*CalendarInlineEvent event1 = new CalendarInlineEvent()
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
            CalendarInlineEvents.Add(event2);*/
        }
        public void Add(CalendarInlineEvent e)
        {
            CalendarInlineEvents.Add(e);
        }

        public static CalendarEvents GetInstance()
        {
            if (instance == null)
            {
                instance = new CalendarEvents();
            }
            return instance;
        }
    }
}

