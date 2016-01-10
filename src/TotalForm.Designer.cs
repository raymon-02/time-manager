namespace TimeManager
{
    partial class TotalForm
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
            this.totalListView = new System.Windows.Forms.ListView();
            this.categoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hourColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // totalListView
            // 
            this.totalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.categoryColumn,
            this.hourColumn});
            this.totalListView.Location = new System.Drawing.Point(28, 91);
            this.totalListView.Name = "totalListView";
            this.totalListView.Size = new System.Drawing.Size(289, 330);
            this.totalListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.totalListView.TabIndex = 0;
            this.totalListView.UseCompatibleStateImageBehavior = false;
            this.totalListView.View = System.Windows.Forms.View.Details;
            // 
            // categoryColumn
            // 
            this.categoryColumn.Text = "Category";
            this.categoryColumn.Width = 100;
            // 
            // hourColumn
            // 
            this.hourColumn.Text = "Hours";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalLabel.Location = new System.Drawing.Point(81, 9);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(146, 29);
            this.totalLabel.TabIndex = 1;
            this.totalLabel.Text = "Total for day\r\n";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(110, 434);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(117, 48);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // TotalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 494);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.totalListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TotalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total for day";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView totalListView;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.ColumnHeader categoryColumn;
        private System.Windows.Forms.ColumnHeader hourColumn;
        private System.Windows.Forms.Button okButton;
    }
}