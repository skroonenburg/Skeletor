using NUnit.Framework;
using Skeletor.Core.Framework;
using Skeletor.Core.Security;

namespace Skeletor.Core.UnitTests
{
    [TestFixture]
    public class when_creating_a_username_object_with_no_text_entered
    {
        private Username username;

        [Test]
        public void it_should_throw_a_validation_exception()
        {
            Assert.Throws<ValidationException>(() => username = new Username(string.Empty));
        }

    }
}