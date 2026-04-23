namespace Calculator.Classes
{
    class Globals
    {
        public static EnumPage CurrentPage { get; set; }
        public static bool ErrorMessage { get; set; }
    }

    public enum EnumPage
    {
        Menu, Standard, Currency
    }

    public enum EnumCurrency
    {
        EUR, USD, GBP, CZK, JPY, CNY
    }
}