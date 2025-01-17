﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nop.Plugin.Payments.Stripe.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public object city { get; set; }
        public string country { get; set; }
        public object line1 { get; set; }
        public object line2 { get; set; }
        public object postal_code { get; set; }
        public object state { get; set; }
    }

    public class AmountDetails
    {
        public Tip tip { get; set; }
    }

    public class BillingDetails
    {
        public Address address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public object phone { get; set; }
    }

    public class Card
    {
        public string brand { get; set; }
        public Checks checks { get; set; }
        public string country { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string fingerprint { get; set; }
        public string funding { get; set; }
        public object installments { get; set; }
        public string last4 { get; set; }
        public object mandate { get; set; }
        public string network { get; set; }
        public object three_d_secure { get; set; }
        public object wallet { get; set; }
        public object mandate_options { get; set; }
        public string request_three_d_secure { get; set; }
    }

    public class Charges
    {
        public string @object { get; set; }
        public List<Data> data { get; set; }
        public bool has_more { get; set; }
        public int total_count { get; set; }
        public string url { get; set; }
    }

    public class Checks
    {
        public object address_line1_check { get; set; }
        public object address_postal_code_check { get; set; }
        public string cvc_check { get; set; }
    }

    public class Data
    {
        public Object @object { get; set; }
        public string id { get; set; }
        public int amount { get; set; }
        public int amount_captured { get; set; }
        public int amount_refunded { get; set; }
        public object application { get; set; }
        public object application_fee { get; set; }
        public object application_fee_amount { get; set; }
        public string balance_transaction { get; set; }
        public BillingDetails billing_details { get; set; }
        public string calculated_statement_descriptor { get; set; }
        public bool captured { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public object customer { get; set; }
        public object description { get; set; }
        public object destination { get; set; }
        public object dispute { get; set; }
        public bool disputed { get; set; }
        public object failure_balance_transaction { get; set; }
        public object failure_code { get; set; }
        public object failure_message { get; set; }
        public FraudDetails fraud_details { get; set; }
        public object invoice { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public object on_behalf_of { get; set; }
        public object order { get; set; }
        public Outcome outcome { get; set; }
        public bool paid { get; set; }
        public string payment_intent { get; set; }
        public string payment_method { get; set; }
        public PaymentMethodDetails payment_method_details { get; set; }
        public object receipt_email { get; set; }
        public object receipt_number { get; set; }
        public string receipt_url { get; set; }
        public bool refunded { get; set; }
        public Refunds refunds { get; set; }
        public object review { get; set; }
        public object shipping { get; set; }
        public object source { get; set; }
        public object source_transfer { get; set; }
        public object statement_descriptor { get; set; }
        public object statement_descriptor_suffix { get; set; }
        public string status { get; set; }
        public object transfer_data { get; set; }
        public object transfer_group { get; set; }
    }

    public class FraudDetails
    {
    }

    public class Metadata
    {
    }

    public class Object
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int amount { get; set; }
        public int amount_capturable { get; set; }
        public AmountDetails amount_details { get; set; }
        public int amount_received { get; set; }
        public object application { get; set; }
        public object application_fee_amount { get; set; }
        public object automatic_payment_methods { get; set; }
        public object canceled_at { get; set; }
        public object cancellation_reason { get; set; }
        public string capture_method { get; set; }
        public Charges charges { get; set; }
        public string client_secret { get; set; }
        public string confirmation_method { get; set; }
        public int created { get; set; }
        public string currency { get; set; }
        public object customer { get; set; }
        public object description { get; set; }
        public object invoice { get; set; }
        public object last_payment_error { get; set; }
        public bool livemode { get; set; }
        public Metadata metadata { get; set; }
        public object next_action { get; set; }
        public object on_behalf_of { get; set; }
        public string payment_method { get; set; }
        public PaymentMethodOptions payment_method_options { get; set; }
        public List<string> payment_method_types { get; set; }
        public object processing { get; set; }
        public object receipt_email { get; set; }
        public object review { get; set; }
        public object setup_future_usage { get; set; }
        public object shipping { get; set; }
        public object source { get; set; }
        public object statement_descriptor { get; set; }
        public object statement_descriptor_suffix { get; set; }
        public string status { get; set; }
        public object transfer_data { get; set; }
        public object transfer_group { get; set; }
    }

    public class Outcome
    {
        public string network_status { get; set; }
        public object reason { get; set; }
        public string risk_level { get; set; }
        public int risk_score { get; set; }
        public string seller_message { get; set; }
        public string type { get; set; }
    }

    public class PaymentMethodDetails
    {
        public Card card { get; set; }
        public string type { get; set; }
    }

    public class PaymentMethodOptions
    {
        public Card card { get; set; }
    }

    public class Refunds
    {
        public string @object { get; set; }
        public List<object> data { get; set; }
        public bool has_more { get; set; }
        public int total_count { get; set; }
        public string url { get; set; }
    }

    public class Request
    {
        [JsonProperty("id")]
        public object Id { get; set; }
        [JsonProperty("idempotency_key")]
        public object Idempotency_key { get; set; }
    }

    public class Root
    {
        public string id { get; set; }
        public string @object { get; set; }
        public string api_version { get; set; }
        public int created { get; set; }
        public Data data { get; set; }
        public bool livemode { get; set; }
        public int pending_webhooks { get; set; }
        public Request request { get; set; }
        public string type { get; set; }
    }

    public class Tip
    {
    }


}
