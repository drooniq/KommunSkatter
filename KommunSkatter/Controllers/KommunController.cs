using KommunSkatter.Data;
using KommunSkatter.Models;
using Microsoft.AspNetCore.Mvc;

namespace KommunSkatter.Controllers
{
    public class KommunController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Kommun> data = await SkatteAPI.GetAPIdataAsync();
            return View(data);
        }
    }
}
