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
    }
}
