using System;
using System.IO;

class FileHandlingAutomation
{
    static void Main(string[] args)
    {
        string folderPath = @"C:\TrumpfMetamation";
        string filePath = Path.Combine(folderPath, "Welcome.txt");

        try
        {
            // Step 1: Create folder
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder created successfully.");
            }

            // Step 2: Create file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Welcome to Trumpf Metamation!");
            }
            Console.WriteLine("File created and content written successfully.");

            // Step 3: Verify file content
            string fileContent = File.ReadAllText(filePath);
            if (fileContent.Trim() == "Welcome to Trumpf Metamation!")
            {
                Console.WriteLine("File content verified successfully.");
            }
            else
            {
                Console.WriteLine("File content verification failed.");
            }

            // Step 4: Delete file
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("File deleted successfully.");
            }

            // Step 5: Delete folder
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath);
                Console.WriteLine("Folder deleted successfully.");
            }

            // Final confirmation
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Both file and folder have been deleted successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
