﻿
namespace Hydra.Crm.Core.Models.Email
{
    public record EmailOutboxModel
    {
        /// <summary>
        /// 
        /// </summary>
        public EmailInboxModel? ReplayTo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ReplayToId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutboxFromAddressModel> EmailOutboxFromAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutboxToAddressModel> EmailOutboxToAddress { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public List<EmailOutboxAttachmentModel> EmailOutboxAttachments { get; set; } = new();


    }

}
