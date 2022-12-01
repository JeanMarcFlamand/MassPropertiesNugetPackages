using Microsoft.Maui.Storage;

namespace MPCFilePickerMauiLibrary;

//Ref https://youtu.be/C6LV_xMGdKc - Intro To Class Libraries in C#
public class PickTxtFile
{
    
    public static async Task<string> GetFilePathAsync()

    {
        //For custom file types.       
        var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.text" } }, // UTType values
                    { DevicePlatform.Android, new[] { "text/plain" } }, // MIME type
                    { DevicePlatform.WinUI, new[] { ".Txt" } }, // file extension
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, new[] { "Txt" } }, // UTType values
                });

        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick MPC Demo file Please",
            FileTypes = customFileType
        });

        if (result == null)
            return "";

        var FileFullPath = result.FullPath.ToString();
        return FileFullPath;
        
    }
    
}


