﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidekick.Training.WebApi.Models.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
