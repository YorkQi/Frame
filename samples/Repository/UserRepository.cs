using Domain.Users;
using Frame.Core;

namespace Repository
{
    public class UserRepository:
        IRepository<int,User>,
        IScopedInstance
    {

    }
}
