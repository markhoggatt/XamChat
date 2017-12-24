
using System;
using XamChat.Core.Contracts;
using XamChat.Core.Fakes;
using XamChat.Core.Models;
using XamChat.Core.Services;
using Xunit;

namespace XamChat.Tests
{
	public class ServiceContainerTests
	{
		[Fact]
		public void CanRegisterServices()
		{
			if (ServicesContainer.NumberInContainer() > 0)
			{
				Assert.Equal(2, ServicesContainer.NumberInContainer());
				return;
			}

			ServicesContainer.Register<IWebService>(() => new FakeWebService());
			Assert.Equal(1, ServicesContainer.NumberInContainer());

			ServicesContainer.Register<ISettings>(() => new FakeSettings { Usr = new User { Id = "999", Password = "blabber", UserName = "testy" } });
			Assert.Equal(2, ServicesContainer.NumberInContainer());
		}

		[Fact]
		public void CanResolveServices()
		{
			if (ServicesContainer.NumberInContainer() == 0)
			{
				CanRegisterServices();
			}

			var webSvc = ServicesContainer.Resolve<IWebService>();
			Assert.NotNull(webSvc);

			Assert.IsAssignableFrom<IWebService>(webSvc);
			Assert.IsAssignableFrom<FakeWebService>(webSvc);
		}

		[Fact]
		public void CanInitLazily()
		{
			var lazyWebSvc = new Lazy<IWebService>(() => new FakeWebService());
			var webSvc = lazyWebSvc.Value;
			Assert.IsAssignableFrom<IWebService>(webSvc);
			Assert.IsAssignableFrom<FakeWebService>(webSvc);
		}
	}
}
