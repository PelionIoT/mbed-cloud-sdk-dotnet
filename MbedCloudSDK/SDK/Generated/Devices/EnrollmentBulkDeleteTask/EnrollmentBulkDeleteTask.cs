namespace MbedCloud.SDK.Entities
{
    using System;
    using MbedCloud.SDK.Enums;

    /// <summary>
    /// EnrollmentBulkDeleteTask
    /// </summary>
    public class EnrollmentBulkDeleteTask
    {
        /// <summary>
        /// account_id
        /// </summary>
        public string AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// completed_at
        /// </summary>
        public DateTime? CompletedAt
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
        /// errors_count
        /// </summary>
        public int? ErrorsCount
        {
            get;
            set;
        }

        /// <summary>
        /// errors_report_file
        /// </summary>
        public string ErrorsReportFile
        {
            get;
            set;
        }

        /// <summary>
        /// full_report_file
        /// </summary>
        public string FullReportFile
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
        /// processed_count
        /// </summary>
        public int? ProcessedCount
        {
            get;
            set;
        }

        /// <summary>
        /// status
        /// </summary>
        public EnrollmentBulkDeleteTaskStatusEnum? Status
        {
            get;
            set;
        }

        /// <summary>
        /// total_count
        /// </summary>
        public int? TotalCount
        {
            get;
            set;
        }
    }
}