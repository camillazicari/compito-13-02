using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace compito_13_02.models
{
    public static class Utente
    {

        public static string Username { get; set; } = "";
        public static string Password { get; set; } = "";
        public static DateTime MomentoAutenticazione { get; set; }
        public static List<DateTime> Storico { get; set; } = new List<DateTime>();



        public static void Operazioni()
        {
            Console.WriteLine("============= OPERAZIONI =============");

            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1. LOGIN");
            Console.WriteLine("2. LOGOUT");
            Console.WriteLine("3. VERIFICA DATA E ORA LOGIN");
            Console.WriteLine("4. LISTA ACCESSI");
            Console.WriteLine("5. ESCI");

            Console.WriteLine("======================================");

            int.TryParse(Console.ReadLine(), out int scelta);

            if (scelta > 5 || scelta == 0)
            {

                Console.WriteLine("Nessuna scelta effettuata, scegliere un numero valido.");
                Operazioni();

            }

            switch (scelta)
            {
                case 1:
                    if(Username != "" && Password != "")
                    {
                        Console.WriteLine("Utente già autenticato.");
                        Operazioni();
                    } else
                    {
                        Login();
                    }
                    break;
                case 2:
                    if (Username != "" && Password != "")
                    {
                        Logout();
                    }
                    else
                    {
                        Console.WriteLine("Nessun utente loggato. Eseguire il login.");
                        Operazioni();
                    }
                    break;
                case 3:
                    if (Username != "" && Password != "")
                    {
                        DataOra();
                    }
                    else
                    {
                        Console.WriteLine("Impossibile verificare data e ora del login, nessun utente loggato.");
                        Operazioni();
                    }
                    break;
                case 4:
                    if (Username != "" && Password != "")
                    {
                        ListaAccessi();
                    }
                    else
                    {
                        Console.WriteLine("Nessun utente loggato. Effettuare il login per visualizzare la lista accessi.");
                        Operazioni();
                    }
                    break;
                case 5:
                    Console.WriteLine("Arrivederci!");
                    break;
            }

        }

        public static void Login()
        {
        repeat:
            Console.WriteLine("Imposta il tuo username");
            string user = Console.ReadLine();
            if (user != "" && user != " ")
            {
                Username = user;
                MomentoAutenticazione = DateTime.Now;
                Storico.Add(MomentoAutenticazione);
                Console.WriteLine("Username scelto: " + Username);
            }
            else
            {
                Console.WriteLine("L'username scelto non è valido");
                goto repeat;
            }
        repeat2:
            Console.WriteLine("Inserisci la tua password: ");
            string pass = Console.ReadLine();
            Console.WriteLine("Ripeti password: ");
            string repeatPw = Console.ReadLine();
            if (repeatPw == pass)
            {
                Password = repeatPw;
                Console.WriteLine("Password corretta, autenticazione riuscita!");
                Operazioni();
            }
            else
            {
                Console.WriteLine("Le password non coincidono");
                goto repeat2;
            }
        }

        public static void Logout()
        {
                Username = "";
                Password = "";
                Console.WriteLine("Logout eseguito correttamente");
                Operazioni();
        }

        public static void DataOra()
        {
            if (Username != "" && Password != "")
            {
                Console.WriteLine("Utente: " + Username + ", Data e ora dell'autenticazione: " + MomentoAutenticazione);
                Operazioni();
            }
            else
            {
                Console.WriteLine("Nessun utente autenticato trovato, effettuare il login.");
                Login();
            }

        }

        public static void ListaAccessi()
        {
            Console.WriteLine(Username + ", ecco lo storico dei tuoi login:");
            foreach (DateTime aut in Storico)
            {
                    Console.WriteLine(aut);
                
            }
        }
    }
}