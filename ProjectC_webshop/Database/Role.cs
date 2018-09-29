using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model {
    public class Role {
        public int UserId { get; set; }
        public Users User { get; set; }
        public string User_role { get; set; } 
    }
}
        