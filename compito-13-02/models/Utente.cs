using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compito_13_02.models
{
    public class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public void Operazioni()
        {
            Console.WriteLine("============= OPERAZIONI =============");

            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1. LOGIN");
            Console.WriteLine("2. LOGOUT");
            Console.WriteLine("3. VERIFICA DATA E ORA LOGIN");
            Console.WriteLine("4. LISTA ACCESSI");
            Console.WriteLine("5. ESCI");

            Console.WriteLine("======================================");

            bool boolean = int.TryParse(Console.ReadLine(), out int scelta);

            if (scelta > 5 || scelta == 0)
            {

                Console.WriteLine("Nessuna scelta effettuata, arrivederci!");
                
            }

            switch(scelta)
            {
                case 1:
                    Login();
                    break;
            }

        }

        public void Login()
        {
            repeat:
            Console.WriteLine("Imposta il tuo username");
            string user = Console.ReadLine();
            if (user != "" && user != " ") {
                Username = user;
                Console.WriteLine("Username scelto: " + Username); }
            else {
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
                Console.WriteLine("Password corretta, autenticazione riuscita!");
                Password = repeatPw;
            } else
            {
                Console.WriteLine("Le password non coincidono");
                goto repeat2;
            }
        }
    }
}
