using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metro_Image_Class_Fliter_App
{
    public partial class Form1 : Form
    {

        private string[] files;
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            //  Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            //                   ^  ^  ^  ^  ^  ^  ^

            this.openFileDialog1.Title = "My Image Browser";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string[] result = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "class.txt"));
            string destinationPath = @"C:\ImageData\";

            foreach (string filePath in files)
            {
               string fileName = Path.GetFileName(filePath);
                Console.WriteLine(fileName);

                foreach (string line in result)
                {
                    if (fileName.Split('.')[0].Equals(line.Split('-')[0]))
                    {
                        Console.WriteLine(line.Split('-')[1]);
                        string destinationFile = System.IO.Path.Combine(destinationPath, fileName);
                        switch (line.Split('-')[1])
                        {
                            case "3 Axle Commercial":
                                destinationFile = System.IO.Path.Combine(destinationPath + "3 Axle Commercial", fileName);
                                if (!System.IO.Directory.Exists(destinationPath + "3 Axle Commercial"))
                                {
                                    System.IO.Directory.CreateDirectory(destinationPath + "3 Axle Commercial");
                                }
                                System.IO.File.Copy(filePath, destinationFile, true);
                                break;
                            case "BUS":
                                destinationFile = System.IO.Path.Combine(destinationPath + "BUS", fileName);
                                if (!System.IO.Directory.Exists(destinationPath + "BUS"))
                                {
                                    System.IO.Directory.CreateDirectory(destinationPath + "BUS");
                                }
                                System.IO.File.Copy(filePath, destinationFile, true);
                                break;
                            case "CAR JEEP VAN":
                                destinationFile = System.IO.Path.Combine(destinationPath + "CAR JEEP VAN", fileName);
                                if (!System.IO.Directory.Exists(destinationPath + "CAR JEEP VAN"))
                                {
                                    System.IO.Directory.CreateDirectory(destinationPath + "CAR JEEP VAN");
                                }
                                System.IO.File.Copy(filePath, destinationFile, true);
                                break;
                            case "LCV":
                                destinationFile = System.IO.Path.Combine(destinationPath + "LCV", fileName);
                                if (!System.IO.Directory.Exists(destinationPath + "LCV"))
                                {
                                    System.IO.Directory.CreateDirectory(destinationPath + "LCV");
                                }
                                System.IO.File.Copy(filePath, destinationFile, true);
                                break;
                            case "MAV":
                                destinationFile = System.IO.Path.Combine(destinationPath + "MAV", fileName);
                                if (!System.IO.Directory.Exists(destinationPath + "MAV"))
                                {
                                    System.IO.Directory.CreateDirectory(destinationPath + "MAV");
                                }
                                System.IO.File.Copy(filePath, destinationFile, true);
                                break;
                            case "TRUCK":
                                destinationFile = System.IO.Path.Combine(destinationPath + "TRUCK", fileName);
                                if (!System.IO.Directory.Exists(destinationPath + "TRUCK"))
                                {
                                    System.IO.Directory.CreateDirectory(destinationPath + "TRUCK");
                                }
                                System.IO.File.Copy(filePath, destinationFile, true);
                                break;
                            default:
                                Console.WriteLine("default");
                                break;
                         

                        }
                    }
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                     files = Directory.GetFiles(fbd.SelectedPath);
                     

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }
    }
}
