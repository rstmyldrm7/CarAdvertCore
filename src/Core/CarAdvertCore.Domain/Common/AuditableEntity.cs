﻿using System;

namespace CarAdvertCore.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
