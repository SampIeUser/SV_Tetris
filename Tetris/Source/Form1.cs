using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //create_objects();


            create_field();

            KeyPreview = true;

            // create first 2 figures
            create_figure(rnd.Next(0, 7));
            create_figure(rnd.Next(0, 7));
            label2.Text = "Score: 0";
            show_next(figures[next_figure].get_position(), figures[next_figure].get_color());



        }
        const int cell_size = 25; // size of game cells

        List<Figure> figures = new List<Figure>();
        //designed for test, but i leave it in case i'd like to change generation/getting new figure
        int current_figure = 0; 
        int next_figure = 1;
        int removed_lines_count = 0;
        public const int rows_count = 20; //playfield rows count
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
                

        public void create_figure(int f)
        {
            switch (f)
            {
                case 0:
                    I plank = new I();
                    figures.Add(plank);
                    
                    break;
                case 1:
                    O square = new O();
                    figures.Add(square);
                    break;
                case 2:
                    T Tplank = new T();
                    figures.Add(Tplank);
                    break;
                case 3:
                    L Lplank = new L();
                    figures.Add(Lplank);
                    break;
                case 4:
                    J Jplank = new J();
                    figures.Add(Jplank);
                    break;
                case 5:
                    Z Zplank = new Z();
                    figures.Add(Zplank);
                    break;
                case 6:
                    S Splank = new S();
                    figures.Add(Splank);
                    break;
            }

        }

        public bool game_over_check()
        {
            for (int i = 0; i<4; i++)
            {
                int x = figures[current_figure].get_position()[i, 0];
                int y = figures[current_figure].get_position()[i, 1];
                if (game_field.Rows[y].Cells[x].Style.BackColor != Color.Empty)
                {
                    return true;
                }                
            }
            return false;
        }

        public void create_field()
        {
            if (game_field.Rows.Count > 0)
            {
                game_field.Rows.Clear();
                game_field.Columns.Clear();
            }
            for (int i = 0; i < 10; i++)
            {
                game_field.Columns.Add("", "");
                game_field.Columns[i].Width = cell_size;
                game_field.Columns[i].ReadOnly = true;
            }
            for (int i = 0; i < rows_count; i++)
            {
                game_field.Rows.Add("", "");
                game_field.Rows[i].Height = cell_size;
                game_field.Rows[i].ReadOnly = true;
            }
            game_field.RowHeadersVisible = false;
            game_field.ColumnHeadersVisible = false;
            game_field.AllowUserToResizeColumns = false;
            game_field.AllowUserToResizeRows = false;
            // perhaps not needed
            game_field.AllowUserToDeleteRows = false;
            game_field.AllowUserToOrderColumns = false;
            game_field.AllowUserToAddRows = false;
            game_field.AllowUserToOrderColumns = false;

            game_field.Width = cell_size * 10 + 3;
            game_field.Height = cell_size * rows_count + 3;

            
            // NEXT field
            if (game_field2.Rows.Count > 0)
            {
                game_field2.Rows.Clear();
                game_field2.Columns.Clear();
            }
            for (int i = 0; i < 4; i++)
            {
                game_field2.Columns.Add("", "");
                game_field2.Columns[i].Width = cell_size;
                game_field2.Columns[i].ReadOnly = true;
                
               
            }
            for (int i = 0; i < 2; i++)
            {
                game_field2.Rows.Add("", "");
                game_field2.Rows[i].Height = cell_size;
                game_field2.Rows[i].ReadOnly = true;
            }
            game_field2.RowHeadersVisible = false;
            game_field2.ColumnHeadersVisible = false;
            game_field2.AllowUserToResizeColumns = false;
            game_field2.AllowUserToResizeRows = false;
            // perhaps not needed
            game_field2.AllowUserToDeleteRows = false;
            game_field2.AllowUserToOrderColumns = false;
            game_field2.AllowUserToAddRows = false;
            game_field2.AllowUserToOrderColumns = false;

            game_field2.Width = cell_size * 4 + 3;
            game_field2.Height = cell_size * 2 + 3;

            
           
        }

        public void draw_figure(int[,] position, Color figure_color)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    game_field.Rows[position[i, 1]].Cells[position[i, 0]].Style.BackColor = figure_color;

                }
            }
            catch
            {
                return;
            }
        }

        private void game_field_SelectionChanged(object sender, EventArgs e)
        {
            game_field.ClearSelection();
        }

        //rotate left
        public void r_left()
        {
            draw_figure(figures[current_figure].get_position(), Color.Empty);
            if (can_rotate(figures[current_figure], 0))
            {
                draw_figure(figures[current_figure].get_position(), Color.Empty);
                figures[current_figure].Rotate_left();
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }
            else
            {
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }
        }

        //rotate right
        public void r_right()
        {
            draw_figure(figures[current_figure].get_position(), Color.Empty);
            if (can_rotate(figures[current_figure], 1))
            {
                draw_figure(figures[current_figure].get_position(), Color.Empty);
                figures[current_figure].Rotate_right();
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }
            else
            {
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }

        }

        // move down
        public void m_down()
        {
            if (can_move(figures[current_figure], 1))
            {
                draw_figure(figures[current_figure].get_position(), Color.Empty);
                figures[current_figure].MoveDown();
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }
        }

        //left
        public void m_left()
        {
            if (can_move(figures[current_figure], 0))
            {
                draw_figure(figures[current_figure].get_position(), Color.Empty);
                figures[current_figure].MoveLeft();
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }

        }
        // right
        public void m_right()
        {
            if (can_move(figures[current_figure], 2))
            {
                draw_figure(figures[current_figure].get_position(), Color.Empty);
                figures[current_figure].MoveRight();
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());                
            }
        }


        public void set_darker_color(Figure fig)
        {
            Color current = fig.get_color();
          
            // switch does not work here
            // better way is getting the color and removeing 1 from r,g or b
            if (current == Color.Gold)
            {
                fig.change_color(Color.FromArgb(255, 214, 0));
            }
            if (current == Color.Blue)
            {
                fig.change_color(Color.FromArgb(0, 0, 254));
            }

            if (current == Color.Purple)
            {
                fig.change_color(Color.FromArgb(128, 0, 127));
            }
            if (current == Color.DarkSlateBlue)
            {
                fig.change_color(Color.FromArgb(72, 61, 138));
            }
            if (current == Color.Firebrick)
            {
                fig.change_color(Color.FromArgb(178, 34, 33));
            }
            if (current == Color.Green)
            {
                fig.change_color(Color.FromArgb(0, 127, 0));
            }
            if (current == Color.Orange)
            {
                fig.change_color(Color.FromArgb(255, 164, 0));
            }
        }

       
        // checks ability to rotate
        public bool can_rotate(Figure fig, byte direction) // 0 left, 1 right
        {
            int[,] pos_new;
            switch (direction)
            {
                
                case 0:
                    fig.Rotate_left();
                    pos_new= fig.get_position();
                    for (int i = 0; i < 4; i++)
                    {
                        if (pos_new[i, 0] < 0 || 
                            pos_new[i, 0] > 9 ||
                            pos_new[i, 1] < 0 ||
                            pos_new[i, 1]> rows_count-1 || 
                            (game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != Color.Empty && game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != fig.get_color()))
                        {
                            fig.Rotate_right();
                            return false;
                            break;
                        }
                    }
                    fig.Rotate_right();
                    break;
                case 1:
                    fig.Rotate_right();
                    pos_new = fig.get_position();
                    for (int i = 0; i < 4; i++)
                    {
                        if (pos_new[i, 0] < 0 ||
                            pos_new[i, 0] > 9 ||
                            pos_new[i, 1] < 0 ||
                            pos_new[i, 1] > rows_count-1 ||
                            (game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != Color.Empty && game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != fig.get_color()))
                        {
                            fig.Rotate_left();
                            return false;
                            break;
                        }
                    }
                    fig.Rotate_left();
                    break;
            }


            return true;
        }


        // checks ability to move.        
        public bool can_move(Figure fig, byte direction) // 0 left, 1 down, 2 right
        {
            //TO DO
            // should find a way to make a copy with better mthod            
            int[,] pos_new = new int[4, 2];
            for (int i = 0; i < 4; i++)
            {
                pos_new[i, 0] = fig.get_position()[i, 0];
                pos_new[i, 1] = fig.get_position()[i, 1];
                switch (direction)
                {
                    case 0:
                        pos_new[i, 0]--; // move left                        
                        if (pos_new[i, 0] < 0 || (game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != Color.Empty && game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != fig.get_color()))
                        {
                            return false;
                            break;
                        }

                        break;
                    case 1:
                        pos_new[i, 1]++; // move down                       
                        if (pos_new[i, 1] > rows_count-1 || (game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != Color.Empty && game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != fig.get_color()))
                        {
                            return false;
                            break;
                        }
                        break;
                    case 2:
                        pos_new[i, 0]++; // move right
                        if (pos_new[i, 0] > 9 || (game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != Color.Empty && game_field.Rows[pos_new[i, 1]].Cells[pos_new[i, 0]].Style.BackColor != fig.get_color()))
                        {
                            return false;
                            break;
                        }
                        break;
                }

            }



            return true;
        }






        public void remove_lines()
        {
            // search for filled lines. 
            int[] filled_cell_count = new int[rows_count];
            for (int row = rows_count-1; row != -1; row--)
            {
                for (int cell = 0; cell < 10; cell++)
                {
                    if (game_field.Rows[row].Cells[cell].Style.BackColor != Color.Empty)
                    {
                        filled_cell_count[row]++;
                    }
                }
            }

            // removeing lines if needed

            if (filled_cell_count.Contains(10))
            {
                for (int i = filled_cell_count.Length - 1; i > -1; i--)
                {
                    Console.WriteLine(i);
                    if (filled_cell_count[i] == 10)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            if (i != 0)
                            {
                                game_field.Rows[i].Cells[c].Style.BackColor = game_field.Rows[i - 1].Cells[c].Style.BackColor;
                                game_field.Rows[i - 1].Cells[c].Style.BackColor = Color.Empty;
                                filled_cell_count[i - 1] = 10; // for cycle could continue
                            }
                            else
                            {
                                game_field.Rows[i].Cells[c].Style.BackColor = Color.Empty;
                            }
                            removed_lines_count++;
                        }


                        
                    }
                }
                label2.Text = "Score: " + removed_lines_count.ToString();
                remove_lines();

            }






            //Console.WriteLine("finished line removal");

        }
        
       
        
        private void timer1_Tick(object sender, EventArgs e)
        {            

            if (can_move(figures[current_figure], 1))
            {
                draw_figure(figures[current_figure].get_position(), Color.Empty);
                figures[current_figure].MoveDown();
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
            }
            else // figure fallen down
            {
                
                // settle fallen figure, add same to figure list
                set_darker_color(figures[current_figure]);
                draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
                figures.RemoveAt(current_figure);
                int r;
                r = rnd.Next(0, 7);
                create_figure(r);

                remove_lines();

                if (game_over_check())
                {
                    timer1.Enabled = false; // to not cause multiply message boxes
                    MessageBox.Show($"Game over. Your score is: {removed_lines_count}");
                    
                    this.Close();
                }
                else
                {
                    draw_figure(figures[current_figure].get_position(), figures[current_figure].get_color());
                    show_next(figures[next_figure].get_position(), figures[next_figure].get_color());

                    // game slowely becomes faster
                    if (timer1.Interval>700)
                    {
                        timer1.Interval -= rnd.Next(0, 6);
                        label3.Text = "Speed: " + (1200 - timer1.Interval).ToString();
                    }
                    
                }



                
            }
            
           
        }
        public void show_next(int[,] position, Color figure_color)
        {
            for (int i = 0; i < 4; i++)
            {
                game_field2.Rows[0].Cells[i].Style.BackColor = Color.Black;
                game_field2.Rows[1].Cells[i].Style.BackColor = Color.Black;

            }


            try
            {
                for (int i = 0; i < 4; i++)
                {

                    game_field2.Rows[position[i, 1]].Cells[position[i, 0]-3].Style.BackColor = figure_color;

                }
            }
            catch
            {
                return;
            }

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar); // convert to capital letters
            switch (e.KeyChar)
            {
                case (char)Keys.Q:
                    r_left();
                    break;
                case (char)Keys.E:
                    r_right();
                    break;
                case (char)Keys.A:
                    m_left();
                    break;
                case (char)Keys.D:
                    m_right();
                    break;
                case (char)Keys.S:
                    m_down();
                    break;
                case (char)Keys.Space:
                    for (int i=0; i<20; i++)
                    {
                        m_down();
                    }
                    break;
                    
            }

            
            

            
        }

        private void game_field2_SelectionChanged(object sender, EventArgs e)
        {
            game_field2.ClearSelection();
        }

        





        // keypress events




    }
}
