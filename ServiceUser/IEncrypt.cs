﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork16.ServiceUser
{
    public interface IEncrypt
    {
        string HashPassword(string password, string salt);
    }
}
