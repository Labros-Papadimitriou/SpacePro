using Entities;
using MyDatabase;
using Persistance_UnitOfWork.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_UnitOfWork.Repositories
{
    public class ChatMessageRepository: Repository<ChatMessage>, IChatMessageRepository
    {
        public ChatMessageRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

    }
}
