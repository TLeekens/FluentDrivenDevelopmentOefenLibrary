using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using FluentDrivenDevelopmentOefenLibrary;

namespace FluentDrivenDevelopmentOefenLibraryTest
{
    [TestClass]
    public class WinstServiceTest
    {
        private IOpbrengstDAO iOpbrengstDAO;
        private IKostDAO iKostDAO;
        private WinstService winstService;

        [TestInitialize]
        public void Initialize()
        {
            iOpbrengstDAO = new OpbrengstDAOStub();
            iKostDAO = new KostDAOStub();
            winstService = new WinstService(iOpbrengstDAO, iKostDAO);
        }
        [TestMethod]
        public void PropertyWinstMoetGelijkZijnAanHetVerschilTussenTotaleOpbrengstEnTotaleKost()
        {
            winstService.Winst.Should().Be(iOpbrengstDAO.TotaleOpbrengst() - iKostDAO.TotaleKost(), "profit is income minus costs");
        }
    }
}
