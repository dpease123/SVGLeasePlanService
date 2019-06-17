using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService
{
    public static class Utilities
    {
        public static dynamic GetCenterFloorFromFileName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;

            if (name.Length < 3) return null;

            dynamic expando = new ExpandoObject();
            expando.CtrAbbr = name.Substring(0, 3);
            expando.Floor = int.Parse(name.Substring(3));
            return expando;
        }
    }
}
