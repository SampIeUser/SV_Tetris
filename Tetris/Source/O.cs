using System.Drawing;

namespace Tetris
{
    // square    
    class O : Figure
    {
        public O()
        {
            position[0, 0] = 3;
            position[0, 1] = 0;

            position[1, 0] = 4;
            position[1, 1] = 0;

            position[2, 0] = 3;
            position[2, 1] = 1;

            position[3, 0] = 4;
            position[3, 1] = 1;
            figure_color = Color.Gold;
        }

        // since there is no need to rotate square:
        public override void Rotate_left() { }
        public override void Rotate_right() { }
    }
}
