using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTool
{
	public static class VisitorCounter
	{
		private static int todayVisitorCount = 0;

		// 保存访问人数到文件（可以替换为数据库操作等其他持久化方式）
		private static void SaveVisitorCount()
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(baseDirectory, "visitor_count.txt");

			// Check if the file doesn't exist and create it
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, "0"); // You can change the initial content here
				Console.WriteLine("File created with initial content.");
			}

			File.WriteAllText(filePath, todayVisitorCount.ToString());
		}

		// 从文件中读取今日访问人数
		private static void LoadVisitorCount()
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(baseDirectory, "visitor_count.txt");

			// Check if the file doesn't exist and create it
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, "0"); // You can change the initial content here
				Console.WriteLine("File created with initial content.");
			}

			if (File.Exists(filePath))
			{
				string countString = File.ReadAllText(filePath);
				int.TryParse(countString, out todayVisitorCount);
			}
		}

		// 初始化，通常在应用程序启动时调用
		public static void Init()
		{
			LoadVisitorCount();
			// 如果上次访问日期不是今天，重置访问人数
			if (DateTime.Now.Date != GetLastVisitDate())
			{
				todayVisitorCount = 0;
			}
		}

		// 获取上次访问日期
		private static DateTime GetLastVisitDate()
		{
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(baseDirectory, "last_visit_date.txt");

			// Check if the file doesn't exist and create it
			if (!File.Exists(filePath))
			{
				DateTime date = DateTime.Now.Date;
				string dateString = date.ToString("yyyy-MM-dd"); // 将日期转换为字符串，使用特定格式
				File.WriteAllText(filePath, dateString); // You can change the initial content here
				Console.WriteLine("File created with initial content.");
			}
			if (File.Exists(filePath))
			{
				string dateStr = File.ReadAllText(filePath);
				if (DateTime.TryParse(dateStr, out DateTime lastVisitDate))
				{
					return lastVisitDate;
				}
			}

			return DateTime.MinValue;
		}

		// 更新访问人数
		public static void UpdateVisitorCount()
		{
			// 每次访问调用该方法增加访问人数
			todayVisitorCount++;
			// 保存今日访问人数
			SaveVisitorCount();

			// 更新上次访问日期为今天
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string filePath = Path.Combine(baseDirectory, "last_visit_date.txt");

			// Check if the file doesn't exist and create it
			if (!File.Exists(filePath))
			{
				DateTime date = DateTime.Now.Date;
				string dateString = date.ToString("yyyy-MM-dd"); // 将日期转换为字符串，使用特定格式
				File.WriteAllText(filePath, dateString); // You can change the initial content here
				Console.WriteLine("File created with initial content.");
			}
			File.WriteAllText(filePath, DateTime.Now.Date.ToString());
		}

		// 获取今日访问人数
		public static int GetTodayVisitorCount()
		{
			return todayVisitorCount;
		}
	}
}
