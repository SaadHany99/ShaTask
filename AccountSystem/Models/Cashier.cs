﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Models;

[Table("Cashier")]
public partial class Cashier
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(200)]
    public string CashierName { get; set; }

    public int BranchID { get; set; }

    [ForeignKey("BranchID")]
    [InverseProperty("Cashiers")]
    public virtual Branch Branch { get; set; }

    [InverseProperty("Cashier")]
    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}