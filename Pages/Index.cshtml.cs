using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Portfolio.Dao;
using Portfolio.Models;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Db _db;

        public IndexModel(Db db)
        {
            _db = db;
        }

        public List<string> Projects { get; set; }

        public void OnGet()
        { }

        public PartialViewResult OnGetHomePartial() => Partial("_HomePartial");

        public PartialViewResult OnGetProjectsPartial()
        {
            var projects = _db.Projects.GetProjectsWithTagsByAuthor("Julien Luccioni")
                                       .ToList();

            return new PartialViewResult
            {
                ViewName = "_ProjectsPartial",
                ViewData = new ViewDataDictionary<IEnumerable<Project>>(ViewData, projects)
            };
        }
    }
}