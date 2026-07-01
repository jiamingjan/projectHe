using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace MyTool
{
    /// <summary>
    /// 生成验证码和图片
    /// </summary>
    public class CheckCode
    {
        /// <summary>
        /// 生成随机验证码数字+字母
        /// </summary>
        /// <param name="codelen">验证码长度</param>
        /// <returns>返回验证码</returns>
        public static string MakeCode(int codelen)
        {
            if (codelen < 1)
            {
                return string.Empty;
            }
            int number;
            StringBuilder strCheckCode = new StringBuilder();
            Random random = new Random();
            for (int index = 0; index < codelen; index++)
            {
                number = random.Next();
                if (number % 2 == 0)
                {
                    strCheckCode.Append((char)('0' + (char)(number % 10)));//生成随机数字
                }
                else
                {
                    strCheckCode.Append((char)('A' + (char)(number % 26)));//生成随机字母
                }
            }
            return strCheckCode.ToString();
        }

        /// <summary>
        /// ImageSharp是对.NET Core平台扩展的一个图像处理方案，以往网上的案例多以生成文字及画出简单图形、验证码等方式进行探讨和实践。
        /// </summary>
        /// <param name="CheckCode"></param>
        /// <param name="imgType"></param>
        /// <returns></returns>
        public static MemoryStream? CheckCodeImage(string CheckCode, SixLabors.ImageSharp.Formats.IImageFormat imgType)
        {
            if (string.IsNullOrEmpty(CheckCode))
            {
                return null;
            }

            int width = (int)Math.Ceiling((CheckCode.Length * 27.5));//12.5
            //width = 110;
            int height = 40;

            using Image image = new Image<Rgba32>(width, height);
            //漆底色白色
            //image.Mutate(x => x.DrawLines(Pens.DashDot(Color.White, width), new PointF[] { new PointF() { X = 0, Y = 0 }, new PointF() { X = width, Y = height } }));

            //FontCollection collection = new();
            //FontFamily family = collection.Add("font/font.ttf");
            //Font font = family.CreateFont(20, FontStyle.Bold);
            var font = SystemFonts.CreateFont("Arial", 36, FontStyle.Regular);

            PointF startPointF = new PointF(10, 5);
            Random random = new Random(); //随机数产生器

            Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Peru, Color.LightSeaGreen, Color.Lime, Color.Magenta, Color.Maroon, Color.MediumBlue, Color.MidnightBlue, Color.Navy };
            //绘制大小
            for (int i = 0; i < CheckCode.Length; i++)
            {
                image.Mutate(x => x.DrawText(CheckCode[i].ToString(), font, colors[random.Next(colors.Length)], startPointF));
                //Console.WriteLine($"draw code:{verifyCode[i]} point:{startPointF.X}-{startPointF.Y}");
                startPointF.X += (int)(width - 10) / CheckCode.Length;
                startPointF.Y = random.Next(5, 10);
            }

            //Pen pen = Pens.DashDot(Color.Silver, 1);
            Brush brush = new SolidBrush(Color.Silver);
            //SixLabors.ImageSharp.Drawing.Processing.RecolorBrush brush = new SixLabors.ImageSharp.Drawing.Processing.RecolorBrush(Color.Red, Color.Blue,1);
            //绘制干扰线
            for (var k = 0; k < 30; k++)
            {
                PointF[] points = new PointF[2];
                points[0] = new PointF(random.Next(width), random.Next(height));
                points[1] = new PointF(random.Next(width), random.Next(height));
                image.Mutate(x => x.DrawLine(brush,1, points));
            }


            using MemoryStream stream = new MemoryStream();
            //image.Save(stream, JpegFormat.Instance);
            image.Save(stream, imgType);
            //输出图片流  
            //return stream.ToArray();
            return stream;
        }

        public static MemoryStream? CheckCodeImage2(string CheckCode, SixLabors.ImageSharp.Formats.IImageFormat imgType)
        {
            // Create a new image with the desired width and height
            int width = 200;
            int height = 80;
            using (var image = new Image<Rgba32>(width, height))
            {
            //    var random = new Random();

            //    // Generate a random string of characters for the captcha
            //    string captchaText = GenerateRandomText(6, random);

            //    // Configure the font and text drawing options
            //    var font = SystemFonts.CreateFont("Arial", 36, FontStyle.Regular);
            //    var textGraphicsOptions = new TextGraphicsOptions()
            //    {
            //        TextOptions = new TextOptions()
            //        {
            //            HorizontalAlignment = HorizontalAlignment.Left,
            //            VerticalAlignment = VerticalAlignment.Top
            //        }
            //    };

            //    // Draw the captcha text on the image
            //    image.Mutate(ctx => ctx.DrawText(textGraphicsOptions, captchaText, font, Rgba32.Black, new PointF(10, 10)));

            //    // Add some random noise to the image
            //    AddNoise(image, random);

                // Save the image to a file (optional)
                //image.Save("captcha.png");
                using MemoryStream stream = new MemoryStream();
                //image.Save(stream, JpegFormat.Instance);
                //输出图片流  
                //return stream.ToArray();
                return stream;
            }
        }

        private static string GenerateRandomText(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = chars[random.Next(chars.Length)];
            }
            return new string(text);
        }

        private static void AddNoise(Image<Rgba32> image, Random random)
        {
            int noiseLevel = 150;
            for (int i = 0; i < noiseLevel; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image[x, y] = new Rgba32((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            }
        }
    }
}