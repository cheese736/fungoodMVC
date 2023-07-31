public static class FileUploadHelper
{

	public static async Task<string> CopyFileAndGeneratePath(IWebHostEnvironment environment, IFormFile file)
	{
		if (file != null && file.Length > 0)
		{
			// Get the file name and extension
			string fileName = Path.GetFileName(file.FileName);
			string fileExtension = Path.GetExtension(fileName);

			// Generate a unique file name (e.g., using Guid)
			string uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

			// Combine the target path where the file will be stored
			string targetPath = Path.Combine(environment.WebRootPath, "uploads");

			// Ensure the target directory exists; create it if not
			if (!Directory.Exists(targetPath))
			{
				Directory.CreateDirectory(targetPath);
			}

			// Combine the target file path
			string targetFilePath = Path.Combine(targetPath, uniqueFileName);

			// Save the file to the server
			using (var stream = new FileStream(targetFilePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Path.Combine("~/uploads/", uniqueFileName);
		}
		return string.Empty;
	}
}
