namespace Windowlib
{
    public class WindowsRepository : IWindowsRepository
    {
        /// <summary>
        /// Liste over alle vinduer i repositoryet.
        /// </summary>
        private List<Window> _windows;

        public WindowsRepository()
        {
            _windows = new List<Window>();
            AddInitialWindows();
        }
        /// <summary>
        /// Henter alle vinduer i repositoryet.
        /// </summary>
        /// <returns></returns>
        public List<Window> GetAll()
        {
            List<Window> windowsCopy = _windows;
            return windowsCopy;
        }

        /// <summary>
        /// Henter et vindue baseret på dets ID.
        /// </summary>
        /// <param name="id">ID'et på vinduet der skal hentes.</param>
        /// /// <returns>Vindue med det angivne ID, eller null hvis det ikke findes.</returns>
        public Window? GetById(int id)
        {
            return _windows.FirstOrDefault(w => w.Id == id);
        }

        /// <summary>
        /// Tilføjer et vindue til repositoryet.
        /// </summary>
        /// <param name="window">Vindue der skal tilføjes.</param>
        /// <returns>Det tilføjede vindue med et genereret ID.</returns>
        public Window Add(Window window)
        {
            window.Id = GenerateId();
            _windows.Add(window);
            return window;
        }

        /// <summary>
        /// Sletter et vindue baseret på dets ID.
        /// </summary>
        /// <param name="id">ID'et på vinduet der skal slettes.</param>
        /// <returns>Det slettede vindue, eller null hvis det ikke findes.</returns>
        public Window? Delete(int id)
        {
            Window? windowToDelete = GetById(id);
            if (windowToDelete != null)
            {
                _windows.Remove(windowToDelete);
                return windowToDelete;
            }
            return windowToDelete;
        }
-
        /// <summary>
        /// genererer et unikt ID for et vindue.
        /// Dette ID er baseret på det nuværende antal vinduer i repositoryet.
        /// </summary>
        /// <returns>Et unikt ID for vinduet.</returns>
        private int GenerateId()
        {
            return _windows.Count > 0 ? _windows.Max(w => w.Id) + 1 : 1;
        }

        /// <summary>
        /// Tilføjer nogle forskellige window objekter til repositoryet.
        /// </summary>
        private void AddInitialWindows()
        {
            Add(new Window("Model A", "A", 100));
            Add(new Window("Model B", "B", 200));
            Add(new Window("Model C", "C", 300));
            Add(new Window("Model D", "A", 400));
            Add(new Window("Model E", "B", 500));
        }

    }
}
