/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: Appointment.cs
// Purpose          : To store information relating to personal appointments
// Author			: Brandon Jones, E-Mail: zbej4@etsu.edu
// Create Date		: Friday, September 16, 2016
//
//-----------------------------------------------------------------------------------
//
// Modified Date	: Tuesday, September 20, 2016
// Modified By		: Brandon Jones
//
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1___Appointment_Tracker.Models
{
    public class Appointment
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan TimeRemaining {
            get
            {
                //Append Time to Date to get full DateTime of appointment and subtract current time
                DateTime schedule = Date.Date.Add(Time.TimeOfDay);
                return schedule.Subtract(DateTime.Now);
            }
        }

        
    }
}