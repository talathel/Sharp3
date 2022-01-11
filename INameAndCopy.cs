using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    interface INameAndCopy
    {
       string Name { get; set; }
       object DeepCopy();
    }
}
