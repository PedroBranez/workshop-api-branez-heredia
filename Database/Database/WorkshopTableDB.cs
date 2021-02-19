using System;
using System.Collections.Generic;

public class WorkshopTableDB : IWorkshopTableDB
{
    List<WorkShop> DataBase = new List<WorkShop>
    {
            new WorkShop() { WorkshopID = "Sesion-1", WorkshopName = "Introducción Internal Apps", WorkshopStatus = "Postponed" },
            new WorkShop() { WorkshopID = "Sesion-2", WorkshopName = "OOP", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-3", WorkshopName = "Branching Model and Versioning (Part I)", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-4", WorkshopName = "Sesión 4 - APIs + miscroservices + Arq. Monolícas - (Part I)", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-5", WorkshopName = "Databases", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-6", WorkshopName = "GIT Dojo", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-7", WorkshopName = "IT", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-8", WorkshopName = "Soft Skills - Comunicaciones Efectivas", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-9", WorkshopName = "SoftSkills and Rules", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-10", WorkshopName = "API .NET Practice", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-11", WorkshopName = "Bases de Datos", WorkshopStatus = "Scheduled" },
            new WorkShop() { WorkshopID = "Sesion-12", WorkshopName = "Calidad en Software Comercial", WorkshopStatus = "Scheduled" },
    };

    public List<WorkShop> GetAll() //Read, returns all WorkShops
    {
        return DataBase;
    }

    public WorkShop Create(WorkShop workshop) // Creates a New WorkShop 
    {
        DataBase.Add(workshop);
        return workshop;
    }

    public void Update(WorkShop workshop) //Updates all fields in a WorkShop except its id
    {
        foreach (WorkShop ws in DataBase)
        {
            if (ws == workshop)
            {
                ws.WorkshopName = workshop.WorkshopName;
                ws.WorkshopStatus = workshop.WorkshopStatus;
                break;
            }
        }
    }

    public void Delete(WorkShop workshop) //Removes a WorkShop
    {
        DataBase.Remove(workshop);
    }

}

