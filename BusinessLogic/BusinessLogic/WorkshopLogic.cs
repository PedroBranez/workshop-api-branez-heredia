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

    public List<Workshop> GetWorkshops()
    {
        //return _workshopList.GetAll();
        return workshops;
    }
}
