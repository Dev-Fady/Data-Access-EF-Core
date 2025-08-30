using ReverseEngineering.Data;
using System;

namespace ReverseEngineering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in new AppDbContext().Speakers)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}

#region Reverse Engineering using Package Manger Console (PMC)
/*
// Step #1: Package Manager Console (PMC)
//    Tools -> Nuget Package Manager -> Package Manager Console

// Step #2: Package Manager Console (PMC) Tool 
//    Install-Package Microsoft.EntityFrameworkCore.Tools

// Step #3: Install Nuget Page on Project Microsoft.EntityFrameworkCore.Design
// Microsoft.EntityFrameworkCore.SqlServer

// Step #4: Install Provider in the project Microsoft.EntityFrameworkCore.SqlServer

// Step #5: Run Command (Full)
//    Scaffold-DbContext '[Connection String]' [Provider]

 scaffold-DbContext 'Data Source = . ; database = TechTalk ; Integrated Security = SSPI ; TrustServerCertificate = True' 
    Microsoft.EntityFrameworkCore.SqlServer -context AppDbContext -ContextDir Data -OutputDir Entites
*/
#endregion

#region Reverse Engineering NET CLI
/*
*         // Step #1: Windows Terminal (Command Prompt) 

// Step #2: Install Ef-Core tool globally
//    dotnet tool install --global dotnet-ef    (new)
//    dotnet tool update --global dotnet-ef     (to upgrade)

// Step #3: Install Provider in the project Microsoft.EntityFrameworkCore.SqlServer

// Step #4: Run Command (Full)
//    dotnet ef dbcontext scaffold '[Connection String]' [Provider]
dotnet ef dbcontext scaffold "Data Source=.;Database=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --context AppDbContext --context-dir Data --output-dir Entities

* 
*/
#endregion