using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DoctorList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DoctorDetails : Page
    {
        string fileName = "MyText.txt";

        List<DetailsOfDoctor> listOfdetailsofdoctor; 
        DetailsOfDoctor detailofDoctor;
        
        public DoctorDetails()
        {
             listOfdetailsofdoctor  = new List<DetailsOfDoctor>();
             detailofDoctor = new DetailsOfDoctor(); 
            this.InitializeComponent();

            CallInitailLoad();

          
          
        }


        public async Task CallInitailLoad()
        {
            await InitailLoad();
        }

        public async Task InitailLoad()
        {

            string text = "";

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFileGet = await storageFolder.GetFileAsync(fileName);
            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFileGet);
            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                text = dataReader.ReadString(buffer.Length);
            }

            string[] totalString = text.Substring(0, text.Length - 2).Split(',');
            listOfdetailsofdoctor.Clear();



            for (int i = 0; i < totalString.Length; i++)
            {
                if (i % 3 == 0)
                {

                    listOfdetailsofdoctor.Add(new DetailsOfDoctor()
                    {
                        doctorId = Convert.ToInt32( totalString[i]),
                        doctorName = totalString[i + 1],
                        doctorAddress = totalString[i + 2]

                    });

                    



                }

            }

        }

        int doctorIdInt = 0;
        protected async  override void OnNavigatedTo(NavigationEventArgs e)
        {
            doctorIdInt = (int)e.Parameter;
            base.OnNavigatedTo(e);

            TimeSpan period = TimeSpan.FromSeconds(1);

            ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
               
                     Dispatcher.RunAsync(CoreDispatcherPriority.High,
                    () =>
                    {

                        detailofDoctor = listOfdetailsofdoctor.Where(w => w.doctorId == doctorIdInt).FirstOrDefault();
                        this.DataContext = detailofDoctor;

                    });

            }, period);
          

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage) , 1111);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string data = doctorId.Text + "," + doctorName.Text + "," + doctorAddress.Text + ",";

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.OpenIfExists);
            await  Windows.Storage.FileIO.AppendTextAsync(sampleFile,  data );
           
           



        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string text = "";

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFileGet = await storageFolder.GetFileAsync(fileName);
            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFileGet);
            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                text = dataReader.ReadString(buffer.Length);
            }

            string[] totalString = text.Substring(0, text.Length - 2).Split(',');
            listOfdetailsofdoctor.Clear();

            

            for (int i = 0; i < totalString.Length; i++)
            {
                if(i % 3 == 0)
                {

                    if( doctorId.Text == totalString[i])
                    {
                        listOfdetailsofdoctor.Add(new DetailsOfDoctor()
                        {
                            doctorId = Convert.ToInt32( totalString[i]),
                            doctorName = doctorName.Text,
                            doctorAddress = doctorAddress.Text

                        });

                    }else
                    {

                        listOfdetailsofdoctor.Add(new DetailsOfDoctor()
                        {
                            doctorId = Convert.ToInt32( totalString[i]),
                            doctorName = totalString[i + 1],
                            doctorAddress = totalString[i + 2]

                        });

                    }

                    

                }
                   
            }


           

            Windows.Storage.StorageFolder storageFolder12 = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder12.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string data = "";
            foreach (var v in listOfdetailsofdoctor)
            {
                data += v.doctorId + "," + v.doctorName + "," + v.doctorAddress + ",";
                
            }

          await   Windows.Storage.FileIO.AppendTextAsync(sampleFile, data);
           



        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string text = "";

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFileGet = await storageFolder.GetFileAsync(fileName);
            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(sampleFileGet);
            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                text = dataReader.ReadString(buffer.Length);
            }

            string[] totalString = text.Substring(0, text.Length - 2).Split(',');
            listOfdetailsofdoctor.Clear();



            for (int i = 0; i < totalString.Length; i++)
            {
                if (i % 3 == 0)
                {

                    if (doctorId.Text == totalString[i])
                    {
                       
                    }
                    else
                    {

                        listOfdetailsofdoctor.Add(new DetailsOfDoctor()
                        {
                            doctorId = Convert.ToInt32( totalString[i]),
                            doctorName = totalString[i + 1],
                            doctorAddress = totalString[i + 2]

                        });

                    }

                }

            }

            Windows.Storage.StorageFolder storageFolder12 = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder12.CreateFileAsync(fileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            string data = "";
            foreach (var v in listOfdetailsofdoctor)
            {
                 data += v.doctorId + "," + v.doctorName + "," + v.doctorAddress + ",";
            }

           await   Windows.Storage.FileIO.AppendTextAsync(sampleFile, data);



          

        }

       


        void CheckingValue()
        {
            int IsInt = 0;
            bool IsIntBool = int.TryParse(doctorId.Text, out IsInt);
            if (!IsIntBool)
            {
                return;
            }

            if (doctorIdInt == Convert.ToInt32(doctorId.Text))
            {
                this.Edit.Visibility = Visibility.Visible;
                this.Delete.Visibility = Visibility.Visible;
                this.Insert.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Edit.Visibility = Visibility.Collapsed;
                this.Delete.Visibility = Visibility.Collapsed;
                this.Insert.Visibility = Visibility.Visible;
            }
        }

        private void doctorId_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckingValue();
        }

        private void doctorName_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckingValue();
        }

        private void doctorAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            CheckingValue();
        }
    }


}
