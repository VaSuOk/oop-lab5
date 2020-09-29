using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassConlsole
{
    class Airplane
    {
        public string StartCity;
        protected string FinishCity;
        protected Date StartDate;
        protected Date FinishDate;
        
        public Airplane(string StartCity = "", string FinishCity = "", Date StartDate = null, Date FinishDate = null)
        {
            this.StartCity = StartCity;
            this.FinishCity = FinishCity;
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
        }
        public Airplane(string StartCity, string FinishCity)
        {
            this.StartCity = StartCity;
            this.FinishCity = FinishCity;
            this.StartDate = null;
            this.FinishDate = null;
        }
        public Airplane( Date StartDate, Date FinishDate )
        {
            this.StartCity = "";
            this.FinishCity = "";
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
        }
        public Airplane(Airplane previousPerson)
        {
            StartCity = previousPerson.StartCity;
            FinishCity = previousPerson.FinishCity;
            StartDate = previousPerson.StartDate;
            FinishDate = previousPerson.FinishDate;
        }
        
        public Airplane() { }
        public void Set_StartCity(string StartCity) { this.StartCity = StartCity; }
        public void Set_FinishCity(string FinishCity) { this.FinishCity = FinishCity; }
        public void Set_StartDate(Date StartDate) { this.StartDate = StartDate; }
        public void Set_FinishDate(Date FinishDate) { this.FinishDate = FinishDate; }

        public string Get_StartCity() { return StartCity; }
        public string Get_FinishCity() { return FinishCity; }
        public Date Get_StartDate() { return StartDate; }
        public Date Get_FinishDate() { return FinishDate; }


        public int GetTotalTime()
        {
            int Total_time = (FinishDate.Get_Year() - StartDate.Get_Year())*(365*1440);
            if(FinishDate.Get_Month() < StartDate.Get_Month())
                Total_time += FinishDate.Get_Month() * 1440;
            else
                Total_time += (FinishDate.Get_Month() - StartDate.Get_Month()) * 1440;

            if (FinishDate.Get_Day() < StartDate.Get_Day())
                Total_time += FinishDate.Get_Day() * 1440;
            else
                Total_time += (FinishDate.Get_Day() - StartDate.Get_Day()) * 1440;

            if(FinishDate.Get_Hours() < StartDate.Get_Hours())
                Total_time += FinishDate.Get_Hours() * 60;
            else
                Total_time += (FinishDate.Get_Hours() - StartDate.Get_Hours()) * 60;
            if (FinishDate.Get_Minutes() < StartDate.Get_Minutes())
                Total_time += FinishDate.Get_Minutes();
            else
                Total_time += (FinishDate.Get_Minutes() - StartDate.Get_Minutes());

            return Total_time;
        }
        public bool IsArrivingToday()
        {
            return StartDate.Get_Day() == FinishDate.Get_Day();
        }

    }
    
}
