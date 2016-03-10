#indent "off"

// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake


// Properties
let buildDir = "./build/";
let testDir  = "./test/";

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

Target "Default" (fun _ ->
	trace "Hello World from FAKE"
)

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Default"

// start build
RunTargetOrDefault "Default";
