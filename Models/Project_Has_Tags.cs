using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models
{
    public class Project_Has_Tags
    {
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        
        public static void BuildConstraint (ModelBuilder builder) {
            builder.Entity<Project_Has_Tags> ()
                .HasKey (p => new { p.TagId, p.ProjectId });
            builder.Entity<Project_Has_Tags> ()
                .HasOne (pht => pht.Project)
                .WithMany (p => p.Taggeds)
                .HasForeignKey (pht => pht.ProjectId);
            builder.Entity<Project_Has_Tags> ()
                .HasOne (pht=> pht.Tag)
                .WithMany (t => t.Taggeds)
                .HasForeignKey (pht => pht.TagId);
        }
    }
}