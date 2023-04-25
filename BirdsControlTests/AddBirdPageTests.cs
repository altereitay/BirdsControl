using Microsoft.VisualStudio.TestTools.UnitTesting;
using BirdsControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsControl.Tests
{
    [TestClass()]
    public class AddBirdPageTests
    {
        [WpfTestMethod]
        public void AddBird_btn_ClickTest()
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();

            Bird birdObject = new Bird()
            {
                Specie = "toki",
                SubSpecie = "super-toki",
                HatchingDate = new DateTime(2004, 06, 03),
                Sex = "male",
                CageNumber = "2"
            };

            db.Bird.Add(birdObject);
            db.SaveChanges();

            var bird = from d in db.Bird
                    where d.Specie == "toki"
                    where d.Sex == "male"
                    where d.SubSpecie == "super-toki"
                    where d.HatchingDate == new DateTime(2004, 06, 03)
                    where d.CageNumber == "2"
                    select d;

            Assert.IsNotNull(bird);

            db.Bird.Remove(birdObject);
            db.SaveChanges();
        }
    }
}