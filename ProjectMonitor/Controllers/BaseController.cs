using Microsoft.AspNetCore.Authorization;

namespace ProjectMonitor.WebUI.Controllers
{
	public class BaseController
	{
		private IAuthorizationService authService;

		public BaseController(IAuthorizationService authService)
		{
			this.authService = authService;
		}
	}
}