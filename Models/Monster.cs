using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csci340lab8.Models;

public class Monster
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Name { get; set; } = string.Empty;

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string Type { get; set; } = string.Empty;

    [Range(1, 30)]
    public int Level { get; set; }
}