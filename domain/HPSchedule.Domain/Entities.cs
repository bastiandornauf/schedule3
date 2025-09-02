namespace HPSchedule.Domain;

public class Patient
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
}

public class Appointment
{
    public long Id { get; set; }
    public long PatientId { get; set; }
    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }
    public string? Notes { get; set; }

    public Patient? Patient { get; set; }
}

public class Invoice
{
    public long Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string Number { get; set; } = string.Empty;
    public long PatientId { get; set; }
    public decimal Total { get; set; }
    public InvoiceStatus Status { get; set; }

    public Patient? Patient { get; set; }
    public List<InvoiceLine> Lines { get; set; } = new();
}

public class InvoiceLine
{
    public long Id { get; set; }
    public long InvoiceId { get; set; }
    public string Label { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Quantity * UnitPrice;
}

public enum InvoiceStatus
{
    Draft = 0,
    Sent = 1,
    Overdue = 2,
    Paid = 3,
    Canceled = 4
}
