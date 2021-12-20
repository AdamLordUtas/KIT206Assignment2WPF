﻿using System;
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
            try
            {
                Researcher selectedRes = (Researcher)researcherListBox.SelectedItem;
                if (selectedRes != null)
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error getting researcher details, {0}\n\n{1}", ex.Message, ex));
                throw;
            }
        }


        private void publicationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Publication selectedPub = (Publication)publicationListBox.SelectedItem;

                if (selectedPub != null)
                {
                    selectedPub = pubControl.GetFullDetails(selectedPub);

                    pubDoi.Content = selectedPub.doi;
                    pubTitle.Content = selectedPub.title;
                    pubAuthors.Content = selectedPub.authours;
                    pubYear.Content = selectedPub.year;
                    pubTitle.Content = selectedPub.type;
                    available.Content = selectedPub.available;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error getting publication details, {0}\n\n{1}", ex.Message, ex));
                throw;
            }
        }

        private void FetchPublications(object sender, RoutedEventArgs e)
        {
            try
            {
                Researcher selectedRes = (Researcher)researcherListBox.SelectedItem;
                if(selectedRes != null)
                {
                    pubControl.LoadPublications(selectedRes.id);
                    publicationListBox.ItemsSource = pubControl.displayList;
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error getting publications, {0}\n\n{1}", ex.Message, ex));
                throw;
            }
        }

        private void levelFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error filtering researchers, {0}\n\n{1}", ex.Message, ex));
                throw;
            }
        }

        private void Button_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                resControl.FilterByName(researchSearchText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error filtering list, {0}\n\n{1}", ex.Message, ex));
                throw;
            }         
        }

        private void Button_Sort_Descending(object sender, RoutedEventArgs e)
        {
            try
            {
                pubControl.OrderByDescending();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Issue ordering by descending year, {0}\n\n{1}", ex.Message, ex));
                throw;
            }
        }
    }
}
