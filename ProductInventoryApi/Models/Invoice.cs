using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Invoice
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Total { get; set; }

    [Range(0, double.MaxValue)]
    public decimal PaidAmount { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Balance { get; set; }

    public ICollection<InvoiceItem> InvoiceItems { get; set; }
}
