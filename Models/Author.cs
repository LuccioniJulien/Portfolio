using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Project> Projects { get; set; }
        public List<Study> Studies { get; set; }
        
        public static void BuildConstraint (ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasMany(x => x.Projects)
                .WithOne(x => x.Author);
            builder.Entity<Author>()
                .HasMany(x => x.Studies)
                .WithOne(x => x.Author);
        }
    }
}