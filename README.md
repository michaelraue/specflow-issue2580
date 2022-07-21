# Minimalistic SpecFlow solution to reproduce issue 2580

https://github.com/SpecFlowOSS/SpecFlow/issues/2580

After checkout
* when using Rider 2022.1.2, the test is failing in _Run_ mode, but successful in _Debug_ mode
* when using Visual Studio 2022 17.2.6, the test is failing in both modes _Debug_ and _Run_

If the xUnit Nuget packages are exchanged with MSTest packages (see comments in SpecFlow.Issue2580.csproj),
then the test is working fine in both VS2022 and Rider, both in _Run_ and _Debug_.
