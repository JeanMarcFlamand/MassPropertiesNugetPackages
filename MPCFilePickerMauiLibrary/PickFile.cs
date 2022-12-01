using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCFilePickerMauiLibrary
{
    public class PickFile
    {
        public static async Task<Stream> GetFileAsync()

        {
            //For custom file types       
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
                FileTypes = customFileType,
            });

            if (result == null)
                return null;

            var stream = await result.OpenReadAsync();
            return stream;

        }

    }
}
