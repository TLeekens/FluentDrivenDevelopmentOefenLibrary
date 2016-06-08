using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentDrivenDevelopmentOefenLibrary;

namespace FluentDrivenDevelopmentOefenLibraryTest
{
    class OpbrengstDAOStub : IOpbrengstDAO
    {
        public decimal TotaleOpbrengst()
        {
            return 2000.0m;
        }
    }
}
