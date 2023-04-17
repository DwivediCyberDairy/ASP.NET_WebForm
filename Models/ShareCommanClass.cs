using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace pramodSourceSystem.Models
{
    public class ShareCommanClass
    {
        public static DataSet CallApiGetDs(string Url)
        {
            try
            {
                HttpClient HClient = new HttpClient();
                HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ShareUrl"].ToString());
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HClient.Timeout = TimeSpan.FromMinutes(5);
                var Response = HClient.GetAsync(Url).Result;
                var a = Response.Content.ReadAsStringAsync().Result.ToString();
                DataSet ds = new DataSet();
                ds = JsonConvert.DeserializeObject<DataSet>(a);
                return ds;
            }

            catch
            {
               // DataSet ds;
                return  null;
            }
        }

        public static DataTable CallApiGetDt(string Url)
        {
            try
            {
                HttpClient HClient = new HttpClient();
                HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ShareUrl"].ToString());
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HClient.Timeout = TimeSpan.FromMinutes(5);
                var Response = HClient.GetAsync(Url).Result;
                var a = Response.Content.ReadAsStringAsync().Result.ToString();
                DataTable dt = new DataTable();
                dt = JsonConvert.DeserializeObject<DataTable>(a);
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt;
                return dt = null;
            }

        }
        public static DataSet CallApiPostDs(string URL, object obj)
        {
            DataSet ds;
            try
            {
                HttpClient HClient = new HttpClient();
                HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ShareUrl"].ToString());
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = URL;
                var response = HClient.PostAsJsonAsync(uri, obj).Result;

                var resData = response.Content.ReadAsStringAsync().Result.ToString();
                ds = new DataSet();
                ds = JsonConvert.DeserializeObject<DataSet>(resData);
                return ds;
            }

            catch (Exception)
            {
                ds = new DataSet();
                return ds;
            }
        }

        //public static DataSet ApiPostDataSet(string URL, object obj)
        //{
        //    DataSet ds;
        //    try
        //    {
        //        HttpClient HClient = new HttpClient();
        //        HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUri"].ToString());
        //        HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HClient.Timeout = TimeSpan.FromMinutes(10);
        //        var uri = URL;
        //        var response = HClient.PostAsJsonAsync(uri, obj).Result;
        //        var resData = response.Content.ReadAsStringAsync().Result.ToString();
        //        ds = new DataSet();
        //        ds = JsonConvert.DeserializeObject<DataSet>(resData);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        ds = new DataSet();
        //        return ds;
        //    }
        //}
        public static DataTable CallApiPostDt(string URL, object obj)
        {
            DataTable dt;

            try
            {
                HttpClient HClient = new HttpClient();
                HClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ShareUrl"].ToString());
                HClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var uri = URL;
                var response = HClient.PostAsJsonAsync(uri, obj).Result;

                var resData = response.Content.ReadAsStringAsync().Result.ToString();
                dt = new DataTable();
                dt = JsonConvert.DeserializeObject<DataTable>(resData);
                return dt;
            }

            catch
            {
                dt = new DataTable();
                return dt;
            }
        }
    }
}