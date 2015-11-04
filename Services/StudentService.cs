using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : BaseService
    {
        public StudentService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<Student> GetStudentsWithLetter(string letter)
        {
            return _unitOfWork.Repository<Student>().GetAll().Where( x => x.Name.StartsWith(letter));
        }

        public void ChangeStudentName(Student student, string newName)
        {
            student.Name = newName;
            _unitOfWork.Repository<Student>().Update(student);
            _unitOfWork.Save();
        }

        public DbPropertyValues GetDatabaseValues(Student student)
        {
            return _unitOfWork.Repository<Student>().GetDatabaseValues(student);
        }
    }
}
