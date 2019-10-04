using Portfolio.Dao;

namespace Portfolio.Interfaces
{
    public interface IDb
    {
        ProjectRepo Projects { get; }
        MailerRepo Mailers { get; }

        TagRepo Tags { get; }
    }
}