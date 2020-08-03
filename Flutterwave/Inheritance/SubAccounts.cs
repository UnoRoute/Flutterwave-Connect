namespace Flutterwave.Inheritance
{
    public class SubAccounts
    {
        /// <summary>
        ///     This is the ID of the subaccount, you can get it from your dashboard e.g. RS_D87A9EE339AE28BFA2AE86041C6DE70E
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///     This is the ratio value representing the share of the amount you intend to give a subaccount. This is only needed
        ///     when:
        ///     1. You are splitting between more than one subaccount.
        ///     2. You are not passing the exact amount you expect the subaccount to get.
        /// </summary>
        public int? transaction_split_ratio { get; set; }

        /// <summary>
        ///     This represents the type for the commission you would like to charge, if you would like to charge a flat fee pass
        ///     the value as flat. If you would like to charge a percentage pass the value as percentage. When you pass this you
        ///     override the type set as commission when the subaccount was created.
        /// </summary>
        public ITransactionChargeType? transaction_charge_type { get; set; }

        /// <summary>
        ///     The flat or percentage value to charge as commission on the transaction. When you pass this, you override the
        ///     values set as commission when the subaccount was created.
        /// </summary>
        public double? transaction_charge { get; set; }
    }
}