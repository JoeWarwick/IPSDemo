using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IPSDemo;
using static IPSDemo.IPSDemoModel;

namespace IPSDemo.Tests
{
    [TestClass]
    public class ModelTests
    {
       
        [TestMethod]
        public void TitleRequired()
        {
            var m = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Test 2",
                LastName = "Test",
                DOB = DateTime.Now
            };

            Assert.IsTrue(ValidateModel(m).Count > 0);
        }

        [TestMethod]
        public void FirstNameRequired()
        {
            var m = new Person
            {
                Id = Guid.NewGuid(),
                Title = "Mr",
                LastName = "Test",
                DOB = DateTime.Now
            };

            Assert.IsTrue(ValidateModel(m).Count > 0);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
