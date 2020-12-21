namespace WebCon.BPS.HelloWorld.WebAPI
{
    partial class ComplaintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintForm));
            this.lblClientName = new System.Windows.Forms.Label();
            this.lblClientAddress = new System.Windows.Forms.Label();
            this.lblClientZipCode = new System.Windows.Forms.Label();
            this.lblClientCity = new System.Windows.Forms.Label();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.lblComplaintDescription = new System.Windows.Forms.Label();
            this.lblWithAttachment = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbClientName = new System.Windows.Forms.TextBox();
            this.tbClientAddress = new System.Windows.Forms.TextBox();
            this.tbClientZipCode = new System.Windows.Forms.TextBox();
            this.tbClientCity = new System.Windows.Forms.TextBox();
            this.tbComplaintDescription = new System.Windows.Forms.TextBox();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.cbWithAttachment = new System.Windows.Forms.CheckBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblClientName
            // 
            this.lblClientName.AutoSize = true;
            this.lblClientName.Location = new System.Drawing.Point(13, 16);
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Size = new System.Drawing.Size(68, 13);
            this.lblClientName.TabIndex = 0;
            this.lblClientName.Text = "Client name: ";
            // 
            // lblClientAddress
            // 
            this.lblClientAddress.AutoSize = true;
            this.lblClientAddress.Location = new System.Drawing.Point(13, 42);
            this.lblClientAddress.Name = "lblClientAddress";
            this.lblClientAddress.Size = new System.Drawing.Size(79, 13);
            this.lblClientAddress.TabIndex = 2;
            this.lblClientAddress.Text = "Client address: ";
            // 
            // lblClientZipCode
            // 
            this.lblClientZipCode.AutoSize = true;
            this.lblClientZipCode.Location = new System.Drawing.Point(13, 68);
            this.lblClientZipCode.Name = "lblClientZipCode";
            this.lblClientZipCode.Size = new System.Drawing.Size(82, 13);
            this.lblClientZipCode.TabIndex = 4;
            this.lblClientZipCode.Text = "Client zip code: ";
            // 
            // lblClientCity
            // 
            this.lblClientCity.AutoSize = true;
            this.lblClientCity.Location = new System.Drawing.Point(13, 94);
            this.lblClientCity.Name = "lblClientCity";
            this.lblClientCity.Size = new System.Drawing.Size(58, 13);
            this.lblClientCity.TabIndex = 6;
            this.lblClientCity.Text = "Client city: ";
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.AutoSize = true;
            this.lblPurchaseDate.Location = new System.Drawing.Point(13, 123);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(82, 13);
            this.lblPurchaseDate.TabIndex = 8;
            this.lblPurchaseDate.Text = "Purchase date: ";
            // 
            // lblComplaintDescription
            // 
            this.lblComplaintDescription.AutoSize = true;
            this.lblComplaintDescription.Location = new System.Drawing.Point(13, 146);
            this.lblComplaintDescription.Name = "lblComplaintDescription";
            this.lblComplaintDescription.Size = new System.Drawing.Size(113, 13);
            this.lblComplaintDescription.TabIndex = 10;
            this.lblComplaintDescription.Text = "Complaint description: ";
            // 
            // lblWithAttachment
            // 
            this.lblWithAttachment.AutoSize = true;
            this.lblWithAttachment.Location = new System.Drawing.Point(13, 172);
            this.lblWithAttachment.Name = "lblWithAttachment";
            this.lblWithAttachment.Size = new System.Drawing.Size(60, 13);
            this.lblWithAttachment.TabIndex = 12;
            this.lblWithAttachment.Text = "Attach file: ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(348, 193);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 14;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbClientName
            // 
            this.tbClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClientName.Location = new System.Drawing.Point(172, 12);
            this.tbClientName.Name = "tbClientName";
            this.tbClientName.Size = new System.Drawing.Size(251, 20);
            this.tbClientName.TabIndex = 1;
            // 
            // tbClientAddress
            // 
            this.tbClientAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClientAddress.Location = new System.Drawing.Point(172, 39);
            this.tbClientAddress.Name = "tbClientAddress";
            this.tbClientAddress.Size = new System.Drawing.Size(251, 20);
            this.tbClientAddress.TabIndex = 3;
            // 
            // tbClientZipCode
            // 
            this.tbClientZipCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClientZipCode.Location = new System.Drawing.Point(172, 65);
            this.tbClientZipCode.Name = "tbClientZipCode";
            this.tbClientZipCode.Size = new System.Drawing.Size(251, 20);
            this.tbClientZipCode.TabIndex = 5;
            // 
            // tbClientCity
            // 
            this.tbClientCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClientCity.Location = new System.Drawing.Point(172, 91);
            this.tbClientCity.Name = "tbClientCity";
            this.tbClientCity.Size = new System.Drawing.Size(251, 20);
            this.tbClientCity.TabIndex = 7;
            // 
            // tbComplaintDescription
            // 
            this.tbComplaintDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComplaintDescription.Location = new System.Drawing.Point(172, 143);
            this.tbComplaintDescription.Name = "tbComplaintDescription";
            this.tbComplaintDescription.Size = new System.Drawing.Size(251, 20);
            this.tbComplaintDescription.TabIndex = 11;
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.Location = new System.Drawing.Point(172, 117);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(151, 20);
            this.dtpPurchaseDate.TabIndex = 9;
            // 
            // cbWithAttachment
            // 
            this.cbWithAttachment.AutoSize = true;
            this.cbWithAttachment.Location = new System.Drawing.Point(172, 172);
            this.cbWithAttachment.Name = "cbWithAttachment";
            this.cbWithAttachment.Size = new System.Drawing.Size(15, 14);
            this.cbWithAttachment.TabIndex = 13;
            this.cbWithAttachment.UseVisualStyleBackColor = true;
            // 
            // tbOutput
            // 
            this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutput.Enabled = false;
            this.tbOutput.Location = new System.Drawing.Point(16, 252);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(407, 72);
            this.tbOutput.TabIndex = 16;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(13, 236);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 13);
            this.lblOutput.TabIndex = 15;
            this.lblOutput.Text = "Output";
            // 
            // ComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 336);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.cbWithAttachment);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.tbComplaintDescription);
            this.Controls.Add(this.tbClientCity);
            this.Controls.Add(this.tbClientZipCode);
            this.Controls.Add(this.tbClientAddress);
            this.Controls.Add(this.tbClientName);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblWithAttachment);
            this.Controls.Add(this.lblComplaintDescription);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.lblClientCity);
            this.Controls.Add(this.lblClientZipCode);
            this.Controls.Add(this.lblClientAddress);
            this.Controls.Add(this.lblClientName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComplaintForm";
            this.Text = "Complaint Form Stub";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClientName;
        private System.Windows.Forms.Label lblClientAddress;
        private System.Windows.Forms.Label lblClientZipCode;
        private System.Windows.Forms.Label lblClientCity;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label lblComplaintDescription;
        private System.Windows.Forms.Label lblWithAttachment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbClientName;
        private System.Windows.Forms.TextBox tbClientAddress;
        private System.Windows.Forms.TextBox tbClientZipCode;
        private System.Windows.Forms.TextBox tbClientCity;
        private System.Windows.Forms.TextBox tbComplaintDescription;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.CheckBox cbWithAttachment;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lblOutput;
    }
}

