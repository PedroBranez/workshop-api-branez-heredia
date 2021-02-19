using System;

public interface IWorkshopTableDB
{
    public List<WorkShop> GetAll(); //Get, Read all in Database
    public WorkShop Create(WorkShop workshop); //Post
    public WorkShop Update(WorkShop workshop); //Put
    public WorkShop Delete(WorkShop workshop); //Delete
    public WorkShop DeleteById(string id); //Delete a Workshop by its ID
}

