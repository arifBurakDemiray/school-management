using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SchoolManagement.API.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.API.Data  {
    public abstract class GenericRepo<T> : IRepo<T> where T : AbstractEntity {
        protected readonly RepoContext db;

        public GenericRepo(RepoContext db) {
            this.db = db;
        }
        public async Task<T> GetById(int id){
            return await db.Set<T>().FindAsync(id);;
        }

        public async void SaveChanges()
        {
            await db.SaveChangesAsync();
        }

         public List<T> GetByPredicate(Expression<System.Func<T, bool>> predicate) {
            return db.Set<T>().Where(predicate).ToList();
        } 

        public async Task<List<T>> List(Expression<System.Func<T, bool>> predicate) {
            return await db.Set<T>().Where(predicate).ToListAsync();
        }
        
        public async void Add(T data) {
            var added = db.Set<T>().AddAsync(data);
            await db.SaveChangesAsync();
        }
 
        public async Task<T> Update(T data) {
            db.Entry(data).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return data;
        }
        

        public async Task<bool> Delete(T data) {
            db.Set<T>().Remove(data);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAll(){
            return await db.Set<T>().ToListAsync();
        }
    }
}