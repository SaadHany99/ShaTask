﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccountSystem.Models;

public partial class InvoiceDetail
{
    [Key]
    public long ID { get; set; }

    public long InvoiceHeaderID { get; set; }

    [Required]
    [StringLength(200)]
    public string ItemName { get; set; }

    public double ItemCount { get; set; }

    public double ItemPrice { get; set; }

    [ForeignKey("InvoiceHeaderID")]
    [InverseProperty("InvoiceDetails")]
    public virtual InvoiceHeader InvoiceHeader { get; set; }
}