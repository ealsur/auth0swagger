//Mapping JSON appsettings.json to a class
public class Auth0Settings
{
    public string Domain { get; set; }
    public string CallbackUrl { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}