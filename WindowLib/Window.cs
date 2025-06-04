namespace Windowlib
{
    /// <summary>
    /// Ræpresenterer et vindue i Windowlib.
    /// Denne klasse indeholder information om vinduets model, energi klasse og pris.
    /// </summary>
    public class Window
    {
        #region instans variabler
        private string _model;
        private char _energyClass;
        private int _price;
        #endregion

        #region properties
        /// <summary>
        /// Unik ID for vinduet
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Modelnavn for vinduet
        /// </summary>
        /// <remarks>
        /// Modelnavnet skal minimum have 2 tegn.
        /// </remarks>
        /// <exception cref="ArgumentException">Modelnavnet skal minimum have 2 tegn.</exception>
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (value.Length < 2) // null
                {
                    throw new ArgumentException("Model skal minumum have 2 tegn");
                }
                _model = value;
            }
        }

        /// <summary>
        /// Energi klasse for vinduet
        /// </summary>
        /// <remarks>
        /// Energi klasse skal være A, B eller C.
        /// </remarks>
        /// <returns>Energi klasse</returns>
        /// <exception cref="ArgumentException">Energi klasse skal være A, B eller C.</exception>
        public char EnergyClass
        {
            get
            {
                return _energyClass;
            }
            set
            {
                switch (value) // null
                {
                    case 'A':
                    case 'B':
                    case 'C':
                        break;
                    default:
                        throw new ArgumentException("Energi klasse skal være A, B eller C");
                }
                _energyClass = value;
            }
        }
        /// <summary>
        /// Pris for vinduet
        /// </summary>
        /// <remarks>
        /// Prisen skal være et positivt tal.
        /// </remarks>
        /// <returns>Pris</returns>
        /// <exception cref="ArgumentException">Prisen kan ikke være negativ</exception>
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value <= -1)
                {
                    throw new ArgumentException("Prisen kan ikke være negativ");
                }
                _price = value;
            }
        }
        #endregion

        #region constructor

        /// <summary>
        /// Constructor for Windowlib class
        /// </summary>
        /// <param name="model">Modelnavn for vinduet</param>
        /// <param name="energyClass">Energi klasse for vinduet</param>
        /// <param name="price">Pris for vinduet</param>
        public Window(string model, char energyClass, int price)
        {
            Model = model;
            EnergyClass = energyClass;
            Price = price;
        }
        /// <summary>
        /// Default constructor for Windowlib class
        /// </summary>
        /// <remarks>
        /// Default constructor sætter Windowlib til at være, Model: "Default Model", EnergyClass: "A" og Price: 0.
        /// </remarks>
        public Window() : this("Default Model", 'A', 0)
        {
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return $"ID: {Id} - Model: {Model} - Energi klasse: {EnergyClass} - Pris: {Price}";
        }
        #endregion 
    }
}
