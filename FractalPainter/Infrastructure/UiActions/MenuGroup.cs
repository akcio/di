namespace FractalPainting.Infrastructure.UiActions
{
    public enum MenuGroup
    {
        File = 1,
        Fractals = 2,
        Settings = 3
    }

    public static class MenuGroupTranslator
    {
        public static string GetTranslate(MenuGroup group)
        {
            return @group switch
            {
                MenuGroup.File => "Файл",
                MenuGroup.Fractals => "Фракталы",
                MenuGroup.Settings => "Настройки",
                _ => "Unknown"
            };
        }
    } 
}