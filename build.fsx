// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake
open Fake.Testing

RestorePackages()

// Properties
let buildDir = "./build/"
let testDir  = "./test/"

// Targets
Target "Clean" (fun f ->
  CleanDirs [buildDir; testDir]
)

Target "BuildApp" (fun f ->
  !! "src/app/**/*.csproj"
    |> MSBuildRelease buildDir "Build"
    |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun f ->
  !! "src/test/**/*.csproj"
    |> MSBuildDebug testDir "Build"
    |> Log "TestBuild-Output: "
)

Target "Test" (fun f ->
 !! (testDir + "/*.Tests.dll")
   |> NUnit3 (fun p ->
     {p with
       ErrorLevel = Error;
       Framework = V45 })
)

Target "Default" (fun f ->
  trace "Default target started"
)

// Dependencies
"Clean"
  ==> "BuildApp"
    ==> "BuildTest"
      ==> "Test"
        ==> "Default"

// Start default build if nothing explicitly specified
RunTargetOrDefault "Default"