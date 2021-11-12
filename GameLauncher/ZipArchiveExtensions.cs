using System;
using System.IO;
using System.IO.Compression;

namespace GameLauncher

// Credit to:
// https://stackoverflow.com/questions/14795197/forcefully-replacing-existing-files-during-extracting-file-using-system-io-compr/30425148

{
	public static class ZipArchiveExtensions
	{
		public static void ExtractToDirectory(this ZipArchive archive, string destinationDirectoryName, bool overwrite)
		{
			if (!overwrite)
			{
				archive.ExtractToDirectory(destinationDirectoryName);
				return;
			}

			DirectoryInfo di = Directory.CreateDirectory(destinationDirectoryName);
			string destinationDirectoryFullPath = di.FullName;

			foreach (ZipArchiveEntry file in archive.Entries)
			{
				string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

				if (!completeFileName.StartsWith(destinationDirectoryFullPath, StringComparison.OrdinalIgnoreCase))
				{
					throw new IOException("Trying to extract file outside of destination directory. See this link for more info: https://snyk.io/research/zip-slip-vulnerability");
				}

				if (file.Name == "")
				{// Assuming Empty for Directory
					Directory.CreateDirectory(Path.GetDirectoryName(completeFileName) ?? throw new InvalidOperationException());
					continue;
				}
				file.ExtractToFile(completeFileName, true);
			}
		}
	}
}