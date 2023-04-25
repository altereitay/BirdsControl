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
    public class UpdateCagePageTests
    {
        [TestMethod()]
        public void updateCage_btn_ClickTest()
        {
            BirdsControlDBEntities db = new BirdsControlDBEntities();

            // Retrieve the bird object from the database
           // Replace with the Id value of the bird you want to update
            Cage cageBeforeUpdate = new Cage()
            {
                SerialNumber = "1",
                Length = 1,
                Width = 2,
                Height = 1,
                Material = "iron"
            };
            db.Cage.Add(cageBeforeUpdate);

            // Update the bird object
            cageBeforeUpdate.SerialNumber = "updated";
            cageBeforeUpdate.Length = 4;
            cageBeforeUpdate.Width = 5;
            cageBeforeUpdate.Height = 3;
            cageBeforeUpdate.Material = "iron";

            db.SaveChanges();

            // Retrieve the updated bird object from the database
            Cage cageUpdated = db.Cage.SingleOrDefault(b => b.Id == cageBeforeUpdate.Id);

            // Verify that the bird object was updated
            Assert.IsNotNull(cageUpdated);
            Assert.AreEqual("updated", cageUpdated.SerialNumber);
            Assert.AreEqual(4, cageUpdated.Length);
            Assert.AreEqual(5, cageUpdated.Width);
            Assert.AreEqual(3, cageUpdated.Height);
            Assert.AreEqual("iron", cageUpdated.Material);


        }
    }
}