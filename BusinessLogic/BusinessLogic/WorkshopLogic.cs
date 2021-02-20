using System;
using System.Collections.Generic;

public class WorkshopLogic : IWorkshopLogic
{
    private List<Workshop> workshopsInstance = new List<Workshop>();

    private readonly IWorkshopTableDB _workshopTableDB;

    private List<string> ValidStatus = new List<string> { "Scheduled", "Postponed", "Cancelled" };

    private string initialWorkshopStatus = "Scheduled";

    public WorkshopLogic(IWorkshopTableDB workshopTableDB)
    {
        _workshopTableDB = workshopTableDB;
        workshopsInstance = GetWorkshops();
    }

    public List<Workshop> GetWorkshops()
    {
        return _workshopTableDB.GetAll();
    }

    public Workshop AddNewWorkshop(Workshop workshop)
    {
        Workshop newWorkshop = new Workshop
        {
            WorkshopID = generateId(),
            WorkshopName = workshop.WorkshopName,
            WorkshopStatus = initialWorkshopStatus
        };
        return _workshopTableDB.Create(newWorkshop);
    }

    public Workshop UpdateWorkshop(Workshop workshop)
    {
        if (ValidStatus.Contains(workshop.WorkshopStatus))
        {
            return _workshopTableDB.Update(workshop);
        }
        return null;
    }

    public Workshop DeleteWorkshop(Workshop workshop)
    {
        return _workshopTableDB.Delete(workshop);
    }

    public Workshop DeleteWorkshopById(string id)
    {
        return _workshopTableDB.DeleteById(id);
    }

    public Workshop UpdateWorkshopStatus(string id, string status)
    {
        Workshop updatedWorkshop = null;
        for (int i = 0; i < workshopsInstance.Count; i++)
        {
            if (workshopsInstance[i].WorkshopID == id)
            {
                updatedWorkshop = workshopsInstance[i];
                updatedWorkshop.WorkshopStatus = status;
            }
        }
        return _workshopTableDB.Update(updatedWorkshop);
    }

    private string generateId()
    {
        Workshop lastWorkshop = workshopsInstance[workshopsInstance.Count - 1];
        int nextCode = Int32.Parse(lastWorkshop.WorkshopID.Substring(7)) + 1;
        return "Sesion-" + nextCode;
    }
}
