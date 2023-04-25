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
                CageNumber = "1"
            };
            db.Bird.Add(birdObject);
            db.SaveChanges();

            // Query for the added bird object using its Id
            var addedBird = db.Bird.SingleOrDefault(b => b.Id == birdObject.Id);

            // Verify that the added bird object was found
            Assert.IsNotNull(addedBird);

            
        }
    }
}