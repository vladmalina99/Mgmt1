using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Rooms
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public RoomDto RoomDto { get; set; } = new RoomDto();

        public Room Room { get; set; } = new Room();

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
                Response.Redirect("/Admin/Rooms/Index");
                return;
            }

            var room = context.Rooms.Find(id);
            if (room == null)
            {
                Response.Redirect("/Admin/Rooms/Index");
                return;
            }

            RoomDto.Name = room.Name;
            RoomDto.Category = room.Category;
            RoomDto.Price = room.Price;
            RoomDto.Description = room.Description;

            Room = room;
        }

        public void OnPost(int? id)
        {

            if (id == null)
            {
                Response.Redirect("/Admin/Rooms/Index");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields";
                return;
            }

            var room = context.Rooms.Find(id);
            if (room == null)
            {
                Response.Redirect("/Admin/Rooms/Index");

            }
            //update the image file if we have a new image file

            string newFileName = room.ImageFileName;
            if (RoomDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(RoomDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/rooms/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    RoomDto.ImageFile.CopyTo(stream);
                }

                //delete the old image
                string oldIamgeFullPath = environment.WebRootPath + "/rooms" + room.ImageFileName;
                System.IO.File.Delete(oldIamgeFullPath);
            }


            //update the room in the database

            room.Name = RoomDto.Name;
            room.Category = RoomDto.Category;
            room.Price = RoomDto.Price;
            room.Description = RoomDto.Description ?? "";
            room.ImageFileName = newFileName;

            context.SaveChanges();

            Room = room;
            successMessage = "Room updated successfully";

            Response.Redirect("/Admin/Rooms/Index");

        }







    }

}
