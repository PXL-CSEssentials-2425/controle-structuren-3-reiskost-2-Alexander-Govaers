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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reiskost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            bool validPrijsVlucht = double.TryParse(basisVluchtTextBox.Text, out double prijsVlucht);
            bool validKlasse = double.TryParse(vluchtklasseTextbox.Text, out double klasse);
            bool validPrijsPerDag = double.TryParse(prijsPerDagTextBox.Text, out double prijsPerDag);
            bool validAantalDagen = double.TryParse(dagenTextBox.Text, out double aantalDagen);
            bool validAantalPersonen = double.TryParse(aantalPersonenTextBox.Text, out double aantalPersonen);
            bool validPercentage = double.TryParse(kortingTextBox.Text, out double kortingPercentage);

            double percentage;
            double percentagePersonen;
            double totaalVerblijfPrijsMetKorting = 0;

           


            //double prijsDerdePersoon = (prijsPerDag * aantalDagen) * 0.5;
            //double prijsVanafVierdePersoon = (prijsPerDag * aantalDagen) * 0.3;
            //double prijsTweePersonen = (prijsPerDag * aantalDagen) * 2;

            
           


            if (!validPrijsVlucht || !validKlasse || !validPrijsPerDag || !validAantalDagen || !validAantalPersonen || !validPercentage)
            {
                MessageBox.Show("Vul een getal in", "foutief getal", MessageBoxButton.OK);
            }

            switch (klasse)

            {

                case 1:

                    percentage = 1.3;
                    break;

                case 3:

                    percentage = 0.8;
                    break;

                default:

                    percentage = 0;

                    break;


            }

            //switch (aantalPersonen)
            //{

            //    case 3:
            //        percentagePersonen = 0.5;
            //        break;

            //    default:
            //        percentagePersonen = 0.3;
            //        break;
            //}





            //if (aantalPersonen == 3)
            //{
            //    double prijsDerdePersoon = (prijsPerDag * aantalDagen) * percentagePersonen;

            //    double eersteTweePersonen = prijsPerDag * aantalDagen * 2;

            //    totaalVerblijfPrijsMetKorting = prijsDerdePersoon + eersteTweePersonen;




            //}
            //else if(aantalPersonen > 3) 
            //{
            //    double prijsVanafVierdePersoon = (prijsPerDag * aantalDagen) * percentagePersonen;
            //}

            //else
            //{
            //    percentagePersonen = 1;
            //}




            if (aantalPersonen <= 2)
            {
               
                totaalVerblijfPrijsMetKorting = (prijsPerDag * aantalDagen) * aantalPersonen;
            }
            else if (aantalPersonen == 3)
            {

                totaalVerblijfPrijsMetKorting = (prijsPerDag * aantalDagen) * 2 + (prijsPerDag * aantalDagen) * 0.5;
            }
      
            if (aantalPersonen > 3)
            {
                double prijsVoorDrie = (prijsPerDag * aantalDagen) * 2 + (prijsPerDag * aantalDagen) * 0.5;



                double resterendePersonen = aantalPersonen - 3;
                double resterendePrijs = ((prijsPerDag * aantalDagen) * 0.3) * resterendePersonen;
                totaalVerblijfPrijsMetKorting = prijsVoorDrie + resterendePrijs;

            }



            double totaleReisPrijs = totaalVerblijfPrijsMetKorting + (prijsVlucht * percentage) * aantalPersonen;
            double extraKorting = totaleReisPrijs * kortingPercentage / 100;
           




            resultTextBox.Text = $"REISKOST VOLGENS BESTEMMING NAAR {bestemmingTextbox.Text} : \n" +
                                  $" Totale vluchtprijs: € {(prijsVlucht * percentage) * aantalPersonen} \n" +
                                  $" Totale verblijfprijs: € {totaalVerblijfPrijsMetKorting}  \n" +
                                  $" Totale reisprijs: € {totaleReisPrijs} \n" +
                                  $" Korting € {extraKorting} \n" +
                                  $" Te betalen: € {totaleReisPrijs - extraKorting}"
                                  ;

            


        }

        private void vluchtklasseTextbox_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
           vluchtklasseTextbox.ToolTip = "1 = businessclass \n" +
                "2 = Standaard lijnvlucht \n" +
                "3 = Charter";
        }
    }
}
