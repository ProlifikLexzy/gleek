﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleek.Core.Models
{
    public class GleekUser: IdentityUser<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}