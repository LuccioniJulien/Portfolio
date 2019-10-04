using System.Collections.Generic;
using System.Linq;
using Portfolio.Interfaces;
using Portfolio.Models;

namespace Portfolio.Dao
{
    public class ProjectRepo : RepositoryBase<Project>, IProjectRepo
    {
        public ProjectRepo(PortfolioEntities context) : base(context)
        {

        }

        public IEnumerable<Project> GetProjectsWithTagsByAuthor(string name, string tag = null)
        {
            IEnumerable<Project> projects;

            if (tag == null)
                projects = base.FindAll(p => p.Author.Name == name);
            else
                projects = base.FindAll(p => p.Author.Name == name && p.Taggeds.Select(t => t.Tag.Name).Contains(tag));


            projects = projects.Select(project =>
                             {
                                 project.Tags = _context.Prj_has_Tags.Where(pht => pht.ProjectId == project.Id)
                                                                     .Select(pht => pht.Tag)
                                                                     .ToList();
                                 return project;
                             }).OrderBy(x => x.Name);

            return projects;
        }
    }
}