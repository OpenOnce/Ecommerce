using Hydra.Infrastructure.Data;
    
namespace Hydra.Crm.Core.Models.Email
{
    public record EmailInboxAttachmentModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmailInboxId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AttachmentId { get; set; }

    }
}
