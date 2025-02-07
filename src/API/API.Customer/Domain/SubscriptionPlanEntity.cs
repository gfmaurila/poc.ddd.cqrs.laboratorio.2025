namespace API.Customer.Domain;
using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;



public class SubscriptionPlanEntity : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public decimal MonthlyPrice { get; set; }
    public int EmailLimit { get; set; }
    public int SmsLimit { get; set; }
    public int WhatsAppLimit { get; set; }
    public decimal OverageCostPerEmail { get; set; }
    public decimal OverageCostPerSms { get; set; }
    public decimal OverageCostPerWhatsApp { get; set; }
}


