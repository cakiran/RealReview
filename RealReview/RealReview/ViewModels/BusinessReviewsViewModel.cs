using RealReview.Helpers;
using RealReview.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RealReview.ViewModels
{
    public class BusinessReviewsViewModel : BaseViewModel
    {
        #region Private members
        private string _searchString;
        private BinaryClassifierPipeline _binaryClassifierPipeline;
        #endregion

        #region Constructor
        public BusinessReviewsViewModel()
        {
            _binaryClassifierPipeline = new BinaryClassifierPipeline();
            Businesses = new ObservableCollection<Business>();
            GetBusinesses = new ActionCommand(GetBusinessesWithReviews);
            ShowReviews = new CommandWithParameter(ShowReviewsClicked);
            GetRealViewScore = new ActionCommand(GetRealViewScoreClicked);
            Location = "";
            SearchString = "";
        }
        #endregion

        #region Public Property
        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value; OnPropertyChanged("SearchString"); }
        }
        private string _location;
        public string Location
        {
            get { return _location; }
            set { _location = value; OnPropertyChanged("Location"); }
        }
        private int _realViewScore;
        public int RealViewScore
        {
            get { return _realViewScore; }
            set { _realViewScore = value; OnPropertyChanged("RealViewScore"); }
        }
        private string[] _reviews;
        public string[] Reviews
        {
            get { return _reviews; }
            set { _reviews = value; OnPropertyChanged("Reviews"); }
        }
        private double _accuracy;

        public double Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; OnPropertyChanged("Accuracy"); }
        }

        private double _areaUnderROCCurve;

        public double AreaUnderROCCurve
        {
            get { return _areaUnderROCCurve; }
            set { _areaUnderROCCurve = value;OnPropertyChanged("AreaUnderROCCurve"); }
        }
        private double _f1Score;

        public double F1Score
        {
            get { return _f1Score; }
            set { _f1Score = value; OnPropertyChanged("F1Score"); }
        }

        private string _selectedBusinessName;

        public string SelectedBusinessName
        {
            get { return _selectedBusinessName; }
            set { _selectedBusinessName = value; OnPropertyChanged("SelectedBusinessName"); }
        }


        public ObservableCollection<Business> Businesses { get; set; }
        #endregion

        #region Commands
        public ActionCommand GetBusinesses { get; set; }
        public CommandWithParameter ShowReviews { get; set; }
        public ActionCommand GetRealViewScore { get; set; }
        #endregion

        #region Private methods
        private void GetRealViewScoreClicked()
        {
            float allProbability = 0;
            Accuracy = _binaryClassifierPipeline.Accuracy;
            AreaUnderROCCurve = _binaryClassifierPipeline.AreaUnderROCCurve;
            F1Score = _binaryClassifierPipeline.F1Score;
            foreach(var reviewTxt in Reviews)
            {
                allProbability+= _binaryClassifierPipeline.GetProbabilityByUsingModelWithSingleItem(reviewTxt)*100;
            }
            RealViewScore = Convert.ToInt32(allProbability / 3);
        }

        private void ShowReviewsClicked(object obj)
        {
            Business b = (Business)obj;
            Reviews = b.Reviews;
            SelectedBusinessName = b.Name;
        }

        private async void GetBusinessesWithReviews()
        {
            Businesses.Clear();
            var client = new Yelp.Api.Client("2R3rYYTTNXbGEp5MJFXrV9JgRZkoDhZeCKcAQCgDyKzHnVKfN85E8nFq7AhibN2zr0vdAb7AvtCGRg2U2WrqCtigLg26xo4XxgEKPhjxDBxVLIdclwTpPdaX3kX8XHYx");
            Yelp.Api.Models.SearchRequest searchRequest = new Yelp.Api.Models.SearchRequest();
            searchRequest.Location = Location;
            searchRequest.Term = SearchString;
            var results = await client.SearchBusinessesAllAsync(searchRequest);
            Yelp.Api.Models.SearchResponse searchResponse = results;
            var businesses = searchResponse.Businesses;
            foreach (var b in businesses)
            {
                var business = new Business();
                business.Name = b.Name.Trim();
                business.Address = b.Location.Address1.Trim();
                business.City = b.Location.City.Trim();
                business.ZipCode = b.Location.ZipCode.Trim();
                business.State = b.Location.State.Trim();
                business.Phone = b.Phone.Trim();
                var reviewresult = await client.GetReviewsAsync(b.Id);
                var revs = reviewresult.Reviews;
                business.Reviews = revs.Select(x => Regex.Replace(x.Text.Trim(), @"\r\n?|\n", "")).ToArray();
                Businesses.Add(business);
            }
        }
        #endregion

    }
}
