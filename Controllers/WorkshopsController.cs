using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace workshop_api.Controllers
{
	[ApiController]
	[Route("workshops")]
	public class WorkshopsController : ControllerBase
	{
		[HttpPost]
		[Route("add-workshop")]
		public int addWorkshop()
		{
			// Empty
			return 200;
		}
	}
}
