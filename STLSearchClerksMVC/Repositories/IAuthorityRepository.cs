using STLSearchClerksMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STLSearchClerksMVC.Repositories
{
    public interface IAuthorityRepository
    {
        List<Authority> GetAuthorities();
    }
}