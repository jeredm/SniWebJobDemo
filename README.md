# SNI Demo
Reproduces a Microsoft.Data.SqlClient.SNI issue: [Microsoft.Data.SqlClient.SNI not included in Azure Webjob app_data](https://github.com/dotnet/SqlClient/issues/460)

### Setup
1. Create a database named `SniWebJobs`
2. Set the connection string in the `app.config` under `SniWebJobDb`
3. Run the `SniWebJobDemo.Data/ScriptStarsTable.sql` file to create the table and seed it. 
4. Ensure you have the Azure Storage Emulator installed and running. Alternately, point the `app.config` setting for `AzureWebJobsStorage` to your existing Azure Storage account.
5. Create an Azure Queue named `sni-webjob-queue`
6. Add a message to `sni-webjob-queue` (the content of the message doesn't matter).

### Pipeline
The build pipeline is in the `azure-pipeline.yml` file. A release pipeline is not included, but it is a `Deploy Azure App Service` task that points to the the build at `$(System.DefaultWorkingDirectory)/**/*.zip` and has a `Continuous deployment trigger` enabled.

### Run Details
This application will pull a message off of an Azure queue and when it does, it will grab the first row in the `dbo.Stars` table and write the name to your console. This should work fine locally.
The problem reproduces itself when you deploy this application to Azure. We are using Azure DevOps pipelines for this.
We see that the `x86` and `x64` files are missing from the `app_data` folder and will eventually generate an exception when the DB is accessed in the Web Job.
