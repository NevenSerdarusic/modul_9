﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebshop.Models;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; }

    [Required]
    public int ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product? Product { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Price { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Quantity { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Total { get; set; }




}
