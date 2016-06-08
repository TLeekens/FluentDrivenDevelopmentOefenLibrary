using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using FluentDrivenDevelopmentOefenLibrary;

namespace FluentDrivenDevelopmentOefenLibraryTest
{
    [TestClass]
    public class ISBNTest
    {
        private ISBN iSBN;
        private Action a;
        private long correctNummerZonderNul = 9789027439642L;
        private long correctNummerMetNul = 9789227439640L;

        [TestMethod]
        public void ConstructorAanroepenMetNegatiefGetalMetCorrecteControleWerptArgumentException()
        {
            a = () => new ISBN(-9789027439642L);
            a.ShouldThrow<ArgumentException>("negative books should be burnt");
        }

        [TestMethod]
        public void ConstructorAanroepenMetNulwaardeWerptArgumentException()
        {
            a = () => new ISBN(0L);
            a.ShouldThrow<ArgumentException>("none is none, even in books");
        }

        [TestMethod]
        public void ConstructorAanroepenMetEenGetalVanTwaalfCijfersWerptArgumentException()
        {
            a = () => new ISBN(123456789012L);
            a.ShouldThrow<ArgumentException>("a dozen is not a dirty dozen");
        }

        [TestMethod]
        public void ConstructorAanroepenMetEenGetalVanVeertienCijfersWerptArgumentException()
        {
            a = () => new ISBN(12345678901234L);
            a.ShouldThrow<ArgumentException>("this dozen is too dirty");
        }

        [TestMethod]
        public void ConstructorAanroepenMetGetalVanDertienCijfersMetFouteControleWerptArgumentException()
        {
            a = () => new ISBN(9789027439643L);
            a.ShouldThrow<ArgumentException>("Checkpoint Charlie don't surf");
        }

        [TestMethod]
        public void NaConstructorAanroepMetGetalVanDertienCijfersMetCorrecteControleDieNietNulIsGeeftDeToStringDezelfdeStringAlsDeToStringVanDatGetal()
        {
            iSBN = new ISBN(correctNummerZonderNul);
            iSBN.ToString().ShouldBeEquivalentTo(correctNummerZonderNul.ToString(), "this book is this book");
        }

        [TestMethod]
        public void NaConstructorAanroepMetGetalVanDertienCijfersMetCorrecteControleDieNulIsGeeftDeToStringDezelfdeStringAlsDeToStringVanDatGetal()
        {
            iSBN = new ISBN(correctNummerMetNul);
            iSBN.ToString().ShouldBeEquivalentTo(correctNummerMetNul.ToString(), "this book is this book");
        }
    }
}
