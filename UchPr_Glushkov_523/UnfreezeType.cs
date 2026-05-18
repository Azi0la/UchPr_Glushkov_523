using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchPr_Glushkov_523
{
    public partial class UnfreezeRequest
    {
        public string UnfreezeType
        {
            get
            {
                if (BookID != null) return ("Книга");
                else return ("Пользователь");

            }
        }

        public string UnfreezeName
        {
            get
            {
                if (BookID != null) return Book.Title;
                else return User.Name;

            }
        }
    }
}
