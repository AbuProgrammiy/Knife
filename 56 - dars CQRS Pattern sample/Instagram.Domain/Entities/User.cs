using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public int PostsCount { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string PicturePath { get; set; }
    }
}
