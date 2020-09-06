namespace Nop.Web.Hesabe
{

    public static class HesabeConstants
    {
        public const string VERSION = "2.0";

        public const string CHECKOUT_URL = "https://sandbox.hesabe.com/checkout";
        public const string PAYMENT_URL = "https://sandbox.hesabe.com/payment";

        // Get below values from Merchant Panel, Profile section
        public const string ACCESS_CODE = "c333729b-d060-4b74-a49d-7686a8353481";
        public const string MERCHANT_KEY = "PkW64zMe5NVdrlPVNnjo2Jy9nOb7v1Xg";
        public const string MERCHANT_IV = "5NVdrlPVNnjo2Jy9";
        public const string MERCHANT_CODE = "842217";

        // This URL are defined by you to get the response from Payment Gateway
        public const string RESPONSE_URL = "http://localhost:15536/checkout/OpcCompleteRedirectionPayment?paymentStatus=true";
        public const string FAILURE_URL = "http://localhost:15536/checkout/OpcCompleteRedirectionPayment?paymentStatus=false";
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
