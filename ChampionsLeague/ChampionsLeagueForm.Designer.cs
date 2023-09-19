namespace ChampionsLeague
{
    partial class ChampionsLeagueForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.listViewPlayers = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.club = new System.Windows.Forms.ColumnHeader();
            this.goalCount = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnShowBest = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 15;
            this.listBoxEvents.Location = new System.Drawing.Point(12, 325);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(776, 109);
            this.listBoxEvents.TabIndex = 0;
            // 
            // listViewPlayers
            // 
            this.listViewPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.club,
            this.goalCount});
            this.listViewPlayers.FullRowSelect = true;
            this.listViewPlayers.GridLines = true;
            this.listViewPlayers.Location = new System.Drawing.Point(12, 40);
            this.listViewPlayers.Name = "listViewPlayers";
            this.listViewPlayers.Size = new System.Drawing.Size(616, 279);
            this.listViewPlayers.TabIndex = 1;
            this.listViewPlayers.UseCompatibleStateImageBehavior = false;
            this.listViewPlayers.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Tag = "";
            this.name.Text = "Name";
            this.name.Width = 350;
            // 
            // club
            // 
            this.club.Text = "Club";
            this.club.Width = 150;
            // 
            // goalCount
            // 
            this.goalCount.Text = "Goals";
            this.goalCount.Width = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(634, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(154, 35);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Přidat hráče";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(634, 81);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(154, 35);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Upravit hráče";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(634, 122);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(154, 35);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Smazat hráče";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnShowBest
            // 
            this.btnShowBest.Location = new System.Drawing.Point(634, 180);
            this.btnShowBest.Name = "btnShowBest";
            this.btnShowBest.Size = new System.Drawing.Size(154, 35);
            this.btnShowBest.TabIndex = 5;
            this.btnShowBest.Text = "Nejlepší kluby";
            this.btnShowBest.UseVisualStyleBackColor = true;
            this.btnShowBest.Click += new System.EventHandler(this.btnShowBest_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(634, 221);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Uložit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(634, 262);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(154, 35);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Načíst";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ChampionsLeagueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowBest);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listViewPlayers);
            this.Controls.Add(this.listBoxEvents);
            this.Name = "ChampionsLeagueForm";
            this.Text = "Liga Mistrů";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxEvents;
        private ListView listViewPlayers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnShowBest;
        private ColorDialog colorDialog1;
        private ColumnHeader name;
        private ColumnHeader club;
        private ColumnHeader goalCount;
        private Button btnSave;
        private Button btnLoad;
    }
}