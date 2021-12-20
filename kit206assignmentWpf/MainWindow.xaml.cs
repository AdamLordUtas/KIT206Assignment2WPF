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
using KIT206Assignment2.Research;

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
            publicationListBox.ItemsSource = pubControl.displayList;
        }

        private void researcherListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Researcher selectedRes = (Researcher)researcherListBox.SelectedItem;
            selectedRes = resControl.GetFullDetails(selectedRes.id);

            resId.Content = selectedRes.id;
            resType.Content = selectedRes.type;
            resGivenName.Content = selectedRes.givenName;
            resFamilyName.Content = selectedRes.familyName;
            resTitle.Content = selectedRes.title;
            resUnit.Content = selectedRes.unit;
            resCampus.Content = selectedRes.campusSting();
            resEmail.Content = selectedRes.email;
            resDegree.Content = selectedRes.degree;
            resSupervisor.Content = selectedRes.supervisorId;
            resPosition.Content = selectedRes.position.Title();
        }

        private void FetchResearchers(object sender, RoutedEventArgs e)
        {
            Researcher selectedRes = (Researcher)researcherListBox.SelectedItem;
            pubControl.LoadPublications(selectedRes.id);
        }

        private void levelFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (levelFilter.SelectedIndex)
            {
                case 1:
                    resControl.FilterByLevel(Level.N);
                    break;
                case 2:
                    resControl.FilterByLevel(Level.A);
                    break;
                case 3:
                    resControl.FilterByLevel(Level.B);
                    break;
                case 4:
                    resControl.FilterByLevel(Level.C);
                    break;
                case 5:
                    resControl.FilterByLevel(Level.D);
                    break;
                case 6:
                    resControl.FilterByLevel(Level.E);
                    break;
                default:
                    resControl.ResetList();
                    break;
            }
        }
    }
}
