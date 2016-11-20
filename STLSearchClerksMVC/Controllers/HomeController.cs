using STLSearchClerksMVC.Models;
using STLSearchClerksMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STLSearchClerksMVC.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            ViewBag.DoubleBookings = GetDoubleBookingsFromLastMonth();

            return View();
        }

        private IList<DoubleBooking> GetDoubleBookingsFromLastMonth()
        {
            return _unitOfWork.DoubleBookingRepository.GetDoubleBookingsFromLastMonth();
        }

        public ActionResult CreateDoubleBooking()
        {
            var doubleBookingViewModel = new DoubleBookingViewModel()
            {
                Authorities = GetAuthorities(),
                SearchClerks = GetSearchClerks(),
                BookingDate = DateTime.Now
            };

            return View(doubleBookingViewModel);
        }

        private IList<SearchClerk> GetSearchClerks()
        {
            return _unitOfWork.SearchClerkRepository.GetSearchClerks();
        }

        private IList<Authority> GetAuthorities()
        {
            return _unitOfWork.AuthorityRepository.GetAuthorities();
        }
    }
}