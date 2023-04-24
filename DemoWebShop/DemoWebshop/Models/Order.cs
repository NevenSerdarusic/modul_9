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
    public ApplicationUser User { get; set; } //OVJDE SAM NAPRAVIO GREŠKU..Treba biti: public ApplicationUser? User jer prilikom stvaranja narudžbe me traži User-a da je Required

    [Column(TypeName = "nvarchar(450)")]
    public string? UserId { get; set; }


    //TODO: Billing i Shipping klase sa svojstvima o kupcu (za neprijavljene kupce)
    //Svojstva: Id, FirstName, LastName, Email, Phone, City, Country, PostalCode, Message

    //TODO: Tablica Customers koja je povezana sa ApplicationUser (labava veza!)

    //Dodatak za osobne informacije korisnika (dodano u isti klasu radi jednostavnosti). Ovi property-i su vezani uz formu koju korisnik ispunjava kod narudžbe (Checkout.cshtml)

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, ErrorMessage = "Max 50 characters")]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, ErrorMessage = "Max 50 characters")]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [StringLength(50, ErrorMessage = "Max 100 characters")]
    [EmailAddress]
    [Column(TypeName = "nvarchar(100)")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Column(TypeName = "nvarchar(100)")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Country is required")]
    [Column(TypeName = "nvarchar(150)")]
    public string Country { get; set; }

    [Required(ErrorMessage = "City is required")]
    [Column(TypeName = "nvarchar(150)")]
    public string City { get; set; }

    [Required(ErrorMessage = "Address number name is required")]
    [Column(TypeName = "nvarchar(150)")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Postal code number name is required")]
    [Column(TypeName = "nvarchar(10)")]
    public string PostalCode { get; set; }

    
    [Column(TypeName = "nvarchar(3000)")]
    public string? Message { get; set; }
}
