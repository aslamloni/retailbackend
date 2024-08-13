namespace Retailer.Common
{
    public static class Helper
    {
        public static decimal CalculateTax(decimal price, decimal rate)
        {
            return price * rate / 100;
        }
    }
}
