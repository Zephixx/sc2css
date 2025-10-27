using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace sc2css;

public class InfoEditor : Form
{
	private bool entrySelected;

	private int selectIdx;

	private IContainer components;

	private ComboBox comboBox1;

	private NumericUpDown costumeCountBox;

	private Label costumeCountLabel;

	private Label label2;

	private NumericUpDown cssIndexBox;

	private Label cssIndexLabel;

    public InfoEditor()
    {
        InitializeComponent();

   
        costumeCountBox.Maximum = 9999;
        cssIndexBox.Maximum = 9999;

        comboBox1.SelectedIndex = 0;
    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		entrySelected = false;
		costumeCountBox.Value = Css.characterEntryCostumes[comboBox1.SelectedIndex];
		cssIndexBox.Value = Css.cssIdx[comboBox1.SelectedIndex];
		entrySelected = true;
	}

	private void numericUpDown1_ValueChanged(object sender, EventArgs e)
	{
		if (entrySelected)
		{
			Css.characterEntryCostumes[comboBox1.SelectedIndex] = (short)costumeCountBox.Value;
		}
	}

	private void InfoEditor_FormClosing(object sender, EventArgs e)
	{
	}

	private void cssIndexBox_ValueChanged(object sender, EventArgs e)
	{
		if (entrySelected)
		{
			Css.cssIdx[comboBox1.SelectedIndex] = (byte)cssIndexBox.Value;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.costumeCountBox = new System.Windows.Forms.NumericUpDown();
		this.costumeCountLabel = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.cssIndexBox = new System.Windows.Forms.NumericUpDown();
		this.cssIndexLabel = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.costumeCountBox).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cssIndexBox).BeginInit();
		base.SuspendLayout();
		this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[33]
		{
			"Dummy", "Mitsurugi", "SeungMina", "Taki", "Maxi", "Voldo", "Sophitia", "Dummy2", "Dummy3", "Dummy4",
			"Dummy5", "Ivy", "Kilik", "Xianghua", "Dummy6", "Yoshimitsu", "Dummy7", "Nightmare", "Astaroth", "Inferno",
			"Cervantes", "Raphael", "Talim", "Cassandra", "Charade", "Necrid", "YunSeong", "Link", "Heihachi", "Spawn",
			"LizardMan", "Assassin", "Berserker"
		});
		this.comboBox1.Location = new System.Drawing.Point(117, 13);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(121, 21);
		this.comboBox1.TabIndex = 0;
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
		this.costumeCountBox.Location = new System.Drawing.Point(117, 44);
		this.costumeCountBox.Maximum = new decimal(new int[4] { 8, 0, 0, 0 });
		this.costumeCountBox.Name = "costumeCountBox";
		this.costumeCountBox.Size = new System.Drawing.Size(53, 20);
		this.costumeCountBox.TabIndex = 1;
		this.costumeCountBox.ValueChanged += new System.EventHandler(numericUpDown1_ValueChanged);
		this.costumeCountLabel.AutoSize = true;
		this.costumeCountLabel.Location = new System.Drawing.Point(58, 46);
		this.costumeCountLabel.Name = "costumeCountLabel";
		this.costumeCountLabel.Size = new System.Drawing.Size(53, 13);
		this.costumeCountLabel.TabIndex = 2;
		this.costumeCountLabel.Text = "Costumes";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(58, 16);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(53, 13);
		this.label2.TabIndex = 3;
		this.label2.Text = "Character";
		this.cssIndexBox.Location = new System.Drawing.Point(117, 71);
		this.cssIndexBox.Maximum = new decimal(new int[4] { 29, 0, 0, 0 });
		this.cssIndexBox.Name = "cssIndexBox";
		this.cssIndexBox.Size = new System.Drawing.Size(53, 20);
		this.cssIndexBox.TabIndex = 4;
		this.cssIndexBox.ValueChanged += new System.EventHandler(cssIndexBox_ValueChanged);
		this.cssIndexLabel.AutoSize = true;
		this.cssIndexLabel.Location = new System.Drawing.Point(54, 73);
		this.cssIndexLabel.Name = "cssIndexLabel";
		this.cssIndexLabel.Size = new System.Drawing.Size(57, 13);
		this.cssIndexLabel.TabIndex = 5;
		this.cssIndexLabel.Text = "CSS Index";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(300, 103);
		base.Controls.Add(this.cssIndexLabel);
		base.Controls.Add(this.cssIndexBox);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.costumeCountLabel);
		base.Controls.Add(this.costumeCountBox);
		base.Controls.Add(this.comboBox1);
		base.Name = "InfoEditor";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Character Info";
		((System.ComponentModel.ISupportInitialize)this.costumeCountBox).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cssIndexBox).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
