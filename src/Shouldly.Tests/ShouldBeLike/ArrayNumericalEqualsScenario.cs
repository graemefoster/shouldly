using NUnit.Framework;
using Shouldly.ShouldlyExtensionMethods.ShouldBeLike;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeLike
{
    public class ArrayNumericalEqualsScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            new { Likes = new[] { 1, 2 } }.ShouldBeLike(new { Likes = new[] { 1, 3 } });
        }

        protected override void ShouldPass()
        {
            new { Likes = new[] { 1, 2 } }.ShouldBeLike(new { Likes = new[] { 1, 2 } });
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @"actualPropertyValue
        should be
    [1, 3]
        but was
    [1, 2]
        difference
    [1, *2*]";
            }
        }
    }
}