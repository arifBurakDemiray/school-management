using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
namespace SchoolManagement.API.Data
{
    public class StudentRepo : GenericRepo<Student>
    {
        public StudentRepo(RepoContext db):base(db){}
        
    }
}