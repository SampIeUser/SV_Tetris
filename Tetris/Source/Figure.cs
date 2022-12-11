using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace Tetris
{
    public class Figure
    {
        protected Color figure_color;
        protected int[,] position = new int[4, 2];
        /*
         int [x.y]
           y y y
         x * * *  
         x * * *
         x * * *
         x * * *
         x * * *
         */

        public Color get_color()
        {
            return figure_color;
        }
        public void change_color(Color new_color)
        {
            figure_color = new_color;
        }
        public void MoveLeft()
        {
            if (position[0, 0] == 0 || position[1, 0] == 0 || position[2, 0] == 0 || position[3, 0] == 0)
            {

            }
            else
            {
                position[0, 0]--;
                position[1, 0]--;
                position[2, 0]--;
                position[3, 0]--;
            }
        }
        public void MoveRight()
        {
            // написание проверки невыхождения за поле
            if (position[0, 0] == 9 || position[1, 0] == 9 || position[2, 0] == 9 || position[3, 0] == 9)
            {

            }
            else
            {
                position[0, 0]++;
                position[1, 0]++;
                position[2, 0]++;
                position[3, 0]++;
            }
        }
        public void MoveDown()
        {
            // написание проверки невыхождения за поле
            if (position[0, 1] == Form1.rows_count-1 || position[1, 1] == Form1.rows_count - 1 || position[2, 1] == Form1.rows_count-1 || position[3, 1] == Form1.rows_count-1)
            {

            }
            else
            {
                position[0, 1]++;
                position[1, 1]++;
                position[2, 1]++;
                position[3, 1]++;
            }

        }
        private void Rotation()
        {
            
        }
        //x2 = px + py - y1
        //y2 = x1 + py - px
        // p -> center of rotation
        //x1 -> current pos of moveing piece
        //

        public virtual void Rotate_left()
        {
            int px = position[0, 0];
            int py = position[0, 1];
            int x1;
            int y1;
            for (int i = 1; i < 4; i++)
            {
                x1 = position[i, 0];
                y1 = position[i, 1];
                position[i, 0] = px + py - y1;
                position[i, 1] = py - px + x1;
            }
        }
        public virtual void Rotate_right()
        {
            Rotate_left(); Rotate_left(); Rotate_left();
        }

        public int[,] get_position()
        {            
            return position;
        }
        public void print_position()
        {
            Console.WriteLine(position[0, 0] + "," + position[0, 1] + " // " + position[1, 0] + "," + position[1, 1] + " // " + position[2, 0] + "," + position[2, 1] + " // " + position[3, 0] + "," + position[3, 1]);
        }




    }


}
