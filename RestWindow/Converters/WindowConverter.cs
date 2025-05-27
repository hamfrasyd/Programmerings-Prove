using RestWindow.DTOs;
using Windowlib;

namespace RestWindow.Converters
{
    public static class WindowConverter
    {
        public static Window DTO2Window(WindowDTO dto)
        {
            Window window = new Window();
            window.Model = dto.Model;
            window.EnergyClass = dto.EnergyClass;
            window.Price = dto.Price;
            return window;
        }
    }
}
