using Common.Core._08.Domain;

namespace API.Customer.Domain;

public class MessageUsageItemEntity : BaseEntity
{
    public Guid MessageUsageId { get; set; }
    public MessageUsageEntity MessageUsage { get; set; }
    public string MessageType { get; set; } // Email, SMS, WhatsApp
    public int Quantity { get; set; }
    public decimal CostPerUnit { get; set; }
    public decimal TotalCost => Quantity * CostPerUnit;
}


