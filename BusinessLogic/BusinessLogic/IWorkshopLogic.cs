using System;
using System.Collections.Generic;

public interface IWorkshopLogic
{
    public List<Workshop> GetWorkshops();
    public Workshop AddNewWorkshop(Workshop workshop);
    public Workshop UpdateWorkshop(Workshop workshop);
    public Workshop DeleteWorkshop(Workshop workshop);
    public Workshop DeleteWorkshopById(string id);
    public Workshop UpdateWorkshopStatus(string id, string status);
}
