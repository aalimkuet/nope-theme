﻿using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.BookTracker.Domain
{
    public class CustomerTracker : BaseEntity
    {
        public string Name { get; set; }   
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
