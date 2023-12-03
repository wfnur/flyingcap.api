using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using flyingcap.api.Models;

namespace flyingcap.api.Controllers
{
    public class PARTNERsController : ApiController
    {
        private elearningEntities db = new elearningEntities();

        // GET: api/PARTNERs
        public List<PARTNER> GetPARTNER(string keyword = null)
        {
            var data= db.PARTNER.ToList();

            if (keyword != null)
            {
                data = db.PARTNER.Where(x => x.CLASSNAME.Contains(keyword)).ToList();
            }

            return data;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PARTNERExists(int id)
        {
            return db.PARTNER.Count(e => e.ID == id) > 0;
        }
    }
}