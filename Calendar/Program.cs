using System;

/*
 * TODO: 
 * Add year parameter, defaulting to current year
 * Select the nearest month, i.e. if the curren tmonth is November 2017 and 1 is specified on the command line, show January 2018. 
 * First try to parse arguments as a DateTime (assemble a string as necessary), failing that, assume month, or month and year, as discussed.
 * Add command line switches:
 *		-year 2017 print a calendar for 2017, four columns, three rows
 *		-diff subtract two DateTimes, output in year, month, day
 *		-julian julian date 
 *		-add add two DateTimes
 *		-color Use Yellow for today's date, shadow color for prefix and suffix dates (before the 1st and after the last day)
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
