using Shouldly.ShouldlyExtensionMethods.ShouldBeLike;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeLike
{
    public class ShouldExistScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldPass()
        {
            new {Person = "Graeme"}.ShouldBeLike(new {Person = Should.Exist()});
        }

        protected override void ShouldThrowAWobbly()
        {
            new { Person = "Graeme" }.ShouldBeLike(new { Person = Should.NotExist() });
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @"Should
        error
    { Person = *Should Not Exist* }
        but was
    { Person = Graeme }";
            }
        }
    }
}