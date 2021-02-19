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
		public Workshop addWorkshop([FromBody] Workshop ws)
		{
			Console.WriteLine("from post => " + ws.WorkshopID + " - " + ws.WorkshopName + " - " + ws.WorkshopStatus);
			Workshop addedWorkshop = _workshopLogic.AddNewWorkshop(ws);
			return addedWorkshop;
		}
		[HttpGet]
		public ActionResult<List<Workshop>> GetWorkshops()
		{
			return _workshopLogic.GetWorkshops();
		}

		[HttpPut]
		public Workshop updateWorkshop([FromBody] Workshop ws)
		{
			Workshop updatedWorkshop = _workshopLogic.UpdateWorkshop(ws);
			return updatedWorkshop;
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult<Workshop> DeleteWorkshop(string id)
		{
			return _workshopLogic.DeleteWorkshopById(id);
		}

		[HttpPut]
		[Route("{id}/postpone")]
		public ActionResult<Workshop> PostponeWorkshop(string id)
		{
			return _workshopLogic.UpdateWorkshopStatus(id, "Postponed");
		}

		[HttpPut]
		[Route("{id}/cancel")]
		public ActionResult<Workshop> CancelWorkshop(string id)
		{
			return _workshopLogic.UpdateWorkshopStatus(id, "Canceled");
		}
	}
}
