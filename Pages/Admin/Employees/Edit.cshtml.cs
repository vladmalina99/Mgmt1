using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Employees
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public EmployeeDto EmployeeDto { get; set; } = new EmployeeDto();

        public Employee Employee { get; set; } = new Employee();

        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context)
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

            EmployeeDto.FirstName = employee.FirstName;
            EmployeeDto.LastName = employee.LastName;
            EmployeeDto.Position = employee.Position;
            EmployeeDto.PhoneNumber = employee.PhoneNumber;
            EmployeeDto.Email = employee.Email;

            Employee = employee;
        }

        public void OnPost(int? id)
        {

            if (id == null)
            {
                Response.Redirect("/Admin/Employees/Index");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                Response.Redirect("/Admin/Employees/Index");

            }
            //update the image file if we have a new image file

            string newFileName = employee.ImageFileName;
            if (EmployeeDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(EmployeeDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/employees/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    EmployeeDto.ImageFile.CopyTo(stream);
                }

                //delete the old image
                string oldIamgeFullPath = environment.WebRootPath + "/employees" + employee.ImageFileName;
                System.IO.File.Delete(oldIamgeFullPath);
            }


            //update the employee in the database

            employee.FirstName = EmployeeDto.FirstName;
            employee.LastName = EmployeeDto.LastName;
            employee.Position = EmployeeDto.Position;
            employee.PhoneNumber = EmployeeDto.PhoneNumber;
            employee.Email = EmployeeDto.Email ?? "";
            employee.ImageFileName = newFileName;

            context.SaveChanges();

            Employee = employee;
            successMessage = "Employee updated successfully";

            Response.Redirect("/Admin/Employees/Index");

        }







    }

}
