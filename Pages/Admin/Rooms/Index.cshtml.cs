using Mgmt1.Models;
using Mgmt1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mgmt1.Pages.Admin.Rooms
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext context;
        public List<Room> Rooms { get; set; } = new List<Room>();
        public  IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Rooms = context.Rooms.OrderByDescending(r => r.Id).ToList();
        }
    }
}
