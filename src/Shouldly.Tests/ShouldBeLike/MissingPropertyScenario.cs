using Shouldly.ShouldlyExtensionMethods.ShouldBeLike;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeLike
{
    public class MissingPropertyScenario : ShouldlyShouldFailureTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            new { Person = "Graeme" }.ShouldBeLike(new { Person = "Graeme", Age = 40 }, () => "Some additional context");
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @" Should
        error
    { Person = Graeme, Age = 40 }
        but was
    { Person = Graeme }
    Additional Info:
    Some additional context";
            }
        }
    }
}