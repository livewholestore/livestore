namespace Nop.Web.Hesabe
{

    public static class HesabeConstants
    {
        public const string VERSION = "2.0";

        public const string CHECKOUT_URL = "https://api.hesabe.com/checkout";
        public const string PAYMENT_URL = "https://api.hesabe.com/payment";

        // Get below values from Merchant Panel, Profile section
        public const string ACCESS_CODE = "6ce42808-53ca-48d9-9e30-6568e8cd9bbf";
        public const string MERCHANT_KEY = "jAvkVmK6XN3e8LyRNJplqL5ZBd0zbwWx";
        public const string MERCHANT_IV = "XN3e8LyRNJplqL5Z";
        public const string MERCHANT_CODE = "27320920";

        // This URL are defined by you to get the response from Payment Gateway
        public const string RESPONSE_URL = "https://www.zadaak.com/checkout/OpcCompleteRedirectionPayment?paymentStatus=true";
        public const string FAILURE_URL = "https://www.zadaak.com/checkout/OpcCompleteRedirectionPayment?paymentStatus=false";
    }

    /// <summary>
    /// Supported payment types by Hesabe
    /// </summary>
    public enum HesabePaymentType
    {
        ChooseLater = 0,
        Knet = 1,
        MPGS = 2
    }
}
