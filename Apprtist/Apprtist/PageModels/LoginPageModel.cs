﻿using Apprtist.Models;
using FreshMvvm;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace Apprtist.PageModels
{
    
    class LoginPageModel : BasePageModel
    {
        string faceResponse;
        public string FaceResponse
        {
            get { return faceResponse; }
            set { faceResponse = value; RaisePropertyChanged(); }
        }

        string facebookAuthUrl;
        public string FacebookAuthUrl
        {
            get { return facebookAuthUrl; }
            set { facebookAuthUrl = value; RaisePropertyChanged(); }
        }

        FacebookProfile userData;
        public FacebookProfile UserData
        {
            get { return userData; }
            set { userData = value; RaisePropertyChanged(); }
        }

        string tokenUrl;
        public string TokenUrl
        {
            get { return tokenUrl; }
            set 
            { 
                tokenUrl = value;
                RaisePropertyChanged();
                ReceiveToken();
            }
        }
        string imagePic;
        public string ImagePic
        {
            get { return imagePic; }
            set {   imagePic = value;   RaisePropertyChanged();}
        }
        string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }
        string accesToken;
        public string AccesToken
        {
            get { return accesToken; }
            set { accesToken = value; RaisePropertyChanged(); }
        }

        public LoginPageModel()
        {
            FacebookAuthUrl = Constants.Constants.FaceAuthUrl;
        }
        private void ReceiveToken()
        {
            if (TokenUrl.Contains("access_token"))
            {
                TokenUrl = TokenUrl.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                AccesToken = TokenUrl.Split('&')[0];
                CallFacebookData();
                
            }
        }

        private void CallFacebookData()
        {
            IsBusy = true;
            var client = new RestClient("https://graph.facebook.com/me?fields=email,name,picture&access_token=" + AccesToken);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            UserData = JsonConvert.DeserializeObject<FacebookProfile>(response.Content);
            ImagePic = UserData.Picture.Data.Url.ToString();
            UserName = UserData.Name;
            Application.Current.Properties["Report"] = response.Content;
            IsBusy = false;
            
        }
    }
}
