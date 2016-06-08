using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentDrivenDevelopmentOefenLibrary
{
    public class WinstService
    {
        private IOpbrengstDAO iOpbrengstDAO;
        private IKostDAO iKostDAO;

        public WinstService(IOpbrengstDAO opbrengstDAO, IKostDAO kostDAO)
        {
            this.iOpbrengstDAO = opbrengstDAO;
            this.iKostDAO = kostDAO;
        }

        public decimal Winst
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        
    }
}
