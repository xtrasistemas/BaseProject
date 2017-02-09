using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Models.Entities;
using Base.Services.IRepositories;

namespace Base.Data.Repositories {
    public class UserRepository : RepositoryBase<User>, IUserRepository {
    }
}
