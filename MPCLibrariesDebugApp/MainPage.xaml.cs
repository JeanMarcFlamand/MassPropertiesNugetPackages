using CommunityToolkit.Maui.Core.Views;
using MPCFilePickerMauiLibrary;



namespace MPCLibrariesDebugApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OpenFile_Clicked(object sender, EventArgs e)
        {
            string appDirPath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(appDirPath);
            }
            catch (DirectoryNotFoundException err)
            {
                await DisplayAlert("File Path", "You have been alerted¨for error", "OK");
            }


            string? filePath = await PickTxtFile.GetFilePathAsync();

            if (File.Exists(filePath))
            {
                var MPCfile = File.ReadAllText(filePath);

            }
            else
            {
                await DisplayAlert("File Path", "Usre did not select a file", "OK");
            }

        }
        //This method returns a read-only Stream representing the file contents. 
        public async Task<string> ReadTextFile(string filePath)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);

            return await reader.ReadToEndAsync();
        }

        async private void GoToCSharpSampleClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "You have been alerted", "OK");
        }
    }
}