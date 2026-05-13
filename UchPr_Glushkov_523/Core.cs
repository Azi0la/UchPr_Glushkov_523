using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchPr_Glushkov_523
{
    internal class Core
    {
        public static UchPr_GlushkovEntities1 Context = new UchPr_GlushkovEntities1();
        public static void Update()
        {
            Context = new UchPr_GlushkovEntities1();
        }
    }
}
