using NearestStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace NearestStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
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

            string nearestPlaceUrl = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input=" + encodedStoreName + "&inputtype=textquery&fields=formatted_address,name&locationbias=circle:32186@" + lat + "," + lng + "&key=AIzaSyC3dCRXiBTV_f0i7Ap2ZgXWTaS933cfn8w";

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

    }
}
