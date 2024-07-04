namespace WinFormsApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        IPBox = new TextBox();
        label2 = new Label();
        label3 = new Label();
        endBox = new TextBox();
        startBox = new TextBox();
        scanBtn = new Button();
        resultBox = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(16, 18);
        label1.Name = "label1";
        label1.Size = new Size(43, 15);
        label1.TabIndex = 0;
        label1.Text = "IP地址";
        // 
        // IPBox
        // 
        IPBox.Location = new Point(16, 36);
        IPBox.Name = "IPBox";
        IPBox.Size = new Size(138, 23);
        IPBox.TabIndex = 1;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(161, 18);
        label2.Name = "label2";
        label2.Size = new Size(59, 15);
        label2.TabIndex = 2;
        label2.Text = "开始端口";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(235, 18);
        label3.Name = "label3";
        label3.Size = new Size(59, 15);
        label3.TabIndex = 3;
        label3.Text = "结束端口";
        // 
        // endBox
        // 
        endBox.Location = new Point(235, 36);
        endBox.Name = "endBox";
        endBox.Size = new Size(59, 23);
        endBox.TabIndex = 4;
        endBox.Text = "1000";
        // 
        // startBox
        // 
        startBox.Location = new Point(161, 36);
        startBox.Name = "startBox";
        startBox.Size = new Size(59, 23);
        startBox.TabIndex = 5;
        startBox.Text = "1";
        // 
        // scanBtn
        // 
        scanBtn.Location = new Point(308, 37);
        scanBtn.Name = "scanBtn";
        scanBtn.Size = new Size(75, 23);
        scanBtn.TabIndex = 6;
        scanBtn.Text = "扫描";
        scanBtn.UseVisualStyleBackColor = true;
        scanBtn.Click += scanBtn_Click;
        // 
        // resultBox
        // 
        resultBox.Location = new Point(16, 65);
        resultBox.Multiline = true;
        resultBox.Name = "resultBox";
        resultBox.ScrollBars = ScrollBars.Vertical;
        resultBox.Size = new Size(367, 138);
        resultBox.TabIndex = 7;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(395, 215);
        Controls.Add(resultBox);
        Controls.Add(scanBtn);
        Controls.Add(startBox);
        Controls.Add(endBox);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(IPBox);
        Controls.Add(label1);
        Name = "Form1";
        Text = "端口扫描工具";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox IPBox;
    private Label label2;
    private Label label3;
    private TextBox endBox;
    private TextBox startBox;
    private Button scanBtn;
    private TextBox resultBox;
}
