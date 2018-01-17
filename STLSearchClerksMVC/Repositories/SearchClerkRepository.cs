using STLSearchClerksMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STLSearchClerksMVC.Repositories
{
    public class SearchClerkRepository : ISearchClerkRepository
    {
        private STLContext _stlContext;

        public SearchClerkRepository()
        {
            _stlContext = new STLContext();
        }

        public SearchClerkRepository(STLContext stlContext)
        {
            _stlContext = stlContext;
        }

        public List<SearchClerk> GetSearchClerks()
        {
            return _stlContext.SearchClerks.ToList();
        }
    }
}