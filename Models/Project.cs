using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string GithubLink { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Project_Has_Tags> Taggeds { get; set; }

        public List<Tag> Tags { get; set; }

        public void Deconstruct (out string name, out string description, out string githubLink, out ICollection<Tag> tags)
        {
            name = Name;
            description = Description;
            githubLink = GithubLink;
            tags = Tags;
        }
    }
}