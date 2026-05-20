using IronOcr;
namespace IronOcr.Examples.GettingStarted.LicenseKeys
{
    public static class Section2
    {
        public static void Run()
        {
            // Validate the license key
            bool result = IronOcr.License.IsValidLicense("IRONOCR-MYLICENSE-KEY-1EF01");
        }
    }
}