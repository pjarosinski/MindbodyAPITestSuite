using System;
using System.Collections.Generic;
using System.Linq;
using MindbodySoapAPI.SaleService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Appointment = MindbodySoapAPI.AppointmentService.Appointment;

namespace MindbodySoapAPI.APITests.Utils.ParsingTools
{
    public class Argument
    {

        public string ClassPath { get; set; }


        public string FieldPath { get; set; }


        public string MemberName { get; set; }


        public string SoapNodeName { get; set; }


        public string Value { get; set; }


        public bool IsRequired { get; set; }


        public JArray RequiredMembers { get; set; }

        public static Argument GetArgument(List<Argument> args, string soapNodeName)
        {
            var retVal = args.Find(arg => arg.SoapNodeName.Equals(soapNodeName));
            if (retVal != null)
            {
                return retVal;
            }
            return new Argument();
        }

        public DateTime ConvertToDateTime()
        {
            if (String.IsNullOrEmpty(Value))
            {
                return DateTime.Today;
            }
            return DateTime.Parse(Value);
        }

        public DateTime[] ConvertToDateTimeArray(DateTime[] defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return (from string s in Value.Split(',')
                    select Convert.ToDateTime(s.Trim())
                   ).ToArray<DateTime>();
        }

        public long[] ConvertToLongArray(long[] defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return (from string s in Value.Split(',')
                    select Convert.ToInt64(s.Trim())
                   ).ToArray<long>();
        }

        public int[] ConvertToIntArray(int[] defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }

            return (from string s in Value.Split(',')
                    select Convert.ToInt32(s.Trim())
                   ).ToArray<int>();
        }

        public byte[] ConvertToByteArray(byte[] defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }

            return (from string s in Value.Split(',')
                    select Convert.ToByte(s.Trim())
                   ).ToArray<byte>();
        }

        public string[] ConvertToStringArray(string[] defaultVal = null)
        {
            if (Value == null)
            {
                return defaultVal;
            }
            return Value.Split(',');
        }

        internal string ConvertToString(string defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return Value;
        }

        public int ConvertToInt(int defaultVal = 0)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return int.Parse(Value);
        }

        public int? ConvertToIntNullable(int? defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return int.Parse(Value);
        }

        public long ConvertToLong(long defaultVal = 0)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return long.Parse(Value);
        }

        public long? ConvertToLongNullable(long? defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return long.Parse(Value);
        }

        public bool ConvertToBool(bool defaultVal = false)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return bool.Parse(Value);
        }

        public bool? ConvertToBoolNullable(bool? defaultVal = null)
        {
            if (String.IsNullOrEmpty(Value))
            {
                return defaultVal;
            }
            return bool.Parse(Value);
        }

        public Appointment[] ConvertToAppointmentArray()
        {
            if (Value == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Appointment[]>(Value);
        }

        public T[] ConvertToVisitsArray<T>()
        {
            if (Value == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T[]>(Value);
        }

        public dynamic ConvertToSpecifiedDynamicType()
        {
            if (Value == null)
            {
                return null;
            }
 
            return JObject.Parse(Value);
        }

        public Service[] ConvertToServiceArray()
        {
            if (Value == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Service[]>(Value);
        }

        public Product[] ConvertToProductArray()
        {
            if (Value == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Product[]>(Value);
        }

        public CreditCardInfo[] ConvertToCreditCardInfoArray()
        {
            if (Value == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<CreditCardInfo[]>(Value);
        }

        public CartItem[] ConvertToCartItemArray(int itemId)
        {
            if (Value == null)
            {
                return null;
            }
            CartItem[] cItem = JsonConvert.DeserializeObject<CartItem[]>(Value);

            foreach (CartItem cartItem in cItem)
            {
                var service = new Service();
                service.ID = itemId.ToString();
                cartItem.Item = service;
            }

            return cItem;
        }

        /*public ClassService.Visit[] ConvertToVisitArray()
        {
            if (Value == null) { return null; }
            return JsonConvert.DeserializeObject<ClassService.Visit[]>(Value);
        }

        internal StaffService.Staff[] ConvertToStaffArray()
        {
            if (Value == null) { return null; }
            return JsonConvert.DeserializeObject<StaffService.Staff[]>(Value);
        }

        public StaffService.StaffCredentials ConvertToStaffCredentials()
        {
            if (Value == null) { return null; }
            return JsonConvert.DeserializeObject<StaffService.StaffCredentials>(Value);
        }

        public StaffFilter[] ConvertToStaffFilterArray()
        {
            if (Value == null) { return null; }
            var filters = new List<StaffFilter>();
            foreach (string str in Value.Split(','))
            {
                if (str.ToLower().Contains("appointmentinstructor")) { filters.Add(StaffFilter.AppointmentInstructor); }
                if (str.ToLower().Contains("staffviewable")) { filters.Add(StaffFilter.StaffViewable); }
                if (str.ToLower().Contains("classinstructor")) { filters.Add(StaffFilter.ClassInstructor); }
                if (str.ToLower().Contains("female")) { filters.Add(StaffFilter.Female); }
                if (str.ToLower().Contains("male")) { filters.Add(StaffFilter.Male); }
            }
            return filters.ToArray();
        }

        public AppointmentService.DayOfWeek[] ConvertToDayOfWeekArray()
        {
            if(Value == null) { return null; }

            var days = new List<DayOfWeek>();
            foreach(string str in Value.Split(','))
            {
                if(str.ToLower().Equals("monday")) { days.Add(DayOfWeek.Monday); }
                if(str.ToLower().Equals("tuesday")) { days.Add(DayOfWeek.Tuesday); }
                if(str.ToLower().Equals("wednesday")) { days.Add(DayOfWeek.Wednesday); }
                if(str.ToLower().Equals("thursday")) { days.Add(DayOfWeek.Thursday); }
                if(str.ToLower().Equals("friday")) { days.Add(DayOfWeek.Friday); }
                if(str.ToLower().Equals("saturday")) { days.Add(DayOfWeek.Saturday); }
                if(str.ToLower().Equals("sunday")) { days.Add(DayOfWeek.Sunday); }
            }
            return days.ToArray();
        }

        public ClientService.ContactLog[] ConvertToContactLogArray()
        {
            if (Value == null) { return null; }
            return JsonConvert.DeserializeObject<ClientService.ContactLog[]>(Value);
        }

        public AvailabilityDisplay ConvertToAvailabilityDisplay(AvailabilityDisplay defaultVal = AvailabilityDisplay.Show)
        {
            if(Value == null) { return defaultVal; }
            if(Value.ToLower().Equals("show")) { return AvailabilityDisplay.Show; }
            if(Value.ToLower().Equals("mask")) { return AvailabilityDisplay.Mask; }
            if(Value.ToLower().Equals("hide")) { return AvailabilityDisplay.Hide; }
            return defaultVal;
        }

        public AppointmentService.ScheduleType ConvertToAppointmentScheduleType(AppointmentService.ScheduleType defaultVal = AppointmentService.ScheduleType.All)
        {
            if (Value == null) { return defaultVal; }
            if (Value.ToLower().Equals("all")) { return AppointmentService.ScheduleType.All; }
            if (Value.ToLower().Equals("dropin")) { return AppointmentService.ScheduleType.DropIn; }
            if (Value.ToLower().Equals("appointment")) { return AppointmentService.ScheduleType.Appointment; }
            if (Value.ToLower().Equals("enrollment")) { return AppointmentService.ScheduleType.Enrollment; }
            if (Value.ToLower().Equals("resource")) { return AppointmentService.ScheduleType.Resource; }
            if (Value.ToLower().Equals("arrival")) { return AppointmentService.ScheduleType.Arrival; }
            if (Value.ToLower().Equals("media")) { return AppointmentService.ScheduleType.Media; }
            return defaultVal;
        }

        public SiteService.ScheduleType ConvertToSiteScheduleType(SiteService.ScheduleType defaultVal = SiteService.ScheduleType.All)
        {
            if (Value == null) { return defaultVal; }
            if (Value.ToLower().Equals("all")) { return SiteService.ScheduleType.All; }
            if (Value.ToLower().Equals("dropin")) { return SiteService.ScheduleType.DropIn; }
            if (Value.ToLower().Equals("appointment")) { return SiteService.ScheduleType.Appointment; }
            if (Value.ToLower().Equals("enrollment")) { return SiteService.ScheduleType.Enrollment; }
            if (Value.ToLower().Equals("resource")) { return SiteService.ScheduleType.Resource; }
            if (Value.ToLower().Equals("arrival")) { return SiteService.ScheduleType.Arrival; }
            if (Value.ToLower().Equals("media")) { return SiteService.ScheduleType.Media; }
            return defaultVal;
        }
    }*/
    }
}
