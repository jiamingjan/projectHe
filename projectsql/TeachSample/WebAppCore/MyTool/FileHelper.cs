using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTool
{
    public class FileHelper
    {
        /// <summary>
        /// 读取结果是字符串
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="startLine">起始行，从0开始算</param>
        /// <param name="linecount">读取的行数</param>
        /// <returns></returns>
        public static string ReaderLinesFromFile(string filename, int startLine, int linecount)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                if (i >= startLine)
                {
                    if (linecount < 1)
                        sb.Append(reader.ReadToEnd());
                    else
                        sb.Append(reader.ReadLine());
                }
                else
                    reader.ReadLine();
                i++;
                if (i >= linecount + startLine) break;
            }
            reader.Close();
            reader.Dispose();
            return sb.ToString();
        }

        /// <summary>
        /// 读取结果List
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="startLine">起始行，从0开始算</param>
        /// <param name="linecount">读取的行数</param>
        /// <returns></returns>
        public static List<string> ReaderLinesArrayFromFile(string filename, int startLine, int linecount)
        {
            int currentLine = 0; //表示当前行
            List<string> lines = new List<string>();

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                if (currentLine >= startLine)
                {
                    if (linecount < 1)
                        lines.Add(reader.ReadToEnd());
                    else
                        lines.Add(reader.ReadLine()!);
                }
                else //小于起始行，那么不要
                    reader.ReadLine();
                currentLine++;
                if (currentLine >= linecount + startLine)//已经读到linecount行了，结束
                    break;
            }
            reader.Close();
            reader.Dispose();
            return lines;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="gap">跳过几个</param>
        /// <param name="skip">前面几行不要参与</param>
        /// <returns></returns>
        public static List<string> ReaderLinesByGap(string filename, int gap, int skip = 0)
        {
            int i = 0;
            List<string> lines = new List<string>();

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                if (skip > 0)
                {
                    if (i < skip)
                    {
                        i++;
                        reader.ReadLine();
                        continue;
                    }
                }
                if (gap == 0)//表示每行都要读
                {
                    lines.Add(reader.ReadLine()!);
                }
                else
                {
                    if ((i-skip) % gap == 0)                    
                        lines.Add(reader.ReadLine()!);                    
                    else
                        reader.ReadLine();
                }
               
                i++;                
            }
            reader.Close();
            reader.Dispose();
            return lines;
        }

        ///
        public static int GetTotalLines(string filename)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while ((line = file.ReadLine()!) != null)
            {                
                counter++;
            }

            file.Close();
            return counter;
        }
    }
}