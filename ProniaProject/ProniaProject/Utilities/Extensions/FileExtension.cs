using System;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;

namespace ProniaProject.Utilities.Extensions
{
	public static class FileExtension
	{
		public static bool isValidType(this IFormFile File, string type)
			=> File.ContentType.StartsWith(type);

		public static bool isValidSize(this IFormFile File, int kb)
			=> File.Length <= 1024 * kb;

		public static async Task<string> UploadAsync(this IFormFile file, params string[] paths)
		{
			string path = Path.Combine(paths);
			if (!Path.Exists(path))
				Directory.CreateDirectory(path);

			string fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
			using (Stream sr = File.Create(Path.Combine(path, fileName)))
				await file.CopyToAsync(sr);

			return fileName; 
		}
	}
}

