﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

internal class UserRole
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Role { get; set; }
}
