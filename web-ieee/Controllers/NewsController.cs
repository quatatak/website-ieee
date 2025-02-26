using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_ieee.Data;

namespace web_ieee.Controllers;

public class NewsController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var news = await dbContext.News.ToListAsync();
        return View(news);
    }
}