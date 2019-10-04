using System.Collections.Generic;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> Projects { get;set; }
        public IEnumerable<Tag> Tags { get;set; }
    }
}