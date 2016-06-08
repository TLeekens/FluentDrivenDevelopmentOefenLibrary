using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using FluentDrivenDevelopmentOefenLibrary;

namespace FluentDrivenDevelopmentOefenLibraryTest
{
    [TestClass]
    public class WoordTest
    {
        private Woord woord;

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ConstructorAansprekenMetLegeStringWerptArgumentException()
        {
            Action act = () => new Woord(string.Empty);
            act.ShouldThrow<ArgumentException>("empty strings are Schroedinger's palindromes");
        }

        [TestMethod]
        public void IsPalindroomOpEenWoordMetOnevenAantalLettersDatEchtEenPalindroomIsGeeftTrue()
        {
            woord = new Woord("lepel");
            woord.IsPalindroom().Should().BeTrue("spoons are palindromes");
        }

        [TestMethod]
        public void IsPalindroomOpEenWoordMetOnevenAantalLettersDatGeenPalindroomIsGeeftFalse()
        {
            woord = new Woord("mes");
            woord.IsPalindroom().Should().BeFalse("knives backwards are sevink");
        }

        [TestMethod]
        public void IsPalindroomOpEenWoordMetEvenAantalLettersDatEchtEenPalindroomIsGeeftTrue()
        {
            woord = new Woord("parterretrap");
            woord.IsPalindroom().Should().BeTrue("going up takes as many steps as going down");
        }

        [TestMethod]
        public void IsPalindroomOpEenWoordMetEvenAantalLettersDatGeenPalindroomIsGeeftFalse()
        {
            woord = new Woord("vork");
            woord.IsPalindroom().Should().BeFalse("forks are not always tridents");
        }
    }
}
