namespace MbedCloud.SDK.Entities
{
    using System.Collections.Generic;
    using System;
    using MbedCloud.SDK.Enums;
    using MbedCloud.SDK.Entities;

    /// <summary>
    /// SubtenantAccount
    /// </summary>
    public class SubtenantAccount
    {
        /// <summary>
        /// address_line1
        /// </summary>
        public string AddressLine1
        {
            get;
            set;
        }

        /// <summary>
        /// address_line2
        /// </summary>
        public string AddressLine2
        {
            get;
            set;
        }

        /// <summary>
        /// admin_email
        /// </summary>
        public string AdminEmail
        {
            get;
            set;
        }

        /// <summary>
        /// admin_full_name
        /// </summary>
        public string AdminFullName
        {
            get;
            set;
        }

        /// <summary>
        /// admin_id
        /// </summary>
        public string AdminId
        {
            get;
            set;
        }

        /// <summary>
        /// admin_key
        /// </summary>
        public string AdminKey
        {
            get;
            set;
        }

        /// <summary>
        /// admin_name
        /// </summary>
        public string AdminName
        {
            get;
            set;
        }

        /// <summary>
        /// admin_password
        /// </summary>
        public string AdminPassword
        {
            get;
            set;
        }

        /// <summary>
        /// aliases
        /// </summary>
        public List<string> Aliases
        {
            get;
            set;
        }

        /// <summary>
        /// city
        /// </summary>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// company
        /// </summary>
        public string Company
        {
            get;
            set;
        }

        /// <summary>
        /// contact
        /// </summary>
        public string Contact
        {
            get;
            set;
        }

        /// <summary>
        /// contract_number
        /// </summary>
        public string ContractNumber
        {
            get;
            set;
        }

        /// <summary>
        /// country
        /// </summary>
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// created_at
        /// </summary>
        public DateTime? CreatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// custom_fields
        /// </summary>
        public object CustomFields
        {
            get;
            set;
        }

        /// <summary>
        /// customer_number
        /// </summary>
        public string CustomerNumber
        {
            get;
            set;
        }

        /// <summary>
        /// display_name
        /// </summary>
        public string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// email
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// end_market
        /// </summary>
        public string EndMarket
        {
            get;
            set;
        }

        /// <summary>
        /// expiration_warning_threshold
        /// </summary>
        public string ExpirationWarningThreshold
        {
            get;
            set;
        }

        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// idle_timeout
        /// </summary>
        public string IdleTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// limits
        /// </summary>
        public object Limits
        {
            get;
            set;
        }

        /// <summary>
        /// mfa_status
        /// </summary>
        public SubtenantAccountMfaStatusEnum? MfaStatus
        {
            get;
            set;
        }

        /// <summary>
        /// notification_emails
        /// </summary>
        public List<string> NotificationEmails
        {
            get;
            set;
        }

        /// <summary>
        /// parent_id
        /// </summary>
        public string ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// password_policy
        /// </summary>
        public object PasswordPolicy
        {
            get;
            set;
        }

        /// <summary>
        /// phone_number
        /// </summary>
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// policies
        /// </summary>
        public List<object> Policies
        {
            get;
            set;
        }

        /// <summary>
        /// postal_code
        /// </summary>
        public string PostalCode
        {
            get;
            set;
        }

        /// <summary>
        /// reason
        /// </summary>
        public string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// reference_note
        /// </summary>
        public string ReferenceNote
        {
            get;
            set;
        }

        /// <summary>
        /// sales_contact
        /// </summary>
        public string SalesContact
        {
            get;
            set;
        }

        /// <summary>
        /// state
        /// </summary>
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public SubtenantAccountStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// sub_accounts
        /// </summary>
        public List<SubtenantAccount> SubAccounts
        {
            get;
            set;
        }

        /// <summary>
        /// template_id
        /// </summary>
        public string TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// tier
        /// </summary>
        public string Tier
        {
            get;
            set;
        }

        /// <summary>
        /// updated_at
        /// </summary>
        public DateTime? UpdatedAt
        {
            get;
            set;
        }

        /// <summary>
        /// upgraded_at
        /// </summary>
        public DateTime? UpgradedAt
        {
            get;
            set;
        }
    }
}