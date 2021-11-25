using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module2HW5.Models;

namespace Module2HW5.Services.Abstractions
{
    public interface IConfigService
    {
        ConfigModel Get();
    }
}
