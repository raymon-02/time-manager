namespace TimeManager
{
    partial class ManagerForm
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
            this.sumButton = new System.Windows.Forms.Button();
            this.dataListView = new System.Windows.Forms.ListView();
            this.timeStartColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeEndColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addEventButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalListView = new System.Windows.Forms.ListView();
            this.categoryColumnTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalHourColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.signoutButton = new System.Windows.Forms.Button();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFromStandartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sumButton
            // 
            this.sumButton.Location = new System.Drawing.Point(332, 370);
            this.sumButton.Name = "sumButton";
            this.sumButton.Size = new System.Drawing.Size(140, 45);
            this.sumButton.TabIndex = 0;
            this.sumButton.Text = "Show total";
            this.sumButton.UseVisualStyleBackColor = true;
            this.sumButton.Click += new System.EventHandler(this.sumButton_Click);
            // 
            // dataListView
            // 
            this.dataListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeStartColumn,
            this.timeEndColumn,
            this.categoryColumn});
            this.dataListView.FullRowSelect = true;
            this.dataListView.Location = new System.Drawing.Point(12, 86);
            this.dataListView.Name = "dataListView";
            this.dataListView.Size = new System.Drawing.Size(314, 329);
            this.dataListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.dataListView.TabIndex = 1;
            this.dataListView.UseCompatibleStateImageBehavior = false;
            this.dataListView.View = System.Windows.Forms.View.Details;
            // 
            // timeStartColumn
            // 
            this.timeStartColumn.Text = "Time Start";
            // 
            // timeEndColumn
            // 
            this.timeEndColumn.Text = "Time End";
            // 
            // categoryColumn
            // 
            this.categoryColumn.Text = "Category";
            this.categoryColumn.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStrip,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(836, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStrip
            // 
            this.userToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.userToolStrip.Name = "userToolStrip";
            this.userToolStrip.Size = new System.Drawing.Size(59, 29);
            this.userToolStrip.Text = "User";
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryToolStripMenuItem,
            this.editCategoriesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFromStandartToolStripMenuItem,
            this.createNewToolStripMenuItem});
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.addCategoryToolStripMenuItem.Text = "Add category";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // editCategoriesToolStripMenuItem
            // 
            this.editCategoriesToolStripMenuItem.Name = "editCategoriesToolStripMenuItem";
            this.editCategoriesToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.editCategoriesToolStripMenuItem.Text = "Remove category...";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 54);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(314, 26);
            this.dateTimePicker.TabIndex = 4;
            this.dateTimePicker.CloseUp += new System.EventHandler(this.dateTimePicker_CloseUp);
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(332, 86);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(140, 45);
            this.addEventButton.TabIndex = 5;
            this.addEventButton.Text = "Add Event...";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(332, 137);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(140, 45);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Edit...";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(332, 188);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(140, 45);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(332, 239);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(140, 45);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalLabel.Location = new System.Drawing.Point(624, 54);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(200, 50);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Total for all time since\r\n";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // totalListView
            // 
            this.totalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.categoryColumnTotal,
            this.totalHourColumn});
            this.totalListView.Location = new System.Drawing.Point(629, 107);
            this.totalListView.Name = "totalListView";
            this.totalListView.Size = new System.Drawing.Size(195, 308);
            this.totalListView.TabIndex = 10;
            this.totalListView.UseCompatibleStateImageBehavior = false;
            this.totalListView.View = System.Windows.Forms.View.Details;
            // 
            // categoryColumnTotal
            // 
            this.categoryColumnTotal.Text = "Category";
            this.categoryColumnTotal.Width = 80;
            // 
            // totalHourColumn
            // 
            this.totalHourColumn.Text = "Hours";
            // 
            // signoutButton
            // 
            this.signoutButton.Location = new System.Drawing.Point(703, 506);
            this.signoutButton.Name = "signoutButton";
            this.signoutButton.Size = new System.Drawing.Size(121, 45);
            this.signoutButton.TabIndex = 11;
            this.signoutButton.Text = "Sign Out";
            this.signoutButton.UseVisualStyleBackColor = true;
            this.signoutButton.Click += new System.EventHandler(this.signoutButton_Click);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.createNewToolStripMenuItem.Text = "Create new...";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // addFromStandartToolStripMenuItem
            // 
            this.addFromStandartToolStripMenuItem.Name = "addFromStandartToolStripMenuItem";
            this.addFromStandartToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.addFromStandartToolStripMenuItem.Text = "Add from standart...";
            this.addFromStandartToolStripMenuItem.Click += new System.EventHandler(this.addFromStandartToolStripMenuItem_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 563);
            this.Controls.Add(this.signoutButton);
            this.Controls.Add(this.totalListView);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.dataListView);
            this.Controls.Add(this.sumButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sumButton;
        private System.Windows.Forms.ListView dataListView;
        private System.Windows.Forms.ColumnHeader timeStartColumn;
        private System.Windows.Forms.ColumnHeader timeEndColumn;
        private System.Windows.Forms.ColumnHeader categoryColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStrip;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.ListView totalListView;
        private System.Windows.Forms.ColumnHeader categoryColumnTotal;
        private System.Windows.Forms.ColumnHeader totalHourColumn;
        private System.Windows.Forms.Button signoutButton;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFromStandartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
    }
}