using System.Collections.Generic;
using Shouldly.ShouldlyExtensionMethods.ShouldBeLike;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeLike
{
    public class DictionaryEqualsScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldThrowAWobbly()
        {
            new {Likes = new Dictionary<int, string> {{1, "A"}, {2, "B"}}}
                .ShouldBeLike(new {Likes = new Dictionary<int, string> {{1, "A"}, {2, "C"}}});
        }

        protected override void ShouldPass()
        {
            new { Likes = new Dictionary<int, string> { { 1, "A" }, { 2, "B" } } }
                .ShouldBeLike(new { Likes = new Dictionary<int, string> { { 1, "A" }, { 2, "B" } } });
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @"actualPropertyValue
        should be
    [[1, A], [2, C]]
        but was
    [[1, A], [2, B]]
        difference
    [[1, A], *[2, B]*]";
            }
        }
    }
}