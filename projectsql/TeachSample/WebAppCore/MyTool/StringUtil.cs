using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyTool
{
    public class StringUtil
    {
        /// <summary>
        /// 去掉socket收到的数据两边的\0和空格
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string GetSocketString(string src)
        {            
            if (string.IsNullOrEmpty(src))
                return "";
            //如果空格开头的：
            src = src.Trim().Trim('\0');
            //如果\0开头的，那么继续下面步骤
            src = src.Trim('\0').Trim();
            return src;
        }

       
    }
}
