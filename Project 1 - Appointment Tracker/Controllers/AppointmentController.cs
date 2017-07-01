/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name	    : Brandon Jones
// Department Name	: Computer and Information Sciences 
// File Name		: Appointment.cs
// Purpose          : Methods for displaying views related to Appointments
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
    public class AppointmentController : Controller
    {
        //Dictionary to contain appointment information
        private static IDictionary<string, Appointment> _appointments = null;

        /// <summary>
        /// GET function to retrieve Create view.
        /// </summary>
        /// <returns>/appointment/create view</returns>
        public ActionResult Create ()
        {
            return View();
        }

        /// <summary>
        /// Function to retrieve view displaying details of given Appointment
        /// </summary>
        /// <param name="id">Id of Appointment to return details of</param>
        /// <returns>/appointment/detail view of given Appointment</returns>
        public ActionResult Details (string id)
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
            if (!_appointments.ContainsKey(id))
            {
                return HttpNotFound("Sorry, but cannot find id:" + id);
            }
            return View(_appointments[id]);
        }

        /// <summary>
        /// POST function to create an instance of appointment object and store it in Session variable
        /// </summary>
        /// <param name="appointment">Appointment object to be created and added to Session variable _appointments.</param>
        /// <returns>Redirect to /home/index view</returns>
        [HttpPost]
        public ActionResult Create (Appointment appointment)
        {
            if (Session["appointments"] != null)
            {
                _appointments = (Dictionary<string, Appointment>)Session["appointments"];
            }
            if (_appointments == null)
            {
                _appointments = new Dictionary<string, Appointment>();
            }
            if (_appointments.ContainsKey(appointment.Id))
            {
                ViewBag.Message = appointment.Id + " already exists!";
                return View();
            }
            _appointments[appointment.Id] = appointment;
            Session["appointments"] = _appointments;
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// GET function to retrieve edit view populated with details of given Appointment object
        /// </summary>
        /// <param name="id">Id of Appointment to be edited</param>
        /// <returns>/appointment/edit view of given Appointment</returns>
        public ActionResult Edit (string id)
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
            if (!_appointments.ContainsKey(id))
            {
                return HttpNotFound("Sorry, but cannot find id:" + id);
            }
            return View(_appointments[id]);
        }

        /// <summary>
        /// POST function to apply changes made to Appointment object and save in Session variable _appointments
        /// </summary>
        /// <param name="appointment">Edited Appointment object to be stored in Session variable _appointments</param>
        /// <returns>Redirect to /home/index view</returns>
        [HttpPost]
        public ActionResult Edit (Appointment appointment)
        {
            if (Session["appointments"] != null)
            {
                _appointments = (Dictionary<string, Appointment>)Session["appointments"];
            }
            if (!_appointments.ContainsKey(appointment.Id))
            {
                return HttpNotFound("Sorry, but cannot find id:" + appointment.Id);
            }
            _appointments[appointment.Id].Description = appointment.Description;
            _appointments[appointment.Id].Location = appointment.Location;
            _appointments[appointment.Id].Date = appointment.Date;
            _appointments[appointment.Id].Time = appointment.Time;
            Session["appointments"] = _appointments;
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// GET function to retrieve delete confirmation view of given Appointment object
        /// </summary>
        /// <param name="id">Id of Appointment to be deleted</param>
        /// <returns>/appointment/delete view of given Appointment</returns>
        public ActionResult Delete (string id = null)
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
            if (!_appointments.ContainsKey(id))
            {
                return HttpNotFound("Sorry, but cannot find id:" + id);
            }
            return View(_appointments[id]);
        }

        /// <summary>
        /// POST function to delete Appointment object from Session variable _appointments
        /// </summary>
        /// <param name="id">Id of Appointment to be deleted</param>
        /// <returns>Redirect to /home/index view</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed (string id)
        {
            if (Session["appointments"] != null)
            {
                _appointments = (Dictionary<string, Appointment>)Session["appointments"];
            }
            if (!_appointments.ContainsKey(id))
            {
                return HttpNotFound("Sorry, but cannot find id:" + id);
            }
            _appointments.Remove(id);
            Session["appointments"] = _appointments;
            return RedirectToAction("Index", "Home");
        }
    }
}