﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Api
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public bool Status { get; set; } = false;
    }

}
