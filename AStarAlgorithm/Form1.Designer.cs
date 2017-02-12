namespace AStarAlgorithm
{   
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMap = new System.Windows.Forms.DataGridView();
            this.btnCreateMap = new System.Windows.Forms.Button();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.btnSetFinish = new System.Windows.Forms.Button();
            this.btnClearMap = new System.Windows.Forms.Button();
            this.btnSetWall = new System.Windows.Forms.Button();
            this.btnPathFinding = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMap
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            this.dgvMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMap.ColumnHeadersVisible = false;
            this.dgvMap.Location = new System.Drawing.Point(12, 12);
            this.dgvMap.Name = "dgvMap";
            this.dgvMap.RowHeadersVisible = false;
            this.dgvMap.Size = new System.Drawing.Size(571, 467);
            this.dgvMap.TabIndex = 0;
            this.dgvMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvMap_MouseClick);
            // 
            // btnCreateMap
            // 
            this.btnCreateMap.Location = new System.Drawing.Point(154, 491);
            this.btnCreateMap.Name = "btnCreateMap";
            this.btnCreateMap.Size = new System.Drawing.Size(111, 23);
            this.btnCreateMap.TabIndex = 1;
            this.btnCreateMap.Text = "Create a Map";
            this.btnCreateMap.UseVisualStyleBackColor = true;
            this.btnCreateMap.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSetStart
            // 
            this.btnSetStart.Location = new System.Drawing.Point(754, 12);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(75, 23);
            this.btnSetStart.TabIndex = 2;
            this.btnSetStart.Text = "set START";
            this.btnSetStart.UseVisualStyleBackColor = true;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // btnSetFinish
            // 
            this.btnSetFinish.Location = new System.Drawing.Point(754, 42);
            this.btnSetFinish.Name = "btnSetFinish";
            this.btnSetFinish.Size = new System.Drawing.Size(75, 23);
            this.btnSetFinish.TabIndex = 3;
            this.btnSetFinish.Text = "set FINISH";
            this.btnSetFinish.UseVisualStyleBackColor = true;
            this.btnSetFinish.Click += new System.EventHandler(this.btnSetFinish_Click);
            // 
            // btnClearMap
            // 
            this.btnClearMap.Location = new System.Drawing.Point(339, 491);
            this.btnClearMap.Name = "btnClearMap";
            this.btnClearMap.Size = new System.Drawing.Size(75, 23);
            this.btnClearMap.TabIndex = 4;
            this.btnClearMap.Text = "Clear a Map";
            this.btnClearMap.UseVisualStyleBackColor = true;
            this.btnClearMap.Click += new System.EventHandler(this.btnClearMap_Click);
            // 
            // btnSetWall
            // 
            this.btnSetWall.Location = new System.Drawing.Point(754, 71);
            this.btnSetWall.Name = "btnSetWall";
            this.btnSetWall.Size = new System.Drawing.Size(75, 23);
            this.btnSetWall.TabIndex = 5;
            this.btnSetWall.Text = "Set a Wall";
            this.btnSetWall.UseVisualStyleBackColor = true;
            this.btnSetWall.Click += new System.EventHandler(this.btnSetWall_Click);
            // 
            // btnPathFinding
            // 
            this.btnPathFinding.Location = new System.Drawing.Point(610, 12);
            this.btnPathFinding.Name = "btnPathFinding";
            this.btnPathFinding.Size = new System.Drawing.Size(75, 23);
            this.btnPathFinding.TabIndex = 6;
            this.btnPathFinding.Text = "Find a Path";
            this.btnPathFinding.UseVisualStyleBackColor = true;
            this.btnPathFinding.Click += new System.EventHandler(this.btnPathFinding_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 518);
            this.Controls.Add(this.btnPathFinding);
            this.Controls.Add(this.btnSetWall);
            this.Controls.Add(this.btnClearMap);
            this.Controls.Add(this.btnSetFinish);
            this.Controls.Add(this.btnSetStart);
            this.Controls.Add(this.btnCreateMap);
            this.Controls.Add(this.dgvMap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMap;
        private System.Windows.Forms.Button btnCreateMap;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Button btnSetFinish;
        private System.Windows.Forms.Button btnClearMap;
        private System.Windows.Forms.Button btnSetWall;
        private System.Windows.Forms.Button btnPathFinding;
    }
}

