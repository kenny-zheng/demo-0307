﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.EF.EF.dbDemoContext
{
    public partial class SalesbyYearResult
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderID { get; set; }
        [Column("Subtotal", TypeName = "money")]
        public decimal? Subtotal { get; set; }
        [StringLength(30)]
        public string Year { get; set; }
    }
}
