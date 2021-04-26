using System;

namespace Common.Shared.Extentions
{
    public static class DateTimeExtention
    {
        public static bool IsAdult(this DateTime birthDay)
        {
            return birthDay.CalculateYears() >= 18;
        }

        public static int CalculateYears(this DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;

            if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
            {
                years--;
            }

            return years;
        }

    }
}
