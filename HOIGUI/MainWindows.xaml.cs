using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using CG.Web.MegaApiClient;
using System.Diagnostics;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Zip;
using System.ComponentModel;

namespace HOIGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {

        public String ModPath;
        public String GamePath;

        public MainWindow()
        {
            InitializeComponent();
            PopulateModList();
            yourMahAppFlyout.IsOpen = true;
        }

        System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();

        static void ExtractZip(string filename, string Name, string basepath)
        {

            string dewLoc = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "ElDewrito");
            string fileloc = System.IO.Path.Combine(Directory.GetCurrentDirectory(), filename);

            FastZip fastZip = new FastZip();
            string filter = null;

            Stopwatch watcher = Stopwatch.StartNew();

            Console.WriteLine("Extraction started for: " + Name);
            watcher.Restart();
            fastZip.ExtractZip(filename, dewLoc, filter);
            watcher.Stop();
            Console.WriteLine("Extraction finished for: " + Name + " in {0}.\n ", watcher.Elapsed);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog.ShowDialog();
            lbl1.Text = dialog.SelectedPath;

            //pb1.Value = pb1.Value += 1;
        }

        public class ModList
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public string Version { get; set; }
            public string Url { get; set; }
        }

        public List<string> UrlList = new List<string>();
        public List<string> Filenames = new List<string>();

        public void PopulateModList()
        {
            System.Net.WebClient WCD = new System.Net.WebClient();
            string sgetjson = WCD.DownloadString("http://thetwist84.github.io/HaloOnlineModManager/game/game.json");
            dynamic getjson = JsonConvert.DeserializeObject(sgetjson);

            List<User> items = new List<User>();
            var dew = getjson["mods"]["0.5.0.2"];
            foreach (var item in dew)
            {
                var name2 = item;
                foreach (var item2 in item)
                {
                    try
                    {
                        var name = item2.Name;
                        var version = item2.Version;
                        var author = item2.Author;
                        var url = item2.Url;
                        UrlList.Add(item2.Url.ToString());
                        Filenames.Add(item2.Filename.ToString());
                        items.Add(new User() { Name = name, Ver = version, Auth = author, Progress = 0, Url = url });
                    }
                    catch (Exception )
                    {
                        System.Windows.Forms.MessageBox.Show("Welcome to Halo Online Installer!");
                    }
                }

                lvUsers.ItemsSource = items;
            }
        }


        public class User
        {
            public string Name { get; set; }
            public string Ver { get; set; }
            public string Auth { get; set; }
            public string Url { get; set; }
            public int Progress { get; set; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        void Settings_Click(object sender, RoutedEventArgs e)
        {
            if (yourMahAppFlyout.IsOpen)
            {
                yourMahAppFlyout.IsOpen = false;
            }
            else
            {
                yourMahAppFlyout.IsOpen = true;
            }
        }

        void downloadlink(object sender, EventArgs e)
        {

            foreach (var item in UrlList)
            {
                System.Windows.Forms.MessageBox.Show(item);

            }
        }



        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvUsers.SelectedItems.Count > 0)
                {
                    if (UrlList[lvUsers.SelectedIndex] == "")
                    {
                        System.Windows.Forms.MessageBox.Show("There's no url for this item :(");
                    }
                    else
                    {
                        string link = UrlList[lvUsers.SelectedIndex];
                        string Fname = Filenames[lvUsers.SelectedIndex];
                        //   System.Windows.Forms.MessageBox.Show(UrlList[lvUsers.SelectedIndex] + Fname);
                        if (link.StartsWith("https://mega"))
                        {
                            HOIGUI.WinDownload WD = new HOIGUI.WinDownload();
                            WD.url = link;
                            WD.fname = Fname;
                            WD.ShowDialog();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.StackTrace);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Not Yet Ready :D");
        }



    }
}


