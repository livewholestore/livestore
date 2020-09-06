﻿using Newtonsoft.Json;
using System;

namespace Nop.Web.Hesabe
{
    /// <summary>
    /// Response recieved after successfull or failed payment
    /// </summary>
    public partial class HesabePaymentResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("response")]
        public HesabePaymentResponseData Response { get; set; }
    }

    /// <summary>
    /// Response information 
    /// </summary>
    public class HesabePaymentResponseData
    {
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("paymentToken")]
        public string PaymentToken { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("paidOn")]
        public DateTimeOffset PaidOn { get; set; }

        [JsonProperty("orderReferenceNumber")]
        public string OrderReferenceNumber { get; set; }

        [JsonProperty("variable1")]
        public int variable1 { get; set; }

        [JsonProperty("variable2")]
        public int variable2 { get; set; }

        [JsonProperty("variable3")]
        public string variable3 { get; set; }

        [JsonProperty("variable4")]
        public string Variable4 { get; set; }

        [JsonProperty("variable5")]
        public string Variable5 { get; set; }

        [JsonProperty("method")]
        public long Method { get; set; }

        [JsonProperty("administrativeCharge")]
        public string AdministrativeCharge { get; set; }
    }
}
