using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DoctorList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string fileName = "MyText.txt";

        IList<MyDoctorList> myDoctorList = new List<MyDoctorList>();

        string text = "";
        public  MainPage()
        {
            this.InitializeComponent();
            DataLoad(); 
                  

        }


        private async void DataLoad()
        {

            Windows.Storage.StorageFolder storageFolder =   Windows.Storage.ApplicationData.Current.LocalFolder;
           
            if (IsFirstTime.IsFirstTimeIssue == 10)
            {
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
                await Windows.Storage.FileIO.AppendTextAsync(sampleFile, "1,Dr.Zahid,Dhanmondi,");
            }

            IsFirstTime.IsFirstTimeIssue = 0;



            Windows.Storage.StorageFile sampleFileGet = await storageFolder.GetFileAsync(fileName);
            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFileGet);
            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                 text = dataReader.ReadString(buffer.Length);
            }

            string[] totalString = text.Substring(0, text.Length-2).Split(',');

            for(int i = 0; i < totalString.Length; i++)
            {

                if ( i % 3.00 == 0.00)
                {

                    myDoctorList.Add(new MyDoctorList()
                    {
                        doctorId = totalString[i]

                    }); 
                }
            }
             this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {

                myList.ItemsSource = myDoctorList;
            });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int doctorId = Convert.ToInt32( ((Button)sender).Content.ToString());
            this.Frame.Navigate(typeof(DoctorDetails), doctorId);
              

        }

        

       
    }

    class IsFirstTime
    {
       public  static int IsFirstTimeIssue = 10;
    }

   
    
}
