using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Net.NetworkInformation;

namespace MyIP
{
    public partial class MainPage
    {
        string ss;
   
        public MainPage()
        {
            InitializeComponent();

            Loaded += OnLoaded;
       
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
           // var available = !NetworkInterface.GetIsNetworkAvailable();

//if (!available)
  //          {
                var webClient = new WebClient();

                webClient.OpenReadCompleted += OnOpenReadCompleted;

                webClient.OpenReadAsync(new Uri("http://www.techfollowers.com/my-ip", UriKind.Absolute));
    //        }
        }


        private void OnOpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
               // var available1 = !NetworkInterface.GetIsNetworkAvailable();

                //if (!available1)
                //{
                    var serializer = new DataContractJsonSerializer(typeof(IPResult));

                    var ipResult = (IPResult)serializer.ReadObject(e.Result);


                    IPAddress.Text = ipResult.IP;
                //}
            }
            catch (WebException ee)
            {
                MessageBox.Show("No internet");
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ss = "http://www.ipgetinfo.com/?mode=ip&lang=en&ip=" + IPAddress.Text;
            if (IPAddress.Text != "Getting IP address.." )
                webBrowser1.Navigate(new Uri(ss, UriKind.RelativeOrAbsolute));
            else
                MessageBox.Show("Connect to internet");
        }
       
    }

}


