using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication.Commands;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    class PlayerViewModel : INotifyPropertyChanged
    {
        private Player player;

        public PlayerViewModel()
        {
            player = new Player();
        }

        public PlayerViewModel(Player p)
        {
            player = p;
        }

        public int Id
        {
            get { return player.Id; }
        } 

        public bool NormWeight { get { return (70 < player.Weight) && (player.Weight < 100); } }

        public string Surname
        {
            get { return player.Surname; }
            set
            {
                player.Surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Name
        {
            get { return player.Name; }
            set
            {
                player.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Birthday
        {
            get { return player.Birthday.ToString("dd.MM.yyyy"); }
            set
            {
                try
                {
                    player.Birthday = DateTime.Parse(value);
                }
                catch
                {
                    MessageBox.Show("Формат даты должен иметь вид: dd.mm.yyyy","Внимание!",
                        MessageBoxButton.OK,MessageBoxImage.Warning);
                }
                finally
                {
                    OnPropertyChanged("Birthday");
                }
            }
        }

        public int Weight
        {
            get { return player.Weight; }
            set
            {
                player.Weight = value;
                OnPropertyChanged("Weight");
                OnPropertyChanged("NormWeight");
            }
        }

        public string TeamName
        {
            get { return player.Team.Name; }
            set
            {
                player.Team.Name = value;
                OnPropertyChanged("TeamName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
