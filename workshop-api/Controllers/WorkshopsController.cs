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
		public WorkshopDTO addWorkshop([FromBody] WorkshopDTO ws)
		{
			WorkshopDTO addedWorkshop = _workshopLogic.AddNewWorkshop(ws);
			return addedWorkshop;
		}
		[HttpGet]
		public ActionResult<List<WorkshopDTO>> GetWorkshops()
		{
			return _workshopLogic.GetWorkshops();
		}

		[HttpPut]
		public WorkshopDTO updateWorkshop([FromBody] WorkshopDTO ws)
		{
			WorkshopDTO updatedWorkshop = _workshopLogic.UpdateWorkshop(ws);
			return updatedWorkshop;
		}

		[HttpDelete]
		[Route("{id}")]
		public ActionResult<WorkshopDTO> DeleteWorkshop(string id)
		{
			return _workshopLogic.DeleteWorkshopById(id);
		}

		[HttpPut]
		[Route("{id}/postpone")]
		public ActionResult<WorkshopDTO> PostponeWorkshop(string id)
		{
			return _workshopLogic.UpdateWorkshopStatus(id, "Postponed");
		}

		[HttpPut]
		[Route("{id}/cancel")]
		public ActionResult<WorkshopDTO> CancelWorkshop(string id)
		{
			return _workshopLogic.UpdateWorkshopStatus(id, "Cancelled");
		}
	}
}
