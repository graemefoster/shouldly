using Shouldly.ShouldlyExtensionMethods.ShouldBeLike;
using Shouldly.Tests.TestHelpers;

namespace Shouldly.Tests.ShouldBeLike
{
    public class NestedAnonymousTypesWithAdditionalPropertiesScenario : ShouldlyShouldTestScenario
    {
        protected override void ShouldPass()
        {
            new { Person = new { Name = "Graeme", Age = 40 } }.ShouldBeLike(new { Person = new { Name = "Graeme" } });
        }

        protected override void ShouldThrowAWobbly()
        {
            new { Person = new { Name = "Graeme", Age = 40 } }.ShouldBeLike(new { Person = new { Name = "Other" } });
        }

        protected override string ChuckedAWobblyErrorMessage
        {
            get
            {
                return @"actualPropertyValue
        should be
    ""Other""
        but was
    ""Graeme""
        difference
    Case Sensitive Comparison
Difference     |  |    |    |         |    |   
               | \|/  \|/  \|/       \|/  \|/  
Index          | 0    1    2    3    4    5    
Expected Value | O    t    h    e    r         
Actual Value   | G    r    a    e    m    e    
Expected Code  | 79   116  104  101  114       
Actual Code    | 71   114  97   101  109  101";
            }
        }
    }
}