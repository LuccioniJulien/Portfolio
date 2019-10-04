using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Portfolio.Dao;
using Portfolio.Interfaces;
using Portfolio.Models;
using Portfolio.Utils;
using Portfolio.ViewModels;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDb _db;

        public IndexModel(IDb db) => _db = db;

        public List<string> Projects { get; set; }

        public void OnGet() { }

        public PartialViewResult OnGetHomePartial() => Partial("_HomePartial");
        public PartialViewResult OnGetContactPartial() => Partial("_ContactPartial");
        public PartialViewResult OnGetProjectsPartial([FromQuery(Name = "tag")] string tag)
        {
            var projects = _db.Projects.GetProjectsWithTagsByAuthor("Julien Luccioni").ToList();
            var model = new ProjectsViewModel()
            {
                Projects = projects,
                Tags = _db.Tags.GetAllTagAttributed()
            };
            return new PartialViewResult
            {
                ViewName = "_ProjectsPartial",
                ViewData = new ViewDataDictionary<ProjectsViewModel>(ViewData, model)
            };
        }

        public PartialViewResult OnGetProjectsPartPartial([FromQuery(Name = "tag")] string tag)
        {
            if (!string.IsNullOrEmpty(tag))
                tag = WebUtility.UrlDecode(tag);

            var projects = _db.Projects.GetProjectsWithTagsByAuthor("Julien Luccioni", tag).ToList();

            return new PartialViewResult
            {
                ViewName = "_ProjectsPartPartial",
                ViewData = new ViewDataDictionary<List<Project>>(ViewData, projects)
            };
        }

        [BindProperty]
        public Mailer Mail { get; set; }
        public async Task<IActionResult> OnPostContactPartial()
        {
            if (!ModelState.IsValid)
                return Partial("_ContactPartial");

            _db.Mailers.Create(Mail);    
            await MailHelper.Send(Mail);

            Mail.Status = "Mail envoyé !";
            Mail.Message = string.Empty;
            Mail.From = string.Empty;
            return new PartialViewResult
            {
                ViewName = "_ContactPartial",
                ViewData = new ViewDataDictionary<Mailer>(ViewData, Mail)
            };
        }
    }
}