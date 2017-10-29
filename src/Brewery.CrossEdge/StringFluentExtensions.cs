namespace Brewery.CrossEdge
{
    public static class StringFluentExtensions
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static bool IsNotNullOrEmpty(this string value) => !value.IsNullOrEmpty();
    }
}