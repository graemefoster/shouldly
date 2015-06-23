using System;
using JetBrains.Annotations;

namespace Shouldly.ShouldlyExtensionMethods.ShouldBeLike
{
    public static class ShouldBeLikeTestExtensions
    {
        public static void ShouldBeLike(this object actual, object expected)
        {
            actual.ShouldBeLike(expected, () => null);
        }

        public static void ShouldBeLike(this object actual, object expected, string customMessage)
        {
            actual.ShouldBeLike(expected, () => customMessage);;
        }

        public static void ShouldBeLike(this object actual, object expected, [InstantHandle] Func<string> customMessage)
        {
            if (!actual.IsLike(expected))
            {
                throw new ShouldAssertException(
                    new ExpectedActualShouldlyMessage(expected, actual, customMessage).ToString());
            }
        }

        internal static bool IsLike(this object actual, object expected)
        {
            foreach (var expectedProperty in expected.GetType().GetProperties())
            {
                var expectedPropertyValue = expectedProperty.GetValue(expected, null);
                var actualProperty = actual.GetType().GetProperty(expectedProperty.Name);

                if (actualProperty == null && expectedPropertyValue != null)
                {
                    return false;
                }

                var actualPropertyValue = actualProperty.GetValue(actual, null);
                if (expectedPropertyValue == Should.ShouldExist)
                {
                    if (actualPropertyValue != null)
                    {
                        continue;
                    }
                }
                if (expectedPropertyValue == Should.ShouldNotExist)
                {
                    if (actualPropertyValue != null)
                    {
                        return false;
                    }
                }

                actualPropertyValue.ShouldBe(expectedPropertyValue);
            }
            return true;
        }
    }
}
