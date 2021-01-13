Task("RestorePackagesReact")
  .Does(() =>
    ForEachReactAppDirectory(dir =>
      Yarn.FromPath(dir).Install()));

Task("CleanReact")
  .IsDependentOn("RestorePackagesReact")
  .Does(() =>
    ForEachReactAppDirectory(dir =>
      Yarn.FromPath(dir).RunScript("clean")));

Task("BuildReact")
  .IsDependentOn("BuildSemanticUI")
  .IsDependentOn("CleanReact")
  .Does(() =>
    ForEachReactAppDirectory(dir =>
      Yarn.FromPath(dir).RunScript("build")));

void ForEachReactAppDirectory(Action<DirectoryPath> action)
{
  var directories = GetDirectories(@"..\src\*.React");
  foreach (var dir in directories) action(dir);

  directories = GetDirectories(@"..\src\*.React.*");
  foreach (var dir in directories) action(dir);
}
