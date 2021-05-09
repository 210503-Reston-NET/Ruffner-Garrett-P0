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
            Assert.True(ValidationService.ValidateCityName("St. Louis"));
            Assert.False(ValidationService.ValidateCityName("city #4"));
            Assert.False(ValidationService.ValidateAddress(" "));
            Assert.False(ValidationService.ValidateAddress(""));
        }
        [Fact]
        public void NameValidationTest()
        {
            Assert.True(ValidationService.ValidatePersonName("Daniel McDowell"));
            Assert.False(ValidationService.ValidatePersonName("sk8r boi"));
            Assert.False(ValidationService.ValidatePersonName(" "));
            Assert.False(ValidationService.ValidatePersonName(""));
        }
        [Fact]
        public void AddressValidationTest()
        {
            Assert.True(ValidationService.ValidateAddress("8323 Somewhere Drive"));
            Assert.True(ValidationService.ValidateAddress("2938 Apt. #289, place, city 20399"));
            Assert.False(ValidationService.ValidateAddress("asfdVDKL3893e(*#@*"));
            Assert.False(ValidationService.ValidateAddress(" "));
            Assert.False(ValidationService.ValidateAddress(""));
        }
        
    }
}
