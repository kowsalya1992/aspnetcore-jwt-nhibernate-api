using NHibernate;

namespace NhApiDemo
{
    public class UserRepository
    {
        private readonly NHibernate.ISession _session;

        public UserRepository(NHibernate.ISession session)
        {
            _session = session;
        }

        public IList<User> GetAll()
        {
            return _session.Query<User>().ToList();
        }

        public void Add(User user)
        {
            _session.Save(user);
            _session.Flush();
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _session.Query<User>()
                .FirstOrDefault(x => x.Name == username && x.Password == password);
        }
    }
}
