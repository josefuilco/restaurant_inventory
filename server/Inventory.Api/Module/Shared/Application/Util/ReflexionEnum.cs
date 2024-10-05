namespace Inventory.Api.Module.Shared.Application.Util
{
	public class ReflexionEnum
	{
		public static Dictionary<string, int> ListValues<T>()
		{
			Type type = typeof(T);
			Dictionary<string, int> enumValues = [];
			foreach (var value in Enum.GetValues(type))
			{
				enumValues.Add(Convert.ToString(value)!, (int)value);
			}
			return enumValues;
		}
	}
}