using NUnit.Framework;
using Skeletor.Core.Framework;

namespace Skeletor.Core.UnitTests
{
    [TestFixture]
    public class when_creating_a_new_validation_exception_object
    {
        private ValidationException exception;

        [SetUp]
        public void SetUp()
        {
            exception = new ValidationException();
        }

        [Test]
        public void it_should_have_zero_errors()
        {
            Assert.IsFalse(exception.HasErrors);
        }

        [Test]
        public void it_should_have_zero_as_the_count_of_messages()
        {
            Assert.AreEqual(0,exception.ErrorCount);
        }

    }
}