﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Models;

public partial class Branch
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(200)]
    public string BranchName { get; set; }

    public int CityID { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

    [ForeignKey("CityID")]
    [InverseProperty("Branches")]
    public virtual City City { get; set; }

    [InverseProperty("Branch")]
    public virtual ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
}