using DatabaseLayer.Database.Models;

namespace ShiftManager.Helpers;

public interface ICurrentData
{

    public static Employee? LoginedEmployee { get; set; }

}