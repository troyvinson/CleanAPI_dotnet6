﻿using Domain.Entities;

namespace Domain.Interfaces;

public interface IMemberRoleRepository
{
    Task<IEnumerable<MemberRole>> GetMemberRolesAsync(bool trackChanges);
    void CreateMemberRole(MemberRole MemberRole);
    void DeleteMemberRole(MemberRole memberRole);
}