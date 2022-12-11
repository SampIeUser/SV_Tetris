using System.Drawing;

namespace Tetris
{
    // stick
    class I : Figure
    {
        public I()
        {
            position[0, 0] = 4;
            position[0, 1] = 0;

            position[1, 0] = 3;
            position[1, 1] = 0;

            position[2, 0] = 5;
            position[2, 1] = 0;

            position[3, 0] = 6;
            position[3, 1] = 0;
            figure_color = Color.Blue;
        }
        
    }

}
