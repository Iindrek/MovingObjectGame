using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Threading;
using System.Windows.Threading;

namespace MovingObjectGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool directionLeft, directionRight; //bool is true or false type variable
        int playerSpeed = 5; //int is async whole number type variable

        DispatcherTimer gameTimer = new DispatcherTimer(); //we create an instance of a class and store in a variable

        public MainWindow()
        {
            InitializeComponent();
            gameCanvas.Focus();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

        }

        private void GameTimer_Tick(Object sender, EventArgs e)
        {
            if (directionLeft)
            {
                double playerX = Canvas.GetLeft(hero);
                if (playerX > playerSpeed)
                {
                    Canvas.SetLeft(hero, playerX - playerSpeed);
                }
            }
            if (directionRight)
            {
                double playerX = Canvas.GetLeft(hero);
                if (playerX + hero.Width < Application.Current.MainWindow.Width - 10)
                {
                    Canvas.SetLeft(hero, playerX + playerSpeed);
                }
            }
        }



        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                gameCanvas.Background = new SolidColorBrush(Colors.Red);
            }
            if (e.Key == Key.Left)
            {
                directionRight = false;
                directionLeft = true;
            }
            if (e.Key == Key.Right)
            {
                directionLeft = false;  
                directionRight = true;
            }
        }

        private void gameCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                gameCanvas.Background = new SolidColorBrush(Colors.Coral);
            }
            if (e.Key == Key.Left)
            {
                //directionLeft = false;
            }
            if (e.Key == Key.Right)
            {
               // directionRight = false;
            }
        }
    }
}
