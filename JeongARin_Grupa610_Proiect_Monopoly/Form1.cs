using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JeongARin_Grupa610_Proiect_Monopoly
{
    public partial class Form1 : Form
    {
        //dice
        private void button15_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var list = new List<int> { 1, 2, 3, 4, 5, 6};
            int index = random.Next(list.Count);
            button15.Text = list[index].ToString();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                MessageBox.Show("Please choose another colour.");
            else
                comboBox.Enabled = false;
        }


        // my turn player 1
        private void button16_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox1.Text;
            if (textBox1.Text == "" || comboBox1.SelectedIndex < 0)
                MessageBox.Show("Please write the name of the player and select a colour!");
            else if (textBox1.Text == textBox2.Text)
                MessageBox.Show("You cannot have the same name as the opposite player");
            string colo = comboBox1.Text;
            button16.BackColor = Color.FromName(colo);



        }

        //my turn player 2
        private void button17_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox2.Text;
            if (textBox2.Text == "" || comboBox2.SelectedIndex < 0)
                MessageBox.Show("Please write the name of the player and select a colour!");
            else if (textBox1.Text == textBox2.Text)
                MessageBox.Show("You cannot have the same name as the opposite player");
            string colo = comboBox2.Text;
            button17.BackColor = Color.FromName(colo);

  
        }

        //pay property price to the bank when buying
        public void payproperty(int z)
        {
            if (textBox3.Text == textBox1.Text)
            {
                int x = int.Parse(player1.Text) - z;
                int y = int.Parse(bank.Text) + z;
                bank.Text = y.ToString();
                player1.Text = x.ToString();
            }
            else
            {
                int x = int.Parse(player2.Text) - z;
                int y = int.Parse(bank.Text) + z;
                bank.Text = y.ToString();
                player2.Text = x.ToString();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            //textBox3== player name holder

            Button button = (Button)sender;
            //foreach (Control list in Controls)
            //    if (list is ListBox)
            //    {
            //        list.Items.Remove(textBox3.Text);     
            //    }
            listBox1.Items.Remove(textBox3.Text);
            listBox2.Items.Remove(textBox3.Text);
            listBox3.Items.Remove(textBox3.Text);
            listBox4.Items.Remove(textBox3.Text);
            listBox5.Items.Remove(textBox3.Text);
            listBox6.Items.Remove(textBox3.Text);
            listBox7.Items.Remove(textBox3.Text);
            listBox8.Items.Remove(textBox3.Text);
            listBox9.Items.Remove(textBox3.Text);
            listBox10.Items.Remove(textBox3.Text);
            listBox11.Items.Remove(textBox3.Text);
            listBox12.Items.Remove(textBox3.Text);
            listBox13.Items.Remove(textBox3.Text);
            listBox14.Items.Remove(textBox3.Text);



            if (textBox3.Text == "")
                MessageBox.Show("Please select a player by clicking on My turn! ");

            //START
            else if (button == button1)
                listBox1.Items.Add(textBox3.Text);


            //Euston
            else if (button == button2)
            {
                listBox2.Items.Add(textBox3.Text);
                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button2.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            //if (comboBox1.Text == "Red")
                            //    button.BackColor = Color.Red;
                            //else if (comboBox1.Text == "Blue")
                            //    button.BackColor = Color.Blue;
                            //else if (comboBox1.Text == "Yellow")
                            //    button.BackColor = Color.Yellow;
                            //else if (comboBox1.Text == "Purple")
                            //    button.BackColor = Color.Purple;
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            //if (comboBox2.Text == "Red")
                            //    button.BackColor = Color.Red;
                            //else if (comboBox2.Text == "Blue")
                            //    button.BackColor = Color.Blue;
                            //else if (comboBox2.Text == "Yellow")
                            //    button.BackColor = Color.Yellow;
                            //else if (comboBox2.Text == "Purple")
                            //    button.BackColor = Color.Purple;
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(100);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $50!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $50!");
                else
                    MessageBox.Show("Home sweet home!");

            }


            // Chance**
            else if (button == button3)
            {
                listBox3.Items.Add(textBox3.Text);
                List<string> list = new List<string> { "Go back 3 spaces.", "Doctor's fees. Pay $50 to bank.", "Bank pays you a divident of $50.", "Advance to go!", "School fees. Pay $50 to bank!", " Is the birthday of the opposite player. Pay the opposite player $100!" };
                var random = new Random();
                int index = random.Next(list.Count);
                MessageBox.Show(list[index]);
                if (list[index] == "Bank pays you a divident of $50." && textBox3.Text == textBox1.Text)
                {
                    int x = int.Parse(player1.Text) +50;
                    int y = int.Parse(bank.Text) -50;
                    bank.Text = y.ToString();
                    player1.Text = x.ToString();
                }
                else if (list[index] == "Bank pays you a divident of $50." && textBox3.Text == textBox2.Text)
                {
                    int x = int.Parse(player2.Text) + 50;
                    int y = int.Parse(bank.Text) - 50;
                    bank.Text = y.ToString();
                    player2.Text = x.ToString();
                }

            }

            //Vine Street //aproape acelasi cod ca la Euston
            else if (button == button4)
            {
                listBox4.Items.Add(textBox3.Text);

                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button3.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(100);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $50!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $50!");
                else
                    MessageBox.Show("Home sweet home!");
            }  



            //Jail**
            else if (button == button5)
            {
                listBox5.Items.Add(textBox3.Text);
            }

            
            //Picadilly
            else if (button == button6)
            {
                listBox6.Items.Add(textBox3.Text);

                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button6.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(200);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $100!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $100!");
                else
                    MessageBox.Show("Home sweet home!");
            }

            //Strand
            else if (button == button7)
            {
                listBox7.Items.Add(textBox3.Text);
                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button7.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(200);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $100!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $100!");
                else
                    MessageBox.Show("Home sweet home!");
            }



            //FREE PARKING**
            else if (button == button8)
                listBox8.Items.Add(textBox3.Text);


            //Oxford Street
            else if (button == button9)
            {
                listBox9.Items.Add(textBox3.Text);
                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button9.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(300);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $150!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $150!");
                else
                    MessageBox.Show("Home sweet home!");
            }


            //Income tax**
            else if (button == button10)
            {
                listBox10.Items.Add(textBox3.Text);
                MessageBox.Show("You need to pay taxes to the bank in value of $200.");
            }


            //Bond Street
            else if (button == button11)
            {
                listBox11.Items.Add(textBox3.Text);
                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button11.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(300);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $150!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $150!");
                else
                    MessageBox.Show("Home sweet home!");
            }

            //Go to JAIL**
            else if (button == button12)
            {
                listBox12.Items.Add(textBox3.Text);
                MessageBox.Show("Go to jail!");
                listBox12.Items.Clear();
                listBox5.Items.Add(textBox3.Text);
                MessageBox.Show("You need to pay $ 200 to get out of jail or you need to be lucky !!! Try rolling the dice twice and get twice number 6 !");
            }


            //Mayfare
            else if (button == button13)
            {
                listBox13.Items.Add(textBox3.Text);
                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button13.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(400);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent $200 !");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $200!");
                else
                    MessageBox.Show("Home sweet home!");
            }

            //Park Place
            else if (button == button14)
            {
                listBox14.Items.Add(textBox3.Text);
                if (button.BackColor == Color.White)
                {
                    if (MessageBox.Show($"Do you want to buy {button14.Text} ?", "Opportunity!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (textBox3.Text == textBox1.Text)
                        {
                            button.BackColor = Color.FromName(comboBox1.Text);
                        }
                        else
                        {
                            button.BackColor = Color.FromName(comboBox2.Text);
                        }

                        payproperty(400);
                    }
                }
                else if (textBox3.Text == textBox1.Text && button.BackColor == Color.FromName(comboBox2.Text))
                    MessageBox.Show($"You need to pay rent!");
                else if (textBox3.Text == textBox2.Text && button.BackColor == Color.FromName(comboBox1.Text))
                    MessageBox.Show($"You need to pay rent $50!");
                else
                    MessageBox.Show("Home sweet home!");
            }

        }

        // Get 200 dollars!!!
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox1.Text)
            {
                int x = int.Parse(player1.Text) + 200;
                int y = int.Parse(bank.Text) - 200;
                bank.Text = y.ToString();
                player1.Text = x.ToString();
            }
            else
            {
                int x = int.Parse(player1.Text) + 200;
                int y = int.Parse(bank.Text) - 200;
                bank.Text = y.ToString();
                player1.Text = x.ToString();

            }
            MessageBox.Show("You have received $200!");
        }

        //Pay now button
        private void button19_Click(object sender, EventArgs e)
        {
            int value;
            if (textBox4.Text == "")
                MessageBox.Show("How much do you want to pay?");
            else if (textBox3.Text == "")
                MessageBox.Show("The payer is not specified.");
            else if (int.TryParse(textBox4.Text, out value) == false)
                MessageBox.Show("You need to add a number!");
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
                MessageBox.Show("You need to select the payee");
            
            else if (textBox1.Text == textBox3.Text)
            {
                if (radioButton1.Checked)
                {
                    int x = int.Parse(player1.Text) - int.Parse(textBox4.Text);
                    int y = int.Parse(bank.Text) + int.Parse(textBox4.Text);
                    bank.Text = y.ToString();
                    player1.Text = x.ToString();
                    
                }
                else if (radioButton2.Checked)
                {
                    int x = int.Parse(player1.Text) - int.Parse(textBox4.Text);
                    int y = int.Parse(player2.Text) + int.Parse(textBox4.Text);
                    player2.Text = y.ToString();
                    player1.Text = x.ToString();
                }
                MessageBox.Show($"You have paid $ {textBox4.Text} !");
            }
            else if (textBox2.Text == textBox3.Text)
            {
                if (radioButton1.Checked)
                {
                    int x = int.Parse(player2.Text) - int.Parse(textBox4.Text);
                    int y = int.Parse(bank.Text) + int.Parse(textBox4.Text);
                    bank.Text = y.ToString();
                    player2.Text = x.ToString();
                }
                else if (radioButton2.Checked)
                {
                    int x = int.Parse(player2.Text) - int.Parse(textBox4.Text);
                    int y = int.Parse(player1.Text) + int.Parse(textBox4.Text);
                    player1.Text = y.ToString();
                    player2.Text = x.ToString();
                }
                MessageBox.Show($"You have paid $ {textBox4.Text} !");
            }


        }

        //Save game
        private void button20_Click(object sender, EventArgs e)
        {
            if (int.Parse(player2.Text) <= 0)
                MessageBox.Show($"Congratulations !!! {textBox1.Text} has won the game");
            else if (int.Parse(player1.Text) <= 0)
                MessageBox.Show($"Congratulations !!! {textBox2.Text} has won the game");
            var lista = new List<string>();
            saveFileDialog1.ShowDialog();
            lista.Add("Bank     $ " + bank.Text);
            lista.Add("Player 1 $ " + player1.Text);
            lista.Add("Player 2 $ " + player2.Text);
            SaveFileDialog dialog = new SaveFileDialog();
            File.WriteAllLines(saveFileDialog1.FileName, lista);

        }

        private void new_game_Click(object sender, EventArgs e)
        {
            if (int.Parse(player2.Text) <= 0)
                MessageBox.Show($"Congratulations !!! {textBox1.Text} has won the game");
            else if (int.Parse(player1.Text) <= 0)
                MessageBox.Show($"Congratulations !!! {textBox2.Text} has won the game");

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    c.Text = "";
                if (c is ListBox)
                    c.Text = "";

            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            listBox9.Items.Clear();
            listBox10.Items.Clear();
            listBox11.Items.Clear();
            listBox12.Items.Clear();
            listBox13.Items.Clear();
            listBox14.Items.Clear();

            button16.BackColor = Color.White;
            button17.BackColor = Color.White;
            button2.BackColor = Color.White;
            button4.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button9.BackColor = Color.White;
            button11.BackColor = Color.White;
            button13.BackColor = Color.White;
            button14.BackColor = Color.White;

            bank.Text = "20580";
            player1.Text = "1500";
            player2.Text = "1500";

            comboBox1.Text = "";
            comboBox1.Enabled = true;
            comboBox2.Text = "";
            comboBox2.Enabled = true;
        }
    }
}
