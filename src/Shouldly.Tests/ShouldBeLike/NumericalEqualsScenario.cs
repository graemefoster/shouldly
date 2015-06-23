using Shouldly.ShouldlyExtensionMethods.ShouldBeLike;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeLike
{
    public class NumericalEqualsScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldPass()
        {
            new { Age = 40 }.ShouldBeLike(new { Age = 40 });
        }

        protected override void ShouldThrowAWobbly()
        {
            new { Age = 39 }.ShouldBeLike(new { Age = 40 });
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @" actualPropertyValue
        should be
    40
        but was
    39"; }
        }
    }
}