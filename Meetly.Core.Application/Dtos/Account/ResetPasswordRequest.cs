﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Dtos.Account
{
    public class ResetPasswordRequest
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
