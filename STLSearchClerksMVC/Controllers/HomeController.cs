using STLSearchClerksMVC.Models;
using STLSearchClerksMVC.Repositories;
using System;
using System.Collections.Generic;
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

        public ActionResult InsertDoubleBooking()
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return View();
        }

        [HttpPost]
        public ActionResult InsertDoubleBooking(DoubleBookingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var doubleBooking = new DoubleBooking
                {
                    AuthorityId = viewModel.AuthorityId,
                    SearchClerkId = viewModel.SearchClerkId,
                    BookingDate = viewModel.BookingDate
                };

                _unitOfWork.DoubleBookingRepository.Add(doubleBooking);
                _unitOfWork.DoubleBookingRepository.Save();

                return RedirectToAction("Index", "Home");
            }

            viewModel.Authorities = GetAuthorities();
            viewModel.SearchClerks = GetSearchClerks();

            return View("~/Views/Home/CreateDoubleBooking.cshtml", viewModel);
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

        private void ValidateDoubleBookingViewModel(DoubleBookingViewModel viewModel)
        {
            if (viewModel.AuthorityId == 0)
            {
                ModelState.AddModelError("AuthorityId", "Please select an authority");
            }

            if (string.IsNullOrEmpty(viewModel.BookingDate.ToString()))
            {
                ModelState.AddModelError("BookingDate", "Please select a Booking Date");
            }

            if (viewModel.SearchClerkId == 0)
            {
                ModelState.AddModelError("SearchClerkId", "Please select a Search Clerk");
            }
        }

        private IList<DoubleBooking> GetDoubleBookingsFromLastMonth()
        {
            return _unitOfWork.DoubleBookingRepository.GetDoubleBookingsFromLastMonth();
        }

        private List<SearchClerk> GetSearchClerks()
        {
            return _unitOfWork.SearchClerkRepository.GetSearchClerks();
        }

        private List<Authority> GetAuthorities()
        {
            return _unitOfWork.AuthorityRepository.GetAuthorities();
        }
    }
}