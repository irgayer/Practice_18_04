﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_04
{
    public class Login
    {
        public bool Access(List<User> users, string userLogin, string userPsswd)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (userLogin == users[i].Login)
                {
                    if (userPsswd == users[i].Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
