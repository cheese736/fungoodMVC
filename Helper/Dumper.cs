namespace fungoodMVC.Helper
{
	public static class Dumper
	{
		public static void print(object obj)
		{
			var dumper = ObjectDumper.Dump(obj);
			System.Console.WriteLine(dumper);
		}
	}
}