using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetApplicants.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace GetApplicants.Controllers
{
    [Route("api/GetApplicants")]
    public class GetApplicantsController : Controller
    {
        private DatabaseContext _context;

        public GetApplicantsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET api/GetApplicants Service
        [HttpGet]
        public string Get()
        {
            string strApplicants = string.Empty;
            using (_context)
            {
                var applicants = _context.Applicants.ToList();
                JsonSerializer serializer = new JsonSerializer();
                var json = JsonConvert.SerializeObject(applicants);
                strApplicants = json;
            }

            return strApplicants;
        }

    }
}
