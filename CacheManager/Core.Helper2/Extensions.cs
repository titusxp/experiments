using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Core.Helper2
{
    public static class Extensions
    {
        public static R Map<T, R>(this T sourceObject) where T : class, new() where R : class, new()
        {
            if (sourceObject == null) return null;
            try
            {
                var returnValue = JsonConvert.SerializeObject(sourceObject);
                return JsonConvert.DeserializeObject<R>(returnValue);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool IsWeekendDay(this DateTime value)
        {
            return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
        }
        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return lValue.Month - rValue.Month + 12 * (lValue.Year - rValue.Year);
        }

        public static int YearDifference(this DateTime lValue, DateTime rValue)
        {
            return lValue.MonthDifference(rValue) / 12;
        }

        public static int MonthDays(this DateTime datetime)
        {
            int mo = datetime.Month;

            switch (mo)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (DateTime.IsLeapYear(Convert.ToInt32(datetime.Year)))
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
                default:
                    return 0;
            }

        }

        public static string ToDateString(this string dateString, string format = "dd-MMM-yyyy")
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "dd-MMM-yyyy";
            }

            var date = DateTime.Parse(dateString);
            var indexer = "{0: " + format + "}";
            var formatted = string.Format(indexer, date);
            return formatted;
        }

        public static DateTime LastDayCurrentMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.MonthDays());
        }

        public static DateTime LastDayPreviousMonth(this DateTime datetime)
        {
            return datetime.AddMonths(-1).LastDayCurrentMonth();
        }

        public static IEnumerable<DateTime> Range(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate.Date - startDate.Date).Days + 1).Select(d => startDate.AddDays(d).Date);
        }

        public static IEnumerable<DateTime> Range(this DateTime? startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).GetValueOrDefault().Days + 1).Select(d => startDate.GetValueOrDefault().AddDays(d));
        }


        public static DateTime FirstDayCurrentMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }

        public static List<string> ToList(this string singleItem)
        {
            return new List<string>() { singleItem };
        }
        public static string[] ToArray(this string singleItem)
        {
            return new[] { singleItem };
        }

        public static DateTime LastMinuteOfTheDay(this DateTime dateTime)
        {
            var date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            return date;
        }
        public static DateTime FirstMinuteOfTheDay(this DateTime dateTime)
        {
            var date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            return date;
        }

        public static string ToMonthShortName(this DateTime dateTime)
        {
            return Convert.ToDateTime(dateTime).ToString("MMM");
        }

        public static DateTime? LastMinuteOfTheDay(this DateTime? d)
        {
            if (d.HasValue == false) return d;
            var dateTime = d.Value;
            var date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            return date;
        }
        public static DateTime? FirstMinuteOfTheDay(this DateTime? d)
        {
            if (d.HasValue == false)
                return d;
            var dateTime = d.Value;
            var date = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
            return date;
        }

        public static bool HasSameMonthAndYear(this DateTime? d1, DateTime? d2)
        {
            if (!d1.HasValue || !d2.HasValue) return false;
            return d1.Value.Month == d2.Value.Month && d1.Value.Year == d2.Value.Year;
        }

        public static string ToMonthName(this DateTime dt, string langue = null)
        {
            if (langue == "01" || langue == null)
            {
                int mo = dt.Month;
                string mon = string.Empty;
                switch (mo.ToString().ToTwoChar())
                {
                    case "01":
                        mon = "JANUARY";
                        break;
                    case "02":
                        mon = "FEBRUARY";
                        break;
                    case "03":
                        mon = "MARCH";
                        break;
                    case "04":
                        mon = "APRIL";
                        break;
                    case "05":
                        mon = "MAY";
                        break;
                    case "06":
                        mon = "JUNE";
                        break;
                    case "07":
                        mon = "JULY";
                        break;
                    case "08":
                        mon = "AUGUST";
                        break;
                    case "09":
                        mon = "SEPTEMBER";
                        break;
                    case "10":
                        mon = "OCTOBER";
                        break;
                    case "11":
                        mon = "NOVEMBER";
                        break;
                    case "12":
                        mon = "DECEMBER";
                        break;
                    default:
                        return "";
                }
                return mon + " ";

            }
            else
            {
                int mo = dt.Month;
                string mon = string.Empty;
                switch (mo.ToString().ToTwoChar())
                {
                    case "01":
                        mon = "JANVIER";
                        break;
                    case "02":
                        mon = "FÉVRIER";
                        break;
                    case "03":
                        mon = "MARS";
                        break;
                    case "04":
                        mon = "AVRIL";
                        break;
                    case "05":
                        mon = "MAI";
                        break;
                    case "06":
                        mon = "JUIN";
                        break;
                    case "07":
                        mon = "JUILLET";
                        break;
                    case "08":
                        mon = "AOÛT";
                        break;
                    case "09":
                        mon = "SEPTEMBRE";
                        break;
                    case "10":
                        mon = "OCTOBRE";
                        break;
                    case "11":
                        mon = "NOVEMBRE";
                        break;
                    case "12":
                        mon = "DÉCEMBRE";
                        break;
                    default:
                        return "";
                }
                return mon + " ";
            }

        }

        public static bool IsBetween(this DateTime dt, DateTime start, DateTime end)
        {
            bool b = dt >= start && dt <= end;
            return b;
        }


        public static string ToAgeString(this DateTime dob, string languageID, DateTime? currentDate = null)
        {
            var today = currentDate ?? DateTime.Today;

            var months = today.Month - dob.Month;
            var years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return
                $"{years} {(languageID == "01" ? "year" : "an")}{(years == 1 ? "" : "s")}, {months} {(languageID == "01" ? "month(s)" : "mois")}";
        }


        public static int AgeInYears(this DateTime Bday, DateTime? Cday = null)
        {
            if (Cday == null)
            {
                Cday = DateTime.Now;
            }

            int Years;
            int Months;
            int Days;

            if (Cday.Value.Year - Bday.Year > 0 ||
                Cday.Value.Year - Bday.Year == 0 && (Bday.Month < Cday.Value.Month ||
                  Bday.Month == Cday.Value.Month && Bday.Day <= Cday.Value.Day))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Value.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Value.Month > Bday.Month)
                {
                    Years = Cday.Value.Year - Bday.Year;
                    Months = Cday.Value.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Value.Month == Bday.Month)
                {
                    if (Cday.Value.Day >= Bday.Day)
                    {
                        Years = Cday.Value.Year - Bday.Year;
                        Months = 0;
                        Days = Cday.Value.Day - Bday.Day;
                    }
                    else
                    {
                        Years = Cday.Value.Year - 1 - Bday.Year;
                        Months = 11;
                        Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Value.Day);
                    }
                }
                else
                {
                    Years = Cday.Value.Year - 1 - Bday.Year;
                    Months = Cday.Value.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }

                return Years;
            }
            else
            {
                return 0;
            }
        }

        public static int AgeInMonths2(this DateTime BirthDate, DateTime currentDate)
        {
            return (currentDate.Year - BirthDate.Year) * 12 + currentDate.Month - BirthDate.Month;
        }


        public static void RemoveRange<T>(this List<T> source, IEnumerable<T> rangeToRemove)
        {
            if (rangeToRemove == null | !rangeToRemove.Any())
                return;

            foreach (T item in rangeToRemove)
            {
                source.Remove(item);
            }


        }

        public static string ToTwoChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToThreeChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"00" + num;
                case 2:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToFourChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"000" + num;
                case 2:
                    return @"00" + num;
                case 3:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToFiveChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"0000" + num;
                case 2:
                    return @"000" + num;
                case 3:
                    return @"00" + num;
                case 4:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToSixChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"00000" + num;
                case 2:
                    return @"0000" + num;
                case 3:
                    return @"000" + num;
                case 4:
                    return @"00" + num;
                case 5:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToSevenChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"000000" + num;
                case 2:
                    return @"00000" + num;
                case 3:
                    return @"0000" + num;
                case 4:
                    return @"000" + num;
                case 5:
                    return @"00" + num;
                case 6:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToEightChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"0000000" + num;
                case 2:
                    return @"000000" + num;
                case 3:
                    return @"00000" + num;
                case 4:
                    return @"0000" + num;
                case 5:
                    return @"000" + num;
                case 6:
                    return @"00" + num;
                case 7:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToNineChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"00000000" + num;
                case 2:
                    return @"0000000" + num;
                case 3:
                    return @"000000" + num;
                case 4:
                    return @"00000" + num;
                case 5:
                    return @"0000" + num;
                case 6:
                    return @"000" + num;
                case 7:
                    return @"00" + num;
                case 8:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static string ToTenChar(this string num)
        {
            switch (num.Length)
            {
                case 1:
                    return @"000000000" + num;
                case 2:
                    return @"00000000" + num;
                case 3:
                    return @"0000000" + num;
                case 4:
                    return @"000000" + num;
                case 5:
                    return @"00000" + num;
                case 6:
                    return @"0000" + num;
                case 7:
                    return @"000" + num;
                case 8:
                    return @"00" + num;
                case 9:
                    return @"0" + num;
                default:
                    return num;
            }
        }

        public static bool IsNumericType(this Type o)
        {
            switch (Type.GetTypeCode(o))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
        public static double ToNumValue(this object obj)
        {
            double i = new double();
            try
            {
                double.TryParse(obj.ToString(), out i);
                return i;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int ToIntegerValue(this object obj)
        {
            int i = new int();
            try
            {
                int.TryParse(obj.ToString(), out i);
                return i;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the string equivalent of this enum. In double digits
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string T2D(this Enum enumValue)
        {
            var intValue = Convert.ToInt32(enumValue);
            return $"{intValue:00}";
        }

        public static int TrimDamaVersionToInt(this string version)
        {
            //var trimmed = version.TrimEnd('0').Replace(".", string.Empty);
            //var first = trimmed[2];
            //if (first == '0')
            //{
            //    trimmed = trimmed.Remove(2, 1);
            //}


            var sections = version.Split('.').Select(s => int.Parse(s)).Take(3);
            var trimmed = sections.Aggregate(string.Empty, (current, next) => $"{current:00}{next:00}").Replace(" ", string.Empty);
            int returnValue = 0;
            int.TryParse(trimmed, out returnValue);
            return returnValue;

        }

        /// <summary>
        /// Gets the string equivalent of this enum. In double digits
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static int ToInt(this Enum enumValue)
        {
            var intValue = Convert.ToInt32(enumValue);
            return intValue;
        }

        public static Color ToColor(this string colorString)
        {
            int colorInt;
            if (int.TryParse(colorString, out colorInt))
            {
                return Color.FromArgb(colorInt);
            }

            return Color.Empty;
        }
    }
}
