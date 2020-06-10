using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace covid19.Data
{
    public class StatCanClient
    {

        static readonly HttpClient Client;

        const string url = "https://www150.statcan.gc.ca/t1/wds/rest/";

        const string ApiKey = Credentials.StatCanApiKey;

        const string language = "en";

        static StatCanClient()
        {
            /*HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = new WebProxy("http://127.0.0.1:8888"),
                UseProxy = true,
            };*/

            Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("X-ApiKey", ApiKey);
        }

        public static async Task<object> GetCallAPI(string url)
        {
            try
            {
                Console.WriteLine("GET:" + url);
                var response = await Client.GetAsync(url);

                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<object>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public static async Task<object> PostCallAPI(string url, object jsonObject)
        {
            try
            {
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                Console.WriteLine("POST: + " + url + content);
                var response = await Client.PostAsync(url, content);

                Console.WriteLine("Response StatusCode: " + (int)response.StatusCode);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<object>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }


        public static void getChangedSeriesList()
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

        public static void getChangedCubeList(string date)
        {
            //date format YYYY-MM-DAY
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name + "/" + date;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

        public static void getCubeMetadata(int productId)
        {
            //date format YYYY-MM-DAY
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.productId = productId;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getCubeMetadata(int productId, string coordinate)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.productId = productId;
            jsonObject.coordinate = coordinate;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getSeriesInfoFromVector(int vectorId)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.vectorId = vectorId;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getAllCubesList()
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

        public static void getAllCubesListLite()
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

        public static void getChangedSeriesDataFromCubePidCoord(int productId, string coordinate)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.productId = productId;
            jsonObject.coordinate = coordinate;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getChangedSeriesDataFromVector(int vectorId)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.vectorId = vectorId;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getDataFromCubePidCoordAndLatestNPeriods(int productId, string coordinate, int latestN)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.productId = productId;
            jsonObject.coordinate = coordinate;
            jsonObject.latestN = latestN;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getDataFromVectorsAndLatestNPeriods(int vectorId, int latestN)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.vectorId = vectorId;
            jsonObject.latestN = latestN;

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getBulkVectorDataByRange(int[] vectorIds, DateTime start, DateTime end)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            dynamic jsonObject = new JObject();
            jsonObject.vectorIds = vectorIds;
            jsonObject.startDataPointReleaseDate = start.ToString("yyyy-MM-ddTHH:mm");  //format 2015-12-01T08:30
            jsonObject.endDataPointReleaseDate = end.ToString("yyyy-MM-ddTHH:mm");

            var result = PostCallAPI(target_url, jsonObject).GetAwaiter().GetResult();
        }

        public static void getFullTableDownloadCSV(int tableId)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name + "/" + tableId + "/" + language;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

        public static void getFullTableDownloadSDMX(int tableId)
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name + "/" + tableId;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

        public static void getCodeSets()
        {
            string method_name = System.Reflection.MethodBase.GetCurrentMethod().Name;

            string target_url = url + method_name;

            var result = GetCallAPI(target_url).GetAwaiter().GetResult();
        }

    }
}


