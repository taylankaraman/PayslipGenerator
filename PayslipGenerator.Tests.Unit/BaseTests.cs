using AutoFixture;
using NUnit.Framework;

namespace PayslipGenerator.Tests.Unit
{
    public class BaseTests
    {
        protected Fixture Fixture;

        [SetUp]
        public void SetupBase()
        {
            Fixture = new Fixture();
        }
    }
}
