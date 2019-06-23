using System.Collections.Generic;
using System.Linq;
using Portfolio.Interfaces;
using Portfolio.Models;

namespace Portfolio.Dao
{
    // classe ou seront rangé les requêtes concernant la table Mailer
    // la classe Project est générée automatiquement par Entity Framework grace au designer
    public class ProjectRepo : RepositoryBase<Project>, IProjectRepo
    {
        public ProjectRepo(PortfolioEntities context) : base(context)
        {

        }

        // Requête spécifique 
        public IEnumerable<Project> GetProjectsWithTagsByAuthor(string name)
        {
            IEnumerable<Project> projects = base.FindAll(x => x.Author.Name == name)
                                                .Select(project =>
                                                {
                                                    project.Tags = _context.Prj_has_Tags.Where(pht => pht.ProjectId == project.Id)
                                                                                        .Select(pht => pht.Tag)
                                                                                        .ToList();
                                                    return project;
                                                });

            return projects;
        }
    }
}