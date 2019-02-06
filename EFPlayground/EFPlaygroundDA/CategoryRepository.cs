using EFPlaygroundBL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlaygroundDA
{
    public class CategoryRepository
    {

        // pobieramy wszystkie kategorie korzystając z DB Contextu
        // dlatego właśnie definiujemy repozytorium
        // żeby taki kod nie walał się po widokach
        public List<Category> GetAll()
        {
            using (var ctx = new WalizkaAppContext())
            {
                return ctx.Categories
                            .Include("Items") //to ważne jeżeli zwracamy obiekt, który ma zależności
                            .ToList<Category>();    
            }
        }

    }
}
