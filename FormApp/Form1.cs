using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class Form1 : Form
    {

        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton rb1, rb2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox lbox;

        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            //Button
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;
            //Label
            tn.Nodes.Add(new TreeNode("Label"));
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);

            tn.Nodes.Add(new TreeNode("CheckBox"));
            tn.Nodes.Add(new TreeNode("Radiobutton"));
            tn.Nodes.Add(new TreeNode("TextKast"));
            tn.Nodes.Add(new TreeNode("Pildikast"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));



            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Label")
            {
                lbl = new Label();
                lbl.Text = "Tarkvara arendajad";
                lbl.Size = new Size(150, 30);
                lbl.Location = new Point(150, 200);
                this.Controls.Add(lbl);
            }

            else if (e.Node.Text == "CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Naita button";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Naita label";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radiobutton")
            {
                rb1 = new RadioButton();
                rb1.Text = "Vasakule-Button";
                rb1.Location = new Point(320, 30);
                rb1.CheckedChanged += new EventHandler(RadioButtons_Changed);
                rb2 = new RadioButton();
                rb2.Text = "Paremale-Button";
                rb2.Location = new Point(320, 70);
                rb2.CheckedChanged += new EventHandler(RadioButtons_Changed);

                this.Controls.Add(rb1);
                this.Controls.Add(rb2);
            }

            else if (e.Node.Text == "TextKast")
            {
                string text;
                try
                {
                    text = File.ReadAllText("text.txt");
                }
                catch (FileNotFoundException excpetion)
                {
                    text = "Tekst Puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 100;
                txt_box.Height = 100;
                this.Controls.Add(txt_box);
            }
            else if (e.Node.Text == "Pildikast")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("panic.jpg");
                picture.Location = new Point(500, 100);
                picture.Size = new Size(90, 90);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(300, 300);
                tabControl.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");
                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                tabControl.SelectedIndex = 2;//0,1,2
                this.Controls.Add(tabControl);
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InpudBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahat tekst saada Teksatisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK);
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }

                }
                
            }

            else if (e.Node.Text == "ListBox")
            {
                string[] Colors_nimetused = new string[] { "Kollane", "Roheline", "Punaene", "Sinine" };
                lbox = new ListBox();
                foreach (var item in Colors_nimetused)
                {
                    lbox.Items.Add(item);
                }
                lbox.Location = new Point(450, 30);
                lbox.Width = 50;
                lbox.Height = Colors_nimetused.Length * 15;
                this.Controls.Add(lbox);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml("breakfast.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(200, 200);
                dgv.Width = 450;
                dgv.Height = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "food";
                dgv.DataSource = dataSet;
                this.Controls.Add(dgv);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuitem1 = new MenuItem("File");
                menuitem1.MenuItems.Add("Exit", new EventHandler(menuitem1_Exit));
                MenuItem menuitem2 = new MenuItem("View");
                menuitem1.MenuItems.Add("1", new EventHandler(menuitem2_1));
                menuitem1.MenuItems.Add("2", new EventHandler(menuitem2_2));
                menuitem1.MenuItems.Add("3", new EventHandler(menuitem2_3));
                menu.MenuItems.Add(menuitem1);

                this.Menu = menu;
            }

        }

        private void menuitem2_3(object sender, EventArgs e)
        {
            
        }

        private void menuitem2_2(object sender, EventArgs e)
        {
            
        }

        private void menuitem2_1(object sender, EventArgs e)
        {
            
        }

        private void menuitem1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas oled kindel?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes) ;
            {
                this.Dispose();
            }
        }

        private void RadioButtons_Changed(object sender, EventArgs e)
        {
            if (rb1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (rb2.Checked)
            {
                btn.Location = new Point(400, 100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                this.Controls.Add(lbl);
            }
            else
            {
                this.Controls.Remove(lbl);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                this.Controls.Add(btn);
            }
            else
            {
                this.Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}