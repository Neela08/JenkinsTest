
using System.Reflection;



namespace TestProjectAqualityFramework.Utilities
{
    internal class ProjectPath
    {
        
        public static String GetProjectPath()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();

          
            string assemblyPath = assembly.Location;

            
            string projectPath = Path.GetDirectoryName(assemblyPath);

            while (!string.IsNullOrEmpty(projectPath))
            {
                string[] projectFiles = Directory.GetFiles(projectPath, "*.csproj");
                if (projectFiles.Length > 0)
                {
                   
                    return Path.GetDirectoryName(projectFiles[0]);
                }

              
                projectPath = Path.GetDirectoryName(projectPath);
            }

            
            throw new Exception("Could not determine project location.");

        }
       
    }
}
