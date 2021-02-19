using System;
using Database.Database.Models;

public interface IWorkshopTableDB
{
    public List<WorkShop> GetAll(); //Get, Read all in Database
    public WorkShop Create(WorkShop workshop); //Post
    public void Update(WorkShop workshop); //Put
    public void Delete(WorkShop workshop); //Delete
}
