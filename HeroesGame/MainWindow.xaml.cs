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

namespace HeroesGame
{

    public partial class MainWindow : Window
    {
        Dictionary<string, TextBlock> field = new Dictionary<string, TextBlock>();
        Dictionary<BattleUnitStack, ListBoxItem> list = new Dictionary<BattleUnitStack, ListBoxItem>();
        Battle battle;
        BattleUnitStack[] PickingArmy  = new BattleUnitStack[6];
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

                                        PickingArmy[spot_ - 1] =new BattleUnitStack(new UnitStack(a, qt_));
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
            Game();
        }

        private void End(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            
        }
        private void arragement()
        { }
        private void Game()
        {
            for (int i = 0;i < battle.player1.army.Count; i++)
            {

                ListboxPlayer1.Items[i] = battle.player1.army[i].bus.Type;

              //  l.Content = battle.player1.army[i].bus.Type;
             //   list.Add(battle.player1.army[i],l);
                
                
            }
            
            while (battle.winner != "")
            {
                battle.round++;
                
            }
        }


        public MainWindow()
        {
           
            InitializeComponent();

            windowbattle.Visibility = Visibility.Hidden;
            windowbattle.IsEnabled = true;
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
