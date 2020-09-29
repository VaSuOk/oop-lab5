using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    class Date
    {
        protected int Year;
        protected int Month;
        protected int Day;
        protected int Hours;
        protected int Minutes;

        public void Set_Year(int Year) { this.Year = Year; }
        public void Set_Month(int Month) { this.Month = Month; }
        public void Set_Day(int Day) { this.Day = Day; }
        public void Set_Hours(int Hours) { this.Hours = Hours; }
        public void Set_Minutes(int Minutes) { this.Minutes = Minutes; }

        public int Get_Year() { return Year; }
        public int Get_Month() { return Month; }
        public int Get_Day() { return Day; }
        public int Get_Hours() { return Hours;  }
        public int Get_Minutes() { return Minutes; }


        public Date(int Year = 0, int Month = 0, int Day = 0, int Hours = 0, int Minutes = 0)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.Hours = Hours;
            this.Minutes = Minutes;
        }
        public Date(int Year, int Month, int Day)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.Hours = 0;
            this.Minutes = 0;
        }
        public Date(int Hours, int Minutes)
        {
            this.Year = 0;
            this.Month = 0;
            this.Day = 0;
            this.Hours = Hours;
            this.Minutes = Minutes;
        }
        public Date(Date previousPerson)
        {
            Year = previousPerson.Year;
            Month = previousPerson.Month;
            Day = previousPerson.Day;
            Hours = previousPerson.Hours;
            Minutes = previousPerson.Minutes;
        }
    }
}
