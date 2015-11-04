using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LINQExamplesService : BaseService
    {
        public LINQExamplesService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<Student> LeftJoin()
        {
            // join student to school and show all students even without schools

            var result = from s in _unitOfWork.Repository<Student>().GetAll()
                         join sch in _unitOfWork.Repository<School>().GetAll() on s.School.Id equals sch.Id into j1
                         from j2 in j1.DefaultIfEmpty()
                         select s;

            return result;
        }

        public IQueryable<School> RightJoin()
        {
            // join school to student and show all schools even without students

            var result = from sch in _unitOfWork.Repository<School>().GetAll()
                         join s in _unitOfWork.Repository<Student>().GetAll() on sch.Id equals s.School.Id into j1
                         from j2 in j1.DefaultIfEmpty()
                         select sch;

            return result;
        }

        public IQueryable<GroupByDto<Student>> GroupByQuery()
        {
            // group students by school
            var result = from s in _unitOfWork.Repository<Student>().GetAll()
                         group s by s.School.Id into g
                         select new GroupByDto<Student>() { Key = g.Key, Values = g.ToList() };

            return result;
        }

        public IQueryable<GroupByDto<Student>> GroupByLambda()
        {
            // group students by school
            var result = _unitOfWork.Repository<Student>().GetAll().GroupBy(x => x.School.Id).Select(x => new GroupByDto<Student>() { Key = x.Key, Values = x.ToList() });

            return result;
        }
    }

    public class GroupByDto<T>
    {
        public int? Key { get; set; }
        public List<T> Values { get; set; }
    }
}
