   M S B A M L   `   `   `  ����I  EWpfApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfApplicationWpfApplication  5   	   E'clr-namespace:WpfApplication.ViewModelsWpfApplication.ViewModels  5   	   E'clr-namespace:WpfApplication.ConvertersWpfApplication.Converters  5   	       WpfApplication.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfApplication     5   	   >
ViewModels'clr-namespace:WpfApplication.ViewModels     5   	   >
Converters'clr-namespace:WpfApplication.Converters     5   	     � Title$  
MainWindow��5
   	   $	��350��6   $	��550��6)    � DataContext 5      3  -WpfApplication.ViewModels.PlayerListViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��120px �6   .+�5   
   �� -   5         ��Name$ chBTeam��5      $��Группировка��6$   $	��5pxq�6:   $��0��5      $��0��6    $��2��60    d� 	IsChecked 5      �� *	IsGrouped+&   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgPlayers��5      $��1��6&   $��0��63      
IsReadOnly . ��5      �� *PlayersCollectionView.View+ �� SelectedItem 5      �� *SelectedPlayer+	 �� 
GroupStyle	 5!      (  "System.Windows.Controls.GroupStyle  5"         DataGridGroupItemStyle
   ContainerStyle#
 [  6   5$      �� 5&   
   -   5         ��Name$ stPanel��5&      $��1��6&   $��1��63    �� Orientation$ Vertical=�5'      $	��Top=�6+   .+�5(      �� $��Фамилия��6     tbStyle#��[ 6(   �� 5)      -   5         ��Name$ 	tbSurname��5)        txtStyle#��[ 6Q   ��6)   �� *SelectedPlayer.Surname+6Q   �� 5+      $��Имя��6   #��[ 6$   �� 5,      -   5        $ tbName��5,      #��[ 6K   ��6&   �� *SelectedPlayer.Name+6K   �� 5.      $��Возраст��6   #��[ 6(   �� 5/      -   5        $ tbAge��5/      #��[ 50       �� 
IsReadOnly . ��5/   %   �� *SelectedPlayer.Birthday+  BirthdayToAgeConverter �� 	Converter# [ 50   9   �� 52      $��День рождения��6   #��[ 6.   �� 53      -   5        $ 
tbBirthday��53      #��[ 54      ��53   *   �� *SelectedPlayer.Birthday+54      �� 56      $��Вес��6   #��[ 6$   �� 57      -   5        $ tbWeight��57      #��[ 58      ��57   (   �� *SelectedPlayer.Weight+58      �� 5:      $��Команда��6   #��[ 6'   �� 5;      -	   5         ��Name$ tbTeam��5;       �� DisplayMemberPath$
 Name��5>        cbStyle#��[ 5?      ��5;   '   �� *
TeamList+ 5<      �� *SelectedPlayer+ �� Text 5=      �� *SelectedPlayer.TeamName+5?      �� 5A      -
   5         ��Name$ btnEdit��5A      $��Добавить��6&     btnStyle#��[ 5B      ��5C      ��  �� Path$ 
AddCommand���5D      �� *SelectedPlayer+5E      5G      5H      