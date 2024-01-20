using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Mgmt1.Pages.Admin.Employees
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public EmployeeDto EmployeeDto { get; set; } = new EmployeeDto();
        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }

        public void OnGet()
        {

        }

        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {

            //save the image file

            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(EmployeeDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/rooms/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                EmployeeDto.ImageFile.CopyTo(stream);

            }

            //save the new room in the database

            Employee employee = new Employee()
            {
                FirstName = EmployeeDto.FirstName,
                LastName = EmployeeDto.LastName,
                Position = EmployeeDto.Position,
                PhoneNumber = EmployeeDto.PhoneNumber,
                Email = EmployeeDto.Email ?? "",
                ImageFileName = newFileName,
                HireDate = DateTime.Now,

            };

            context.Employees.Add(employee);
            context.SaveChanges();


            //clear the form
            EmployeeDto.FirstName = "";
            EmployeeDto.LastName = "";
            EmployeeDto.Position = "";
            EmployeeDto.PhoneNumber = "";
            EmployeeDto.Email = "";
            EmployeeDto.ImageFile = null;

            ModelState.Clear();

            successMessage = "Product created successfully";

            Response.Redirect("/Admin/Employees/Index");


        }


    }


}
