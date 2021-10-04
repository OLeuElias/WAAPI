using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAAPI.Filter;

namespace WAAPI.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
