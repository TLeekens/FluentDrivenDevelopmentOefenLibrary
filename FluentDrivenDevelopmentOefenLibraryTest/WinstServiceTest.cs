using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using FluentDrivenDevelopmentOefenLibrary;

namespace FluentDrivenDevelopmentOefenLibraryTest
{
    [TestClass]
    public class WinstServiceTest
    {
        private Mock<IOpbrengstDAO> opbrengstMockFactory;
        private Mock<IKostDAO> kostMockFactory;
        private IOpbrengstDAO iOpbrengstDAO;
        private IKostDAO iKostDAO;
        private WinstService winstService;

        [TestInitialize]
        public void Initialize()
        {
            opbrengstMockFactory = new Mock<IOpbrengstDAO>();
            iOpbrengstDAO = opbrengstMockFactory.Object;
            opbrengstMockFactory.Setup(eenOpbrengstDAO => eenOpbrengstDAO.TotaleOpbrengst()).Returns(2000.0m);
            kostMockFactory = new Mock<IKostDAO>();
            iKostDAO = kostMockFactory.Object;
            kostMockFactory.Setup(eenKostDAO => eenKostDAO.TotaleKost()).Returns(1000.0m);
            winstService = new WinstService(iOpbrengstDAO, iKostDAO);
        }
        [TestMethod]
        public void PropertyWinstMoetGelijkZijnAanHetVerschilTussenTotaleOpbrengstEnTotaleKost()
        {
            winstService.Winst.Should().Be(iOpbrengstDAO.TotaleOpbrengst() - iKostDAO.TotaleKost(), "profit is income minus costs");
            opbrengstMockFactory.Verify(eenOpbrengstDAO => eenOpbrengstDAO.TotaleOpbrengst());
            kostMockFactory.Verify(eenKostDAO => eenKostDAO.TotaleKost());
        }
    }
}
