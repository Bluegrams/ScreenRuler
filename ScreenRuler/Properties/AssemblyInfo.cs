﻿using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using Bluegrams.Application.Attributes;

[assembly: AssemblyTitle("Screen Ruler")]
[assembly: AssemblyDescription("Screen measuring tool for Windows")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Bluegrams")]
[assembly: AssemblyProduct("Screen Ruler")]
[assembly: AssemblyCopyright("Copyright © 2017-2022 Bluegrams")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ProductWebsite("https://screenruler.sourceforge.io")]
[assembly: ProductLicense("https://github.com/Bluegrams/ScreenRuler/blob/master/LICENSE.txt", "BSD-3-Clause")]
[assembly: CompanyWebsite("http://bluegrams.com", "Bluegrams")]

#if PORTABLE
[assembly: AppPortable(true)]
#endif

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("67b8f96e-8237-4c57-983b-a2ca5bddc9ae")]

[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.10.0")]
[assembly: AssemblyFileVersion("0.10.0")]
