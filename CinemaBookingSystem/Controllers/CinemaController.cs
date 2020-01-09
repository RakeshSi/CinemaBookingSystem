using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.DAL.Models;
using Cinema.Repositories.Repository;
using CinemaBookingSystem.Helper;
using CinemaBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CinemaBookingSystem.Controllers
{
    public class CinemaController : Controller
    {
        private IGenericRepository<TblBookingSeat> repository;
        private IGenericRepository<TblCustomer> repositoryCustomer;
        private IGenericRepository<TblErrorLog> repositoryErrorLog;

        CinemaBookingDBContext cinemaBookingDBContext = new CinemaBookingDBContext();
        public CinemaController(IGenericRepository<TblBookingSeat> repository, IGenericRepository<TblCustomer> repositoryCustomer, IGenericRepository<TblErrorLog> repositoryErrorLog)
        {
            this.repository = repository;
            this.repositoryCustomer = repositoryCustomer;
            this.repositoryErrorLog = repositoryErrorLog;
        }

        /*This Method For Index Page, For Showing The All Seats Are Available Or Not*/
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var model = repository.GetAll();
                return View(model);
            }
            catch (Exception ex)
            {

                LogException(ex, "Index");
                return RedirectToAction("Index", "Cinema");
            }
        }

        /* This Method For Book The Ticket Based On Selected Seats*/
        [HttpPost]
        public JsonResult BookTicket([FromBody]CustomerModel customer)
        {
            try
            {
                CommonMail common = new CommonMail();
                List<TblCustomer> tblCustomers = new List<TblCustomer>();
                string SeatNumber = "";
                for (int i = 0; i < customer.SeatNumber.Count; i++)
                {
                    SeatNumber += Convert.ToString(customer.SeatNumber[i]) + ',';

                }

                var customerName = new SqlParameter("CustomerName", customer.UserName);
                var Email = new SqlParameter("Email", customer.Email);
                var SeatNumbers = new SqlParameter("SeatNumbers", SeatNumber);

                var CustomerLst = cinemaBookingDBContext.TblCustomer
                     .FromSqlRaw("EXECUTE dbo.SP_BookSheet @customerName,@Email,@SeatNumbers", customerName, Email, SeatNumbers)
                     .ToList();

                if (CustomerLst.Count!=0)
                {
                    string MsgBody = "";
                    MsgBody += "Dear " + customer.UserName;
                    MsgBody += "<br/>";
                    MsgBody += "Greetings!!";
                    MsgBody += "<br/>";
                    MsgBody += "Thank you for choosing our Booking Cinema System. Your Ticket Has Been Booked.";
                    MsgBody += "<br/><table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr><th>Seat Number</th><th>Secret Key</th></tr>";

                    for (int i = 0; i < CustomerLst.Count; i++)
                    {
                        MsgBody += "<tr><td>" + CustomerLst[i].SeatNumber + "</td><td>" + CustomerLst[i].SecretKey + "</td><tr>";
                    }
                    MsgBody += "</table><br/>";
                    MsgBody += "Thanks<br/>Cinema Booking System";

                    common.SendMail(customer.Email, MsgBody, "Confirmation Ticket Booking");
                    return Json(1);

                }
                else
                {
                    return Json(0);
                }

            }
            catch (Exception ex)
            {
                LogException(ex, "BookTicket");
                return Json(0);
            }

        }

        /*This Method For Check the Secret Code Is Valid Or Not*/
        [HttpPost]
        public JsonResult CheckSecretCode(string SecretCode, int TicketNumber)
        {

            try
            {
                var TicketInformtion = repository.GetById(TicketNumber);
                Boolean SecretMatch = false;

                if (TicketInformtion.CustomerId != null && TicketInformtion.BookingStatus == true)
                {
                    var CustomerTicketInfo = repositoryCustomer.GetById(TicketInformtion.CustomerId);
                    SecretMatch = CustomerTicketInfo.SecretKey == SecretCode ? true : false;
                }

                return Json(SecretMatch);

            }
            catch (Exception ex)
            {
                LogException(ex, "CheckSecretCode");
                return Json(false);
            }
        }

        /*This Method For UnBook The Selected SeatNumber*/
        [HttpPost]
        public JsonResult UnBookTicket(int SeatNumber)
        {
            try
            {
                var TicketStatus = repository.GetById(SeatNumber); string UserMail = ""; CommonMail common = new CommonMail(); string UserName = ""; string MsgBody = "";

                if (TicketStatus != null && TicketStatus.BookingStatus == true)
                {
                    var CustomerInform = repositoryCustomer.GetById(TicketStatus.CustomerId);
                    UserMail = CustomerInform.Email;
                    UserName = CustomerInform.CustomerName;
                    repositoryCustomer.Delete(TicketStatus.CustomerId);
                    repositoryCustomer.Save();

                    TicketStatus.BookingStatus = false;
                    TicketStatus.CustomerId = 0;

                    repository.Update(TicketStatus);
                    repository.Save();
                    MsgBody += "Dear " + UserName;
                    MsgBody += "<br/>";
                    MsgBody += "Greetings!!"; MsgBody += "<br/><br/>";

                    MsgBody += "Your Ticket (Seat Number) " + SeatNumber + "  Has Been Cancelled."; MsgBody += "<br/><br/>";
                    MsgBody += "Thanks <br/>";
                    MsgBody += "Cinema Booking System";
                    common.SendMail(UserMail, MsgBody, "Cancelled Ticket Update");

                }
                return Json(1);

            }
            catch (Exception ex)
            {
                LogException(ex, "UnBookTicket");
                return Json(0);

            }
        }

        //Method for handler an exception 
        public string getExDetails(Exception ex)
        {
            Exception e = ex;
            StringBuilder s = new StringBuilder();
            while (e != null)
            {
                s.AppendLine("Exception type: " + e.GetType().FullName);
                s.AppendLine("Message       : " + e.Message);
                s.AppendLine("Stacktrace:");
                s.AppendLine(e.StackTrace);
                s.AppendLine();
                e = e.InnerException;
            }
            return s.ToString();
        }

        //Method for log an exception
        private ActionResult LogException(Exception ex, string Method)
        {
            TblErrorLog errorLogs = new TblErrorLog();
            errorLogs.CreatedDate = DateTime.Now;
            errorLogs.Controller = "Cinema";
            errorLogs.Method = Method;
            errorLogs.Message = getExDetails(ex);
            repositoryErrorLog.Insert(errorLogs);
            repositoryErrorLog.Save();
            return View();
        }

    }

}