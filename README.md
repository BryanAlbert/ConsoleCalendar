# Calendar
This console application is a simple calendar. 

## Usage
Run from a Command Prompt or PowerShell. 
* **Calendar.exe [int]** Print a calendar for the month specified, e.g. **Calendar.exe 2** prints the calendar for February.
* **Calendar.exe [DateTime]** Print a calendar for the parsed DataTime, e.g. **Calendar.exe "2/1966"** prints a calendar for February 1966, an interesting year. 

## TODO
* Use DarkGray for prefix and suffix dates (before the 1st and after the last day)
* Add command line switches:
   * **-year** print a calendar for a particular year, four columns, three rows (depending on window size?)
   * **-diff** subtract two DateTimes, output in year, month, day
   * **-julian** julian date 
   * **-add** add two DateTimes
