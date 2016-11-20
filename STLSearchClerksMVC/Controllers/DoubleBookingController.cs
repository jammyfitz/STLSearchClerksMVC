using STLSearchClerksMVC.Models;
using STLSearchClerksMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STLSearchClerksMVC.Controllers
{
    public class DoubleBookingController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DoubleBookingController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public DoubleBookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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

            return View(viewModel);
        }
    }
}