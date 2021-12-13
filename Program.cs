using System;
using System.Collections.Generic;
using System.Linq;

namespace KataCompte
{
    class Client
    {
        public string nom { get; private set; }
        public string prenom { get; private set; }
        public string ville { get; private set; }
        public string pays { get; private set; }
        public int telephone { get; private set; }
        

        public Client(string nom, string prenom, string ville, string pays)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.ville = ville;
            this.pays = pays;
            
        }
        


    }
    class Operation
    {
        public string note { get; private set; }
        public double montant { get; private set; }
        public DateTime date { get; private set; }

        public Operation (string note, double montant, DateTime date)
        {
            this.note = note;
            this.montant = montant;
            this.date = date;
        }


    }
    class Compte :Client
    {
        public int Numero { get; private set; }
        public double Solde { get; private set; }

        public List<Operation> Releve = new List<Operation>();
       
        


        public Compte (string nom, string prenom, string ville, string pays, int numero, double solde) : base(nom, prenom, ville,pays)
        {
            this.Numero = numero;
            this.Solde = solde;
            
        }
        public void Depot (double montant)
        {

            Solde += montant;
            Console.WriteLine("Votre nouveau solde est : " + Solde + " $ ");

        }
        public void Retrait (double montant)
        {
            if (Solde < montant)
            {
                Console.WriteLine("Votre solde est insuffisant pour retirer cette somme ");

            }
            else
            {
                Solde -= montant;
                Console.WriteLine("Votre nouveau solde est : " + Solde + " $ ");

            }
            
        }
        public void Affichage ()
        {
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("   Relevé de compte ");
            Console.WriteLine("Titulaire Mr : " + nom + " " + prenom);
            Console.WriteLine("Pays : " + pays + "     " + "Ville : " + ville);
            Console.WriteLine("Numéro de carte : " + Numero);
            foreach (var item in Releve)
            {
                Console.WriteLine("Operation : " + item.note + "      " + "montant : " + item.montant + "     " + "éffectué le : " + item.date);
                
            }
            Console.WriteLine("Votre solde actuel est de " + Solde + "$");



        }
        


    }
    internal class Program
    {
        static void Affichage2 ()
        {
            Console.WriteLine("****************************************************************************");


            Console.WriteLine("Voulez vous faire une nouvelle opération");

            Console.WriteLine("1 - pour faire un dépôt");
            Console.WriteLine("2 - pour faire un retrait");
            Console.WriteLine("3 - pour imprimer votre releve");
            Console.WriteLine("4 - pour quitter");
            Console.Write("Faite votre choix : ");

        }
        static void Main(string[] args)
        {
            var compte1 = new Compte("Dubois", "Jean", "Paris", "France", 112556354, 500);
            var operat = new Operation("initial", 500, DateTime.Now);
            compte1.Releve.Add(operat);
            
           
            Console.WriteLine("  ---------- !!! Bienvenue sur votre guichet automatique !!! ---------");
           
            

            int choix = 0;
            
            while (true)
            {

                Affichage2();
                string choix1 = Console.ReadLine();
                try
                {
                    choix = int.Parse(choix1);
                    if (choix != 1 && choix !=2 && choix !=3 && choix != 4)
                    {
                        Console.WriteLine("ERREUR : Vous devez choisir un nombre entre 1 et 4");

                    }
                    if (choix == 4)
                    {
                        Console.WriteLine("Aurevoir, passez une agréable journée");
                        break;
                    }
                    if (choix == 1)
                    {
                        double somme;
                        Console.Write("Entrez la somme que vous souhaitez déposer : ");
                        somme = double.Parse(Console.ReadLine());
                        
                        compte1.Depot(somme);
                        var opera1 = new Operation("dépot", somme, DateTime.Now);
                        compte1.Releve.Add(opera1);
                        
                        


                    }

                    if (choix == 2)
                    {
                        double somme2;
                        Console.Write("Entrez le montant à retirer : ");
                        somme2 = double.Parse(Console.ReadLine());
                        if(somme2 > compte1.Solde)
                        {
                            Console.WriteLine("Votre solde est insuffisant pour retirer cette somme ");
                        }
                        else
                        {
                            compte1.Retrait(somme2);
                            var opera2 = new Operation("Retrait", somme2, DateTime.Now);
                            compte1.Releve.Add(opera2);

                        }
                        
                        
                        

                    }
                    if (choix == 3)
                    {
                        compte1.Affichage();
                        break;
                        
                    }

                    
                }
                catch
                {
                    Console.WriteLine("ERREUR : Vous devez choisir un nombre entre 1 et 4");
                }

            }
            
            















        }
    }
}
