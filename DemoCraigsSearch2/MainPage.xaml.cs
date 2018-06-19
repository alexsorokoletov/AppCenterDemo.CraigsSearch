﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoCraigsSearch2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.bikesList.ItemsSource = new List<BikeItem>() {
                new BikeItem
                {
                    Id = "1",
                    Text = "Some bike selling and you know you need it",
                    Description = "Good bike, long desc, Good bike, long desc, Good bike, long desc, Good bike, long desc, Good bike, long desc,Good bike, long desc,Good bike, long desc",
                    Price = 42.2,
                    Image = "https://loremflickr.com/cache/resized/895_27433178678_0f71493c2f_320_240_g.jpg"
                },
                new BikeItem
                {
                    Id = "2",
                    Text = "Nicer bike",
                    Description = "Short desc, no talk, give the money",
                    Price = 25,
                    Image = "https://loremflickr.com/cache/resized/953_41177494854_b70b678d4d_320_240_p.jpg"
                }
            };
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItemsAsync();
        }

        private async Task LoadItemsAsync()
        {
            this.bikesList.IsRefreshing = true;
            this.bikesList.ItemsSource = await CraigsHelper.SearchAsync("bike");
            this.bikesList.IsRefreshing = false;
        }
    }
}
