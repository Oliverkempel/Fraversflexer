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
using RestSharp;

namespace API_Fun
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            //MapsRequesters mapsRequester = new MapsRequesters();
            //PurpleConverter resultat = new PurpleConverter();
            //resultat = PurpleConverter.FromJson(mapsRequester.searchLocations("Photoshops in aarhus").Content); 

           

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputtedSearchQuery = UserSearchInput.Text;

            AmazonRequester amazonRequester = new AmazonRequester();
            AmazonSeachObject seachObject = new AmazonSeachObject();


            seachObject = AmazonSeachObject.FromJson(amazonRequester.searchAmazon(inputtedSearchQuery, "24D9D062BE844C7F939DA76E3BD07BC8").Content);

            List<itemObject> searchItems = new List<itemObject>();

            foreach (SearchResult result in seachObject.SearchResults)
            {

                //searchItems.Add(new itemObject { itemName = "test", itemPrice = result.Prices.First().Value, itemDesc = "None yet", itemImage = "google.com", itemPriceRaw = result.Prices.First().Raw });
                if(result.Price != null)
                {
                    searchItems.Add(new itemObject { itemName = result.Title, itemPrice = result.Price.Value, itemDesc = "None yet", itemImage = result.Image, itemPriceRaw = result.Price.Raw });
                }
                


            }

            ResultsDatagrid.ItemsSource = searchItems;
        }

        public class itemObject
        {
            public string? itemName { get; set; }
            public double? itemPrice { get; set; }
            public string? itemPriceRaw { get; set; }
            public Uri? itemImage { get; set; }
            public string? itemDesc { get; set; }
        }
    }
}
