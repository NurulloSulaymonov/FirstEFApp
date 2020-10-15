using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Data.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{

    public class PostsController : Controller
    {
        private readonly PracticeDbContext _context;

        public PostsController(PracticeDbContext context) // 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var posts = _context.Posts.Include(x=>x.Author).Select(x=>
            new PostsListViewModel() { 
             Author = x.Author.FullName,
             Content = x.Content,
             CreatedAt = x.CreatedAt,
             Status = x.Status.ToString(),
             Id = x.Id
            }).ToList();
            return View(posts);

        }

        [HttpGet]
        public IActionResult Create()
        {
           var statusList  = Enum.GetValues(typeof(Status)).Cast<Status>().Select(x => new {
           Id  = (int)x,
           Name = x.ToString()
           }).ToList();
            ViewBag.Status = new SelectList(statusList, "Id", "Name");
            ViewBag.Authors = new SelectList(_context.Authors.ToList(), "Id", "FullName");
            return View(new PostRequestViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(PostRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post()
                {
                    AuthorId = model.AuthorId,
                    CreatedAt = DateTime.Now,
                    Status = Status.Enabled,
                    Content = model.Content
                };
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        [HttpPut]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(PostRequestViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var mustUpdate = _context.Posts.Find(model.Id);
                if(mustUpdate != null)
                {
                    mustUpdate.AuthorId = model.AuthorId;
                    mustUpdate.Content = model.Content;
                    mustUpdate.CreatedAt  = DateTime.Now;
                    mustUpdate.Status   = model.Status;
                    _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                }

            }
            return View(model);
        }
    }
}
