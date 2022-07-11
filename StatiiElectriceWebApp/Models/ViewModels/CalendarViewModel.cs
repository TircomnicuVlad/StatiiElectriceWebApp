namespace StatiiElectriceWebApp.Models.ViewModels
{
    public class CalendarViewModel
    {
        public List<CalendarViewModelcs> calendars { get; set; } = new List<CalendarViewModelcs>();
        public String StartWeekDay { get; set; }

        public int PrizaId { get; set; }

        public CalendarViewModel()
        {

            calendars.Add(new CalendarViewModelcs(DayOfWeek.Monday));
            calendars.Add(new CalendarViewModelcs(DayOfWeek.Tuesday));
            calendars.Add(new CalendarViewModelcs(DayOfWeek.Wednesday));
            calendars.Add(new CalendarViewModelcs(DayOfWeek.Thursday));
            calendars.Add(new CalendarViewModelcs(DayOfWeek.Friday));
            calendars.Add(new CalendarViewModelcs(DayOfWeek.Saturday));
            calendars.Add(new CalendarViewModelcs(DayOfWeek.Sunday));
        }
    }
}
