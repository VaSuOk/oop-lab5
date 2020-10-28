using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleClassLibrary;

namespace SimpleClassConlsole
{
    /*
     * Класи знаходяться в окремих файлах проекту 
     *
     * По умові поля в класах захищені (protected)
    */
    class Program
    {
        static void Main(string[] args)
        {
            
            Airplane[] MyAirplanes = ReadAirplaneArray();
            PrintAirplanes(MyAirplanes);
            int max_time, min_time;
            GetAirplaneInfo(MyAirplanes, out max_time, out min_time);
            Console.WriteLine("Максимальний час подорожi = "+ max_time + ", Мiнiмальний час подорожi = " + min_time);
            Console.WriteLine("====Сортування по датi початку польоту====");
            PrintAirplanes( SortAirplanesByDate(MyAirplanes) );
            Console.WriteLine("====Сортування по тривалостi польоту====");
            PrintAirplanes(SortAirplanesByTotalTime(MyAirplanes));
            Console.ReadKey();
        }
        
        static Airplane[] ReadAirplaneArray()
        {
            
            int size_arr;
            Console.WriteLine("Введiть кiлькiсть рейсiв !");
            size_arr = Convert.ToInt32(Console.ReadLine());
            Airplane[] temp_arr = new Airplane[size_arr];

            for (int i = 0; i < size_arr; i++)
            {
                Console.WriteLine("Рейс №-" +( i + 1));
                Console.WriteLine("");

                Console.WriteLine("Введiть назву мiста вiдльоту ");
                temp_arr[i] = new Airplane();
                temp_arr[i].Set_StartCity(Console.ReadLine());
                Console.WriteLine("Введiть назву мiста прильоту ");
                temp_arr[i].Set_FinishCity(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Введiть наступнi данi дати вiдльоту ");
                Console.WriteLine("(цiлочисельними значеннями)");

                Date temp_date_input = new Date();

                Console.WriteLine("Введiть рiк");
                temp_date_input.Set_Year(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть мiсяць");
                temp_date_input.Set_Month(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть день");
                temp_date_input.Set_Day(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть годину");
                temp_date_input.Set_Hours(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть хвилину");
                temp_date_input.Set_Minutes(Convert.ToInt32(Console.ReadLine()));
                temp_arr[i].Set_StartDate(temp_date_input);
                Console.WriteLine();

                Date temp_date_out = new Date();

                Console.WriteLine("Введiть наступнi данi дати прильоту ");
                Console.WriteLine("(цiлочисельними значеннями)");
                Console.WriteLine("Введiть рiк");
                temp_date_out.Set_Year(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть мiсяць");
                temp_date_out.Set_Month(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть день");
                temp_date_out.Set_Day(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть годину");
                temp_date_out.Set_Hours(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Введiть хвилину");
                temp_date_out.Set_Minutes(Convert.ToInt32(Console.ReadLine()));
                temp_arr[i].Set_FinishDate(temp_date_out);
            }
            return temp_arr;
        } 
            
    static void PrintAirplanes(Airplane[] obj) 
        {
            Console.WriteLine("---------------Вивiд данних----------------");
            Console.WriteLine();
            for (int i = 0; i < obj.Length; i++)
            {
                Console.WriteLine("Рейс №"+(i+1));
                PrintAirplane(obj[i]);
            }
            
        }
    static void PrintAirplane(Airplane obj)
        {
            Console.WriteLine("Початкове мiсто - " + obj.Get_StartCity());
            Console.WriteLine("Фiнальне мiсти  - " + obj.Get_FinishCity());
            Console.WriteLine("Дата вiдльоту   - " + obj.Get_StartDate().Get_Year() + "," + obj.Get_StartDate().Get_Month() + "," + obj.Get_StartDate().Get_Day() + "," + obj.Get_StartDate().Get_Hours() + ":" + obj.Get_StartDate().Get_Minutes() + ".");
            Console.WriteLine("Дата прильоту   - " + obj.Get_FinishDate().Get_Year() + "," + obj.Get_FinishDate().Get_Month() + "," + obj.Get_FinishDate().Get_Day() + "," + obj.Get_FinishDate().Get_Hours() + ":" + obj.Get_FinishDate().Get_Minutes() + ".");
            Console.WriteLine("");
        }
        static void GetAirplaneInfo(Airplane[] obj, out int max_time, out int min_time)
        {
            max_time = obj[0].GetTotalTime();
            min_time = max_time;
            for (int i = 1; i < obj.Length; i++)
            {
                if(max_time < obj[i].GetTotalTime())
                {
                    max_time = obj[i].GetTotalTime();
                }
                else if( min_time > obj[i].GetTotalTime())
                {
                    min_time = obj[i].GetTotalTime();
                }
            }
        }

        static Airplane[] SortAirplanesByDate(Airplane[] obj)
        {
            for (int i = 1; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length-i; j++)
                {
                    if(obj[j].Get_StartDate().Get_Year() > obj[j].Get_StartDate().Get_Year() || 
                        (obj[j].Get_StartDate().Get_Year() == obj[j].Get_StartDate().Get_Year() && obj[j].Get_StartDate().Get_Month() > obj[j+1].Get_StartDate().Get_Month())||
                        (obj[j].Get_StartDate().Get_Year() == obj[j].Get_StartDate().Get_Year() && obj[j].Get_StartDate().Get_Month() == obj[j + 1].Get_StartDate().Get_Month() && obj[j].Get_StartDate().Get_Day() > obj[j+1].Get_StartDate().Get_Day()) ||
                        (obj[j].Get_StartDate().Get_Year() == obj[j].Get_StartDate().Get_Year() && obj[j].Get_StartDate().Get_Month() == obj[j + 1].Get_StartDate().Get_Month() && obj[j].Get_StartDate().Get_Day() == obj[j+1].Get_StartDate().Get_Day() && obj[j].Get_StartDate().Get_Hours() > obj[j +1].Get_StartDate().Get_Hours())||
                        (obj[j].Get_StartDate().Get_Year() == obj[j].Get_StartDate().Get_Year() && obj[j].Get_StartDate().Get_Month() == obj[j + 1].Get_StartDate().Get_Month() && obj[j].Get_StartDate().Get_Day() == obj[j + 1].Get_StartDate().Get_Day() && obj[j].Get_StartDate().Get_Hours() == obj[j + 1].Get_StartDate().Get_Hours() && obj[j].Get_StartDate().Get_Minutes() > obj[j + 1].Get_StartDate().Get_Minutes()))
                    {
                        Airplane temp_obj;
                        temp_obj = obj[j];
                        obj[j] = obj[j + 1];
                        obj[j + 1] = temp_obj;
                    }
                }
            }
            return obj;
        }

        static Airplane[] SortAirplanesByTotalTime(Airplane[] obj)
        {
            for (int i = 1; i < obj.Length; i++)
            {
                for (int j = 0; j < obj.Length-i; j++)
                {
                    if (obj[j].GetTotalTime() > obj[j + 1].GetTotalTime())
                    {
                        Airplane temp_obj;
                        temp_obj = obj[j];
                        obj[j] = obj[j + 1];
                        obj[j + 1] = temp_obj;
                    }
                }
            }
            return obj;
        }
    }
}
