using System.ComponentModel.DataAnnotations.Schema;
using WebApplication5.Models.Abstracts;

namespace WebApplication5.Models.Concretes;

public class Person : BaseEntity
{
    public string? FullName { get; set; }

    public string? Desgination { get; set; }


    public string? ImgURl { get; set; }

    [NotMapped]

    public IFormFile? File { get; set; }
}
