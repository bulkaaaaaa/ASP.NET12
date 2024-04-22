using Microsoft.AspNetCore.Mvc;
using WebApplication12.Data;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyContext _context;

        public CompanyController(CompanyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Company> companies = _context.Companies.ToList();
            return View(companies);
        }
    }
}
