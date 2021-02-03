namespace FractalPainting.Infrastructure.UiActions
{
    public interface IUiAction
    {
        MenuGroup Category { get; }
        string Name { get; }
        string Description { get; }
        void Perform();
    }
}