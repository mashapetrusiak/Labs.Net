﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface INameAndCopy
    {
        object DeepCopy();
        string Name { get; set; }
    }
}
