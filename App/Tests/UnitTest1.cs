using System;
using Xunit;
using UI;
using Service;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CityValidationTest()
        {
            
            Assert.Equal(ValidationService.ValidateCityName("St. Louis"), true);
            Assert.Equal(ValidationService.ValidateCityName("city #4"),false);
        }
        [Fact]
        public void NameValidationTest()
        {
            Assert.Equal(ValidationService.ValidatePersonName("Daniel McDowell"), true);
            Assert.Equal(ValidationService.ValidatePersonName("sk8r boi"),false);
            Assert.Equal(ValidationService.ValidatePersonName(" "),false);
            Assert.Equal(ValidationService.ValidatePersonName(""),false);
        }
        
    }
}
