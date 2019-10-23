using Assignment5.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Assignment5
{
    
    public class Service1 : IService1
    {
        public string findNearestStore(string zipcode, string storeName)
        {

            GoogleResponse response = new GoogleResponse(); //Instantiating google response object
            NearestStoreResponse storeResponse = new NearestStoreResponse(); //Instantiating places response object
            string formattedString = "";
            string encodedZipCode = HttpUtility.UrlEncode(zipcode);
            var googleUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + encodedZipCode + "&key=AIzaSyC3dCRXiBTV_f0i7Ap2ZgXWTaS933cfn8w"; //Googles geocode url with users zipcode input

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(googleUrl); //downloaded content from google url page 
                response = JsonConvert.DeserializeObject<GoogleResponse>(json); //Deserializing content to response object 
            }

            var lat = "";
            var lng = "";
            try //error handling
            {
                //setting lat , lng to results from google call
                lat = response.results[0].geometry.location.lat;
                lng = response.results[0].geometry.location.lng;
            }
            catch (Exception)
            {
                formattedString = "Your search result has returned zero places";
                return formattedString;
            }
            

            // Encode the string.
            string encodedStoreName = HttpUtility.UrlEncode(storeName);

            string nearestPlaceUrl = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input="+ encodedStoreName +"&inputtype=textquery&fields=formatted_address,name&locationbias=circle:32186@"+lat+","+lng+"&key=AIzaSyC3dCRXiBTV_f0i7Ap2ZgXWTaS933cfn8w";
            
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(nearestPlaceUrl); //downloaded content from google url page 
                storeResponse = JsonConvert.DeserializeObject<NearestStoreResponse>(json); //Deserializing content to response object 
            }

            if (storeResponse.status.Equals("OK"))
            {
                formattedString = storeResponse.candidates[0].name + " was found at " + storeResponse.candidates[0].formatted_address;
            }
            else
            {
                formattedString = "Your search result has returned zero places";
            }
            return formattedString;
        }

        public string[] Weather5day(string zipcode) // PLEASE READ - Weather API that I am using only has 10 free monthly API calls. I have used 8 already.
        {
            string[] arr = new string[5];

            GoogleResponse response = new GoogleResponse(); //Instantiating google response object
            WeatherResponse weatherResponse = new WeatherResponse(); //Instantiating weather response object

            var googleUrl = "https://maps.googleapis.com/maps/api/geocode/json?address="+zipcode+"&key=AIzaSyC3dCRXiBTV_f0i7Ap2ZgXWTaS933cfn8w"; //Googles geocode url with users zipcode input

            using(var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(googleUrl); //downloaded content from google url page 
                response = JsonConvert.DeserializeObject<GoogleResponse>(json); //Deserializing content to response object 
            }

            
            var lat = "";
            var lng = "";
            try //error handling
            {
                //setting lat , lng to results from google call
                lat = response.results[0].geometry.location.lat;
                lng = response.results[0].geometry.location.lng;
            }
            catch (Exception)
            {
                string[] errorArr = new string[1]; //creating new array object so only 1 message can be returned
                errorArr[0] = "There was an issue processing your search result";
                return errorArr;
            }

            var weatherUrl = "https://www.amdoren.com/api/weather.php?api_key=SdtjvfUjhyXBMAJaSvYmqfxp57w5Tn&lat="+lat+"&lon="+lng; //setting up weather api with lat, lng retrieved from googles geocoder

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(weatherUrl); // downloading content from weather url page
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(json); //Deserializing content to weatherResponse object 
            }
            
            arr[0] = weatherResponse.forecast[0].date + " temp: " + weatherResponse.forecast[0].avg_f;
            arr[1] = weatherResponse.forecast[1].date + " temp: " + weatherResponse.forecast[1].avg_f;
            arr[2] = weatherResponse.forecast[2].date + " temp: " + weatherResponse.forecast[2].avg_f;
            arr[3] = weatherResponse.forecast[3].date + " temp: " + weatherResponse.forecast[3].avg_f;
            arr[4] = weatherResponse.forecast[4].date + " temp: " + weatherResponse.forecast[4].avg_f;
            return arr;
        }

    }
}
