Task("RestorePackagesDotNet").Does(() => DotNetCoreRestore("../src"));

Task("CleanDotNet")
  .IsDependentOn("RestorePackagesDotNet")
  .Does(() => {
    DotNetCoreClean("../src/", new DotNetCoreCleanSettings {Configuration = Argument("configuration", "Release")});
    CleanDirectory("../artifacts/");
  });

Task("BuildDotNet")
  .IsDependentOn("BuildEmails")
  .IsDependentOn("CleanDotNet")
  .Does(() => DotNetCoreBuild("../src/", new DotNetCoreBuildSettings {Configuration = Argument("configuration", "Release")}));

Task("PublishDotNet")
  .IsDependentOn("BuildDotNet")
  .Does(() => {
    var publishSettings = new DotNetCorePublishSettings {Configuration = Argument("configuration", "Release")};

    var projectFiles = GetFiles("../src/*.Api/*.csproj");

    foreach (var file in projectFiles) {
      var sausageCaseName = file.GetFilenameWithoutExtension().ToString().Replace('.', '-').ToLowerInvariant();

      publishSettings.OutputDirectory = $"../artifacts/{sausageCaseName}/";
      DotNetCorePublish(file.FullPath, publishSettings);
    }
  });

Task("PackageWindowsDotNet")
  .Does(() => {
    var projectFiles = GetFiles("../src/*.Api/*.csproj");

    foreach (var file in projectFiles) {
      var sausageCaseName = file.GetFilenameWithoutExtension().ToString().Replace('.', '-').ToLowerInvariant();

      var msDeploySettings = new MsDeploySettings {
         Verb = Operation.Sync,
         Source = new ContentPathProvider
         {
             Direction = Direction.source,
             Path = MakeAbsolute(Directory($"../artifacts/{sausageCaseName}/")).ToString()
         },
         Destination = new PackageProvider
         {
             Direction = Direction.dest,
             Path = MakeAbsolute(File($"../artifacts/{sausageCaseName}.zip")).ToString()
          }
       };

       MsDeploy(msDeploySettings);
    }
  });

Task("PublishDatabaseDotNet")
  .IsDependentOn("RestorePackagesDotNet")
  .Does(() => {
    var projectFiles = GetFiles("../src/*.Domain/*.csproj");

    foreach (var file in projectFiles)
    {
      var sausageCaseName = file.GetFilenameWithoutExtension().ToString().Replace('.', '-').ToLowerInvariant();

      var argBuilder = new ProcessArgumentBuilder();
      argBuilder.Append("--configuration");
      argBuilder.Append("Release");
      argBuilder.Append("migrations");
      argBuilder.Append("script");
      argBuilder.Append("--idempotent");
      argBuilder.Append("--output");
      argBuilder.AppendQuoted($"../../artifacts/{sausageCaseName}-database.sql");

      DotNetCoreTool(file.FullPath, "ef", argBuilder);
    }
  });

