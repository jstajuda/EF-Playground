using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFPlaygroundBL;

namespace EFPlaygroundDA
{
    public class ParamGroupRepository
    {
        public List<ParamGroup> GetAll()
        {
            using (var ctx = new WalizkaAppContext())
            {
                return ctx.ParamsGroups
                            .Include("Params") //to ważne jeżeli zwracamy obiekt, który ma zależności
                            .ToList<ParamGroup>();
            }
            return new List<ParamGroup>();
        }
    }
}
