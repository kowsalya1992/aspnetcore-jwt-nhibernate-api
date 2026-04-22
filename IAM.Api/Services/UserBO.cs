using NHibernate;

namespace IAM.Api
{
    public class UserBO
    {
        private readonly ISession _session;

        public UserBO(ISession session)
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
