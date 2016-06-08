using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using FluentDrivenDevelopmentOefenLibrary;

namespace FluentDrivenDevelopmentOefenLibraryTest
{
    [TestClass]
    public class VeilingTest
    {
        private Veiling veiling;

        [TestInitialize]
        public void Initialize()
        {
            veiling = new Veiling();
        }

        [TestMethod]
        public void EenBodDoenMetEenNegatiefBedragWerptArgumentException()
        {
            Action a = () => veiling.DoeBod(decimal.Negate(1000.0m));
            a.ShouldThrow<ArgumentException>("negative buying is selling");
        }

        [TestMethod]
        public void AlsGeenEnkelBodIngevoerdIsIsHetHoogsteBodGelijkAanNul()
        {
            veiling.HoogsteBod.ShouldBeEquivalentTo(decimal.Zero, "none is none");
        }

        [TestMethod]
        public void NaInvoerenVanExactEenBodIsHetHoogsteBodGelijkAanHetBedragVanDatBod()
        {
            decimal bedrag = 1000.0m;
            veiling.DoeBod(bedrag);
            veiling.HoogsteBod.Should().Be(bedrag);
        }

        [TestMethod]
        public void NaInvoerenVanMeerdereBodenIsHetHoogsteBodGelijkAanHetHoogsteBedrag()
        {
            decimal hoogsteBedrag = 2000.0m;
            veiling.DoeBod(1000.0m);
            veiling.DoeBod(hoogsteBedrag);
            veiling.DoeBod(1500.0m);
            veiling.HoogsteBod.Should().Be(hoogsteBedrag);
        }
    }
}
