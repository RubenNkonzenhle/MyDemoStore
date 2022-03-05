using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStoreFix
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;


        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AfPS0J6CoYF-vQ9qrT3BAb9dgutaiHALwqxpcY_OpeHrWa-lYChl-3zklEvZjgiiQMm__-_tSm84mtJY";
            clientSecret = "ENBr2BoxAgmrSVLqrtB-c5GBl6Kb3_YHRFqczNnqvp5kAcC-BV8fQ12Yz4p2gxhi7cdZsIdzs6Udjoc9";
        }

        private static Dictionary<string, string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret,getconfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext() 
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}