using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.SfCalendar.XForms;

namespace SharpPlanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calendar : ContentPage
    {
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public Calendar()
        {

            InitializeComponent();

            CalendarInlineEvent event1 = new CalendarInlineEvent();
            event1.StartTime = new DateTime(2020, 5, 1, 5, 0, 0);
            event1.EndTime = new DateTime(2020, 5, 1, 7, 0, 0);
            event1.Subject = "Go to Meeting";
            event1.Color = Color.Fuchsia;

            CalendarInlineEvent event2 = new CalendarInlineEvent();
            event2.StartTime = new DateTime(2020, 5, 1, 10, 0, 0);
            event2.EndTime = new DateTime(2020, 5, 1, 12, 0, 0);
            event2.Subject = "Planning";
            event2.Color = Color.Green;

            CalendarInlineEvent event3 = new CalendarInlineEvent();
            event1.StartTime = new DateTime(2020, 1, 1, 1, 1, 1);
            event1.EndTime = new DateTime(2020, 1, 1, 1, 1, 1);
            event1.Subject = "Go to Meeting";
            event1.Color = Color.Fuchsia;

            CalendarInlineEvents.Add(event1);
            CalendarInlineEvents.Add(event2);
            CalendarInlineEvents.Add(event3);


        }
    }
}