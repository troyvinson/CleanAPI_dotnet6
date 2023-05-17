using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        public Task<Session?> GetSessionByIdAsync(int roleId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void CreateSession(Session role)
        {
            throw new NotImplementedException();
        }

        public void DeleteSession(Session role)
        {
            throw new NotImplementedException();
        }

    }
}
