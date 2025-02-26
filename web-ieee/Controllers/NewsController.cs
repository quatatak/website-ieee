using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_ieee.Data;
using web_ieee.Models;
using web_ieee.ViewModels;

namespace web_ieee.Controllers;

public class NewsController(ApplicationDbContext dbContext, BlobServiceClient blobService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var news = await dbContext.News.ToListAsync();
        return View(news);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }
        
        var newsEntity = await dbContext.News.FirstOrDefaultAsync(e => e.Id == id);
        if (newsEntity is null)
        {
            return NotFound();
        }

        return View(newsEntity);
    }

    [HttpPost]
    [ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePost([Bind("Title", "Description", "PhotoFile")] NewsViewModel newsViewModel)
    {
        if (!ModelState.IsValid)
        {
            return Problem();
        }
        var fileToUpload = newsViewModel.PhotoFile;
        var containerClient = blobService.GetBlobContainerClient("images");
        var blobClient = containerClient.GetBlobClient(fileToUpload.FileName);

        await using (var stream = fileToUpload.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, true);
        }

        await dbContext.News.AddAsync(new News()
        {
            Title = newsViewModel.Title,
            Description = newsViewModel.Description,
            PhotoLink = blobClient.Uri.AbsoluteUri,
        });
        await dbContext.SaveChangesAsync();

        var home = RedirectToAction("Index", "News");
        return home;
    }
}