using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace SharpPlanner
{
    public partial class Weather : ContentPage
    {

        public static string API = "49e841a01dddd473f095af8cf7dc4ca9";
        public string cityEntry { get; set; }
        public Weather()
        {
            InitializeComponent();
            

        }

        async void getWeather(object sender, System.EventArgs e)
        {
            HttpClient client = new HttpClient();
            

            var uri = new Uri(string.Format(
                $"https://api.openweathermap.org/data/2.5/weather?q=" + $"San Marcos" + "&units=imperial" 
                + $"&appid={API}"));

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = uri;

            HttpResponseMessage response = await client.SendAsync(request);
            WeatherItem weatherData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = WeatherItem.FromJson(content);

                BindingContext = weatherData;
                DisplayAlert("Success", "test", "OK");
            }
        }
    }
}
