using STLSearchClerksMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STLSearchClerksMVC.Repositories
{
    public class AuthorityRepository : IAuthorityRepository
    {
        private STLContext _stlContext;

        public AuthorityRepository()
        {
            _stlContext = new STLContext();
        }

        public AuthorityRepository(STLContext stlContext)
        {
            _stlContext = stlContext;
        }

        public IList<Authority> GetAuthorities()
        {
            return _stlContext.Authorities.ToList();
        }
    }
}