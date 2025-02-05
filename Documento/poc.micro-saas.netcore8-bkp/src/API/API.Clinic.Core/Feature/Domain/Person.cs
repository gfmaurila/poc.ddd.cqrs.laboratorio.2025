using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.Exemple1.Core._08.Feature.Domain;

public class Person : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Document { get; set; } // CPF/CNPJ
    public string Address { get; set; }
}

public class HealthcareProfessional : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Specialty { get; set; }
    public string RegistrationNumber { get; set; } // CRM ou outro registro
    public decimal HourlyRate { get; set; }
    public decimal PercentageEarnings { get; set; } // % que o profissional recebe por consulta
    public List<Appointment> Appointments { get; set; } = new();
}

public class Patient : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string MedicalRecord { get; set; } // Informações médicas básicas
    public List<Appointment> Appointments { get; set; } = new();
}

public class Appointment : BaseEntity, IAggregateRoot
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid HealthcareProfessionalId { get; set; }
    public HealthcareProfessional HealthcareProfessional { get; set; }
    public DateTime AppointmentDate { get; set; }
    public decimal ConsultationFee { get; set; }
    public AppointmentStatus Status { get; set; }
    public bool Confirmed { get; set; } // Se não for confirmado, assume-se que o paciente comparecerá
}

public class InventoryItem : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string Supplier { get; set; }
}

public class Notification : BaseEntity, IAggregateRoot
{
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public NotificationType Type { get; set; } // SMS, E-mail, WhatsApp
    public DateTime SentAt { get; set; }
    public bool Acknowledged { get; set; }
}

public enum AppointmentStatus
{
    Scheduled,
    Confirmed,
    Canceled,
    Completed
}

public enum NotificationType
{
    Email,
    SMS,
    WhatsApp
}
