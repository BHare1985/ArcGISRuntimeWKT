using System;
using System.IO;
using System.Reflection;
using Esri.ArcGISRuntime;

namespace ArcGISRuntimeWKTTests
{
    public abstract class EsriBaseTest
    {
        protected EsriBaseTest()
        {
            SafeInitEsriSdk();
        }

        private static void SafeInitEsriSdk()
        {
            if (!ArcGISRuntimeEnvironment.IsInitialized)
            {
                ArcGISRuntimeEnvironment.InstallPath = GetCodeBaseDirectory();
            }
        }

        private static string GetCodeBaseDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}