using Moq;
using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using NUnit.Framework;

namespace NewWebPortal.UnitTests.Services
{
    public class SendMailServiceTest
    {
        private readonly ISendMailService _sendMailService;

        private static Email BlankEmail => new Email();

        private static Email ValidEmail =>
            new Email()
            {
                Message = "Test Message",
                Subject = "Test",
                ToEmail = "test@gmail.com"
            };

        public  SendMailServiceTest()
        {
            _sendMailService = new Mock<ISendMailService>().Object;
        }

        /// <summary>
        /// Test send mail returns error message if require fields are empty or null
        /// </summary>
        [Test]
        public void SendMail_WithoutRequireFields_ReturnsFalse()
        {
            //act
            var actualResult = _sendMailService.SendMail(BlankEmail);

            //assert
            Assert.False(actualResult);
        }

        /// <summary>
        /// Test sendmail works with all require data and valid email
        /// </summary>
        [Test]
        public void SendMail_WithRequireTrueData_ReturnsTrue()
        {
            //Act
            var actualResult = _sendMailService.SendMail(ValidEmail);

            //Assert
            Assert.True(actualResult);
        }

    }
}
