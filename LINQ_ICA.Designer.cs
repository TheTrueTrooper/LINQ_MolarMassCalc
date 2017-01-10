namespace CMPE2800_LINQICA
{
    partial class LINQ_ICA
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
            this._dgv_elementList = new System.Windows.Forms.DataGridView();
            this._btn_sortName = new System.Windows.Forms.Button();
            this._btn_singleCharFilter = new System.Windows.Forms.Button();
            this._btn_atomicSort = new System.Windows.Forms.Button();
            this._lbl_chemFormula = new System.Windows.Forms.Label();
            this._tbx_chemFormula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._tbx_molarMass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgv_elementList)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgv_elementList
            // 
            this._dgv_elementList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgv_elementList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgv_elementList.Location = new System.Drawing.Point(8, 8);
            this._dgv_elementList.Margin = new System.Windows.Forms.Padding(2);
            this._dgv_elementList.Name = "_dgv_elementList";
            this._dgv_elementList.RowTemplate.Height = 28;
            this._dgv_elementList.Size = new System.Drawing.Size(494, 350);
            this._dgv_elementList.TabIndex = 0;
            // 
            // _btn_sortName
            // 
            this._btn_sortName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_sortName.Location = new System.Drawing.Point(506, 8);
            this._btn_sortName.Margin = new System.Windows.Forms.Padding(2);
            this._btn_sortName.Name = "_btn_sortName";
            this._btn_sortName.Size = new System.Drawing.Size(136, 26);
            this._btn_sortName.TabIndex = 1;
            this._btn_sortName.Text = "Sort by Name";
            this._btn_sortName.UseVisualStyleBackColor = true;
            this._btn_sortName.Click += new System.EventHandler(this._btn_sortName_Click);
            // 
            // _btn_singleCharFilter
            // 
            this._btn_singleCharFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_singleCharFilter.Location = new System.Drawing.Point(506, 38);
            this._btn_singleCharFilter.Margin = new System.Windows.Forms.Padding(2);
            this._btn_singleCharFilter.Name = "_btn_singleCharFilter";
            this._btn_singleCharFilter.Size = new System.Drawing.Size(136, 26);
            this._btn_singleCharFilter.TabIndex = 2;
            this._btn_singleCharFilter.Text = "Single Character Symbols";
            this._btn_singleCharFilter.UseVisualStyleBackColor = true;
            this._btn_singleCharFilter.Click += new System.EventHandler(this._btn_singleCharFilter_Click);
            // 
            // _btn_atomicSort
            // 
            this._btn_atomicSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btn_atomicSort.Location = new System.Drawing.Point(506, 68);
            this._btn_atomicSort.Margin = new System.Windows.Forms.Padding(2);
            this._btn_atomicSort.Name = "_btn_atomicSort";
            this._btn_atomicSort.Size = new System.Drawing.Size(136, 26);
            this._btn_atomicSort.TabIndex = 3;
            this._btn_atomicSort.Text = "Sort By Atomic #";
            this._btn_atomicSort.UseVisualStyleBackColor = true;
            this._btn_atomicSort.Click += new System.EventHandler(this._btn_atomicSort_Click);
            // 
            // _lbl_chemFormula
            // 
            this._lbl_chemFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lbl_chemFormula.AutoSize = true;
            this._lbl_chemFormula.Location = new System.Drawing.Point(8, 363);
            this._lbl_chemFormula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lbl_chemFormula.Name = "_lbl_chemFormula";
            this._lbl_chemFormula.Size = new System.Drawing.Size(90, 13);
            this._lbl_chemFormula.TabIndex = 4;
            this._lbl_chemFormula.Text = "Chemical Formula";
            // 
            // _tbx_chemFormula
            // 
            this._tbx_chemFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tbx_chemFormula.Location = new System.Drawing.Point(103, 361);
            this._tbx_chemFormula.Margin = new System.Windows.Forms.Padding(2);
            this._tbx_chemFormula.Name = "_tbx_chemFormula";
            this._tbx_chemFormula.Size = new System.Drawing.Size(320, 20);
            this._tbx_chemFormula.TabIndex = 5;
            this._tbx_chemFormula.TextChanged += new System.EventHandler(this._tbx_chemFormula_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 363);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Aprox. Molar Mass:";
            // 
            // _tbx_molarMass
            // 
            this._tbx_molarMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._tbx_molarMass.Location = new System.Drawing.Point(525, 361);
            this._tbx_molarMass.Margin = new System.Windows.Forms.Padding(2);
            this._tbx_molarMass.Name = "_tbx_molarMass";
            this._tbx_molarMass.ReadOnly = true;
            this._tbx_molarMass.Size = new System.Drawing.Size(119, 20);
            this._tbx_molarMass.TabIndex = 7;
            // 
            // LINQ_ICA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 382);
            this.Controls.Add(this._tbx_molarMass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbx_chemFormula);
            this.Controls.Add(this._lbl_chemFormula);
            this.Controls.Add(this._btn_atomicSort);
            this.Controls.Add(this._btn_singleCharFilter);
            this.Controls.Add(this._btn_sortName);
            this.Controls.Add(this._dgv_elementList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LINQ_ICA";
            this.Text = "LINQ ICA";
            ((System.ComponentModel.ISupportInitialize)(this._dgv_elementList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgv_elementList;
        private System.Windows.Forms.Button _btn_sortName;
        private System.Windows.Forms.Button _btn_singleCharFilter;
        private System.Windows.Forms.Button _btn_atomicSort;
        private System.Windows.Forms.Label _lbl_chemFormula;
        private System.Windows.Forms.TextBox _tbx_chemFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbx_molarMass;
    }
}

