namespace Core.Models;

public class Chantier
{
    public int Id_Chantier { get; set; }
    public string Nom_Chantier { get; set; } = string.Empty;
    public string Rue { get; set; } = string.Empty;
    public string Date_Debut_Chantier { get; set; } = string.Empty;
    public string Date_Fin_Chantier { get; set; } = string.Empty;
    public string Code_Postal { get; set; } = string.Empty;
}