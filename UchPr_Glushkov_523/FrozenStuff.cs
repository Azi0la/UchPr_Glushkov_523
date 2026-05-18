using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchPr_Glushkov_523
{
    public class FrozenStuff
    {
        public string type {  get; set; }
        public string name { get; set; }
        public string motive { get; set; }

        public FrozenStuff(User user)
        {
            type = "Пользователь";
            name = user.Name;
            motive = user.Motive.Name;
        }

        public FrozenStuff(Book book)
        {
            type = "Книга";
            name = book.Title;
            motive = book.Motive.Name;
        }

        public FrozenStuff(Review rev)
        {
            type = "Комментарий";
            name = rev.User.Name;
            motive = rev.Motive.Name;
        }
    }
}
