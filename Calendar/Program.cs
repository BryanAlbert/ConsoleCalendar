using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime month = ParseCommandLine(args);
			string title = month.ToString("MMMM yyyy");
			Console.WriteLine("{0}{1}", new string(' ', (21 - title.Length) / 2), title);
			DateTime first = new DateTime(month.Year, month.Month, 1);
			int day = 1 - (int) first.DayOfWeek;
			while (day < DateTime.DaysInMonth(month.Year, month.Month))
			{
				string week = "";
				for (int weekDay = 0; weekDay < 7 && day <= DateTime.DaysInMonth(month.Year, month.Month); weekDay++, day++)
					week += day > 0 ? string.Format("{0,2} ", day) : new string(' ', 3);
				Console.WriteLine(week);
			}
			Console.ReadKey();
		}

		private static DateTime ParseCommandLine(string[] args)
		{
			if (args.Length == 0)
				return DateTime.Now;
			int month;
			if (!int.TryParse(args[0], out month))
				return DateTime.Now;
			return new DateTime(DateTime.Now.Year, month, 1);
		}
	}
}
