﻿using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;

public class WorkshopLogic : IWorkshopLogic
{
    private List<Workshop> workshopsInstance = new List<Workshop>();

    private readonly IWorkshopTableDB _workshopTableDB;

    private List<string> ValidStatus = new List<string> { "Scheduled", "Postponed", "Cancelled" };

    const string initialWorkshopStatus = "Scheduled";
    const string idPrefix = "Sesion-";

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
        if (string.IsNullOrEmpty(workshop.WorkshopName))
            throw new BusinessLogicException("Empty Name field");

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
        throw new BusinessLogicException("Empty status field");
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
        if (updatedWorkshop == null)
            throw new BusinessLogicException("Workshop not found");

        return _workshopTableDB.Update(updatedWorkshop);
    }

    private string generateId()
    {
        Workshop lastWorkshop = workshopsInstance[workshopsInstance.Count - 1];
        int nextCode = Int32.Parse(lastWorkshop.WorkshopID.Substring(7)) + 1;
        return idPrefix + nextCode;
    }
}
