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
        Random rnd = new Random();
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox lbox;
        DataGridView dgv;
        public Form1()
        {
            Height = 500;
            Width = 750;
            Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.BackColor = Color.DarkGray;
            btn.Location = new Point(130, 10);
            btn.Height = 40;
            btn.Width = 80;
            btn.Click += Btn_Click;
            tn.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Dadova";
            lbl.Size = new Size(500, 15);
            lbl.Location = new Point(148, 70);
            tn.Nodes.Add(new TreeNode("Märkeruut-CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast-TextBox"));
            tn.Nodes.Add(new TreeNode("Pildikast-PictureBox")); //
            tn.Nodes.Add(new TreeNode("Kaart-TabControl"));
            tn.Nodes.Add(new TreeNode("Sõnumkast-MessageBox"));
            tn.Nodes.Add(new TreeNode("Nimekirikast-ListBox"));
            tn.Nodes.Add(new TreeNode("Andmedvõrevaade-DataGridView"));
            tn.Nodes.Add(new TreeNode("Menüü-Menu"));
            tree.Nodes.Add(tn);
            Controls.Add(tree);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt-Label")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut-CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(230, 10);
                Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(230, 40);
                Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "Vasakule";
                r1.Location = new Point(130, 90);
                r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
                r2 = new RadioButton();
                r2.Text = "Paremale";
                r2.Location = new Point(250, 90);
                r2.CheckedChanged += new EventHandler(RadioButtons_Changed);
                Controls.Add(r1);
                Controls.Add(r2);
            }
            else if (e.Node.Text == "Tekstkast-TextBox")
            {
                string text;
                try
                {
                    text = File.ReadAllText(path: "text.txt");
                }
                catch (FileNotFoundException exception)
                {
                    text = "tekst puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Location = new Point(130, 120);
                txt_box.Height = 100;
                txt_box.Width = 200;
                Controls.Add(txt_box);
            }
            else if (e.Node.Text == "Pildikast-PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("panic.jpg");
                picture.Location = new Point(130, 240);
                picture.Size = new Size(100, 100);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                Controls.Add(picture);
            }
            else if (e.Node.Text == "Kaart-TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(350, 120);
                tabControl.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");
                page1.BackColor = Color.Blue;
                page2 = new TabPage("Teine");
                page2.BackColor = Color.Black;
                page3 = new TabPage("Kolmas");
                page2.BackColor = Color.Black;
                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                Controls.Add(tabControl);
                var ans = MessageBox.Show("Kas sa tahad 1 lehel?", "Mida sa tahad?", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes)
                {
                    tabControl.SelectedIndex = 0;
                }
                else
                {
                    var ans1 = MessageBox.Show("Kas sa tahad 2 lehel?", "Mida sa tahad?", MessageBoxButtons.YesNo);
                    if (ans1 == DialogResult.Yes)
                    {
                        tabControl.SelectedIndex = 1;
                    }
                    else
                    {
                        var ans2 = MessageBox.Show("Kas sa tahad 3 lehel?", "Mida sa tahad?", MessageBoxButtons.YesNo);
                        if (ans2 == DialogResult.Yes)
                        {
                            tabControl.SelectedIndex = 2;
                        }
                        else
                        {
                            Controls.Remove(tabControl);
                        }
                    }
                }
            }
            else if (e.Node.Text == "Sõnumkast-MessageBox")
            {
                MessageBox.Show("Dadova", "kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nuppudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        lbl.Location = new Point(130, 70);
                        Controls.Add(lbl);
                    }
                }
            }
            else if (e.Node.Text == "Nimekirikast-ListBox")
            {
                string[] Colors_nimetused = new string[] { "Kollane", "Punane", "Roheline", "Sinine" };
                lbox = new ListBox();
                foreach (var item in Colors_nimetused)
                {
                    lbox.Items.Add(item);
                }
                lbox.Location = new Point(130, 360);
                lbox.Width = 50;
                lbox.Height = Colors_nimetused.Length * 15;
                Controls.Add(lbox);
            }
            else if (e.Node.Text == "Andmedvõrevaade-DataGridView")
            {
                DataSet dataSet = new DataSet("Näide");
                dataSet.ReadXml("breakfast.xml");
                dgv = new DataGridView();
                dgv.Location = new Point(250, 240);
                dgv.Width = 443;
                dgv.Height = 200;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "food";
                dgv.DataSource = dataSet;
                Controls.Add(dgv);
            }
            else if (e.Node.Text == "Menüü-Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuitem1 = new MenuItem("File");
                menuitem1.MenuItems.Add("Exit", new EventHandler(menuitem1_Exit));
                menuitem1.MenuItems.Add("Clear", new EventHandler(menuitem1_Clear));
                MenuItem menuitem2 = new MenuItem("Tree");
                MenuItem menuitem2_1 = new MenuItem("Color");
                menuitem2.MenuItems.Add("Hide Tree", new EventHandler(menuitem2_Hide));
                menuitem2.MenuItems.Add("Show Tree", new EventHandler(menuitem2_Show));
                menuitem2.MenuItems.Add(menuitem2_1);
                menuitem2_1.MenuItems.Add("Standart Color", new EventHandler(menuitem2_SdColor));
                menuitem2_1.MenuItems.Add("Random Color", new EventHandler(menuitem2_RndColor));
                menu.MenuItems.Add(menuitem1);
                menu.MenuItems.Add(menuitem2);
                Menu = menu;
            }
        }

        private void menuitem2_RndColor(object sender, EventArgs e)
        {
            Color rndColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            tree.BackColor = rndColor;
        }

        private void menuitem2_SdColor(object sender, EventArgs e)
        {
            tree.BackColor = Color.White;
        }

        private void menuitem1_Clear(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas oled kindel?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Controls.Remove(btn);
                Controls.Remove(lbl);
                Controls.Remove(box_btn);
                Controls.Remove(box_lbl);
                Controls.Remove(r1);
                Controls.Remove(r2);
                Controls.Remove(txt_box);
                Controls.Remove(picture);
                Controls.Remove(tabControl);
                Controls.Remove(lbox);
                Controls.Remove(dgv);
            }
        }

        private void menuitem2_Show(object sender, EventArgs e)
        {
            Controls.Add(tree);
        }

        private void menuitem2_Hide(object sender, EventArgs e)
        {
            Controls.Remove(tree);
        }

        private void menuitem1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas oled kindel?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void RadioButtons_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(130, 10);
                lbl.Location = new Point(148, 60);
            }
            else
            {
                btn.Location = new Point(495, 10);
                lbl.Location = new Point(518, 60);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Green)
            {
                btn.BackColor = Color.Orange;
                btn.ForeColor = Color.Green;
                lbl.ForeColor = Color.Orange;
            }
            else
            {
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.Orange;
                lbl.ForeColor = Color.Green;
            }
        }
    }
}