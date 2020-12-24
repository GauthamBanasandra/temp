using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace RESTClient
{
    class MatchMakerClient
    {
        private const string Url = "http://localhost:9090/match";

        public static string GetMatch(string xmlRequestBody)
        {
            var request = WebRequest.Create(Url) as HttpWebRequest;
            var bytes = Encoding.ASCII.GetBytes(xmlRequestBody);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var responseStream = response.GetResponseStream();
            var responseStr = new StreamReader(responseStream).ReadToEnd();
            return responseStr;
        }
    }
}
