using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Rooms
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
                Response.Redirect("/Admin/Rooms/Index");
                return;

            }

            var room = context.Rooms.Find(id);
            if (room == null)
            {
                Response.Redirect("/Admin/Room/Index");
                return;
            }
            string imageFullPath = environment.WebRootPath + "/rooms/" + room.ImageFileName;
            System.IO.File.Delete(imageFullPath);


            context.Rooms.Remove(room);
            context.SaveChanges();

            Response.Redirect("/Admin/Rooms/Index");
            

        }

    }
}
