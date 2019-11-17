using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HeroesGame
{

    public partial class MainWindow : Window
    {
        ObservableCollection<string> a = new ObservableCollection<string>();
        ObservableCollection<string> b = new ObservableCollection<string>();
        string select;
        string selected = " ";
        ListBox l;
        Dictionary<BattleUnitStack, TextBlock> field = new Dictionary<BattleUnitStack, TextBlock>();
        Dictionary<string,BattleUnitStack> list = new Dictionary<string,BattleUnitStack>(); // (int)1 or 2 + pos
        Battle battle;
        BattleUnitStack[] PickingArmy = new BattleUnitStack[6];
        BattleUnitStack[] PickingArmy2 = new BattleUnitStack[6];
        private void pick(ComboBox arm)
        {

            Dictionary<string, TextBlock> textblocksarmy1 = new Dictionary<string, TextBlock>()
            {
                 { "Armyspot1",Armyspot1 },
                 { "Armyspot2",Armyspot2 },
                 { "Armyspot3",Armyspot3 },
                 { "Armyspot4",Armyspot4 },
                 { "Armyspot5",Armyspot5 },
                 { "Armyspot6",Armyspot6 },
                 { "qtspot1",qtspot1 },
                 { "qtspot2",qtspot2 },
                 { "qtspot3",qtspot3 },
                 { "qtspot4",qtspot4 },
                 { "qtspot5",qtspot5 },
                 { "qtspot6",qtspot6 },
            };
            Dictionary<string, TextBlock> textblocksarmy2 = new Dictionary<string, TextBlock>()
            {
                 { "Armyspot1",Armyspot21 },
                 { "Armyspot2",Armyspot22 },
                 { "Armyspot3",Armyspot23 },
                 { "Armyspot4",Armyspot24 },
                 { "Armyspot5",Armyspot25 },
                 { "Armyspot6",Armyspot26 },
                 { "qtspot1",qtspot21 },
                 { "qtspot2",qtspot22 },
                 { "qtspot3",qtspot23 },
                 { "qtspot4",qtspot24 },
                 { "qtspot5",qtspot25 },
                 { "qtspot6",qtspot26 },
            };
            if ((qt.Text != "") && (spot.Text != ""))
            {

                int qt_;
                int spot_;
                if ((int.TryParse(qt.Text, out qt_) && (int.TryParse(spot.Text, out spot_))))
                {
                    if ((spot_ <= 6) && (spot_ > 0) && (qt_ > 0))
                    {
                        string strSpot = "Armyspot" + spot.Text;
                        string strqt = "qtspot" + spot.Text;
                        TextBlock textS;
                        TextBlock textQ;
                        ComboBoxItem selectedplayer = (ComboBoxItem)Armyselect.SelectedItem;
                        TextBlock player = (TextBlock)selectedplayer.Content;
                        ComboBoxItem selectedItem = (ComboBoxItem)ComboBoxPickingUnit.SelectedItem;
                        TextBlock hero = (TextBlock)selectedItem.Content;
                        if (player.Text == "Player1")
                        {
                            textblocksarmy1.TryGetValue(strSpot, out textS);
                            textblocksarmy1.TryGetValue(strqt, out textQ);
                        }
                        else
                        {
                            textblocksarmy2.TryGetValue(strSpot, out textS);
                            textblocksarmy2.TryGetValue(strqt, out textQ);

                        }
                        textS.Text = hero.Text.Substring(0, 1);
                        textQ.Text = qt.Text;

                        StatusofPicking.Text = StatusofPicking.Text + "\n" + "Units has been created";
                        switch (hero.Text)
                        {
                            case "Angel":
                                {
                                    Angel a = new Angel();

                                    if (player.Text == "Player1")

                                        PickingArmy[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    else
                                        PickingArmy2[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    break;
                                }
                            case "Demon":
                                {

                                    Demon a = new Demon();

                                    if (player.Text == "Player1")
                                        PickingArmy[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    else
                                        PickingArmy2[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    break;
                                }
                            case "Lich":
                                {
                                    Lich a = new Lich();

                                    if (player.Text == "Player1")
                                        PickingArmy[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    else
                                        PickingArmy2[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    break;
                                }
                            case "Ranger":
                                {
                                    Ranger a = new Ranger();
                                    if (player.Text == "Player1")

                                        PickingArmy[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    else
                                        PickingArmy2[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    break;
                                }
                            case "Sceleton":
                                {
                                    Sceleton a = new Sceleton();

                                    if (player.Text == "Player1")
                                        PickingArmy[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    else
                                        PickingArmy2[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    break;
                                }
                            case "Warrior":
                                {
                                    Warrior a = new Warrior();

                                    if (player.Text == "Player1")
                                        PickingArmy[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    else
                                        PickingArmy2[spot_ - 1] = new BattleUnitStack(new UnitStack(a, qt_));
                                    break;
                                }
                        }

                    }
                    else
                        StatusofPicking.Text = StatusofPicking.Text + "\n" + "You have only 6 slots!!!";
                }
                else
                    StatusofPicking.Text = StatusofPicking.Text + "\n" + "Something got wrong:\\ \n Try again";

            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            pick(Armyselect);

        }
        private void finishPicking(object sender, RoutedEventArgs e)
        {
            battle = new Battle(new BattleArmy(PickingArmy), new BattleArmy(PickingArmy2));
            StatusofPicking.Text = StatusofPicking.Text + "\n" + "You finished picking first Army";
            window1.Visibility = Visibility.Hidden;
            windowbattle.Visibility = Visibility.Visible;
            listAdding();
        }
        private void End(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }
        private void arragement()
        { }
        private void listAdding()
        {
            for (int i = 0; i < battle.player[0].army.Count; i++)
            {
                string str = battle.player[0].army[i].bus.Type + "1" + i.ToString();
                a.Add(battle.player[0].army[i].bus.Type);
                list.Add(str, battle.player[0].army[i]);
            }
            
            ListboxPlayer1.ItemsSource = a;
          

            for (int i = 0; i < battle.player[1].army.Count; i++)
            {
                string str = battle.player[1].army[i].bus.Type + "2" + i.ToString();
                b.Add(battle.player[1].army[i].bus.Type);
                list.Add(str, battle.player[1].army[i]);
            }
            ListboxPlayer2.ItemsSource = b;

     
        }


        public MainWindow()
        {
            InitializeComponent();
            windowbattle.Visibility = Visibility.Hidden;
            windowbattle.IsEnabled = true;
        }

        private void chooseposition(object sender, SelectionChangedEventArgs e)
        {
          var buff = ((sender as ListBox).SelectedItem as string);
            if (buff != null)
            {
                selected = ((sender as ListBox).SelectedItem as string);
                l = (ListBox)sender;
                    if (l.Name == "ListboxPlayer1")
                    {
                        selected = selected + "1";
                    }
                    else
                        selected = selected + "2";
            }
          //  }
        }
        private void selectposition(object sender, MouseButtonEventArgs e)
        {
            string buff = selected;
                if ((selected != " ") && (selected != null))
                {
                     if (l.Name == "ListboxPlayer1")
                     {
                        foreach (var i in list.Keys)
                        {
                            if (i.Contains(selected))
                            {
                            select = i;
                            int x1 = 0;
                            x1 = selected.Length - 1;
                            selected = selected.Substring(0, x1);
                            a.Remove(selected);
                        }
                        }
                     }
                    if (l.Name == "ListboxPlayer2")
                    {
                        foreach (var i in list.Keys)
                        {
                            if (i.Contains(selected))
                            {
                                select = i;
                                int x1 = 0;
                                x1 = selected.Length - 1;
                                selected = selected.Substring(0, x1);
                                b.Remove(selected);
                            }
                        }
                    }

                    BattleUnitStack bat = list[select];
                    TextBlock t = (TextBlock)sender;
                    field.Add(bat, t);


                    t.Text = buff.Substring(0, 1);

                    list.Remove(select);
              
             
                if ((a.Count() + b.Count()) == 0)
                {
                    selected = " ";
                    ListboxPlayer1.Visibility = Visibility.Collapsed;
                    ListboxPlayer2.Visibility = Visibility.Collapsed;
                    ListboxPlayer1.IsEnabled = false;
                    ListboxPlayer2.IsEnabled = false;
                    Gamelogic();
                }
            }
        }
        private void Gamelogic()
        {
            battle.updateUnits();
            string win = battle.winCondition(); // winning contition
            if (win != " ")
            {
                battleStatus.FontSize = 40;
                battleStatus.Text = win + "\n";
                for (int i = 5; i > 0; i--)
                {
                    Thread.Sleep(1000);
                    battleStatus.Text ="Window will close." + i.ToString() + "Seconds";
                }
                Environment.Exit(0);
            }
            battle.round++;
            round.Text = battle.round.ToString() + " Round";
            battle.queue();
            foreach (var a in field.Values)
            {
                a.Foreground = Brushes.Black;
                
            }
            TextBlock myKey = field[battle.player[battle.whichTern].army[battle.whowillgo()]];
            myKey.Foreground = Brushes.Red;
        }

        private void move(object sender, MouseButtonEventArgs e)
        {

            TextBlock start = field[battle.player[battle.whichTern].army[battle.whowillgo()]];      
            TextBlock finish = (TextBlock)sender;
            if (field.ContainsValue(finish))
            {
                foreach (var a in field.Keys.ToArray())
                {
                    if (field[a] == finish)
                    {
                        var beatbef = a.bus.qty * a.bus.StandardHitpoints + a.bus.Hitpoints;
                        string s = battle.attack(battle.player[battle.whichTern].army[battle.whowillgo()], a);
                        var beataft = a.bus.qty * a.bus.StandardHitpoints + a.bus.Hitpoints;
                        battleStatus.Text = finish.Text + " " + s + " by " + start.Text + "(" + (beatbef - beataft).ToString() + ")" + "\n";
                        field[battle.player[battle.whichTern].army[battle.whowillgo()]].Foreground = Brushes.Gray;
                        battle.player[battle.whichTern].army[battle.whowillgo()].useInStep = false;
                       // field[battle.player[battle.whichTern].army[battle.whowillgo()]].Foreground = Brushes.Red;
                        if (s == "Killed")
                        {
                            field.Remove(a);
                            finish.Text = "";
                        }
                    }
                }
            }
            else
            {
                finish.Text = start.Text;
                field.Remove(battle.player[battle.whichTern].army[battle.whowillgo()]);
                field.Add(battle.player[battle.whichTern].army[battle.whowillgo()], finish);               
                field[battle.player[battle.whichTern].army[battle.whowillgo()]].Foreground = Brushes.Gray;
                battle.player[battle.whichTern].army[battle.whowillgo()].useInStep = false;
                start.Text = "";
                
                battle.whowillgo();
                
            }
            if (battle.endOfTheRound() == true)
            {
                Gamelogic();

            }
            field[battle.player[battle.whichTern].army[battle.whowillgo()]].Foreground = Brushes.Red;
        }
        private void waitButton(object sender, RoutedEventArgs e)
        {
            battle.player[battle.whichTern].army[battle.whowillgo()].bus.Initiative = 0;
            battle.queue();
            battle.player[battle.whichTern].army[battle.whowillgo()].useInStep = false;

        }
        private void defendButton(object sender, RoutedEventArgs e)
        {
            battle.player[battle.whichTern].army[battle.whowillgo()].bus.Defence *= (int)1.3;

        }
       
        private void defeatButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
