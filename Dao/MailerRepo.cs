using Portfolio.Models;

namespace Portfolio.Dao
{
    // classe où seront rangée les requêtes concernant la table Mailer
    // la classe Mailer est générée automatiquement par Entity Framework grace au designer
    public class MailerRepo : RepositoryBase<Mailer>
    {
        public MailerRepo(PortfolioEntities context) : base(context)
        {

        }
    }
}