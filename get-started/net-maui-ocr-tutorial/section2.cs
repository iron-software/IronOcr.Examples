using IronOcr;
namespace IronOcr.Examples.GettingStarted.NetMauiOcrTutorial
{
    public static class Section2
    {
        public static void Run()
        {
            var images = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick image",
                FileTypes = FilePickerFileType.Images
            });
            var path = images.FullPath.ToString();
        }
    }
}