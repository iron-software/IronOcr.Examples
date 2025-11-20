using IronOcr;
namespace IronOcr.Examples.GettingStarted.LicenseKeys
{
    public static class Section1
    {
        public static void Run()
        {
            // Set your IronOCR license key at the beginning of your application
            IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
        }
    }
}