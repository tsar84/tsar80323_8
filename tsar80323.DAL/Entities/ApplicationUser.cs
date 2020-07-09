﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;


namespace tsar80323.DAL.Entities
{
   public class ApplicationUser : IdentityUser
    {

        public byte[] AvatarImage { get; set; }

    }
}
