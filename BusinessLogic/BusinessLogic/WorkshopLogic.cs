using System;
using System.Collections.Generic;

public class WorkshopLogic : IWorkshopLogic
{
    private List<Workshop> workshops = new List<Workshop>()
    {
        new Workshop {
            WorkshopID = "Sesion-1",
            WorkshopName = "Introducción Internal Apps",
            WorkshopStatus = "Postponed"
        },
        new Workshop{
            WorkshopID = "Sesion-2",
            WorkshopName = "OOP",
            WorkshopStatus = "Scheduled"
        },
        new Workshop{
            WorkshopID = "Sesion-3",
            WorkshopName = "Branching Model and Versioning (Part I)",
            WorkshopStatus = "Scheduled"
        }
    };

    /*private readonly IWorkshopTableDB _workshopTableDB;

    public WorkshopLogic(IWorkshopTableDB workshopTableDB)
    {
        _workshopTableDB = workshopTableDB;
    }*/

    public List<Workshop> GetWorkshops()
    {
        //return _workshopTableDB.GetAll();
        return workshops;
    }

    public Workshop AddNewWorkshop(Workshop workshop)
    {
        
        Workshop newWorkshop = new Workshop
        {
            WorkshopID = generateId(),
            WorkshopName = workshop.WorkshopName,
            WorkshopStatus = workshop.WorkshopStatus
        };
        workshops.Add(newWorkshop);
        return newWorkshop;
        //return _workshopTableDB.Create(workshop);
    }

    public Workshop UpdateWorkshop(Workshop workshop)
    {
        Workshop updatedWorkshop = null;
        for (int i = 0; i < workshops.Count; i++)
        {
            if (workshops[i].WorkshopID == workshop.WorkshopID)
            {
                workshops[i] = workshop;
                updatedWorkshop = workshop;
            }
        }
        return updatedWorkshop;
        //return _workshopTableDB.Update(workshop);
    }

    public Workshop DeleteWorkshop(Workshop workshop)
    {
        
        Workshop deletedWorkshop = null;
        for (int i = 0; i < workshops.Count; i++)
        {
            if (workshops[i].WorkshopID == workshop.WorkshopID)
            {
                workshop = workshops[i];
                workshops.RemoveAt(i);
            }
        }
        return deletedWorkshop;
        //return _workshopTableDB.Delete(workshop);
    }

    public Workshop DeleteWorkshopById(string id)
    {

        Workshop deletedWorkshop = null;
        for (int i = 0; i < workshops.Count; i++)
        {
            if (workshops[i].WorkshopID == id)
            {
                deletedWorkshop = workshops[i];
                workshops.RemoveAt(i);
            }
        }
        return deletedWorkshop;
        //return _workshopTableDB.DeleteById(id);
    }

    public Workshop UpdateWorkshopStatus(string id, string status)
    {
        //return _workshopTableDB.UpdateStatus(id, status);
        Workshop canceledWorkshop = null;
        for (int i = 0; i < workshops.Count; i++)
        {
            if (workshops[i].WorkshopID == id)
            {
                workshops[i].WorkshopStatus = status;
                canceledWorkshop = workshops[i];
            }
        }
        return canceledWorkshop;
    }

    private string generateId()
    {
        Workshop lastWorkshop = workshops[workshops.Count - 1];
        int nextCode = Int32.Parse(lastWorkshop.WorkshopID.Substring(7)) + 1;
        return "Sesion-" + nextCode;
    }
}
