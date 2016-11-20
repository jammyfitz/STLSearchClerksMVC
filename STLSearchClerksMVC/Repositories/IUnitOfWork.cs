using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLSearchClerksMVC.Repositories
{
    public interface IUnitOfWork
    {
        IDoubleBookingRepository DoubleBookingRepository { get; }
        IAuthorityRepository AuthorityRepository { get; }
        ISearchClerkRepository SearchClerkRepository { get; }
        void Save();
    }
}
