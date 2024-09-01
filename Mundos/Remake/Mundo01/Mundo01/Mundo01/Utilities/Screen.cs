namespace Mundo01.Utilities
{
    class Screen
    {
        static Screen instance;
        public int Width { get; set; }
        public int Height { get; set; }

        public static Screen GetInstance()
        {
            if (instance == null)
                instance = new Screen();

            return instance;
        }
    }
}
