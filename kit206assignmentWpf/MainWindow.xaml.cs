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
using KIT206Assignment2.Control;

namespace kit206assignmentWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ResearcherControls resControl = new ResearcherControls();
        PublicationControls pubControl = new PublicationControls();

        public MainWindow()
        {
            InitializeComponent();

            resControl.LoadResearchers();

            researcherListBox.ItemsSource = resControl.displayList;
        }
    }
}
