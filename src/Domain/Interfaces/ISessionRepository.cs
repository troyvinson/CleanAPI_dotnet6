﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetSessionsAsync(bool trackChanges);
        Task<Session?> GetSessionByIdAsync(int roleId, bool trackChanges);
        Task<IEnumerable<Session>> GetSessionsByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        void CreateSession(Session role);
        void DeleteSession(Session role);
    }
}