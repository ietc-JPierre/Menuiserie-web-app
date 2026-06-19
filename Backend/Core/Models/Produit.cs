namespace Core.Models;

public class Produit
{
    public int Id_Produit { get; set; }

    public string Nom_Produit { get; set; } = string.Empty;

    public double Prix_Unitaire_Produit { get; set; }

    public int Id_Categorie { get; set; }
}