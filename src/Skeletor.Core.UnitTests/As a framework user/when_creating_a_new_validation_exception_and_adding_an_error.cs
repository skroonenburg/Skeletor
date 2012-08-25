using NUnit.Framework;
using Skeletor.Core.Framework;

namespace Skeletor.Core.UnitTests
{
    [TestFixture]
    public class when_creating_a_new_validation_exception_and_adding_an_error
    {
        private ValidationException exception;

        [SetUp]
        public void SetUp()
        {
            exception = new ValidationException();
            exception.AddError("User error message");
        }

        [Test]
        public void it_should_have_errors()
        {
            Assert.IsTrue(exception.HasErrors);
        }

        [Test]
        public void it_should_have_one_as_the_count_of_messages()
        {
            Assert.AreEqual(1, exception.ErrorCount);
        }

    }
}