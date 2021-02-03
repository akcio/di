using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class ImageSettingsAction : IUiAction
    {
        private IImageHolder imageHolder;

        private ImageSettings _imageSettings;
        // private IImageSettingsProvider imageSettingsProvider;

        public ImageSettingsAction(IImageHolder imageHolder, ImageSettings imageSettings)
        {
            this.imageHolder = imageHolder;
            this._imageSettings = imageSettings;
            // this.imageSettingsProvider = provider;
        }

        public string Category => "Настройки";
        public string Name => "Изображение...";
        public string Description => "Размеры изображения";

        public void Perform()
        {
            // var imageSettings = imageSettingsProvider.ImageSettings;
            SettingsForm.For(_imageSettings).ShowDialog();
            imageHolder.RecreateImage(_imageSettings);
        }
    }
}