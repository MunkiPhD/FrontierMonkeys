using System;

namespace FrontierMonkeys {
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FrontierMonkeys game = new FrontierMonkeys())
            {
                game.Run();
            }
        }
    }
#endif
}


