using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MyTool
{
    public class MathUtil
    {
        /// <summary>
        /// 获取指定区间的随机数
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static int GetRandom(int min = 0, int max = 1000000)
        {
            return new Random(GetRandomSeed()).Next(min, max);
        }

        /// <summary>
        /// 加密随机数生成器 生成随机种子
        /// </summary>
        /// <returns></returns>

        static int GetRandomSeed()

        {

            byte[] bytes = new byte[4];

            RandomNumberGenerator r = RandomNumberGenerator.Create();

            r.GetBytes(bytes);

            return BitConverter.ToInt32(bytes, 0);

        }
    }
}
