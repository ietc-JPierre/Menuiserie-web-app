namespace Core.Models;

public class Commande
{
    public int Id_Commande { get; set; }
    public string Date_Commande { get; set; } = string.Empty;
    public double Montant_Paye { get; set; }
    public double Reste_A_Payer { get; set; }
    public string Statut_Commande { get; set; } = string.Empty;
    public double Total_Commande { get; set; }
    public int Id_Client { get; set; }
}