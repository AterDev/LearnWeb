namespace Share.Options;
public class JwtOption
{
    public required string ValidAudiences { get; set; }
    public required string ValidIssuer { get; set; }
    public required string Sign { get; set; }
}
