using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DemoWebshop.Areas.Identity.Data;

namespace DemoWebshop.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Subtotal { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Tax { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Total { get; set; }

    //AplicationUser klasa je klasa korisnika povezana s Identity paketom (za prijavljenje kupce)
    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; }

    [Column(TypeName = "nvarchar(450)")]
    public string? UserId { get; set; }


    //TODO: Billing i Shipping klase sa svojstvima o kupcu (za neprijavljene kupce)
    //Svojstva: Id, FirstName, LastName, Email, Phone, City, Country, PostalCode, Message

    //TODO: Tablica Customers koja je povezana sa ApplicationUser (labava veza!)

}
