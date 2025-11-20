using IronOcr;
namespace IronOcr.Examples.GettingStarted.Aws
{
    public static class Section1
    {
        public static void Run()
        {
            // Set temporary folder path and log file path for IronOCR.
            var awsTmpPath = @"/tmp/";
            IronOcr.Installation.InstallationPath = awsTmpPath;
            IronOcr.Installation.LogFilePath = awsTmpPath;
        }
    }
}