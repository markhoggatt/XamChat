
using XamChat.Core.Contracts;
using XamChat.Core.Fakes;
using XamChat.Core.Services;
using XamChat.Core.ViewModels;

namespace XamChat.Tests
{
	public class ServiceFixture
	{
		public ServiceFixture()
		{
			ServicesContainer.Register<IWebService>(() => new FakeWebService { SleepDuration = 0 });
			ServicesContainer.Register<ISettings>(() => new FakeSettings());
			ServicesContainer.Register(() => new LoginViewModel());
		}
	}
}
