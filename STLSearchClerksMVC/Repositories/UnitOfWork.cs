using STLSearchClerksMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STLSearchClerksMVC.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private STLContext context = new STLContext();
        private IAuthorityRepository _authorityRepository;
        private ISearchClerkRepository _searchClerkRepository;
        private IDoubleBookingRepository _doubleBookingRepository;

        public IAuthorityRepository AuthorityRepository
        {
            get
            {
                if (_authorityRepository == null)
                {
                    _authorityRepository = new AuthorityRepository(context);
                }
                return _authorityRepository;
            }
        }

        public ISearchClerkRepository SearchClerkRepository
        {
            get
            {
                if (_searchClerkRepository == null)
                {
                    _searchClerkRepository = new SearchClerkRepository(context);
                }
                return _searchClerkRepository;
            }
        }

        public IDoubleBookingRepository DoubleBookingRepository
        {
            get
            {
                if (_doubleBookingRepository == null)
                {
                    _doubleBookingRepository = new DoubleBookingRepository(context);
                }
                return _doubleBookingRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}