namespace Calculator2.Classes
{
    class ConvertCurrency
    {
        GetCurrencyData GetCurrencyData1;

        private double Dollar;
        private double Yen;
        private double Koruna;
        private double Pound;
        private double Yuan;

        public ConvertCurrency()
        {
            GetCurrencyData1 = new GetCurrencyData();

            Dollar = GetCurrencyData1.GetDollar();
            Yen = GetCurrencyData1.GetYen();
            Koruna = GetCurrencyData1.GetKoruna();
            Pound = GetCurrencyData1.GetPound();
            Yuan = GetCurrencyData1.GetYuan();
        }

        public string GetAmountCurrency2(EnumCurrency currency1, EnumCurrency currency2, double amountCurrency1)
        {
            double currencyAmount;
            double currentRate = 0;

            if (currency1 == EnumCurrency.EUR) amountCurrency1 /= 1;
            if (currency1 == EnumCurrency.USD) amountCurrency1 /= Dollar;
            if (currency1 == EnumCurrency.JPY) amountCurrency1 /= Yen;
            if (currency1 == EnumCurrency.CZK) amountCurrency1 /= Koruna;
            if (currency1 == EnumCurrency.GBP) amountCurrency1 /= Pound;
            if (currency1 == EnumCurrency.CNY) amountCurrency1 /= Yuan;

            if (currency2 == EnumCurrency.EUR) currentRate = 1;
            if (currency2 == EnumCurrency.USD) currentRate = Dollar;
            if (currency2 == EnumCurrency.JPY) currentRate = Yen;
            if (currency2 == EnumCurrency.CZK) currentRate = Koruna;
            if (currency2 == EnumCurrency.GBP) currentRate = Pound;
            if (currency2 == EnumCurrency.CNY) currentRate = Yuan;

            currencyAmount = amountCurrency1 * currentRate;
            currencyAmount = Math.Round(currencyAmount, 2);

            //normally the decimal point would be "," so we replace it with "."
            string currencyAmount2 = currencyAmount.ToString();
            currencyAmount2 = currencyAmount2.Replace(",", ".");

            return currencyAmount2;
        }

        public string GetCurrencyRate(EnumCurrency currency1, EnumCurrency currency2)
        {
            double currentRate = 1;

            if (currency1 == EnumCurrency.USD) currentRate /= Dollar;
            if (currency1 == EnumCurrency.JPY) currentRate /= Yen;
            if (currency1 == EnumCurrency.CZK) currentRate /= Koruna;
            if (currency1 == EnumCurrency.GBP) currentRate /= Pound;
            if (currency1 == EnumCurrency.CNY) currentRate /= Yuan;

            if (currency2 == EnumCurrency.USD) currentRate *= Dollar;
            if (currency2 == EnumCurrency.JPY) currentRate *= Yen;
            if (currency2 == EnumCurrency.CZK) currentRate *= Koruna;
            if (currency2 == EnumCurrency.GBP) currentRate *= Pound;
            if (currency2 == EnumCurrency.CNY) currentRate *= Yuan;

            currentRate = Math.Round(currentRate, 2);

            //normally the decimal point would be "," so we replace it with "."
            string currentRate2 = currentRate.ToString();
            currentRate2 = currentRate2.Replace(",", ".");

            return currentRate2;
        }
    }
}
