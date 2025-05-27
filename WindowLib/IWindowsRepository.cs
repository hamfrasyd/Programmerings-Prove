namespace Windowlib
{
    public interface IWindowsRepository
    {
        Window Add(Window window);
        Window? Delete(int id);
        List<Window> GetAll();
        Window? GetById(int id);
    }
}