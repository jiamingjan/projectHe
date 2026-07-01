using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTool
{
    public class HttpAPI
    {
        public string[] apiset;
        public HttpAPI()
        {
            apiset = null!;
        }
        public HttpAPI(string[] apiSet)
        {
            apiset = apiSet;
        }


        public static string HttpUploadFile(string url, string fileFullPath)
        {
            // 设置参数

            HttpWebRequest? request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            if (request == null || cookieContainer == null)
                return "";
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
            int pos = fileFullPath.LastIndexOf("\\");
            string fileName = fileFullPath.Substring(pos + 1);

            //请求头部信息
            StringBuilder sbHeader = new StringBuilder(string.Format("Content-Disposition:form-data;name=\"file\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n", fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

            FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
            byte[] bArr = new byte[fs.Length];
            fs.Read(bArr, 0, bArr.Length);
            fs.Close();

            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bArr, 0, bArr.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();

            //发送请求并获取相应回应数据
            HttpWebResponse? response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        }

        public static string HttpGet(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                //创建Web访问对  象
                HttpWebRequest? myRequest = (HttpWebRequest)WebRequest.Create(url);

                //设置请求头
                if (headers != null)
                {
                    foreach (var item in headers)
                        myRequest.Headers.Add(item.Key, item.Value);
                }

                //通过Web访问对象获取响应内容
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
                string returnXml = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
                reader.Close();
                myResponse.Close();
                return returnXml;
            }
            catch (Exception ex)
            {
                 LogUtil.Log("HttpGet失败:" + ex.Message);
                return "";
            }
        }

        public static string HttpPostJson(string url, string json, Dictionary<string, string>? headers = null)
        {
            string result = "";
            try
            {
                if (string.IsNullOrEmpty(url))
                    return result;
                HttpWebRequest request = (WebRequest.Create(url) as HttpWebRequest)!;
                request.Method = "POST";
                //request.Method = "GET";

                //设置请求头
                if (headers != null)
                {
                    foreach (var item in headers)
                        request.Headers.Add(item.Key, item.Value);
                }


                //这是用url的方式提交参数
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json";

                //string jsonEncoded = EncodeBase64("UTF-8", json.ToString());
                //StringBuilder builder = new StringBuilder();
                ////下面宋承文这里有问题
                //builder.AppendFormat("{0}={1}", "data", jsonEncoded);
                //byte[] encodeJson = Encoding.UTF8.GetBytes(builder.ToString());
                byte[] encodeJson = Encoding.UTF8.GetBytes(json.ToString());
                request.ContentLength = encodeJson.Length;

                using (Stream reqStream = request.GetRequestStream())  // 获取
                {
                    reqStream.Write(encodeJson, 0, encodeJson.Length);  // 向当前流中写入字节
                    reqStream.Close();                      // 关闭当前流
                }

                // Get response           
                HttpWebResponse response = (request.GetResponse() as HttpWebResponse)!;
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    if (reader != null)
                        result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                // LogUtil.Log("发送hbase失败:" + ex.Message);
                if (string.IsNullOrEmpty(result))
                    result = "result:"+ex.Message;
                return result;
            }
            return result;
        }


        public static string EncodeBase64(string code_type, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
    }
}