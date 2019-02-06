using EFPlaygroundBL;
using EFPlaygroundDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlayground
{
    public class Program
    {

        public static void Main()
        {
            // wkurzająca rzecz u mnie występuje
            // w WalizkaAppContext mamy ustawione usuwanie starej i tworzenie nowej przy każdym uruchomieniu aplikacji
            // ale jeżeli mam połączenie w server explorer w visual studio
            // to nawet jeśli je zamknę - dostaję błąd przy próbie usunięcia bazy
            // więc dorzuciłem funkcje wyłączające i uruchamiające LocalDb w celu usunięcia połączeń
            // mam nadzieję, że u ciebie zadziała ;)
            RestartLocalDBServer();

            //tworzymy obiekt viewModel
            //przy większej ilości widoków można tworzyć różne
            //w zależności od tego na jakich danych będziemy chcieli operować
            //u nas jest tego tak mało, że można wpakować do jednego ;)
            var viewModel = new ViewModel();

            //tworzymy widok, który w konstruktorze przyjmuje obiekt viewModel
            //i dalej korzysta z niego przy manipulowaniu na danych
            //(nic nie robi bezpośrednio - tylko przez viewModel)
            //(a viewModel też nic bezpośrednio - tylko przez repozytoria)
            //czyli: view -> viewModel -> repozytorium -> baza danych
            //przy małych apkach to trochę dużo pracy, ale wszystko ma tendencję do rozrastania się ;)
            var mainView = new View(viewModel);

            //i włala - wszystko działa
            mainView.Render();

            //teraz możemy w tym projekcie zrobić wszystkie metody repozytorium
            //poeksperymentować, przetestować
            //dorzucić przykładowe dane
            //i wykorzystać to wszystko nie mieszając na naszym głównym repo

            Console.ReadKey();
        }







        public static void RestartLocalDBServer(bool print = false)
        {
            string result = StopLocalDBServer();
            result += '\n';
            result += StartLocalDBServer();

            if(print) Console.WriteLine(result);
        }

        public static string StopLocalDBServer()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C sqllocaldb stop mssqllocaldb";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            return "LocalDB stopped";
        }

        public static string StartLocalDBServer()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C sqllocaldb start mssqllocaldb";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            return "LocalDB started";
        }


    }
}
