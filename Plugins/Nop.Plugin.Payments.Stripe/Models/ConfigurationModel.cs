﻿//using Nop.Plugin.Payments.Stripe.Validators;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Payments.Stripe.Models
{
    //[Validator(typeof(ConfigurationModelValidator))]
    public record ConfigurationModel : BaseNopModel
    {
        #region Ctor

        public ConfigurationModel()
        {

        }

        #endregion

        #region Properties

        [NopResourceDisplayName("Plugins.Payments.Stripe.Fields.SecretKey")]
        public string SecretKey { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Stripe.Fields.PublishableKey")]
        public string PublishableKey { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Stripe.Fields.AdditionalFee")]
        public decimal AdditionalFee { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Stripe.Fields.AdditionalFeePercentage")]
        public bool AdditionalFeePercentage { get; set; }

        #endregion
    }
}