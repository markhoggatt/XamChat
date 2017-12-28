
using System.Threading.Tasks;
using XamChat.Core.Contracts;
using XamChat.Core.Fakes;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;
using Xunit;

namespace XamChat.Tests
{
	public class LoginViewModelTests : IClassFixture<ServiceFixture>
	{
		ServiceFixture services;

		public LoginViewModelTests(ServiceFixture svcs)
		{
			services = svcs;
		}

		[Fact]
		public async Task CanLoginSuccessfully()
		{
			var login = new LoginViewModel { Username = "testuser", Password = "password" };
			await login.Login();

			ISettings settings = ServicesContainer.Resolve<ISettings>();
			Assert.NotNull(settings.Usr);
		}

		[Fact]
		public async Task CanLoginWithServices()
		{
			const string sampleUserId = "Test1";
			const string samplePassword = "pass";

			var login1 = ServicesContainer.Resolve<LoginViewModel>();
			Assert.NotNull(login1);
			Assert.IsAssignableFrom<LoginViewModel>(login1);

			login1.Username = sampleUserId;
			login1.Password = samplePassword;
			await login1.Login();

			var settings = ServicesContainer.Resolve<ISettings>();
			Assert.NotNull(settings);
			Assert.IsAssignableFrom<FakeSettings>(settings);
			Assert.Equal(sampleUserId, settings.Usr.UserName);
			Assert.Equal(samplePassword, settings.Usr.Password);

			var login2 = ServicesContainer.Resolve<LoginViewModel>();
			Assert.Equal(sampleUserId, login2.Username);
		}
	}
}
