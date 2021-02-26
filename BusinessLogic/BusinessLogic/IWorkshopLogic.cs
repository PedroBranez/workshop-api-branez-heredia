using System;
using System.Collections.Generic;

public interface IWorkshopLogic
{
    public List<WorkshopDTO> GetWorkshops();
    public WorkshopDTO AddNewWorkshop(WorkshopDTO workshop);
    public WorkshopDTO UpdateWorkshop(WorkshopDTO workshop);
    public WorkshopDTO DeleteWorkshopById(string id);
    public WorkshopDTO UpdateWorkshopStatus(string id, string status);
}
