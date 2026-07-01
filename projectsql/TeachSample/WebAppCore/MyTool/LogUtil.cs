using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTool
{
    public class LogUtil
    {
        public static DateTime lastWriteDate; //上一次写日志时间
        public static DateTime startDate = DateTime.Now;
        public static string fileName = date2FileName(startDate) + "Log.log"; 
        public static void Log(string content)
        {
            //日志文件会存在windows服务程序目录下 （System.Environment.CurrentDirectory使用该方法无法获取到正确的目录？）
            string dir = AppDomain.CurrentDomain.BaseDirectory;//获取该服务所在的程序安装目录路径
            
            FileStream fs;
            StreamWriter sw;
            try
            {
                DateTime now = DateTime.Now;
                if (lastWriteDate.Subtract(DateTime.Now).Days != 0) //表示不是同一天，就是过了一天,一天检查一次
                {
                    ////检测文件大小
                    //if (GetLogFileSize(dir + "//" + fileName) > 20000000)//20M
                    //{
                        fileName = date2FileName(now) + "Log.log"; //新的文件
                   // }
                    lastWriteDate = now;
                }
                //fs = new FileStream(dir + "//" + "Log0.log", FileMode.Append);
                fs = new FileStream(dir + "//" + fileName, FileMode.Append);
                sw = new StreamWriter(fs);
                //开始写入
                sw.Write("\r\n**" + now.ToString() + "** " + content);
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }

        }

        /// <summary>
        /// 下面方法还有问题
        /// </summary>
        public static long GetLogFileSize(string fileName)
        {
            if (File.Exists(fileName))
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                if (fileInfo != null && fileInfo.Exists)
                {
                    return fileInfo.Length;
                }
            }

            return 0;
        }

        /// <summary>
        /// 日期格式：2018/8/17 12:17:37
        /// 删除  / 空格 : 3种字符
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string date2FileName(DateTime date)
        {
            //[:/ ]里面是冒号斜杠和空格，都要去掉
            //return Regex.Replace(date.ToString(), "[:/ ]", "");
            return "" + date.Year + "_" + date.Month + "_" + date.Day;
        }
    }
}