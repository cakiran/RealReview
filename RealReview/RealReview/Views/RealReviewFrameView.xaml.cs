using MahApps.Metro.Controls;
using RealReview.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealReview
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RealReviewFrameView : MetroWindow
    {
        public RealReviewFrameView()
        {
            InitializeComponent();
            BusinessReviewsViewModel businessReviewsViewModel = new BusinessReviewsViewModel();
            this.DataContext = businessReviewsViewModel;
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //var client = new HttpClient();
        //    //// var address = new Uri("https://www.googleapis.com/customsearch/v1?q=restaurants+near+me&cx=012572433248785697579%3A1mazi7ctlvm&num=10&fields=items(link%2Cpagemap%2Ctitle)&key=AIzaSyCGXXa_kgjOiLa-NGsk4kgEbLZDEv8dJMQ" );

        //    ////var addressnew = new Uri("https://www.googleapis.com/customsearch/v1?key=AIzaSyCGXXa_kgjOiLa-NGsk4kgEbLZDEv8dJMQ&cx=017576662512468239146:omuauf_lfve&q=restaurants+near+me");
        //    //var address = new Uri("https://maps.googleapis.com/maps/api/place/textsearch/json?query=passagetoindia&sensor=true&key=AIzaSyCGXXa_kgjOiLa-NGsk4kgEbLZDEv8dJMQ");
        //    //HttpResponseMessage response = await client.GetAsync(address);
        //    //String stream = await response.Content.ReadAsStringAsync();

        //    var client = new Yelp.Api.Client("2R3rYYTTNXbGEp5MJFXrV9JgRZkoDhZeCKcAQCgDyKzHnVKfN85E8nFq7AhibN2zr0vdAb7AvtCGRg2U2WrqCtigLg26xo4XxgEKPhjxDBxVLIdclwTpPdaX3kX8XHYx");
        //    Yelp.Api.Models.SearchRequest searchRequest = new Yelp.Api.Models.SearchRequest();
        //    searchRequest.Location = "28213";
        //    searchRequest.Term = "Indian food";
        //    var results = await client.SearchBusinessesAllAsync( searchRequest);
        //    Yelp.Api.Models.SearchResponse searchResponse = results;
        //    var businesses = searchResponse.Businesses;
        //    foreach(var b in businesses)
        //    {
        //        var reviewresult = await client.GetReviewsAsync(b.Id);
        //                                                                var reviews = reviewresult.Reviews;
        //    }
           

        //}
    }
}
