using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Models;
using System.Data.Entity;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (SchoolContext ctx = new SchoolContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //School s1 = new School() { Name = "Coopers", Address = "Royal Parade" };
                //EntityState st1 = ctx.Entry(s1).State;
                //ctx.Schools.Add(s1);


                //ctx.SaveChanges();

                School s2 = ctx.Schools.Include(x => x.Students).Where(x => x.Id == 1).FirstOrDefault();


                EntityState st2 = ctx.Entry(s2).State;
                s2.Name = "change";
                st2 = ctx.Entry(s2).State;
            }

            using (UnitOfWork uow = new UnitOfWork())
            {
                School s1 = uow.Repository<School>().GetByID(1);

                uow.Repository<School>().Insert(new School() { Name = "Coopers", Address = "Royal Parade" });
                uow.Save(); 
            }
        }
    }
}
