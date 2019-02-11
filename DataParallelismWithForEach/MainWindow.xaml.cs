using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;



namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }// end ctor
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // This will be updated shortly
        }//end cmdCancle
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            ProcessFiles();
            //Task.Factory.StartNew(() => ProcessFiles());
        }// end cmdProcess
        private void ProcessFiles()
        {
            // Load up all *.jpg files, and make a new folder for the modified data.
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string newDir = @".\ModifiedPictures";
            Directory.CreateDirectory(newDir);
            // Process the image data in a blocking manner.
            /*foreach (string currentFile in files)
            {
                string filename = System.IO.Path.GetFileName(currentFile);
                using (Bitmap bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(System.IO.Path.Combine(newDir, filename));
                    // Print out the ID of the thread processing the current image .
                    this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                }
            }*/
            Parallel.ForEach(files, currentFile =>
                                                {
                string filename = System.IO.Path.GetFileName(currentFile);
                                                    using (Bitmap bitmap = new Bitmap(currentFile))
                                                    {
                                                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                                        bitmap.Save(System.IO.Path.Combine(newDir, filename));
                                                        // Eek! This will not work anymore!
                                                        //this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                                                        // Invoke on the Form object, to allow secondary threads to access controls
                                                        // in a thread-safe manner.
                                                        //this.Dispatcher.Invoke((Action)delegate
                                                        //{
                                                            //this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                                                        //}
                                                        //);
                                                    }
                                                }
);
        }// end ProcessFiles()

        }// end class
}// end ns
