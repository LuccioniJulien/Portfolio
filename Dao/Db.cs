using Portfolio.Interfaces;
using Portfolio.Models;

namespace Portfolio.Dao
{
    public class Db : IDb
    {
        // _context correspond au context généré par Entity Framework
        private PortfolioEntities _context;

        private ProjectRepo _projects;
        private MailerRepo _mailers;

        public Db(PortfolioEntities context)
        {
            _context = context;
        }
        public ProjectRepo Projects
        {
            get
            {
                if (_projects == null)
                {
                    _projects = new ProjectRepo(_context);
                }
                return _projects;
            }
        }

        public MailerRepo Mailers
        {
            get
            {
                if (_mailers == null)
                {
                    _mailers = new MailerRepo(_context);
                }
                return _mailers;
            }
        }

    }
}