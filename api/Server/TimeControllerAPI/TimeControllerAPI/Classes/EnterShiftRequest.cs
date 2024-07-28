using System;
namespace TimeControllerAPI.Classes
{
	public record EnterShiftRequest
	{

		public string ShiftID { get; set; }
		public string TradePointID { get; set; }
		public string EmployeeID { get; set; }

	}
}

