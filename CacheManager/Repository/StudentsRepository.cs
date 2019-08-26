using DataModels.Entities;
using MongoDB.Driver;
using Repository.Interfaces;
using System;
using System.Linq;

namespace Database
{
    namespace Dama.Test.Console
    {
        public class StudentsRepository : BaseRepository<Student>, IStudentsRepository
        {
            public StudentsRepository(IMongoDBClient<Student> client) : base(client)
            {

            }

            public override DeleteResult Delete(Student item)
            {
                return Collection.DeleteMany(r => r.Id == item.Id);
            }

            public override Student Get(Student item)
            {
                return Collection.AsQueryable().Where(r => r.Id == item.Id).FirstOrDefault();
            }
        }
    }

}
