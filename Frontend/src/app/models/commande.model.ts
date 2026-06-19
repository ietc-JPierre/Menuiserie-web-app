export interface Commande {
  id_Commande: number;
  date_Commande: string;
  montant_Paye: number;
  reste_A_Payer: number;
  statut_Commande: string;
  total_Commande: number;
  id_Client: number;
}