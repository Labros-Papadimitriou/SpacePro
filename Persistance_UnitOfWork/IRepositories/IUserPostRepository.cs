﻿using Entities.IdentityUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.IRepositories
{
    public interface IUserPostRepository:IRepository<UserPost>
    {
        Task<IEnumerable<UserPost>> GetPostWithLikes();
        Task<IEnumerable<UserPost>> GetTenBestPosts();
    }
}
