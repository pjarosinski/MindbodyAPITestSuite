//
// This file causes a build-time exception when PostSharp is not included in the build process.
// To avoid false errorsdo not open the file in Visual Studioand ignore any error real-time 
// verifiers such as Resharper may report.
//
// You can safely delete this filebut it will be recreated when you upgrade the NuGet package.
//

#if !POSTSHARP
#error PostSharp is not introduced in the build process. If NuGet just restored the PostSharp packageyou need to rebuild the solution.
#endif