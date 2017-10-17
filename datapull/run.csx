#r "VSTSETL"

using System;


public static void Run(TimerInfo myTimer, TraceWriter log)
{
	
	string _VSTSInstance = System.Configuration.ConfigurationManager.ConnectionStrings["Instance"].ConnectionString;
    string _PersonalAccessToken = System.Configuration.ConfigurationManager.ConnectionStrings["PATok"].ConnectionString;
    string _AzureSQLConnection = System.Configuration.ConfigurationManager.ConnectionStrings["AzSQLDB"].ConnectionString;

	DateTime StDate = DateTime.Today.AddDays(-2);

	string projTimeFrame = "current";

	Project.GetProjects(_VSTSInstance, _AzureSQLConnection, _PersonalAccessToken);

	WorkItems.GetWorkItemRevisions(_VSTSInstance, _AzureSQLConnection, StDate, _PersonalAccessToken);

	Iteration.GetIterations(_VSTSInstance, _AzureSQLConnection, projTimeFrame, _PersonalAccessToken);

	AzureSQL.merge(_AzureSQLConnection);
}
