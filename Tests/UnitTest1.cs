using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Models;

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
                ctx.Schools.Add(new School() { Name = "Coopers", Address = "Royal Parade" });
                ctx.SaveChanges();

                School l = ctx.Schools.Find(1);
            }

            using (UnitOfWork uow = new UnitOfWork())
            {
                School s1 = uow.Repository<School>().GetByID(1);

                uow.Repository<School>().Insert(new School() { Id= 3, Name = "Coopers", Address = "Royal Parade" });
                uow.Save(); 
            }
        }
    }
}
