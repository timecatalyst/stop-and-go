#addin "Cake.Npm"
#addin "Cake.Yarn"
#addin "Cake.MsDeploy"
#load "semantic-ui.cake"
#load "react.cake"
#load "emails.cake"
#load "dotnet.cake"

var target = Argument("target", "Default");

Task("Default").Does(() => {
  RunTarget("Clean");
  RunTarget("Build");
});

Task("Clean").Does(() => {
  RunTarget("CleanReact");
  RunTarget("CleanDotNet");
});

Task("Build").Does(() => {
  RunTarget("BuildReact");
  RunTarget("BuildDotNet");
});

Task("Publish").Does(() => {
  RunTarget("BuildReact");
  RunTarget("PublishDotNet");
});

Task("PackageWindows").Does(() => {
  RunTarget("BuildReact");
  RunTarget("PackageWindowsDotNet");
});

RunTarget(target);
