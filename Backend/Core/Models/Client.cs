namespace Core.Models;

public class Client
{
    public int Id_Client { get; set; }
    public string Nom_Client { get; set; } = string.Empty;
    public string Adresse_Client { get; set; } = string.Empty;
    public string Tel_Client { get; set; } = string.Empty;
    public int Id_Type_Client { get; set; }
}