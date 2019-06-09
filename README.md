# RealReview
AI model based WPF MVVM app to read/review restaurant reviews to get the aggregated real review score using YELP api

## Real Review App: ##
![Alt text](RealReview/RealReview/Realreview.png?raw=true "Real Review")

## Use case: ##
We all read reviews and there are many of them for a given restaurant or any other business entity. How can we get a real sense of how the business is doing and how their services are? Yes we can spend time and read all the reviews ourselves to get the real picture that is being presented by all the reviews or you can use RealReview an AI based WPF app which will read all the reviews of the business for you and give you an aggregated score which will accurately reflect the holistic picture presented by all the reviewers in the reviews. 

## Techologies Used: ##

WPF MVVM
C#
Microsoft ML.NET
YELP API
MahApps.Metro

## Things Needed: ##

1. Visual Studio 2017 community edition
2. Register yourself with Yelp's developer program and get api key -> https://www.yelp.com/developers/v3/manage_app
3. Install-Package Yelp.API 
4. Install-Package Microsoft.ML 
5. Install-Package MahApps.Metro
6. Yelp labelled data for model training - https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip

## How does this work and more details: ##
Any user can search for any type of restaurants and give the location details like zipcode or city. This information is fed to yelp api which returns a list of 20 relevant businesses. Once they are fetched the app lists them with their name, phone number and address details. The user can pick any business from this list to see 3 reviews given by yelp api(3 is the limitation of number of review text provided by yelp api). Once the reviews are loaded the user can click on the "Get Real Review Score" button to get the aggregation of the score received for all the reviews provided by passing these review text through the AI based binary classifier pipeline which gives each of them a score. The mean of these scores is the RealReview score. 

The prediction accuracy of the model is 0.83422459893048129, areaunderROCCurve is 0.90494166094715167 and F1Score is 0.83597883597883593.

The binary classifier model is trained on preclassified 1000 yelp comments with 20% seperated out for testing. This is a sample app to show the combination of ML.NET and WPF, and in no way near a perfect application. There are many limitations in this app with the review text from yelp api being only 3 and also the review text being truncated without having the whole review text from the reviewer. This app might not be complete in the sense that the RealReview score is based off just 3 truncated reviews but the concept is very solid which can be scaled up to make a real world working sample. If only I could get more number of reviews and more review text from yelp api! Anyway this concept is free for anyone to use. Enjoy and happy coding. 
