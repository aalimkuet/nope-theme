﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Nop.Core;
using Stripe;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Stripe.Services
{
    /// <summary>
    /// Represents the HTTP client to request Stripe services
    /// </summary>
    public partial class StripeHttpClient
    {
        #region Fields

        private readonly HttpClient _httpClient;
        private readonly StripePaymentSettings _StripeStandardPaymentSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;


        #endregion

        #region Ctor

        public StripeHttpClient(HttpClient client,
            StripePaymentSettings StripeStandardPaymentSettings,
            IHttpContextAccessor httpContextAccessor)
        {
            //configure client
            client.Timeout = TimeSpan.FromSeconds(20);
            client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, $"nopCommerce-{NopVersion.CURRENT_VERSION}");

            _httpClient = client;
            _StripeStandardPaymentSettings = StripeStandardPaymentSettings;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods


      

    /// <summary>
    /// Gets PDT details
    /// </summary>
    /// <param name="tx">TX</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the asynchronous task whose result contains the PDT details
    /// </returns>
    public async Task<string> GetPdtDetailsAsync(string tx)
        {
            //get response
            var url = _StripeStandardPaymentSettings.UseSandbox ?
                "https://www.sandbox.Stripe.com/us/cgi-bin/webscr" :
                "https://www.Stripe.com/us/cgi-bin/webscr";
            var requestContent = new StringContent($"cmd=_notify-synch&at={_StripeStandardPaymentSettings.PdtToken}&tx={tx}",
                Encoding.UTF8, MimeTypes.ApplicationXWwwFormUrlencoded);
            var response = await _httpClient.PostAsync(url, requestContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Verifies IPN
        /// </summary>
        /// <param name="formString">Form string</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the asynchronous task whose result contains the IPN verification details
        /// </returns>
        public async Task<string> VerifyIpnAsync(string formString)
        {
            //get response
            var url = _StripeStandardPaymentSettings.UseSandbox ?
                "https://ipnpb.sandbox.Stripe.com/cgi-bin/webscr" :
                "https://ipnpb.Stripe.com/cgi-bin/webscr";
            var requestContent = new StringContent($"cmd=_notify-validate&{formString}",
                Encoding.UTF8, MimeTypes.ApplicationXWwwFormUrlencoded);
            var response = await _httpClient.PostAsync(url, requestContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        #endregion
    }
}