using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Portfolio.Utils;

namespace Portfolio.Models
{
    public class PortfolioEntities : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Mailer> Mails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Project_Has_Tags> Prj_has_Tags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Project_Has_Tags.BuildConstraint(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var (dbHost, dbName, dbUser, dbPassword) = new DbConfig();
            optionsBuilder.UseNpgsql($"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPassword}");
        }

        public void Seed(PortfolioEntities context)
        {
            var author = new Author
            {
                Name = "Julien Luccioni",
                Description = ""
            };
            context.Add(author);
            context.SaveChanges();

            var projects = new List<Project>();

            var csharp = new Tag("c#", "is-success");
            var netcore = new Tag(".net core", "is-success");
            var html = new Tag("html", "is-danger");
            var css = new Tag("css", "is-warning");
            var js = new Tag("js", "is-warning");
            var node = new Tag("node", "is-warning");
            var sqlserver = new Tag("sql-server", "is-warning");
            var postg = new Tag("postgresql", "is-link");
            var ruby = new Tag("ruby", "is-warning");
            var android = new Tag("android", "is-primary");
            var webform = new Tag("webform", "is-info");
            var netfram = new Tag(".net framework", "is-primary");
            var efF = new Tag("Entity Framework", "is-warning");
            var efc = new Tag("EF core", "is-warning");

            var typescript = new Tag("Typescript", "is-info");
            var typeorm = new Tag("Typescript", "is-warning");

            var swift = new Tag("swift", "is-danger");
            var ios = new Tag("ios", "is-light");

            context.AddRange(new List<Tag>
            {
                csharp, netcore, html, css, js, node, sqlserver, postg, ruby, android, webform, netfram, efF, efc,
                swift, ios,typescript,typeorm
            });
            context.SaveChanges();

            var portf = new Project
            {
                AuthorId = author.Id,
                Description = "Portfolio fait avec des pages Razor, .net core 2.2 et une base de données postgresql",
                Name = "Portfolio",
                GithubLink = "https://github.com/LuccioniJulien/Portfolio"
            };
            var api = new Project
            {
                AuthorId = author.Id,
                Description =
                    "Api rest fait dans le cadre d'un projet, avec stack libre, en cours de concepteur développeur d'application au groupe Efrei." +
                    " Le but était de trouver une idée d'application et de présenter un mvp en 6 jours. Cette api est consommée par une application mobile cross platefrome (React Native)." +
                    " L'idée était de faire une application permettant à des utilisateurs d'ajouter des tags sur des livres selon leurs contenus." +
                    " Ainsi d'autre utilisateurs peuvent trouver ces livres grace à ces tags." +
                    " Le groupe était constitué de 3 personnes, 2 sur le front et 1 sur le back (moi).",
                Name = "Api Rest",
                GithubLink = "https://github.com/LuccioniJulien/Bookup-api"
            };
            var tuturu = new Project
            {
                AuthorId = author.Id,
                Description =
                    "Application android faite avec ruboto, une gem ruby pour faire des applications android en ... ruby." +
                    " Un bouton avec 3 animations différentes et 3 sons différents se déclenchant à l'appui du bouton",
                Name = "Application android en ruby",
                GithubLink = "https://github.com/LuccioniJulien/tuturu"
            };
            var spie = new Project
            {
                AuthorId = author.Id,
                Description =
                    "Maintient, correction et évolution d’une suite applicative à destination d’une filiale (Applications de gestion des abonnements clients et facturation pour des piscines et des parkings)." +
                    " Développement d'une application de gestion de dossiers de contentieux.",
                Name = "Suite applicative service BtoC de Spie Batignolle Amitec",
                GithubLink = string.Empty
            };
            var weather = new Project
            {
                AuthorId = author.Id,
                Description =
                    "Application météo ios/swift. Cette app consume une api rest pour avoir les informations météorologiques.",
                Name = "Weather app",
                GithubLink = "https://github.com/LuccioniJulien/Weather"
            };

              var apiStypescript = new Project
            {
                AuthorId = author.Id,
                Description = "Api rest fait dans le cadre d'un projet tuteuré. Cette Api fourni des données pour une application mobile visant à fournir des informations"
                +" sur la cinquième extinction de masse.",
                Name = "Api annihimal",
                GithubLink = "https://github.com/LuccioniJulien/Portfolio"
            };

            context.AddRange(new List<Project> { portf, api, tuturu, spie, weather, apiStypescript});
            context.SaveChanges();

            var portflien = new List<Project_Has_Tags>
            {
                new Project_Has_Tags {ProjectId = portf.Id, TagId = csharp.Id},
                new Project_Has_Tags {ProjectId = portf.Id, TagId = netcore.Id},
                new Project_Has_Tags {ProjectId = portf.Id, TagId = html.Id},
                new Project_Has_Tags {ProjectId = portf.Id, TagId = css.Id},
                new Project_Has_Tags {ProjectId = portf.Id, TagId = postg.Id},
                new Project_Has_Tags {ProjectId = portf.Id, TagId = js.Id},
                new Project_Has_Tags {ProjectId = portf.Id, TagId = efc.Id},

                new Project_Has_Tags {ProjectId = api.Id, TagId = csharp.Id},
                new Project_Has_Tags {ProjectId = api.Id, TagId = netcore.Id},
                new Project_Has_Tags {ProjectId = api.Id, TagId = efc.Id},
                new Project_Has_Tags {ProjectId = api.Id, TagId = postg.Id},

                new Project_Has_Tags {ProjectId = tuturu.Id, TagId = ruby.Id},
                new Project_Has_Tags {ProjectId = tuturu.Id, TagId = android.Id},

                new Project_Has_Tags {ProjectId = spie.Id, TagId = sqlserver.Id},
                new Project_Has_Tags {ProjectId = spie.Id, TagId = webform.Id},
                new Project_Has_Tags {ProjectId = spie.Id, TagId = netfram.Id},
                new Project_Has_Tags {ProjectId = spie.Id, TagId = efF.Id},

                new Project_Has_Tags {ProjectId = weather.Id, TagId = swift.Id},
                new Project_Has_Tags {ProjectId = weather.Id, TagId = ios.Id},

                new Project_Has_Tags {ProjectId = apiStypescript.Id, TagId = typescript.Id},
                new Project_Has_Tags {ProjectId = apiStypescript.Id, TagId = typeorm.Id}
            };

            context.AddRange(portflien);
            context.SaveChanges();
        }
    }
}