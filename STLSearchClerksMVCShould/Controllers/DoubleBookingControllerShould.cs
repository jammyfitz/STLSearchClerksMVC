using NSubstitute;
using NUnit.Framework;
using STLSearchClerksMVC.Controllers;
using STLSearchClerksMVC.Models;
using STLSearchClerksMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLSearchClerksMVCShould.Controllers
{
    public class DoubleBookingControllerShould
    {
        private DoubleBookingController _doubleBookingController;
        private IUnitOfWork _unitOfWork;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _doubleBookingController = new DoubleBookingController(_unitOfWork);
        }

        [Test]
        public void SupportInsertingADoubleBooking()
        {
            var doubleBookingToInsert = GetTestDoubleBooking();
            var viewModel = GetTestDoubleBookingViewModel(doubleBookingToInsert);

            var result = _doubleBookingController.InsertDoubleBooking(viewModel);

            _unitOfWork.DoubleBookingRepository.ReceivedWithAnyArgs().Add(null);
            _unitOfWork.DoubleBookingRepository.Received().Save();
        }

        private static DoubleBooking GetTestDoubleBooking()
        {
            return new DoubleBooking()
            {
                AuthorityId = 2,
                SearchClerkId = 3,
                BookingDate = new DateTime(2001, 12, 12)
            };
        }

        private static DoubleBookingViewModel GetTestDoubleBookingViewModel(DoubleBooking doubleBooking)
        {
            return new DoubleBookingViewModel()
            {
                AuthorityId = doubleBooking.AuthorityId,
                SearchClerkId = doubleBooking.SearchClerkId,
                BookingDate = doubleBooking.BookingDate
            };
        }
    }
}
