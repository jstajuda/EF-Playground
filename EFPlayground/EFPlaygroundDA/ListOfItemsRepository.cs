using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPlaygroundBL;

namespace EFPlaygroundDA
{
    public class ListOfItemsRepository
    {
        public List<ListOfItems> GetAll()
        {
             using (var ctx = new WalizkaAppContext())
            {
                return ctx.ListsOfItems
                            .ToList<ListOfItems>();    
            }
        }


    }
}
