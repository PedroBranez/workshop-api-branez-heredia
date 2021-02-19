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
		private readonly IWorkshopLogic _workshopLogic;
		public WorkshopsController(IWorkshopLogic workshopLogic)
        {
			_workshopLogic = workshopLogic;
        }

		[HttpPost]
		[Route("add-workshop")]
		public int addWorkshop()
		{
			// Empty
			return 200;
		}
		[HttpGet]
		[Route("workshops")]
		public ActionResult<List<Workshop>> GetWorkshops()
		{
			return _workshopLogic.GetWorkshops();
		}

		[HttpPut]
		[Route("workshops/{code}")]
		public ActionResult<Workshop> DeleteWorkshop(string code)
		{
			return _workshopLogic.DeleteWorkshopById(code);
		}

		[HttpPut]
		[Route("workshops/{code}/postpone")]
		public ActionResult<Workshop> PostponeWorkshop(string code)
		{
			return _workshopLogic.UpdateWorkshopStatus(code, "Postponed");
		}

		[HttpPut]
		[Route("workshops/{code}/cancel")]
		public ActionResult<Workshop> CancelWorkshop(string code)
		{
			return _workshopLogic.UpdateWorkshopStatus(code, "Canceled");
		}
	}
}
