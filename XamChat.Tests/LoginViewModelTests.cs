
using System.Threading.Tasks;
using XamChat.Core.Contracts;
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
	}
}
