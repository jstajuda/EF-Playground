﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlayground
{


    public class View
    {

        // przygotowujemy sobie pole na view model
        // chyba nie powinno być publiczne (ale różnie bywa ;) )
        private ViewModel viewModel;

        // w konstruktorze przejmujemy podany view model
        // (widok inicjujemy w punkcie wejsciowym programu - tutaj Program.cs)
        // żeby odnieść to do wpf, możemy potraktować Program.cs jako MainView.xaml
        // a View.cs jako MainView.xaml.cs (czyli code-behind)
        // jak popatrzysz na to co zrobiłem do tej pory w wpf to zobaczysz bardzo podobne konstrukcje
        public View(ViewModel model)
        {
            viewModel = model;
        }

        public void Render()
        {
            //w widoku już nie pobieramy danych z DB Context
            //korzystamy z już przygotowanych w obiekcie viewModel
            //a pobranych z bazy danych przez repozytorium
            var cats = viewModel.Categories;

            //działamy na danych - np wyświetlamy
            foreach (var cat in cats)
            {
                Console.WriteLine("=========");
                Console.WriteLine($"Kategoria-{cat.Id}: {cat.Name} [{cat.Description}]");
                foreach (var item in cat.Items)
                {
                    Console.WriteLine($"--{item.Name} [{item.Description}]");
                }
            }
        }

    }
}
