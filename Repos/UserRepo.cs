using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
namespace SchoolManagement.API.Data
{
    public class UserRepo : GenericRepo<User>
    {
        public UserRepo(RepoContext db) : base(db)
        {
        }

        internal User[] getUsers(){
            return db.Users.ToArray();
        }

    }

}