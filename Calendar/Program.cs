using System;


namespace Calendar
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime month;
			if (ParseCommandLine(args, out month))
			{
				string title = month.ToString("MMMM yyyy");
				Console.WriteLine("{0}{1}", new string(' ', (21 - title.Length) / 2), title);
				Console.WriteLine("Su Mo Tu We Th Fr Sa");
				ConsoleColor initialColor = Console.ForegroundColor;
				for (int day = 1 - (int) new DateTime(month.Year, month.Month, 1).DayOfWeek; day <= DateTime.DaysInMonth(month.Year, month.Month);)
				{
					for (int weekDay = 0; weekDay < 7 && day <= DateTime.DaysInMonth(month.Year, month.Month); weekDay++, day++)
					{
						Console.ForegroundColor = DateTime.Now.Year == month.Year && DateTime.Now.Month == month.Month && DateTime.Now.Day == day ?
							ConsoleColor.Red : ConsoleColor.White;
						Console.Write(day > 0 ? string.Format("{0,2} ", day) : new string(' ', 3));
					}
					Console.WriteLine();
				}

				Console.ForegroundColor = initialColor;
			}

#if DEBUG
			Console.WriteLine("Hit a key to exit.");
			Console.ReadKey();
#endif
		}

		private static bool ParseCommandLine(string[] args, out DateTime month)
		{
			month = DateTime.Now;
			if (args.Length == 0)
				return true;

			foreach (string arg in args)
			{
				switch (arg)
				{
					case "-?":
					case "-help":
						PrintUsage();
						return false;
				}
			}

			// parse as a DateTime, failing that, as an int
			if (DateTime.TryParse(args[0], out month))
				return true;

			int monthNumber;
			if (!int.TryParse(args[0], out monthNumber))
			{
				Console.WriteLine($"Failed to parse '{args[0]}' as a DateTime or an int.");
				return false;
			}

			month = new DateTime(DateTime.Now.Year, Math.Min(12, Math.Max(monthNumber, 1)), 1);
			return true;
		}

		private static void PrintUsage()
		{
			Console.WriteLine("Calendar [-?|-help]  Print this help");
			Console.WriteLine("Calendar [int]       Print a calendar for the month specified");
			Console.WriteLine("Calendar [DateTime]  Print a calendar for the parsed DataTime");
		}
	}
}
