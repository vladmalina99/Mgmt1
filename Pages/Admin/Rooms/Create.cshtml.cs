using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Mgmt1.Pages.Admin.Rooms
{
    public class CreateModel : PageModel 
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public RoomDto RoomDto { get; set; } = new RoomDto();
        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        { 
            this.environment =  environment;
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
            newFileName += Path.GetExtension(RoomDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/rooms/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                RoomDto.ImageFile.CopyTo(stream);

            }

            //save the new room in the database

            Room room = new Room()
            {
                Name = RoomDto.Name,
                Category = RoomDto.Category,
                Price = RoomDto.Price,
                Description = RoomDto.Description ?? "",
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,

            };

            context.Rooms.Add(room);
            context.SaveChanges();


                //clear the form
                RoomDto.Name = "";
            RoomDto.Category = "";
            RoomDto.Price = 0;
            RoomDto.Description = "";
            RoomDto.ImageFile = null;

            ModelState.Clear();

            successMessage = "Product created successfully";

            Response.Redirect("/Admin/Rooms/Index");


        }


    }


}
