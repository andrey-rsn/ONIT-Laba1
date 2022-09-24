
using System.ComponentModel.DataAnnotations;

namespace ONIT_Laba1.Data.Models;

public class Song
{
    [Key]
    public int SongId { get; set; }

    public string Name { get; set; }

    public string Genre { get; set; }

    public int AuditionsQuantity { get; set; }
}
