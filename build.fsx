// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake
open Fake.Testing

RestorePackages()

// Properties
let buildDir = "./build/"
let testDir  = "./test/"

// Targets
Target "Clean" (fun _ ->
  CleanDirs [buildDir; testDir]
)

Target "BuildApp" (fun _ ->
  !! "src/app/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
  !! "src/test/**/*.csproj"
    |> MSBuildDebug testDir "Build"
    |> Log "TestBuild-Output: "
)

Target "Test" (fun _ ->
 !! (testDir + "/*.Tests.dll")
   |> NUnit3 (fun p ->
     {p with
       ErrorLevel = Error;
       Framework = V45 })
)

Target "Default" (fun _ ->
  trace "Hello World from FAKE"
)

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"
  ==> "Default"

// start build
RunTargetOrDefault "Default"