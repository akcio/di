using System.Runtime.InteropServices.ComTypes;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class ImageSettingsAction : IUiAction
    {
        private IImageHolder imageHolder;

        private ImageSettings imageSettings;

        private SettingsManager manager;
        // private IImageSettingsProvider imageSettingsProvider;

        public ImageSettingsAction(IImageHolder imageHolder, ImageSettings imageSettings, SettingsManager manager)
        {
            this.imageHolder = imageHolder;
            this.imageSettings = imageSettings;
            this.manager = manager;
            // this.imageSettingsProvider = provider;
        }

        public MenuGroup Category => MenuGroup.Settings;
        public string Name => "Изображение...";
        public string Description => "Размеры изображения";

        public void Perform()
        {
            // var imageSettings = imageSettingsProvider.ImageSettings;
            SettingsForm.For(imageSettings).ShowDialog();
            imageHolder.RecreateImage(imageSettings);
            var appSettings = manager.Load();
            appSettings.ImageSettings = imageSettings;
            manager.Save(appSettings);
        }
    }
}