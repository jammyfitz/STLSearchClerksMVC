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
    [TestFixture]
    public class HomeControllerShould
    {
        private HomeController _homeController;
        private IUnitOfWork _unitOfWork;
        private IDoubleBookingRepository _fakeRepo;

        [SetUp]
        public void Setup()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _fakeRepo = Substitute.For<IDoubleBookingRepository>();
            _homeController = new HomeController(_unitOfWork);
        }

        [Test]
        public void DisplayDoubleBookingsFromLastMonth()
        {
            var result = _homeController.Index();

            _unitOfWork.DoubleBookingRepository.Received().GetDoubleBookingsFromLastMonth();
        }

        [Test]
        public void SupportCreatingADoubleBooking()
        {
            var result = _homeController.CreateDoubleBooking();

            _unitOfWork.SearchClerkRepository.Received().GetSearchClerks();
            _unitOfWork.AuthorityRepository.Received().GetAuthorities();
        }
    }
}
