using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Employees
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Employees = context.Employees.OrderByDescending(r => r.Id).ToList();
        }
    }
}