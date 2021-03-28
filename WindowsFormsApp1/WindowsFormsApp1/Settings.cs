using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public enum Directions {        //Объявление направлений движения змейки
        Left, Right, Up, Down
    };


    /// <summary>
    /// Класс отвечает за все действия на форме.
    /// </summary>
    class Settings
    {
        /// <value>Gets and sets the value of Height.</value>
        public static int Height { get; set; }
        /// <value>Gets  and sets the value of Widht.</value>
        public static int Widht { get; set; }
        /// <value>Gets and sets the value of Speed.</value>
        public static int Speed { get; set; }
        /// <value>Gets and sets the value of Point.</value>
        public static int Point { get; set; }
        /// <value>Gets and sets the value of Score.</value>
        public static int Score { get; set; }
        /// <value>Gets and sets the value of EndGame.</value>
        public static bool EndGame { get; set; }
        /// <value>Gets and sets the value of direction.</value>
        public static Directions direction { get; set; }


        public Settings() {
            Widht = 17;
            Height = 17;
            Speed = 5;
            Score = 0;
            Point = 10;
            EndGame = false;

        }   
    }

    
}
