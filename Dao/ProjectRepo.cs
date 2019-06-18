using System.Collections.Generic;
using System.Linq;
using Portfolio.Models;

namespace Portfolio.Dao
{
    // classe ou seront rangé les requêtes concernant la table Mailer
    // la classe Project est générée automatiquement par Entity Framework grace au designer
    public class ProjectRepo : RepositoryBase<Project>
    {
        public ProjectRepo(PortfolioEntities context) : base(context)
        {

        }
        // un projet a plusieurs tags
        // un tag peut être attribué à plusieurs projets
        // c'est une relation Has_many des deux cotés
        public void AddTag(int idProject, int idTag)
        {
            Project project = _context.Projects.Find(idProject);
            Tag tag = _context.Tags.Find(idTag);
            project.Tags.Add(tag);
            _context.SaveChanges();
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