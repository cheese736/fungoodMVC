using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace fungoodMVC.Helper
{
	public static class Dumper
	{
		public static void print(object obj)
		{
			var dumper = ObjectDumper.Dump(obj);
			System.Console.WriteLine(dumper);
		}

		public static void LogModelStateErrors(ModelStateDictionary modelState)
		{
			var errors = modelState.Select(x => x.Value.Errors)
			.Where(y => y?.Count > 0)
			.ToList();
			errors.ForEach(e => Dumper.print(e));
		}
	}
}