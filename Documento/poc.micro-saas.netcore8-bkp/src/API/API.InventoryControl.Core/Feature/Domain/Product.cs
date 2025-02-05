using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Exemple1.Core._08.Feature.Domain;

public class Product : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string SKU { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int StockQuantity { get; set; }
    public int MinStockLevel { get; set; }
    public List<StockMovement> StockMovements { get; set; } = new();
}

public class Category : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Product> Products { get; set; } = new();
}

public class Supplier : BaseEntity, IAggregateRoot
{
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public List<Product> SuppliedProducts { get; set; } = new();
}

public class PurchaseOrder : BaseEntity, IAggregateRoot
{
    public Guid SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public List<PurchaseOrderItem> Items { get; set; } = new();
}

public class PurchaseOrderItem : BaseEntity
{
    public Guid PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class StockMovement : BaseEntity, IAggregateRoot
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public MovementType Type { get; set; }
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public string Reason { get; set; }
}

public enum MovementType
{
    Entry,
    Exit,
    Adjustment
}

public enum OrderStatus
{
    Pending,
    Approved,
    Received,
    Cancelled
}
