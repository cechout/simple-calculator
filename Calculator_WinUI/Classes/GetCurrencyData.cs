using System;
using System.Globalization;
using System.Xml;

namespace Calculator_WinUI.Classes
{
    class GetCurrencyData
    {
        //this variable can be used in the entire class
        private XmlTextReader reader1;

        //In the constructor we set the URLString when we create an object of the class GetCurrencyData
        public GetCurrencyData()
        {
            String URLString = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml?69f7107f63e7ce4e4f9a922f93f74b4d";
            reader1 = new XmlTextReader(URLString);
        }

        public double GetDollar()
        {
            double dollar = 0;

            while (reader1.Read())
            {
                if (reader1.NodeType == XmlNodeType.Element && reader1.Name == "Cube" && reader1.AttributeCount == 2 && reader1.GetAttribute(0) == "USD")
                {
                    dollar = Double.Parse(reader1.GetAttribute(1), CultureInfo.InvariantCulture);
                    break;
                }
            }
            return dollar;
        }

        public double GetYen()
        {
            double yen = 0;

            while (reader1.Read())
            {
                if (reader1.NodeType == XmlNodeType.Element && reader1.Name == "Cube" && reader1.AttributeCount == 2 && reader1.GetAttribute(0) == "JPY")
                {
                    yen = Double.Parse(reader1.GetAttribute(1), CultureInfo.InvariantCulture);
                    break;
                }
            }
            return yen;
        }

        public double GetKoruna()
        {
            double koruna = 0;

            while (reader1.Read())
            {
                if (reader1.NodeType == XmlNodeType.Element && reader1.Name == "Cube" && reader1.AttributeCount == 2 && reader1.GetAttribute(0) == "CZK")
                {
                    koruna = Double.Parse(reader1.GetAttribute(1), CultureInfo.InvariantCulture);
                    break;
                }
            }
            return koruna;
        }

        public double GetPound()
        {
            double pound = 0;

            while (reader1.Read())
            {
                if (reader1.NodeType == XmlNodeType.Element && reader1.Name == "Cube" && reader1.AttributeCount == 2 && reader1.GetAttribute(0) == "GBP")
                {
                    pound = Double.Parse(reader1.GetAttribute(1), CultureInfo.InvariantCulture);
                    break;
                }
            }
            return pound;
        }

        public double GetYuan()
        {
            double yuan = 0;

            while (reader1.Read())
            {
                if (reader1.NodeType == XmlNodeType.Element && reader1.Name == "Cube" && reader1.AttributeCount == 2 && reader1.GetAttribute(0) == "CNY")
                {
                    yuan = Double.Parse(reader1.GetAttribute(1), CultureInfo.InvariantCulture);
                    break;
                }
            }
            return yuan;
        }
    }
}
