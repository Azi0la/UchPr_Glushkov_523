using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchPr_Glushkov_523
{
    public partial class Complaint
    {
        public string CompType 
        { 
            get
            {
                if (BookId != null) return ("Книга");
                else if (TargetUserId != null) return ("Пользователь");
                else return ("Отзыв");
            }
        }
        public string CompName
        {
            get
            {
                if (BookId != null) return Book.Title;
                else if (TargetUserId != null) return User.Name;
                else return Review.Text;
            }
        }
    }
}
