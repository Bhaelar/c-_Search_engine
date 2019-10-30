
using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;


namespace Group_D__search_engine
{
	class Program
	{
		
		private static void Main(string[] args)
		{
			Console.WriteLine("Welcome to our search engine");
			Console.WriteLine("Enter whatever you wish to search");
			string sourceFolder = @"C:\Users\Modupe Okenla\Documents\SharpDevelop Projects\Group D_ search engine\Group D_ search engine\documents";
	        string searchWord = "Algorithm";
	        string shortFile = null;
	
	        List<string> allFiles = new List<string>();
	        AddFileNamesToList(sourceFolder, allFiles);
	        foreach (string fileName in allFiles)
	        {
	            string contents = File.ReadAllText(fileName);
	            if (contents.Contains(searchWord))
	            {
	            	shortFile = Path.GetFileName(fileName);
	                Console.WriteLine(shortFile);
	            }
	        }
			Console.ReadKey(true);
		}
		
		/* public static void results(String a) {
			
			DirectoryInfo dInfo = new DirectoryInfo(@"C:\Users\Modupe Okenla\Documents\SharpDevelop Projects\Group D_ search engine\Group D_ search engine\documents");
//			var files = dInfo.GetFilesByExtensions("*.pdf","*.doc","*.docx","*.ppt","*.xls","*.txt","*.html","*.xml");
			
			string[] extensions = new[] {"*.pdf","*.doc","*.docx","*.ppt","*.xls","*.txt","*.html","*.xml"};
			FileInfo[] files = dInfo.GetFiles()
				.Where(f => extensions.Contains(f.Extension.ToLower()))
				.ToArray();
		} */

		
		private static void AddFileNamesToList(string sourceDir, List<string> allFiles)
	    {
	
	            string[] fileEntries = Directory.GetFiles(sourceDir);
	            foreach (string fileName in fileEntries)
	            {
	                allFiles.Add(fileName);
	            }
	
	            //Recursion    
	            string[] subdirectoryEntries = Directory.GetDirectories(sourceDir);
	            foreach (string item in subdirectoryEntries)
	            {
	                // Avoid "reparse points"
	                if ((File.GetAttributes(item) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
	                {
	                    AddFileNamesToList(item, allFiles);
	                }
	            }
	
	    }
	}
}