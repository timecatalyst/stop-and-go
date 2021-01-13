Task("RestorePackagesEmails")
  .Does(() => ForEachEmailsDirectory(dir =>
    Yarn.FromPath(dir).Install()));

Task("CleanEmails")
  .IsDependentOn("RestorePackagesEmails")
  .Does(() =>
    ForEachEmailsDirectory(dir =>
      Yarn.FromPath(dir).RunScript("clean")));

Task("BuildEmails")
  .IsDependentOn("CleanEmails")
  .Does(() =>
    ForEachEmailsDirectory(dir =>
      Yarn.FromPath(dir).RunScript("build")));

void ForEachEmailsDirectory(Action<DirectoryPath> action)
{
  var directories = GetDirectories(@"..\src\*.Emails");
  foreach (var dir in directories) action(dir);
}
