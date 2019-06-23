using Portfolio.Models;

namespace Portfolio.Dao
{
    public class MailerRepo : RepositoryBase<Mailer>
    {
        public MailerRepo(PortfolioEntities context) : base(context)
        {

        }
    }
}