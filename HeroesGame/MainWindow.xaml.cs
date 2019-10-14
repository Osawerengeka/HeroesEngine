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

namespace Heroes
{

    public partial class MainWindow : Window
    {
        Army firstPlayer;
        UnitStack[] PickingArmy = new UnitStack[6];
            
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             Dictionary<string, TextBlock> textblocks = new Dictionary<string, TextBlock>()
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
            Button button = (Button)sender;
            if ((qt.Text != "") &&(spot.Text != ""))
            {
                
                int qt_;
                int spot_;
                if ((int.TryParse(qt.Text, out qt_) && (int.TryParse(spot.Text, out spot_))))
                {
                    if ((spot_ <= 6)&&(spot_ > 0)&&(qt_>0))
                    {
                        string strSpot = "Armyspot" + spot.Text;
                        string strqt = "qtspot" + spot.Text;
                        TextBlock textS;
                        TextBlock textQ;
                        ComboBoxItem selectedItem = (ComboBoxItem)ComboBoxPickingUnit.SelectedItem;
                        TextBlock hero = (TextBlock)selectedItem.Content;
                        textblocks.TryGetValue(strSpot, out textS);
                        textblocks.TryGetValue(strqt, out textQ);
                        textS.Text = hero.Text.Substring(0, 1);
                        textQ.Text = qt.Text;
                        
                        StatusofPicking.Text = StatusofPicking.Text + "\n" + "Units has been created";
                        switch (hero.Text)
                        {
                            case "Angel":
                                {
                                    Angel a = new Angel();
                                    PickingArmy[spot_ - 1] = new UnitStack(a, qt_);
                                    break;
                                }
                            case "Demon":
                                {
                                    
                                    Demon a = new Demon();
                                    PickingArmy[spot_ - 1] = new UnitStack(a, qt_);
                                    break;
                                }
                            case "Lich":
                                {
                                    Lich a = new Lich();
                                    PickingArmy[spot_ - 1] = new UnitStack(a, qt_);
                                    break;
                                }
                            case "Ranger":
                                {
                                    Ranger a = new Ranger();
                                    PickingArmy[spot_ - 1] = new UnitStack(a, qt_);
                                    break;
                                }
                            case "Sceleton":
                                {
                                    Sceleton a = new Sceleton();
                                    PickingArmy[spot_ - 1] = new UnitStack(a, qt_);
                                    break;
                                }
                            case "Warrior":
                                {
                                    Warrior a = new Warrior();
                                    PickingArmy[spot_ - 1] = new UnitStack(a, qt_);
                                    break;
                                }
                        }
                      
                    }
                    else
                        StatusofPicking.Text = StatusofPicking.Text + "\n" + "You have only 6 slots!!!" ;
                }
                else
                    StatusofPicking.Text = StatusofPicking.Text + "\n" + "Something got wrong:\\ \n Try again";

            }
        }

        private void finishPicking(object sender, RoutedEventArgs e)
        {
            buttonAddUnit.IsEnabled = false;
            firstPlayer = new Army(PickingArmy[0], PickingArmy[1], PickingArmy[2], PickingArmy[3], PickingArmy[4], PickingArmy[5]);
            StatusofPicking.Text = StatusofPicking.Text + "\n" + "You finished picking Army";
        }

        private void End(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        public MainWindow()
        {
            InitializeComponent();
            
        }

       
    }
}
