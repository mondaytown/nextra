using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class IpAddressAttributeBehavior
    {
        private IValidator _validator;


        [TestFixtureSetUp]
        public void SetUp()
        {
            _validator = new IpAddressAttribute();
        }


        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(_validator.IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(_validator.IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForDomain()
		{
			Assert.That(_validator.IsValid("foobar.com"), Is.False);
		}

        [Test]
        public void IsValid_ShouldReturnFalseForTooFewSections()
        {
            Assert.That(_validator.IsValid("192"), Is.False);
            Assert.That(_validator.IsValid("192.168"), Is.False);
            Assert.That(_validator.IsValid("192.168.0"), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForNoDots()
        {
            Assert.That(_validator.IsValid("19216801"), Is.False);
        }

		[Test]
		public void IsValid_ShouldReturnTrueForValidIpAddress()
		{
			Assert.That(_validator.IsValid("192.168.0.1"), Is.True);
		}
	}
}