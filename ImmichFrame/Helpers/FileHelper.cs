using Avalonia.Controls;
using Avalonia.Platform.Storage;
using ImmichFrame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmichFrame.Helpers
{
    public static class FileHelper
    {
        public async static Task<IStorageFile?> ShowSaveFileDialog(bool showOverwritePrompt)
        {
            var topLevel = WindowView.MainTopLevel;
            if (topLevel != null)
            {
                var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
                {
                    Title = "Save File",
                    SuggestedFileName = "ImmichFrameSettings.json",
                    ShowOverwritePrompt = showOverwritePrompt
                });
                if (file is not null)
                {
                    return file;
                }
            }
            return null;
        }
        public async static Task<IStorageFile?> ShowOpenFileDialog()
        {
            var topLevel = WindowView.MainTopLevel;
            if (topLevel != null)
            {
                var file = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    Title = "Open File",
                    AllowMultiple = false,
                    SuggestedFileName = "ImmichFrameSettings.json",
                });
                if (file is not null)
                {
                    return file[0];
                }
            }
            return null;
        }
    }
}
