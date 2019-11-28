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
using System.Windows.Threading;

namespace Quiz_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Quiz _q = new Quiz();
        private List<int> _lst = new List<int>();
        private string _ans;
        private int _score = 0;
        private int _number = 1;

        private int _time = 60;
        private DispatcherTimer Timer;

        public MainWindow()
        {
            InitializeComponent();

            

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time > 0)
            {
                if (_time < 10)
                {
                    if (_time % 2 == 0)
                    {
                        TBCountDown.Foreground = Brushes.Red;
                    }
                    else
                    {
                        TBCountDown.Foreground = Brushes.White;
                    }
                    _time--;
                    TBCountDown.Text = string.Format("00:0{0}:0{1}", _time / 60, _time % 60);
                }
                else
                {
                    _time--;
                    TBCountDown.Text = string.Format("00:0{0}:{1}", _time / 60, _time % 60);
                }
            }
            else
            {
                Timer.Stop();
                MessageBox.Show("You fail this test");
                this.Close();
                
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Hidden;
            logoName.Visibility = Visibility.Hidden;
            quest.Visibility = Visibility.Visible;
            ans1.Visibility = Visibility.Visible;
            ans2.Visibility = Visibility.Visible;
            ans3.Visibility = Visibility.Visible;
            ans4.Visibility = Visibility.Visible;
            scoreLbl.Visibility = Visibility.Visible;
            countdown.Visibility = Visibility.Visible;
            TBCountDown.Visibility = Visibility.Visible;
            info.Visibility = Visibility.Hidden;
            border.Visibility = Visibility.Hidden;
            quest_info.Visibility = Visibility.Visible;

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();

            //
            int i = this.getRandom();
            quest.Content = _q.getQuestion(i);
            //
            ans1.Content = _q.getAnswer(i, 1);
            ans2.Content = _q.getAnswer(i, 2);
            ans3.Content = _q.getAnswer(i, 3);
            ans4.Content = _q.getAnswer(i, 4);
            if (Convert.ToString(ans1.Content).StartsWith("*"))
            {
                this._ans = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                ans1.Content = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
            }
            else
            {
                if (Convert.ToString(ans2.Content).StartsWith("*"))
                {
                    this._ans = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                    ans2.Content = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                }
                else
                {
                    if (Convert.ToString(ans3.Content).StartsWith("*"))
                    {
                        this._ans = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                        ans3.Content = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                    }
                    else
                    {
                        this._ans = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                        ans4.Content = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                    }
                }
            }


            _lst.Add(i);
        }
        public int getRandom()
        {
            Random rnd = new Random();
            int i = rnd.Next(11);
            if(_lst.Contains(i) && _lst.Count()<11)
                while(_lst.Contains(i))
                    i = rnd.Next(0,11);
            return i;
        }


        private void ans1_Click(object sender, RoutedEventArgs e)
        {
            if (this._number < 11)
            {
                this._number++;
                if (Convert.ToString(ans1.Content) == this._ans)
                    this._score++;
                int i = this.getRandom();
                quest.Content = _q.getQuestion(i);
                //
                ans1.Content = _q.getAnswer(i, 1);
                ans2.Content = _q.getAnswer(i, 2);
                ans3.Content = _q.getAnswer(i, 3);
                ans4.Content = _q.getAnswer(i, 4);
                if (Convert.ToString(ans1.Content).StartsWith("*"))
                {
                    this._ans = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                    ans1.Content = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                }
                else
                {
                    if (Convert.ToString(ans2.Content).StartsWith("*"))
                    {
                        this._ans = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                        ans2.Content = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                    }
                    else
                    {
                        if (Convert.ToString(ans3.Content).StartsWith("*"))
                        {
                            this._ans = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                            ans3.Content = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                        }
                        else
                        {
                            this._ans = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                            ans4.Content = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                        }
                    }
                }
                _lst.Add(i);
                scoreLbl.Content = "Score : "+this._score;
            }
            else
            {
                quest.Visibility = Visibility.Hidden;
                quest_info.Visibility = Visibility.Hidden;
                ans1.Visibility = Visibility.Hidden;
                ans2.Visibility = Visibility.Hidden;
                ans3.Visibility = Visibility.Hidden;
                ans4.Visibility = Visibility.Hidden;
                final.Visibility = Visibility.Visible;
                final.Content ="         Congratulations" + "\n          Your score is " + this._score;
                restart.Visibility = Visibility.Visible;
                moreinfo.Visibility = Visibility.Visible;
                Timer.Stop();
                TBCountDown.Visibility = Visibility.Hidden;
            }
        }

        private void ans2_Click(object sender, RoutedEventArgs e)
        {
            if (this._number < 11)
            {
                this._number++;
                if (Convert.ToString(ans2.Content) == this._ans)
                    this._score++;
                int i = this.getRandom();
                quest.Content = _q.getQuestion(i);
                //
                ans1.Content = _q.getAnswer(i, 1);
                ans2.Content = _q.getAnswer(i, 2);
                ans3.Content = _q.getAnswer(i, 3);
                ans4.Content = _q.getAnswer(i, 4);
                if (Convert.ToString(ans1.Content).StartsWith("*"))
                {
                    this._ans = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                    ans1.Content = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                }
                else
                {
                    if (Convert.ToString(ans2.Content).StartsWith("*"))
                    {
                        this._ans = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                        ans2.Content = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                    }
                    else
                    {
                        if (Convert.ToString(ans3.Content).StartsWith("*"))
                        {
                            this._ans = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                            ans3.Content = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                        }
                        else
                        {
                            this._ans = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                            ans4.Content = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                        }
                    }
                }
                _lst.Add(i);
                scoreLbl.Content = "Score : " + this._score;
            }
            else
            {
                quest.Visibility = Visibility.Hidden;
                quest_info.Visibility = Visibility.Hidden;
                ans1.Visibility = Visibility.Hidden;
                ans2.Visibility = Visibility.Hidden;
                ans3.Visibility = Visibility.Hidden;
                ans4.Visibility = Visibility.Hidden;
                final.Visibility = Visibility.Visible;
                final.Content = "         Congratulations"+"\n          Your score is " + this._score;
                restart.Visibility = Visibility.Visible;
                moreinfo.Visibility = Visibility.Visible;
                Timer.Stop();
                TBCountDown.Visibility = Visibility.Hidden;
            }
        }

        private void ans3_Click(object sender, RoutedEventArgs e)
        {
            if (this._number < 11)
            {
                this._number++;
                if (Convert.ToString(ans3.Content) == this._ans)
                    this._score++;
                int i = this.getRandom();
                quest.Content = _q.getQuestion(i);
                //
                ans1.Content = _q.getAnswer(i, 1);
                ans2.Content = _q.getAnswer(i, 2);
                ans3.Content = _q.getAnswer(i, 3);
                ans4.Content = _q.getAnswer(i, 4);
                if (Convert.ToString(ans1.Content).StartsWith("*"))
                {
                    this._ans = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                    ans1.Content = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                }
                else
                {
                    if (Convert.ToString(ans2.Content).StartsWith("*"))
                    {
                        this._ans = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                        ans2.Content = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                    }
                    else
                    {
                        if (Convert.ToString(ans3.Content).StartsWith("*"))
                        {
                            this._ans = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                            ans3.Content = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                        }
                        else
                        {
                            this._ans = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                            ans4.Content = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                        }
                    }
                }
                _lst.Add(i);
                scoreLbl.Content = "Score : " + this._score;
            }
            else
            {
                quest.Visibility = Visibility.Hidden;
                quest_info.Visibility = Visibility.Hidden;
                ans1.Visibility = Visibility.Hidden;
                ans2.Visibility = Visibility.Hidden;
                ans3.Visibility = Visibility.Hidden;
                ans4.Visibility = Visibility.Hidden;
                final.Visibility = Visibility.Visible;
                final.Content = "         Congratulations"+"\n          Your score is " + this._score;
                restart.Visibility = Visibility.Visible;
                moreinfo.Visibility = Visibility.Visible;
                Timer.Stop();
                TBCountDown.Visibility = Visibility.Hidden;
            }
        }

        private void ans4_Click(object sender, RoutedEventArgs e)
        {
            if (this._number <11)
            {
                this._number++;
                if (Convert.ToString(ans4.Content) == this._ans)
                    this._score++;
                int i = this.getRandom();
                quest.Content = _q.getQuestion(i);
                //
                ans1.Content = _q.getAnswer(i, 1);
                ans2.Content = _q.getAnswer(i, 2);
                ans3.Content = _q.getAnswer(i, 3);
                ans4.Content = _q.getAnswer(i, 4);
                if (Convert.ToString(ans1.Content).StartsWith("*"))
                {
                    this._ans = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                    ans1.Content = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                }
                else
                {
                    if (Convert.ToString(ans2.Content).StartsWith("*"))
                    {
                        this._ans = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                        ans2.Content = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                    }
                    else
                    {
                        if (Convert.ToString(ans3.Content).StartsWith("*"))
                        {
                            this._ans = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                            ans3.Content = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                        }
                        else
                        {
                            this._ans = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                            ans4.Content = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                        }
                    }
                }
                _lst.Add(i);
                scoreLbl.Content = "Score : " + this._score;
            }
            else
            {
                quest.Visibility = Visibility.Hidden;
                quest_info.Visibility = Visibility.Hidden;
                ans1.Visibility = Visibility.Hidden;
                ans2.Visibility = Visibility.Hidden;
                ans3.Visibility = Visibility.Hidden;
                ans4.Visibility = Visibility.Hidden;
                final.Visibility = Visibility.Visible;
                final.Content = "         Congratulations" + "\n          Your score is " + this._score;
                restart.Visibility = Visibility.Visible;
                moreinfo.Visibility = Visibility.Visible;
                Timer.Stop();
                TBCountDown.Visibility = Visibility.Hidden;

            }
        }

 

        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void minimizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void Button_More(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            this._score = 0;
            scoreLbl.Content = "Score : " + this._score;
            this._number = 1;
            final.Visibility = Visibility.Hidden;
            this._time = 60;

            _lst.Clear();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
            restart.Visibility = Visibility.Hidden;
            moreinfo.Visibility = Visibility.Hidden;

            TBCountDown.Visibility = Visibility.Visible;
            quest.Visibility = Visibility.Visible;
            quest_info.Visibility = Visibility.Visible;
            ans1.Visibility = Visibility.Visible;
            ans2.Visibility = Visibility.Visible;
            ans3.Visibility = Visibility.Visible;
            ans4.Visibility = Visibility.Visible;
            scoreLbl.Visibility = Visibility.Visible;



            //
            int i = this.getRandom();
            quest.Content = _q.getQuestion(i);
            //
            ans1.Content = _q.getAnswer(i, 1);
            ans2.Content = _q.getAnswer(i, 2);
            ans3.Content = _q.getAnswer(i, 3);
            ans4.Content = _q.getAnswer(i, 4);
            if (Convert.ToString(ans1.Content).StartsWith("*"))
            {
                this._ans = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
                ans1.Content = Convert.ToString(ans1.Content).Substring(1, Convert.ToString(ans1.Content).Length - 1);
            }
            else
            {
                if (Convert.ToString(ans2.Content).StartsWith("*"))
                {
                    this._ans = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                    ans2.Content = Convert.ToString(ans2.Content).Substring(1, Convert.ToString(ans2.Content).Length - 1);
                }
                else
                {
                    if (Convert.ToString(ans3.Content).StartsWith("*"))
                    {
                        this._ans = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                        ans3.Content = Convert.ToString(ans3.Content).Substring(1, Convert.ToString(ans3.Content).Length - 1);
                    }
                    else
                    {
                        this._ans = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                        ans4.Content = Convert.ToString(ans4.Content).Substring(1, Convert.ToString(ans4.Content).Length - 1);
                    }
                }
            }
            _lst.Add(i);
        }
    }
}
