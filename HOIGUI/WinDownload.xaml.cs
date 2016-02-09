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
using System.Windows.Shapes;
using CG.Web.MegaApiClient;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Threading;

namespace HOIGUI
{
    /// <summary>
    /// Interaction logic for WinDownload.xaml
    /// </summary>
    public partial class WinDownload : Window
    {
        public WinDownload()
        {
            InitializeComponent();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            Uri uri = new Uri(url);
            megaClient.LoginAnonymous();
            Stopwatch Wtchr = Stopwatch.StartNew();
            Task t = megaClient.DownloadFileAsync(uri, path + "\\" + fname);

            try
            {
                Wtchr.Start();
                while (!t.IsCompleted)
                {
                    if (Application.Current.Dispatcher.CheckAccess())
                    {
                        this.pbwd.Value = megaClient.Progress;
                    }
                    else
                    {
                        this.Dispatcher.Invoke(
                            DispatcherPriority.Normal,
                            (System.Windows.Forms.MethodInvoker) delegate(){
                                pbwd.Value = megaClient.Progress;
                                percentlbl.Content = megaClient.Progress + " %";
                            });
                    }
                     
                }
                megaClient.Logout();
                Wtchr.Stop();
                Console.WriteLine("download fnshed!", Wtchr.Elapsed);
            }
            catch (Exception exx)
            {
                System.Windows.Forms.MessageBox.Show(exx.StackTrace);
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.Dispose();
            MessageBox.Show("Download Finished!");
            this.Close();
        }

        MegaApiClient megaClient = new MegaApiClient();
        private BackgroundWorker backgroundWorker1;



        public void GetWithMega(string Url, string Fname)
        {
            this.backgroundWorker1.RunWorkerAsync();
            mname.Content = Fname;
        }

        public string url;
        public string fname;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetWithMega(url, fname);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }


    }
}
