using EFPlaygroundBL;
using EFPlaygroundDA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlayground
{
    public class ViewModel
    {

        // ustawiamy publiczne propertiesy, do których możemy się odnosić w widoku
        // docelowo w wpf ma to być ObservableCollection
        // tutaj lista dla uproszczenia
        public List<Item> Items { get; set; }
        public List<Category> Categories { get; set; }

        // tworzymy instancję repozytorium, żeby później móc na nim działać
        private CategoryRepository catRepo = new CategoryRepository();

        public ViewModel()
        {
            // do publicznej property ładujemy dane z repozytorium
            // teraz w widoku mamy dostęp do pobranych danych
            Categories = catRepo.GetAll();
        }

    }
}
