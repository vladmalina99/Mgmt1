using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)

        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Employees/Index");
                return;

            }

            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                Response.Redirect("/Admin/Employees/Index");
                return;
            }
            string imageFullPath = environment.WebRootPath + "/employees/" + employee.ImageFileName;
            System.IO.File.Delete(imageFullPath);


            context.Employees.Remove(employee);
            context.SaveChanges();

            Response.Redirect("/Admin/Employees/Index");


        }

    }
}
