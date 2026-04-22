
using FluentNHibernate.Mapping;

namespace IAM.Api
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Email);
            Map(x => x.Password);
        }
    }
}