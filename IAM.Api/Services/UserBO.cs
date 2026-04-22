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

        public User GetById(int id)
        {
            return _session.Get<User>(id);
        }

        public void Update(User user)
        {
            _session.Update(user);
            _session.Flush();
        }

        public void Delete(int id)
        {
            var user = _session.Get<User>(id);
            if (user != null)
            {
                _session.Delete(user);
                _session.Flush();
            }
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return _session.Query<User>()
                .FirstOrDefault(x => x.Name == username && x.Password == password);
        }
    }
}
