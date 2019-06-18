using Portfolio.Models;

namespace Portfolio.Dao
{
    // Cette classe sera injectée et utilisée dans les differents contrôleurs
    // Elle donnera accés aux différentes classes permettant de faire des requêtes sur les différentes tables
    // C'est une sorte de "Wrapper"
    // Le but est de ne jamais exposer le type IQueryable
    // Le context sera générée par Entity Framework sera lui aussi injectée
    // Le but est de ne jamais instancier de nouveaux context nous même
    public class Db
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