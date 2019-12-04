namespace CookBook
{
    partial class MainForm
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
            this.cookBookDataSet = new CookBook.CookBookDataSet();
            this.lblRecipes = new System.Windows.Forms.Label();
            this.listRecipes = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.cookBookDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cookBookDataSet
            // 
            this.cookBookDataSet.DataSetName = "CookBookDataSet";
            this.cookBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblRecipes
            // 
            this.lblRecipes.AutoSize = true;
            this.lblRecipes.Location = new System.Drawing.Point(12, 9);
            this.lblRecipes.Name = "lblRecipes";
            this.lblRecipes.Size = new System.Drawing.Size(59, 17);
            this.lblRecipes.TabIndex = 0;
            this.lblRecipes.Text = "Recipes";
            // 
            // listRecipes
            // 
            this.listRecipes.FormattingEnabled = true;
            this.listRecipes.ItemHeight = 16;
            this.listRecipes.Location = new System.Drawing.Point(15, 30);
            this.listRecipes.Name = "listRecipes";
            this.listRecipes.Size = new System.Drawing.Size(120, 212);
            this.listRecipes.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 450);
            this.Controls.Add(this.listRecipes);
            this.Controls.Add(this.lblRecipes);
            this.Name = "MainForm";
            this.Text = "Cookbook";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cookBookDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CookBookDataSet cookBookDataSet;
        private System.Windows.Forms.Label lblRecipes;
        private System.Windows.Forms.ListBox listRecipes;
    }
}

