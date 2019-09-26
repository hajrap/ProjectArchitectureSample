using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Infrastructure;
using Moq;

namespace NewWebPortal.UnitTests.Services
{
    public class JoinOnlineServiceTest
    {
        private readonly Mock<IAsyncRepository<User>> _iMockUserRepository;

        private static User ValidUser
        {
            get
            {
                return new User()
                {
                    ChildName = "John",
                    ParentEmail = "liz@gmail.com",
                    ParentName = "Liz"
                };
            }
        }

       
       
        public JoinOnlineServiceTest()
        {
            _iMockUserRepository = new Mock<IAsyncRepository<User>>();
            _iMockUserRepository.SetupAllProperties();
        }

        //[Fact]
        //public async Task Insert_ValidUserData_ReturnsUserID()
        //{
        //    //Arrange
        //    User validUser = ValidUser;

        //    _iMockUserRepository.SetupAllProperties();
        //    _iMockUserRepository.Setup(r => r.InsertAsync(validUser).Result).Returns(1);
        //    var joinOnlineService = new JoinOnlineService(_iMockUserRepository.Object);

        //    //Act
        //    var actualResult = (await joinOnlineService.InsertAsync(validUser));

        //    //Assert
        //    Assert.NotEqual(0,actualResult);//User ID of added user must be greater than 0
        //}

        //[Fact]
        //public void Insert_BlankUserData_ReturnsZero()
        //{
        //    //Arrange
        //    User blankUser = new User();

        //    _iMockUserRepository.Setup(r => (r.InsertAsync(blankUser)).Result).Returns(0);
        //    var joinOnlineService = new JoinOnlineService(_iMockUserRepository.Object);

        //    //Act
        //    var actualResult = joinOnlineService.InsertAsync(blankUser);

        //    //Assert
        //    Assert.Equal(0,actualResult.Result);
        //}

        //[Fact]
        //public async Task GetAllUsers_FetchAll_ReturnsUserList()
        //{
        //    //Arrange
        //    var expectedUserList = new List<User>();

        //    _iMockUserRepository.Setup(r => r.SelectAllAsync().Result).Returns(expectedUserList);
        //    var joinOnlineService = new JoinOnlineService(_iMockUserRepository.Object);

        //    //Act
        //    var actualResult = await joinOnlineService.GetAllUsersAsync();

        //    //Assert
        //    Assert.Equal(expectedUserList, actualResult);
        //}
    }
}
