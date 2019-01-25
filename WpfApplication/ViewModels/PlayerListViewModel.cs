using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WpfApplication.Commands;
using WpfApplication.Models;

namespace WpfApplication.ViewModels
{
    class PlayerListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PlayerViewModel> Players { get; set; }
        public ObservableCollection<Team> TeamList { get; set; }

        public PlayerListViewModel()
        {
            Players = new ObservableCollection<PlayerViewModel>();
            TeamList = new ObservableCollection<Team>();
            AddPlayers();

            PlayersCollectionView = new CollectionViewSource()
            {
                Source = Players
            };
        }

        //добавление игрока
        private ProcessCommand addCommand;
        public ProcessCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new ProcessCommand(obj =>
                    {
                        Player player = new Player()
                        {
                            Id = Players.Last().Id + 1,
                            Birthday = DateTime.Parse("01.01.1970"),
                            Team = TeamList[0],
                        };
                        PlayerViewModel playerV = new PlayerViewModel(player);

                        Players.Add(playerV);
                        PlayersCollectionView.Source = Players;

                        SelectedPlayer = playerV;
                    }));
            }
        }   

        public void AddPlayers()
        {
            Team t1 = new Team() { Id = 1, Name = "Котятки", Country = "Россия" };
            Team t2 = new Team() { Id = 2, Name = "Собачки", Country = "Америка" };
            Team t3 = new Team() { Id = 3, Name = "Львята", Country = "Япония" };

            TeamList.Add(t1);
            TeamList.Add(t2);
            TeamList.Add(t3);

            Players.Add(new PlayerViewModel(new Player()
                { Id = 1, Surname = "Козлов", Name="Денис",
                Birthday = DateTime.Parse("15.07.1993"),
                Weight = 59, Team = t1 }));

            Players.Add(new PlayerViewModel(new Player()
                { Id = 2, Surname = "Иванов", Name = "Евгений",
                Birthday = DateTime.Parse("04.09.1989"),
                Weight = 78, Team = t3 }));

            Players.Add(new PlayerViewModel(new Player()
                { Id = 3, Surname = "Дуров", Name = "Николай",
                Birthday = DateTime.Parse("21.05.1983"),
                Weight = 87, Team = t2 }));

            Players.Add(new PlayerViewModel(new Player()
                { Id = 4, Surname = "Суворов", Name = "Александр",
                Birthday = DateTime.Parse("08.11.1991"),
                Weight = 64, Team = t3 }));

            Players.Add(new PlayerViewModel(new Player()
                { Id = 5, Surname = "Семенов", Name = "Олег",
                Birthday = DateTime.Parse("19.02.1996"),
                Weight = 72, Team = t1 }));

            Players.Add(new PlayerViewModel(new Player()
                { Id = 6, Surname = "Курвыков", Name = "Алексей",
                Birthday = DateTime.Parse("13.12.1988"),
                Weight = 102, Team = t2 }));
        }        

        private bool isGrouped;
        public bool IsGrouped
        {
            get { return isGrouped; }
            set
            {
                isGrouped = value;
                OnPropertyChanged("IsGrouped");
                GroupCollectionView(isGrouped);
            }
        }

        public CollectionViewSource PlayersCollectionView { get; set; }
        private void GroupCollectionView(bool isGrouped)
        {
            if (isGrouped)
            {
                PlayersCollectionView.GroupDescriptions.Add(new PropertyGroupDescription("TeamName"));
            }
            else
            {
                PlayersCollectionView.GroupDescriptions.Clear();
            }
        }


        private PlayerViewModel selectedPlayer = new PlayerViewModel();
        public PlayerViewModel SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                selectedPlayer = value;
                OnPropertyChanged("SelectedPlayer");
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
