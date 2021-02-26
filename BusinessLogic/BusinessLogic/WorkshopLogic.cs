using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;

public class WorkshopLogic : IWorkshopLogic
{
    private List<WorkshopDTO> workshopsInstance = new List<WorkshopDTO>();

    private readonly IWorkshopTableDB _workshopTableDB;

    private List<string> ValidStatus = new List<string> { "Scheduled", "Postponed", "Cancelled" };

    const string initialWorkshopStatus = "Scheduled";
    const string idPrefix = "Sesion-";

    public WorkshopLogic(IWorkshopTableDB workshopTableDB)
    {
        _workshopTableDB = workshopTableDB;
        workshopsInstance = GetWorkshops();
    }

    public List<WorkshopDTO> GetWorkshops()
    {
        List<WorkshopDTO> dtoData = new List<WorkshopDTO>();
        List<Workshop> dbData = _workshopTableDB.GetAll();
        foreach (Workshop ws in dbData)
        {
            dtoData.Add(ConvDBtoDTO(ws));
        }
        return dtoData;
    }

    public WorkshopDTO AddNewWorkshop(WorkshopDTO workshop)
    {
        if (string.IsNullOrEmpty(workshop.WorkshopName))
            throw new BusinessLogicException("Empty Name field");

        WorkshopDTO newWorkshop = new WorkshopDTO
        {
            WorkshopID = generateId(),
            WorkshopName = workshop.WorkshopName,
            WorkshopStatus = initialWorkshopStatus
        };
        Workshop newWorkShopDB = _workshopTableDB.Create(ConvDTOtoDB(newWorkshop));
        return ConvDBtoDTO(newWorkShopDB);
    }

    public WorkshopDTO UpdateWorkshop(WorkshopDTO workshop)
    {
        if (ValidStatus.Contains(workshop.WorkshopStatus))
        {
            Workshop updatedWorkShopDB = _workshopTableDB.Update(ConvDTOtoDB(workshop));
            Console.WriteLine(updatedWorkShopDB.WorkshopStatus);
            return ConvDBtoDTO(updatedWorkShopDB);
        }
        throw new BusinessLogicException("Empty or invalid status field");
    }

    public WorkshopDTO DeleteWorkshopById(string id)
    {
        Workshop deletedWorkShopDB = _workshopTableDB.DeleteById(id);
        return ConvDBtoDTO(deletedWorkShopDB);
    }

    public WorkshopDTO UpdateWorkshopStatus(string id, string status)
    {
        WorkshopDTO updatedWorkshop = null;
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

        Workshop statusUpdatesWorkShopDB = _workshopTableDB.Update(ConvDTOtoDB(updatedWorkshop));
        return ConvDBtoDTO(statusUpdatesWorkShopDB);
    }

    private string generateId()
    {
        WorkshopDTO lastWorkshop = workshopsInstance[workshopsInstance.Count - 1];
        int nextCode = Int32.Parse(lastWorkshop.WorkshopID.Substring(7)) + 1;
        return idPrefix + nextCode;
    }

    public Workshop ConvDTOtoDB(WorkshopDTO old)
    {
        Workshop valid = new Workshop();
        valid.WorkshopID = old.WorkshopID;
        valid.WorkshopName = old.WorkshopName;
        valid.WorkshopStatus = old.WorkshopStatus;
        return valid;
    }

    public WorkshopDTO ConvDBtoDTO(Workshop old)
    {
        WorkshopDTO valid = new WorkshopDTO();

        valid.WorkshopID = old.WorkshopID;
        valid.WorkshopName = old.WorkshopName;
        valid.WorkshopStatus = old.WorkshopStatus;
        return valid;
    }
}
