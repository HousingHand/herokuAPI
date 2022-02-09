using HHPassport.DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using static HHPassport.DAL.Enums.EnumHelper;

namespace HHPassport.DAL.Helpers
{
    public static class CommonManager
    {
        public static System.Net.Http.HttpContent CreateHttpContent(object content)
        {
            System.Net.Http.HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new System.IO.MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, System.IO.SeekOrigin.Begin);
                httpContent = new System.Net.Http.StreamContent(ms);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public static void SerializeJsonIntoStream(object value, System.IO.Stream stream)
        {
            using (var sw = new System.IO.StreamWriter(stream, new System.Text.UTF8Encoding(false), 1024, true))
            using (var jtw = new Newtonsoft.Json.JsonTextWriter(sw) { Formatting = Newtonsoft.Json.Formatting.None })
            {
                var js = new Newtonsoft.Json.JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }

        public static bool IsBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;
            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception exception)
            {
                // Handle the exception
            }
            return false;
        }

        public static string CreatePathIfMissing(string path)
        {
            bool folderExists = System.IO.Directory.Exists(path);
            if (!folderExists)
                System.IO.Directory.CreateDirectory(path);
            return path;
        }

        public static string CreateUniqueFileName(string type)
        {
            return string.Format(@"{0}", DateTime.Now.Ticks + type);
        }

        public enum ExtensionEnum
        {
            [Description(".png")]
            PNGExtension
        }

        public static List<StateModel> getStates()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(System.Configuration.ConfigurationManager.AppSettings["APPPhysicalPath"].ToString() + "/xml/states.xml");
            List<StateModel> objList = new List<StateModel>();
            System.Xml.XmlNode idNodes = doc.SelectSingleNode("states");
            StateModel obj = null;
            foreach (System.Xml.XmlNode node1 in idNodes.ChildNodes)
            {
                obj = new StateModel();
                obj.Id = Convert.ToInt32(node1.Attributes["Id"].InnerText);
                obj.statename = node1.Attributes["statename"].InnerText;
                objList.Add(obj);
            }

            return objList;
        }

        public static List<CityModel> getCities()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(System.Configuration.ConfigurationManager.AppSettings["APPPhysicalPath"].ToString() + "/xml/cities.xml");
            List<CityModel> objList = new List<CityModel>();
            System.Xml.XmlNode idNodes = doc.SelectSingleNode("cities");
            CityModel obj = null;
            foreach (System.Xml.XmlNode node1 in idNodes.ChildNodes)
            {
                obj = new CityModel();
                obj.Id = Convert.ToInt32(node1.Attributes["Id"].InnerText);
                obj.cityname = node1.Attributes["cityname"].InnerText;
                objList.Add(obj);
            }

            return objList;
        }

        public static List<CountryModel> getCountries()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(System.Configuration.ConfigurationManager.AppSettings["APPPhysicalPath"].ToString() + "/xml/countries.xml");
            List<CountryModel> objList = new List<CountryModel>();
            System.Xml.XmlNode idNodes = doc.SelectSingleNode("countries");
            CountryModel obj = null;
            foreach (System.Xml.XmlNode node1 in idNodes.ChildNodes)
            {
                obj = new CountryModel();
                obj.name = node1.Attributes["name"].InnerText;
                obj.code = node1.Attributes["alpha-2"].InnerText;
                objList.Add(obj);
            }
            return objList;
        }
        public static List<RejectionModel> getRejectedList()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(System.Configuration.ConfigurationManager.AppSettings["APPPhysicalPath"].ToString() + "/xml/rejectedlist.xml");
            List<RejectionModel> objList = new List<RejectionModel>();
            System.Xml.XmlNode idNodes = doc.SelectSingleNode("rejectedlists");
            RejectionModel obj = null;
            foreach (System.Xml.XmlNode node1 in idNodes.ChildNodes)
            {
                obj = new RejectionModel();
                obj.Id = Convert.ToInt32(node1.Attributes["Id"].InnerText);
                obj.Item = node1.Attributes["name"].InnerText;
                objList.Add(obj);
            }

            return objList;
        }

        public static List<CosignerRejectionModel> GetCosignerRejectedList()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(System.Configuration.ConfigurationManager.AppSettings["APPPhysicalPath"].ToString() + "/xml/cosignerRejectionList.xml");
            List<CosignerRejectionModel> objList = new List<CosignerRejectionModel>();
            System.Xml.XmlNode idNodes = doc.SelectSingleNode("rejectedlists");
            CosignerRejectionModel obj = null;
            foreach (System.Xml.XmlNode node1 in idNodes.ChildNodes)
            {
                obj = new CosignerRejectionModel();
                obj.Id = node1.Attributes["Id"].InnerText;
                obj.Item = node1.Attributes["name"].InnerText;
                objList.Add(obj);
            }

            return objList;
        }

        public static List<APTypeModel> GetAPTypes()
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(System.Configuration.ConfigurationManager.AppSettings["APPPhysicalPath"].ToString() + "/xml/APType.xml");
            List<APTypeModel> objList = new List<APTypeModel>();
            System.Xml.XmlNode idNodes = doc.SelectSingleNode("APTypes");
            APTypeModel obj = null;
            foreach (System.Xml.XmlNode node1 in idNodes.ChildNodes)
            {
                obj = new APTypeModel();
                obj.Id = node1.Attributes["Id"].InnerText;
                obj.name = node1.Attributes["name"].InnerText;
                objList.Add(obj);
            }

            return objList;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void SendHubspotResponseToText(string email, string applicantId, string responseMessage)
        {
            string appPhysicalPath = ConfigurationManager.AppSettings["APPPhysicalPath"].ToString();
            string message = "Email :" + email + " applicantID:  " + applicantId + "Message: " + responseMessage;
            try
            {
                string fileUploadPath = DirectoryPathEnum.Upload.ToString() + "/";
                string directoryPath = CreatePathIfMissing(appPhysicalPath + "/" + fileUploadPath);
                string filepath = directoryPath + DateTime.Today.ToString("dd-MM-yy") + ".txt"; 
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString();
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(message);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                CommonManager.LogError(MethodBase.GetCurrentMethod(), e, email, applicantId, responseMessage);
                e.ToString();
            }
        }

        public static void LogError(MethodBase method, Exception ex, params object[] values)
        {
            string appPhysicalPath = ConfigurationManager.AppSettings["APPPhysicalPath"].ToString();
            ParameterInfo[] parms = method.GetParameters();
            object[] namevalues = new object[2 * parms.Length];
            string msg = "Error in " + string.Format("{0} {1}", method.Name, "method") + "(";
            for (int i = 0, j = 0; i < parms.Length; i++, j += 2)
            {
                msg += "{" + j + "}={" + (j + 1) + "}, ";
                namevalues[j] = parms[i].Name;
                if (i < (values.Length)) namevalues[j + 1] = values[i];
            }
            msg += "exception=" + ex.Message + ")";
            //var paramJson = values == null ? "--" : JsonConvert.SerializeObject(values));
            //var paramJson = JsonConvert.SerializeObject(namevalues);
            //msg += "exception=" + ex.Message + ")";

            //System.Diagnostics.Debug.WriteLine(string.Format(msg, json));
            try
            {
                string fileUploadPath = DirectoryPathEnum.Upload.ToString() + "/" + DirectoryPathEnum.ErrorLogs.ToString() + "/";
                string directoryPath = CreatePathIfMissing(appPhysicalPath + "/" + fileUploadPath);
                string filepath = directoryPath + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString();
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(error);
                    sw.WriteLine(string.Format(msg, namevalues));

                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
    }
}
