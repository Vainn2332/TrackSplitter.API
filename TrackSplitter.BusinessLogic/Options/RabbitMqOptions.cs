using System.ComponentModel.DataAnnotations;

namespace TrackSplitter.BusinessLogic.Options;

public class RabbitMqOptions
{
    public const string SectionName = "RabbitMqOptions";

    [Required]
    public required string ServerHost { get; set; }

    [Required]
    public required string UserName { get; set; }

    [Required]
    public required string Password { get; set; }
}
