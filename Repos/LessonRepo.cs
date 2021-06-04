using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;

namespace SchoolManagement.API.Data {
    public class LessonRepo : GenericRepo<Lesson>
    {
        public LessonRepo(RepoContext db) : base(db)
        {
        }
        
    }
}