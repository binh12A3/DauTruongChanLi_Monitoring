using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using InputManager;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;
using System.Management;

namespace Tool_LOL
{
    public partial class Form1 : Form
    {
        /*
         * ##############################################################################################
         * ######################### Add Firebase feature to manage licenses ############################
         * ##############################################################################################
         */

        //Config database access
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "qRjWvaHWeTL0HaSdZiIB5EeE3ckyBE1K85wYuy8n",
            BasePath = "https://license-manager-3d043-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        //Define a class to acquire CPU ID of the user when they start this application
        internal class Data
        {
            public string cpuID { get; set; }
        }


        string Directory = "";
        string LicenseKey = "";


        //This function is used to instal license to the current user's CPU id
        async void installLicense(string cpuInfo)
        {
            try
            {
                var data = new Data
                {
                    cpuID = cpuInfo,
                };

                FirebaseResponse response = await client.SetTaskAsync("LOL_TOOL/" + LicenseKey, data);
                Data result = response.ResultAs<Data>();
                MessageBox.Show("Install License sucessfully");
            }
            catch
            {
                MessageBox.Show("There is an issue when installLicense(). Please contact \"binhmagic1995@gmail.com\" for support");
                Application.Exit();
            }
        }//end installLicense()


        //This function is used to check the user's license if it is matched with their CPU id which is registered at the first time they start the app
        async void checkLicense(string LicenseKey, string cpuInfo)
        {
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("LOL_TOOL/" + LicenseKey);
                Data obj = response.ResultAs<Data>();

                //"00" means new license is not activated and can be used
                if (obj.cpuID == "00")
                {
                    installLicense(cpuInfo);
                }
                else if (obj.cpuID == cpuInfo)
                {
                    MessageBox.Show("License OK, Happy Welcome Back ❤️");
                }
                else if (obj.cpuID != cpuInfo)
                {
                    MessageBox.Show("This License \"" + LicenseKey + "\" is used. Please contact \"binhmagic1995@gmail.com\" for purchasing new license");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Please contact \"binhmagic1995@gmail.com\" for purchasing new license");
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("This License \"" + LicenseKey + "\" is used. Please contact \"binhmagic1995@gmail.com\" for purchasing new license");
                Application.Exit();
            }
        }//end checkLicense()


        //This function is used to load the setting.txt file, which contains the license code
        void load_setting()
        {
            try
            {
                string[] lines = File.ReadAllLines(String.Concat(Directory, "\\setting.txt"));
                LicenseKey = lines[0].After("<License>");
            }
            catch
            {
                MessageBox.Show("Missing \"setting.txt\" in " + Directory + "\\");
                Application.Exit();
            }
        }//end load_setting()




        /*
         * ##############################################################################################
         * #################################### Form pre-processing #####################################
         * ##############################################################################################
         */

        public Form1()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;// add here to avoid "Cross-thread operation not valid: Control 'textBox1' accessed from a thread other than the thread it was created on"
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Get the location of the app
            Directory = Application.StartupPath;

            load_setting();

            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                //Get the unique CPU id
                string cpuInfo = string.Empty;
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (cpuInfo == "")
                    {
                        //Get only the first CPU id
                        cpuInfo = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                checkLicense(LicenseKey, cpuInfo);

            }//end client != null
        }





        /*
         * ##############################################################################################
         * ####################################### Main processing ######################################
         * ##############################################################################################
         */

        bool isShow = false;
        Thread newThread;

        private void buttonbuttonMonitor_Click(object sender, EventArgs e)
        {
            /* [Issue] https://stackoverflow.com/questions/7136000/sending-keyboard-events-to-another-application-in-c-sharp-that-does-not-handle-w
             * --> InputSimulator : works fine for "traditional" Windows applications, but when sending inputs to applications like "Half-Life" or "Doom" it simply doesn't work.
             * [Solution] https://stackoverflow.com/questions/33358047/problems-sending-keystroke-to-directx-application-using-sendinput-wrapper
             * --> Menubar --> Manage Nuget --> install InputManager + "Run as an Administrator" 
             * 
            var sim = new InputSimulator();
            sim.Mouse.MoveMouseTo(8000, 8000);
            Thread.Sleep(2000);
            sim.Mouse.LeftButtonClick();
            Thread.Sleep(100);
            sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_Q });
            sim.Keyboard.Sleep(1000);
            */

            labelStatus.Text = "Running";

            try
            {
                int loop = Convert.ToInt32(textBoxLoop.Text);
                if (loop > 0 && loop <= 8)
                {
                    //chạy thread mới
                    newThread = new Thread(() => captureImage(loop));
                    newThread.Start();
                }
                else
                {
                    labelStatus.Text = "Ready";
                    textBoxLoop.Text = "";
                    MessageBox.Show("Vùi lòng nhập số từ 1 đến 8");
                }

            }
            catch
            {
                labelStatus.Text = "Ready";
                textBoxLoop.Text = "";
                MessageBox.Show("Vùi lòng nhập số từ 1 đến 8");
            }
            //MessageBox.Show("Done");
        }

        void captureImage(int loop)
        {
            Mouse.Move(500, 500);
            Thread.Sleep(1000); ;
            Mouse.PressButton(Mouse.MouseKeys.Left);
            Thread.Sleep(300);

            //chụp hình
            for (int i = 0; i < loop; i++)
            {
                Keyboard.KeyDown(Keys.Q);
                Keyboard.KeyUp(Keys.Q);
                Thread.Sleep(300);

                //Rectangle rect = new Rectangle(0, 260, 200, 650);
                //Rectangle rect = new Rectangle(0, 0, 1920, 1080);
                Rectangle rect = new Rectangle(500, 20, 900, 450);
                Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                //bmp.Save(@"D:\p" + i + ".jpeg", ImageFormat.Jpeg);

                switch (i)
                {
                    case 0:
                        pictureBox1.Image = bmp;
                        break;
                    case 1:
                        pictureBox2.Image = bmp;
                        break;
                    case 2:
                        pictureBox3.Image = bmp;
                        break;
                    case 3:
                        pictureBox4.Image = bmp;
                        break;
                    case 4:
                        pictureBox5.Image = bmp;
                        break;
                    case 5:
                        pictureBox6.Image = bmp;
                        break;
                    case 6:
                        pictureBox7.Image = bmp;
                        break;
                    case 7:
                        pictureBox8.Image = bmp;
                        break;
                }
            }



            //not default all 8 players ==> set remaining pictureboxes to gray color
            if (loop != 8)
            {
                for (int i = loop; i < 8; i++)
                {
                    switch (i)
                    {
                        case 0:
                            pictureBox1.Image = Tool_LOL.Properties.Resources.n1;
                            break;
                        case 1:
                            pictureBox2.Image = Tool_LOL.Properties.Resources.n2;
                            break;
                        case 2:
                            pictureBox3.Image = Tool_LOL.Properties.Resources.n3;
                            break;
                        case 3:
                            pictureBox4.Image = Tool_LOL.Properties.Resources.n4;
                            break;
                        case 4:
                            pictureBox5.Image = Tool_LOL.Properties.Resources.n5;
                            break;
                        case 5:
                            pictureBox6.Image = Tool_LOL.Properties.Resources.n6;
                            break;
                        case 6:
                            pictureBox7.Image = Tool_LOL.Properties.Resources.n7;
                            break;
                        case 7:
                            pictureBox8.Image = Tool_LOL.Properties.Resources.n8;
                            break;
                    }
                }
            }


            labelStatus.Text = "Ready";
        }//end captureImage



        private void buttonTopMost_Click(object sender, EventArgs e)
        {
            isShow = !isShow;
            if (isShow == true)
            {
                this.TopMost = true;
                buttonTopMost.Image = Tool_LOL.Properties.Resources.eye;
            }
            else
            {
                this.TopMost = false;
                buttonTopMost.Image = Tool_LOL.Properties.Resources.invisible;
            }
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Tool_LOL.Properties.Resources.n1;
            pictureBox2.Image = Tool_LOL.Properties.Resources.n2;
            pictureBox3.Image = Tool_LOL.Properties.Resources.n3;
            pictureBox4.Image = Tool_LOL.Properties.Resources.n4;
            pictureBox5.Image = Tool_LOL.Properties.Resources.n5;
            pictureBox6.Image = Tool_LOL.Properties.Resources.n6;
            pictureBox7.Image = Tool_LOL.Properties.Resources.n7;
            pictureBox8.Image = Tool_LOL.Properties.Resources.n8;
        }





        /*---------------------------------------Trên---------------------------------------*/
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox1");
            pictureBox1.Cursor = Cursors.Hand;
            pictureBoxBelow.Image = pictureBox1.Image;
            pictureBoxBelow.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBelow.Visible = false;
            pictureBox1.Cursor = Cursors.Default;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox2");
            pictureBox2.Cursor = Cursors.Hand;
            pictureBoxBelow.Image = pictureBox2.Image;
            pictureBoxBelow.Visible = true;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBelow.Visible = false;
            pictureBox2.Cursor = Cursors.Default;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox3");
            pictureBox3.Cursor = Cursors.Hand;
            pictureBoxBelow.Image = pictureBox3.Image;
            pictureBoxBelow.Visible = true;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBelow.Visible = false;
            pictureBox3.Cursor = Cursors.Default;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox4");
            pictureBox4.Cursor = Cursors.Hand;
            pictureBoxBelow.Image = pictureBox4.Image;
            pictureBoxBelow.Visible = true;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBelow.Visible = false;
            pictureBox4.Cursor = Cursors.Default;
        }

        /*---------------------------------------Dưới---------------------------------------*/
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox5");
            pictureBox5.Cursor = Cursors.Hand;
            pictureBoxAbove.Image = pictureBox5.Image;
            pictureBoxAbove.Visible = true;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAbove.Visible = false;
            pictureBox5.Cursor = Cursors.Default;
        }


        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox6");
            pictureBox6.Cursor = Cursors.Hand;
            pictureBoxAbove.Image = pictureBox6.Image;
            pictureBoxAbove.Visible = true;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAbove.Visible = false;
            pictureBox6.Cursor = Cursors.Default;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox7");
            pictureBox7.Cursor = Cursors.Hand;
            pictureBoxAbove.Image = pictureBox7.Image;
            pictureBoxAbove.Visible = true;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAbove.Visible = false;
            pictureBox7.Cursor = Cursors.Default;
        }


        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBox8");
            pictureBox8.Cursor = Cursors.Hand;
            pictureBoxAbove.Image = pictureBox8.Image;
            pictureBoxAbove.Visible = true;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAbove.Visible = false;
            pictureBox8.Cursor = Cursors.Default;
        }


        /*---------------------------------------Xẻng---------------------------------------*/
        private void pictureBoxXeng_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("MOUSE ENTER pictureBoxXeng");
            pictureBoxXeng.Cursor = Cursors.Hand;
            pictureBoxAbove.Image = Tool_LOL.Properties.Resources.ghep_xeng;
            pictureBoxAbove.Visible = true;
        }

        private void pictureBoxXeng_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAbove.Image = null;
            pictureBoxAbove.Visible = false;
            pictureBoxXeng.Cursor = Cursors.Default;
        }


    }
}
