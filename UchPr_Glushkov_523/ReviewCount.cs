using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace UchPr_Glushkov_523
{
        public partial class Book
        {
            public int ReviewCount
            {
                get
                {
                    return Review.Count() ;
                }
            }
        }
}
