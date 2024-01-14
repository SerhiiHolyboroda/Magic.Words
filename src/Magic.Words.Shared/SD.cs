using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Shared {
    public static class SD {
        public const string Role_Admin ="Admin";
        public const string Role_Employee = "Employee";
        public const string Role_Default = "Default";
        public const string Role_UserPremium = "UserPremium";

        public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusProcessing = "Processing";
		public const string StatusShipped = "Shipped";
		public const string StatusCanceled = "Canceled";
		public const string StatusRefunded = "Refunded";

		public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approved";
		public const string PaymentApprovedForDelayedPayment = "ApprovedForDelayedPayment";
		public const string PaymentStatusRejected = "Rejected";


	}
}
