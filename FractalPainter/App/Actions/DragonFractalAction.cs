using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.Injection;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App.Actions
{
    public class DragonFractalAction : IUiAction
    {
        private IDragonPainterFactory dragonPainterFactory;
        private Func<Random, DragonSettingsGenerator> dragonSettingsGeneratorFuncFactory;

        public DragonFractalAction(IDragonPainterFactory dragonPainterFactory, 
            Func<Random, DragonSettingsGenerator> dragonSettingsGeneratorFuncFactory)
        {
            this.dragonPainterFactory = dragonPainterFactory;
            this.dragonSettingsGeneratorFuncFactory = dragonSettingsGeneratorFuncFactory;
        }

        public string Category => "Фракталы";
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = CreateRandomSettings();
            // редактируем настройки:
            SettingsForm.For(dragonSettings).ShowDialog();
            // создаём painter с такими настройками
            var dragonPainter = dragonPainterFactory.Create(dragonSettings);
            dragonPainter.Paint();
        }

        private DragonSettings CreateRandomSettings()
        {
            return dragonSettingsGeneratorFuncFactory(new Random()).Generate();
        }
    }
}