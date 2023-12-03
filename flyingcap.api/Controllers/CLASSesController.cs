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
    public class CLASSesController : ApiController
    {
        private elearningEntities db = new elearningEntities();

        // GET: api/CLASSes
        public List<CLASS> GetCLASS(string keyword=null,string typeclass=null)
        {
            var data = db.CLASS.ToList();
            if (keyword != null && typeclass==null)
            {
                data = db.CLASS.Where(x => x.CLASSNAME.Contains(keyword)).ToList();
            }

            if (typeclass != null && keyword == null)
            {
                data = db.CLASS.Where(x => x.TYPECLASS.Contains(typeclass)).ToList();
            }

            if(typeclass != null && keyword != null)
            {
                data = db.CLASS.Where(x => x.TYPECLASS.Contains(typeclass) && x.CLASSNAME.Contains(keyword)).ToList();
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

        private bool CLASSExists(int id)
        {
            return db.CLASS.Count(e => e.id == id) > 0;
        }
    }
}