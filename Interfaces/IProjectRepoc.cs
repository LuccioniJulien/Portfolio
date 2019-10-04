using System.Collections.Generic;
using Portfolio.Models;

namespace Portfolio.Interfaces
{
    public interface IProjectRepo
    {
         IEnumerable<Project> GetProjectsWithTagsByAuthor(string name,string tag);
    }
}