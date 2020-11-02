using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpServerApp
{
    /// <summary>
    /// Przykładowa klasa do obsługi wiadomości otrzymywanych przez serwer.
    /// </summary>
    public class MessageTimeParser
    {
        /// <summary>
        /// Metoda zwraca obecny czas w zależności od otrzymanej wiadomości.
        /// </summary>
        /// <param name="data">Tablica bajtów zawierająca wiadomość</param>
        /// <param name="size">Ilość danych w tablicy</param>
        /// <returns>Tablica bajtów będąca odpowiedzią lub null.</returns>
        /// <example>
        /// <list type="table">
        ///     <item>
        ///         <term>exit</term>
        ///         <description>Kończy działanie funkcji</description>
        ///     </item>
        ///     <item>
        ///         <term>time</term>
        ///         <description>Zwraca obecny czas</description>
        ///     </item>
        ///     <item>
        ///         <term>date</term>
        ///         <description>Zwraca obecną datę</description>
        ///     </item>
        ///     <item>
        ///         <term>day</term>
        ///         <description>Zwraca obecny dzień</description>
        ///     </item>
        ///     <item>
        ///         <term>dayname</term>
        ///         <description>Zwraca nazwę obecnego dnia</description>
        ///     </item>
        ///     <item>
        ///         <term>month</term>
        ///         <description>Zwraca obecny miesiąc</description>
        ///     </item>
        ///     <item>
        ///         <term>year</term>
        ///         <description>Zwraca obecny rok</description>
        ///     </item>
        ///     <item>
        ///         <term>hour</term>
        ///         <description>Zwraca obecną godzinę</description>
        ///     </item>
        ///     <item>
        ///         <term>minute</term>
        ///         <description>Zwraca obecną minutę</description>
        ///     </item>
        ///     <item>
        ///         <term>second</term>
        ///         <description>Zwraca obecną sekundę</description>
        ///     </item>
        /// </list>
        /// </example>
        public static byte[] messageParser(byte[] data, int size)
        {
            string message = Encoding.ASCII.GetString(data.Take(size).ToArray()).Trim().ToLower();
            string answer = "Nieznana komenda\n";
            switch (message)
            {
                case "exit": { answer = ""; break; }
                case "time": {answer = DateTime.Now.ToLongTimeString(); break; }
                case "date": { answer = DateTime.Now.ToShortDateString(); break; }

                case "day": { answer = DateTime.Now.Day.ToString(); break; }
                case "dayname": {answer = DateTime.Now.DayOfWeek.ToString(); break; }
                case "month": { answer = DateTime.Now.Month.ToString(); break; }
                case "year": {answer = DateTime.Now.Year.ToString(); break; }

                case "hour": { answer = DateTime.Now.Hour.ToString(); break; }
                case "minute": {answer = DateTime.Now.Minute.ToString(); break; }
                case "second": {answer = DateTime.Now.Second.ToString(); break; }
            }
            return (answer.Length > 0) ? Encoding.ASCII.GetBytes(answer) : null;
        }
    }
}
