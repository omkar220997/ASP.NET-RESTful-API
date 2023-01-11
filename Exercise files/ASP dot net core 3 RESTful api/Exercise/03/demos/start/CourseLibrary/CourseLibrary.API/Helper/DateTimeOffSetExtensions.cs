using Microsoft.VisualBasic;
using System;

namespace CourseLibrary.API.Helper
{
    public static class DateTimeOffSetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffSet)
        {
            var currentDate=DateTime.UtcNow;
            int age=currentDate.Year-dateTimeOffSet.Year;
            if (currentDate < dateTimeOffSet.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
