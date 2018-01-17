using STLSearchClerksMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLSearchClerksMVC.Repositories
{
    public interface ISearchClerkRepository
    {
        List<SearchClerk> GetSearchClerks();
    }
}
