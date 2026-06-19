namespace Core.Models;

public class CommandeProduit
{
    public int Id_Produit { get; set; }
    public int Id_Dimension { get; set; }
    public int Id_Commande { get; set; }
    public int Quantite { get; set; }
    public double Prix_Unitaire { get; set; }
}