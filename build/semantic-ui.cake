Task("RestorePackagesSemanticUI")
  .Does(() => ForEachSemanticUIDirectory(dir =>
    NpmInstall(settings => settings.WorkingDirectory = dir)));

Task("CleanSemanticUI")
  .IsDependentOn("RestorePackagesSemanticUI")
  .Does(() =>
    ForEachSemanticUIDirectory(dir =>
      NpmRunScript("clean", settings => settings.WorkingDirectory = dir)));

Task("BuildSemanticUI")
  .IsDependentOn("CleanSemanticUI")
  .Does(() =>
    ForEachSemanticUIDirectory(dir =>
      NpmRunScript("build", settings => settings.WorkingDirectory = dir)));

void ForEachSemanticUIDirectory(Action<DirectoryPath> action)
{
  var directories = GetDirectories(@"..\src\*.SemanticUI");
  foreach (var dir in directories) action(dir);
}
