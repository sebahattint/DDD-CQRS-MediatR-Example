﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain.Entities
{
    [Serializable]
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
