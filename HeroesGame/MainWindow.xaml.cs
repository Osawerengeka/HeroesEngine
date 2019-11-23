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
        int pos = 0;
        public struct listinfo
        {
            public string fullName;
            public string showingName;
            public int pos;
           public int posincoll;
            public int posInArmy;
            public int army;
        }
        public struct TextblockInfo
        {



        }
        listinfo ListboxElement;
        ObservableCollection<string> a = new ObservableCollection<string>();
        ObservableCollection<string> b = new ObservableCollection<string>();
        string select;
        string selected;
        //string ListboxElement = " ";
        ListBox l;
        Dictionary<BattleUnitStack, TextBlock> field = new Dictionary<BattleUnitStack, TextBlock>();
        Dictionary<listinfo,BattleUnitStack> list = new Dictionary<listinfo,BattleUnitStack>(); // (int)1 or 2 + pos
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
        private void listAdding()
        {
            for (int i = 0; i < battle.player[0].army.Count; i++)
            {
                
                string str = battle.player[0].army[i].bus.Type + "0" + i.ToString();
                a.Add(battle.player[0].army[i].bus.Type);
                listinfo sct =new listinfo { fullName = str ,showingName = battle.player[0].army[i].bus.Type,posincoll = a.Count - 1, pos = list.Count, posInArmy = i, army = 0 };
                list.Add(sct, battle.player[0].army[i]);
            }
            
            ListboxPlayer1.ItemsSource = a;
          

            for (int i = 0; i < battle.player[1].army.Count; i++)
            {
                string str = battle.player[1].army[i].bus.Type + "1" + i.ToString();
                b.Add(battle.player[1].army[i].bus.Type);
                listinfo sct = new listinfo { fullName = str, showingName = battle.player[1].army[i].bus.Type, posincoll = b.Count - 1,pos = list.Count, posInArmy = i, army = 1 };
                list.Add(sct, battle.player[1].army[i]);
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
                selected = buff;           
                l = (ListBox)sender;
              //  ((l.SelectedItem) as TextBox).Foreground = Brushes.Gray;      
            }
         
        }
        int kol = 0;
        private void selectposition(object sender, MouseButtonEventArgs e)
        {
            listinfo flag = new listinfo();
            string buff = selected;

            if ((selected != " ") && (selected != null))
                {

                if (l.Name == "ListboxPlayer1")
                {
                    foreach (var i in list.Keys)
                    {
                        if ((i.showingName == selected) && (i.army == 0) && (l.SelectedIndex == i.posincoll))
                        {
                            
                            flag = i;
                          //  a.RemoveAt(i.posincoll);                         
                        }
                    }
                    
                }
                if (l.Name == "ListboxPlayer2")
                {
                    foreach (var i in list.Keys)
                    {
                        if ((i.showingName == selected) && (i.army == 1) && (l.SelectedIndex == i.posincoll))
                        {
                            flag = i;
                          //  b.RemoveAt(i.posincoll);
                        }
                    }
                    
                }
                kol++;
                    BattleUnitStack bat = list[flag];
                    TextBlock tb = (TextBlock)sender;
                    field.Add(bat, tb);
                    tb.Text = buff.Substring(0, 1);
                    list.Remove(flag);
                   



                if ((a.Count() + b.Count()) == kol)
                {
                    selected = " ";
                    a.Clear();
                       b.Clear();
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
                battleStatus.FontSize = 30;
                battleStatus.Text = win + "\n";
               
                Environment.Exit(0);
            }
            battle.round++;
            round.Text = battle.round.ToString() + " Round";
            battle.queue();
            foreach (var a in field.Keys)
            {
                battle.colorise(a,field[a]);
                
            }
            TextBlock myKey = field[battle.whowillgo()];
            myKey.Foreground = Brushes.Red;
        }
        private void move(object sender, MouseButtonEventArgs e)
        {
            
            var unit = battle.whowillgo();
            TextBlock start = field[unit];      
            TextBlock finish = (TextBlock)sender;
            if (field.ContainsValue(finish))
            {
                foreach (var a in field.Keys.ToArray())
                {
                    if (field[a] == finish)
                    {
                        
                        var beatbef = a.bus.qty * a.bus.StandardHitpoints + a.bus.Hitpoints;
                        string s = battle.attack(unit, a);
                        var beataft = a.bus.qty * a.bus.StandardHitpoints + a.bus.Hitpoints;
                        battleStatus.Text = finish.Text + " " + s + " by " + start.Text + "(" + (beatbef - beataft).ToString() + ")" + "\n";                     
                      
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
                field.Remove(unit);
                field.Add(unit, finish);                        
                start.Text = ""; 
            }

            unit.canBeUse = false;
            if (battle.endOfTheRound() == true)
            {
                Gamelogic();
                return;
            }
           
            battle.colorise(unit, field[unit]);

            unit = battle.whowillgo();
            field[unit].Foreground = Brushes.Red;
            
        }
        private void RedGuy()
        {
            var unit = battle.whowillgo();
            if (unit != null)
            {
                field[unit].Foreground = Brushes.Red;
            }        
        }
        private void waitButton(object sender, RoutedEventArgs e)
        {
            var unit = battle.whowillgo();
            battle.wait(unit);
            battle.queue();
            battle.colorise(unit, field[unit]);

            unit = battle.whowillgo();

            field[unit].Foreground = Brushes.Red;

        }
        
        private void defendButton(object sender, RoutedEventArgs e)
        {
            var unit = battle.whowillgo();
            battle.defend(unit);
            battle.colorise(unit, field[unit]);

            unit = battle.whowillgo();
            field[unit].Foreground = Brushes.Red;
        }
       
        private void defeatButton(object sender, RoutedEventArgs e)
        {
            var unit = battle.whowillgo();
            battle.defeat(unit);
        }
        
    }
}
