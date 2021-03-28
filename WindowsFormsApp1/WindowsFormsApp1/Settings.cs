using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public enum Directions
    {        //Объявление направлений движения змейки
        Left, Right, Up, Down
    };

 
    class Settings
    {
        
        public static int Height { get; set; }
        
        public static int Widht { get; set; }
        
        public static int Speed { get; set; }
        
        public static int Point { get; set; }
        
        public static int Score { get; set; }
        
        public static bool EndGame { get; set; }
        
        public static Directions direction { get; set; }


        public Settings()
        {
            Widht = 17;
            Height = 17;
            Speed = 5;
            Score = 0;
            Point = 10;
            EndGame = false;

        }
    }
}