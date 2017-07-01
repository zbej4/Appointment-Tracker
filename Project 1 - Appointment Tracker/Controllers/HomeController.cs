/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: HomeController.cs
// Purpose          : Methods for displaying views related to Home
// Author			: Brandon Jones, E-Mail: zbej4@etsu.edu
// Create Date		: Friday, September 16, 2016
//
//-----------------------------------------------------------------------------------
//
// Modified Date	: Tuesday, September 20, 2016
// Modified By		: Brandon Jones
//
/////////////////////////////////////////////////////////////////////////////////////

using Project_1___Appointment_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1___Appointment_Tracker.Controllers
{
    public class HomeController : Controller
    {
        //Dictionary to contain appointment information
        private static IDictionary<string, Appointment> _appointments = null;

        /// <summary>
        /// Function to retrieve home page view
        /// </summary>
        /// <returns>Index view listing appointments</returns>
        public ActionResult Index ()
        {
            if (Session["appointments"] != null)
            {
                _appointments = (Dictionary<string, Appointment>)Session["appointments"];
            }
            else
            {
                _appointments = new Dictionary<string, Appointment>();
                Session["appointments"] = _appointments;
            }
            return View(_appointments);
        }


    }
}