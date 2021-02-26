using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

public class WorkshopTableDB : IWorkshopTableDB
{
    List<Workshop> DataBase = new List<Workshop>
    {
            new Workshop() { WorkshopID = "Sesion-1", WorkshopName = "Introducción Internal Apps", WorkshopStatus = "Postponed" },
            new Workshop() { WorkshopID = "Sesion-2", WorkshopName = "OOP", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-3", WorkshopName = "Branching Model and Versioning (Part I)", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-4", WorkshopName = "Sesión 4 - APIs + miscroservices + Arq. Monolícas - (Part I)", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-5", WorkshopName = "Databases", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-6", WorkshopName = "GIT Dojo", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-7", WorkshopName = "IT", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-8", WorkshopName = "Soft Skills - Comunicaciones Efectivas", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-9", WorkshopName = "SoftSkills and Rules", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-10", WorkshopName = "API .NET Practice", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-11", WorkshopName = "Bases de Datos", WorkshopStatus = "Scheduled" },
            new Workshop() { WorkshopID = "Sesion-12", WorkshopName = "Calidad en Software Comercial", WorkshopStatus = "Scheduled" },
    };

    public List<Workshop> GetAll() //Read, returns all WorkShops
    {
        return DataBase;
    }

    public Workshop Create(Workshop workshop) // Creates a New Workshop 
    {
        DataBase.Add(workshop);
        return workshop;
    }

    public Workshop Update(Workshop workshop) //Updates all fields in a Workshop except its id
    {
        Workshop workshopToUpdate = DataBase.FirstOrDefault(ws => workshop.WorkshopID == ws.WorkshopID);
        if (workshopToUpdate != null)
        {
            workshopToUpdate.WorkshopName = workshop.WorkshopName;
            workshopToUpdate.WorkshopStatus = workshop.WorkshopStatus;
            return workshopToUpdate;
        }
        else
        {
            throw new DatabaseException("Workshop Not found");
        }
    }

    public Workshop DeleteById(string id) //Removes a Workshop
    {
        Workshop workshopToDelete = DataBase.FirstOrDefault(ws => id == ws.WorkshopID);
        if (workshopToDelete != null)
        {
            DataBase.Remove(workshopToDelete);
            return workshopToDelete;
        }
        else
        {
            throw new DatabaseException("Workshop Not found");
        }
    }

}

