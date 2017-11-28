using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * TODO: 
 * Add year parameter, defaulting to current year
 * Select the nearest month, i.e. if the curren tmonth is November 2017 and 1 is specified on the command line, show January 2018. 
 */

namespace Calendar
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime month = ParseCommandLine(args);
			string title = month.ToString("MMMM yyyy");
			Console.WriteLine("{0}{1}", new string(' ', (21 - title.Length) / 2), title);
			for (int day = 1 - (int) new DateTime(month.Year, month.Month, 1).DayOfWeek; day <= DateTime.DaysInMonth(month.Year, month.Month);)
			{
				string week = "";
				for (int weekDay = 0; weekDay < 7 && day <= DateTime.DaysInMonth(month.Year, month.Month); weekDay++, day++)
					week += day > 0 ? string.Format("{0,2} ", day) : new string(' ', 3);
				Console.WriteLine(week);
			}
		}

		private static DateTime ParseCommandLine(string[] args)
		{
			if (args.Length == 0)
				return DateTime.Now;
			int month;
			if (!int.TryParse(args[0], out month))
				return DateTime.Now;
			return new DateTime(DateTime.Now.Year, Math.Min(12, Math.Max(month, 1)), 1);
		}
	}
}
