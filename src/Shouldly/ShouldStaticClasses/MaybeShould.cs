namespace Shouldly
{
    public static partial class Should
    {
        public static readonly ShouldExistInterrnal ShouldExist = new ShouldExistInterrnal("*Should Exist*");
        public static readonly ShouldExistInterrnal ShouldNotExist = new ShouldExistInterrnal("*Should Not Exist*");

        public static ShouldExistInterrnal Exist()
        {
            return ShouldExist;
        }

        public static ShouldExistInterrnal NotExist()
        {
            return ShouldNotExist;
        }

        public class ShouldExistInterrnal
        {
            private readonly string _message;

            public ShouldExistInterrnal(string message)
            {
                _message = message;
            }

            public override string ToString()
            {
                return _message;
            }
        }
    }
}