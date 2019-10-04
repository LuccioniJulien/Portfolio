using System;
using Portfolio.Interfaces;
using Portfolio.Models;

namespace Portfolio.Dao
{
    public class DbContext : IDb, IDisposable
    {
        private PortfolioEntities _context;

        private ProjectRepo _projects;
        private MailerRepo _mailers;
        private TagRepo _tags;

        public DbContext(PortfolioEntities context)
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

        public TagRepo Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new TagRepo(_context);
                }
                return _tags;
            }
        }

        public void Dispose() => _context.Dispose();
    }
}