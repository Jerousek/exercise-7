using ChampionsLeagueLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ChampionsLeague
{
    public partial class ChampionsLeagueForm : Form
    {
        PlayersRecords records = new PlayersRecords();
        public event PlayersCountChangedEventHandler? PlayersCountChanged;

        public ChampionsLeagueForm()
        {
            records.PlayersCountChanged += this.PlayersCountChanged;
            InitializeComponent();
        }

        virtual protected void onPlayersCountChanged(PlayersCountChangedEventArgs eventArgs)
        {
            listBoxEvents.BeginUpdate();
            listBoxEvents.Items.Add(DateTime.Now.TimeOfDay + " | Změna počtu hráčů z " + eventArgs.OldCount + " na " + eventArgs.NewCount);
            PlayersCountChanged?.Invoke(this, eventArgs);
            listBoxEvents.EndUpdate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form1 = new Form();
            Button button1 = new Button();
            Button button2 = new Button();
            ComboBox cb = new ComboBox();
            TextBox txt1 = new TextBox();
            TextBox txt2 = new TextBox();

            Label jmeno = new Label();
            Label club = new Label();
            Label gol = new Label();

            form1.Height = 220;
            form1.Width = 330;
            form1.FormBorderStyle = FormBorderStyle.FixedSingle;
            form1.MaximizeBox = false;
            form1.Text = "Přidání/úprava hráče";


            jmeno.Text = "Jméno:";
            jmeno.Location = new Point(9, 36);
            jmeno.AutoSize = true;

            club.Text = "Klub:";
            club.Location = new Point(9, 72);
            club.AutoSize = true;

            gol.Text = "Počet gólů:";
            gol.Location = new Point(9, 108);
            gol.AutoSize = true;

            txt1.SetBounds(100, 36, 200, 20);

            cb.SetBounds(100, 72, 200, 20);

            txt2.SetBounds(100, 108, 200, 20);

            button2.SetBounds(9, 144, 75, 23);
            button1.SetBounds(225, 144, 75, 23);

            cb.Items.AddRange(new object[] {FootballClub.None,
                FootballClub.Arsenal,
                FootballClub.Barcelona,
                FootballClub.Chelsea,
                FootballClub.FCPorto,
                FootballClub.RealMadrid
            }); ;
            cb.SelectedItem = FootballClub.None;

            button1.Text = "OK";
            button2.Text = "Storno";
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.Cancel;
            form1.AcceptButton = button1;
            form1.CancelButton = button2;
            form1.Controls.AddRange(new Control[]
            {
                jmeno, txt1, club, cb, gol, txt2, button1, button2

            });
            form1.ResumeLayout(false);
            form1.PerformLayout();
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                string msgEmpty = "Nebyla zadána hodnota";
                string msgNotNum = "Zadaná hodnota není číslo";
                string title = "chyba";


                if (txt1.Text.Length == 0)
                {
                    MessageBox.Show(msgEmpty, title);
                    return;
                }
                if (txt2.Text.Length == 0)
                {
                    MessageBox.Show(msgEmpty, title);
                    return;
                }
                try
                {
                    Int32.Parse(txt2.Text);
                }
                catch
                {
                    MessageBox.Show(msgNotNum, title);
                    return;
                }
                Player? player = new Player(txt1.Text, (FootballClub)cb.SelectedItem, Int32.Parse(txt2.Text));
                records.Add(player);
                string[] row = { player.Name, FootballClubInfo.GetName(player.Club), player.GoalCount.ToString() };
                var ListViewItem = new ListViewItem(row);
                listViewPlayers.Items.Add(ListViewItem);
                onPlayersCountChanged(new PlayersCountChangedEventArgs(records.Count - 1, records.Count));
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (listViewPlayers.FocusedItem == null)
            {
                MessageBox.Show("Není vybrán hráč", "chyba");
                return;
            }
            else
            {
                Form form1 = new Form();
                Button button1 = new Button();
                Button button2 = new Button();
                ComboBox cb = new ComboBox();
                TextBox txt1 = new TextBox();
                TextBox txt2 = new TextBox();

                Label jmeno = new Label();
                Label club = new Label();
                Label gol = new Label();

                form1.Height = 220;
                form1.Width = 330;
                form1.FormBorderStyle = FormBorderStyle.FixedSingle;
                form1.MaximizeBox = false;
                form1.Text = "Přidání/úprava hráče";


                jmeno.Text = "Jméno:";
                jmeno.Location = new Point(9, 36);
                jmeno.AutoSize = true;

                club.Text = "Klub:";
                club.Location = new Point(9, 72);
                club.AutoSize = true;

                gol.Text = "Počet gólů:";
                gol.Location = new Point(9, 108);
                gol.AutoSize = true;

                txt1.SetBounds(100, 36, 200, 20);
                txt1.Text = records[listViewPlayers.FocusedItem.Index].Name;

                cb.SetBounds(100, 72, 200, 20);
                cb.SelectedItem = (FootballClub)records[listViewPlayers.FocusedItem.Index].Club;

                txt2.SetBounds(100, 108, 200, 20);
                txt2.Text = records[listViewPlayers.FocusedItem.Index].GoalCount + "";


                button2.SetBounds(9, 144, 75, 23);
                button1.SetBounds(225, 144, 75, 23);

                cb.Items.AddRange(new object[] {FootballClub.None,
                    FootballClub.Arsenal,
                    FootballClub.Barcelona,
                    FootballClub.Chelsea,
                    FootballClub.FCPorto,
                    FootballClub.RealMadrid
                }); ;
                cb.SelectedItem = FootballClub.None;

                button1.Text = "OK";
                button2.Text = "Storno";
                button1.DialogResult = DialogResult.OK;
                button2.DialogResult = DialogResult.Cancel;
                form1.AcceptButton = button1;
                form1.CancelButton = button2;
                form1.Controls.AddRange(new Control[]
                {
                    jmeno, txt1, club, cb, gol, txt2, button1, button2

                });
                form1.ResumeLayout(false);
                form1.PerformLayout();
                form1.ShowDialog();
                if (form1.DialogResult == DialogResult.OK)
                {
                    string msgEmpty = "Nebyla zadána hodnota";
                    string msgNotNum = "Zadaná hodnota není číslo";
                    string title = "chyba";

                    if (txt1.Text.Length == 0)
                    {
                        MessageBox.Show(msgEmpty, title);
                        return;
                    }
                    if (txt2.Text.Length == 0)
                    {
                        MessageBox.Show(msgEmpty, title);
                        return;
                    }
                    try
                    {
                        Int32.Parse(txt2.Text);
                    }
                    catch
                    {
                        MessageBox.Show(msgNotNum, title);
                        return;
                    }

                    records[listViewPlayers.FocusedItem.Index].Name = txt1.Text;
                    records[listViewPlayers.FocusedItem.Index].Club = (FootballClub)cb.SelectedItem;
                    records[listViewPlayers.FocusedItem.Index].GoalCount = Int32.Parse(txt2.Text);

                    listViewPlayers.SelectedItems[0].SubItems[0].Text = txt1.Text;
                    listViewPlayers.SelectedItems[0].SubItems[1].Text = FootballClubInfo.GetName((FootballClub)cb.SelectedItem);
                    listViewPlayers.SelectedItems[0].SubItems[2].Text = txt2.Text;

                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (listViewPlayers.FocusedItem == null)
            {
                MessageBox.Show("Není vybrán hráč", "chyba");
                return;
            }
            else
            {
                records.Delete(listViewPlayers.FocusedItem.Index);
                listViewPlayers.Items.RemoveAt(listViewPlayers.FocusedItem.Index);
                onPlayersCountChanged(new PlayersCountChangedEventArgs(records.Count + 1, records.Count));
            }
        }

        private void btnShowBest_Click(object sender, EventArgs e)
        {
            Form form1 = new Form();
            Button button1 = new Button();
            TextBox txt1 = new TextBox();
            ListBox listBox = new ListBox();
            Label pocetGolu = new Label();
            Label kluby = new Label();

            form1.Height = 300;
            form1.Width = 250;
            form1.FormBorderStyle = FormBorderStyle.FixedSingle;
            form1.MaximizeBox = false;
            form1.Text = "Nejlepší kluby";

            listBox.SetBounds(9, 100, 200, 100);

            pocetGolu.Text = "Počet gólů:";
            pocetGolu.Location = new Point(9, 36);
            pocetGolu.AutoSize = true;

            kluby.Text = "Nejlepší kluby:";
            kluby.Location = new Point(9, 72);
            kluby.AutoSize = true;


            txt1.SetBounds(100, 36, 110, 20);
            txt1.ReadOnly = true;

            button1.SetBounds(135, 220, 75, 23);
            button1.Text = "OK";
            button1.DialogResult = DialogResult.OK;
            form1.AcceptButton = button1;
            form1.Controls.AddRange(new Control[]
            {
                        pocetGolu, txt1, kluby, listBox ,button1

            });
            FootballClub[] clubls = new FootballClub[0];
            int goalCount = 0;
            records.FindBestClubs(out clubls, out goalCount);

            txt1.Text = goalCount + "";
            foreach (FootballClub item in clubls)
            {
                listBox.Items.Add(item);
            }

            form1.ResumeLayout(false);
            form1.PerformLayout();
            form1.ShowDialog();
            if (form1.DialogResult == DialogResult.OK)
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ".players |*.players*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PlayersFileSerializerDeserializer serializator = new PlayersFileSerializerDeserializer(records, dialog.FileName);
                serializator.Save();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int puvodniCount = records.Count;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ".players |*.players*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PlayersFileSerializerDeserializer deserializer = new PlayersFileSerializerDeserializer(records, dialog.FileName);
                deserializer.Load();

                listViewPlayers.Items.Clear();
                int i = 0;
                while(records[i] != null)
                {
                    string[] row = {records[i].Name, FootballClubInfo.GetName(records[i].Club), records[i].GoalCount.ToString() };
                    var ListViewItem = new ListViewItem(row);
                    listViewPlayers.Items.Add(ListViewItem);
                    i++;
                }
                onPlayersCountChanged(new PlayersCountChangedEventArgs(puvodniCount, records.Count));
            }
        }
    }
}
