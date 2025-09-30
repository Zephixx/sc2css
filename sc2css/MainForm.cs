using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace sc2css;

public class MainForm : Form
{
	public bool slotSelected;

	private int selectedIdx;

	private bool columnsCentered;

	private List<Button> cssButtons = new List<Button>();

	private List<NumericUpDown> cosIcons = new List<NumericUpDown>();

	private List<NumericUpDown> bgIcons = new List<NumericUpDown>();

	private List<Css.Entry> cssEntries = new List<Css.Entry>();

	private Css.Entry cssCopy = new Css.Entry();

	private IContainer components;

	private ToolStrip toolStrip1;

	private ToolStripDropDownButton fileButton;

	private ToolStripMenuItem openMenu;

	private Button slotxx;

	private ToolStripMenuItem openGcnItem;

	private ToolStripMenuItem openXboxItem;

	private ToolStripMenuItem openPS2Item;

	private ToolStripMenuItem saveMenu;

	private ToolStripMenuItem exitToolStripMenuItem;

	private GroupBox groupBox1;

	private ComboBox characterBox;

	private NumericUpDown costumeNumBox;

	private OpenFileDialog dolOpenDialog;

	private TextBox textBox3;

	private TextBox textBox2;

	private NumericUpDown stageIdBox;

	private NumericUpDown numericUpDown10;

	private NumericUpDown cosIconBox4;

	private NumericUpDown cosIconBox5;

	private NumericUpDown cosIconBox6;

	private NumericUpDown cosIconBox7;

	private NumericUpDown cosIconBox3;

	private NumericUpDown cosIconBox2;

	private NumericUpDown cosIconBox1;

	private NumericUpDown cosIconBox0;

	private TextBox unkAddressBox;

	private NumericUpDown bgIconBox0;

	private NumericUpDown bgIconBox1;

	private NumericUpDown bgIconBox2;

	private NumericUpDown bgIconBox3;

	private NumericUpDown bgIconBox4;

	private NumericUpDown bgIconBox5;

	private NumericUpDown bgIconBox6;

	private NumericUpDown bgIconBox7;

	private Label label2;

	private Label label1;

	private Label label3;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem copyToolStripMenuItem;

	private ContextMenuStrip contextMenuStrip2;

	private ToolStripMenuItem pasteToolStripMenuItem;

	private ToolStripDropDownButton editButton;

	private ToolStripDropDownButton helpButton;

	private ToolStripMenuItem characterEntryToolStripMenuItem;

	private ToolStripMenuItem aboutToolStripMenuItem;

	private TextBox exeOffsetBox;

	private CheckBox centerCheckBox;

	private StatusStrip statusStrip1;

	private ToolStripStatusLabel statusLabel;

	private OpenFileDialog xbeOpenDialog;

	private OpenFileDialog ps2OpenDialog;

	private OpenFileDialog xexOpenDialog;

    private OpenFileDialog ps3OpenDialog;

    private ToolStripMenuItem openXEXItem;
    private ToolStripMenuItem openPS3Item;

    private ToolStripMenuItem weaponMasterCSSItem;

	public MainForm()
	{
		InitializeComponent();
		CreateCSSBoxes();
		CreateCostumeIconBoxes();
		CreateBGIconBoxes();
	}

	private void CreateCSSBoxes()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 30; i++)
		{
			Button button = new Button();
			button.Text = i.ToString();
			button.Name = "cssBox" + i;
			button.Size = new Size(64, 64);
			button.Location = new Point(40 + num * 64, 40 + num2 * 64);
			button.Click += slotxx_Click;
			button.ContextMenuStrip = contextMenuStrip1;
			button.MouseDown += b_MouseDown;
			button.Enabled = false;
			base.Controls.Add(button);
			cssButtons.Add(button);
			num++;
			if (num % 5 == 0)
			{
				num = 0;
				num2++;
			}
		}
	}

	private void CreateCostumeIconBoxes()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 8; i++)
		{
			NumericUpDown numericUpDown = new NumericUpDown();
			int num3 = cosIconBox0.Size.Width;
			int num4 = cosIconBox0.Size.Height;
			int num5 = cosIconBox0.Location.X + num * num3 + num * 5;
			int num6 = cosIconBox0.Location.Y + num2 * num4 + num2 * 4;
			numericUpDown.Name = "cIcon" + i;
			numericUpDown.Size = new Size(num3, num4);
			numericUpDown.Location = new Point(num5, num6);
			numericUpDown.Value = 0m;
			numericUpDown.Maximum = 255m;
			numericUpDown.Enabled = false;
			numericUpDown.ValueChanged += cosIconChanged;
			groupBox1.Controls.Add(numericUpDown);
			cosIcons.Add(numericUpDown);
			num++;
			if (num % 4 == 0)
			{
				num = 0;
				num2++;
			}
		}
	}

	private void CreateBGIconBoxes()
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < 8; i++)
		{
			NumericUpDown numericUpDown = new NumericUpDown();
			int num3 = bgIconBox0.Size.Width;
			int num4 = bgIconBox0.Size.Height;
			int num5 = bgIconBox0.Location.X + num * num3 + num * 5;
			int num6 = bgIconBox0.Location.Y + num2 * num4 + num2 * 4;
			numericUpDown.Name = "bgIcon" + i;
			numericUpDown.Size = new Size(num3, num4);
			numericUpDown.Location = new Point(num5, num6);
			numericUpDown.Value = 0m;
			numericUpDown.Maximum = 255m;
			numericUpDown.Enabled = false;
			numericUpDown.ValueChanged += bgIconChanged;
			groupBox1.Controls.Add(numericUpDown);
			bgIcons.Add(numericUpDown);
			num++;
			if (num % 4 == 0)
			{
				num = 0;
				num2++;
			}
		}
	}

	private void Items_Enable()
	{
		foreach (Button cssButton in cssButtons)
		{
			cssButton.Enabled = true;
		}
		foreach (NumericUpDown cosIcon in cosIcons)
		{
			cosIcon.Enabled = true;
		}
		foreach (NumericUpDown bgIcon in bgIcons)
		{
			bgIcon.Enabled = true;
		}
		exeOffsetBox.Enabled = true;
		unkAddressBox.Enabled = true;
		textBox2.Enabled = true;
		textBox3.Enabled = true;
		numericUpDown10.Enabled = true;
		stageIdBox.Enabled = true;
		characterBox.Enabled = true;
		costumeNumBox.Enabled = true;
		if (Css.console == Css.Console.GC || Css.console == Css.Console.XBOX)
		{
			centerCheckBox.Enabled = true;
		}
		else
		{
			centerCheckBox.Enabled = false;
		}
		label1.Enabled = true;
		label2.Enabled = true;
		label3.Enabled = true;
		saveMenu.Enabled = true;
		editButton.Enabled = true;
	}

	private void b_MouseDown(object sender, MouseEventArgs e)
	{
		Button obj = (Button)sender;
		obj.PerformClick();
		obj.Select();
		_ = e.Button;
		_ = e.Button;
	}

	private void slotxx_Click(object sender, EventArgs e)
	{
		Button item = sender as Button;
		int num = cssButtons.IndexOf(item);
		statusLabel.Text = $"Index {num}";
		selectedIdx = num;
		slotSelected = false;
		Css.Entry entry = cssEntries[num];
		int humanIdx = (int)cssEntries[num].HumanIdx;
		int selectedIndex = characterBox.Items.Count - 1;
		int selectedIndex2 = characterBox.Items.Count - 2;
		switch (humanIdx)
		{
		case -1:
			characterBox.SelectedIndex = selectedIndex;
			break;
		case -2:
			characterBox.SelectedIndex = selectedIndex2;
			break;
		default:
			characterBox.SelectedIndex = humanIdx;
			break;
		}
		costumeNumBox.Value = (int)entry.CostumeCount;
		unkAddressBox.Text = $"{entry.Unk1:X8}";
		for (int i = 0; i < 8; i++)
		{
			cosIcons[i].Value = (int)entry.CostumeIcon[i];
		}
		for (int j = 0; j < 8; j++)
		{
			bgIcons[j].Value = (int)entry.BgIcon[j];
		}
		textBox2.Text = $"{entry.Unk2:X8}";
		textBox3.Text = $"{entry.Unk3:X8}";
		numericUpDown10.Value = (int)entry.Unk4;
		stageIdBox.Value = (int)entry.Unk5;
		exeOffsetBox.Text = $"{num * 36 + Css.tableOffset:X8}";
		slotSelected = true;
	}

	private void cosIconChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			NumericUpDown numericUpDown = sender as NumericUpDown;
			int num = cosIcons.IndexOf(numericUpDown);
			cssEntries[selectedIdx].CostumeIcon[num] = (byte)numericUpDown.Value;
		}
	}

	private void bgIconChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			NumericUpDown numericUpDown = sender as NumericUpDown;
			int num = bgIcons.IndexOf(numericUpDown);
			cssEntries[selectedIdx].BgIcon[num] = (byte)numericUpDown.Value;
		}
	}

	private void CSSEntries_Read(FileStream fs, BinaryReader br)
	{
		fs.Seek(Css.tableOffset, SeekOrigin.Begin);
		for (int i = 0; i < 30; i++)
		{
			Css.Entry entry = new Css.Entry(br);
			cssEntries.Add(entry);
			cssButtons[i].Text = $"{entry.HumanIdx}";
		}
	}

	private void CharacterInfoEntries_Read(FileStream fs, BinaryReader br)
	{
		long num = Css.charInfoOffset;
		long num2 = 248L;
		long num3 = 138L;
		fs.Seek(num, SeekOrigin.Begin);
		for (int i = 0; i < 33; i++)
		{
			long num4 = num + i * num2;
			num4 += num3;
			fs.Seek(num4, SeekOrigin.Begin);
			short item = Helper.readInt16(br, Css.endian);
			Css.characterEntryCostumes.Add(item);
		}
		fs.Seek(Css.cssIdxOff, SeekOrigin.Begin);
		for (int j = 0; j < 33; j++)
		{
			byte item2 = br.ReadByte();
			Css.cssIdx.Add(item2);
		}
		fs.Seek(Css.wmTableOffset, SeekOrigin.Begin);
		for (int k = 0; k < 20; k++)
		{
			short item3 = Helper.readInt16(br, Css.endian);
			Css.wmEntries.Add(item3);
		}
	}

	private void ClearEntries()
	{
		cssEntries = new List<Css.Entry>();
		cssCopy = new Css.Entry();
		Css.characterEntryCostumes = new List<short>();
		Css.cssIdx = new List<byte>();
	}

	private void LoadExe()
	{
		using FileStream fileStream = new FileStream(Css.filePath, FileMode.Open);
		BinaryReader br = new BinaryReader(fileStream);
		if (Css.console == Css.Console.GC)
		{
			fileStream.Seek(28L, SeekOrigin.Begin);
			if (Helper.readInt32B(br) == 2158708)
			{
				Css.GetPracticeOffsets();
			}
		}
		CSSEntries_Read(fileStream, br);
		CharacterInfoEntries_Read(fileStream, br);
		if (Css.console == Css.Console.GC || Css.console == Css.Console.XBOX)
		{
			long offset = Css.xPosOff;
			fileStream.Seek(offset, SeekOrigin.Begin);
			if (Helper.readUInt32(br, Css.endian) == 1126236160)
			{
				centerCheckBox.Checked = true;
			}
			else
			{
				centerCheckBox.Checked = false;
			}
		}
	}

	private void OpenExecutable(Css.Console console)
	{
		ClearEntries();
		Css.EndianSet(console);
		Css.GetConsoleOffsets(console);
		Css.console = console;
		LoadExe();
		Items_Enable();
		cssButtons[0].Select();
		cssButtons[0].PerformClick();
	}

	private void dolGCN_Click(object sender, EventArgs e)
	{
		if (dolOpenDialog.ShowDialog() == DialogResult.OK)
		{
			Css.filePath = dolOpenDialog.FileName;
			OpenExecutable(Css.Console.GC);
		}
	}

	private void exitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			int num = characterBox.Items.Count - 1;
			int num2 = characterBox.Items.Count - 2;
			int selectedIndex = characterBox.SelectedIndex;
			Css.Human human = ((selectedIndex == num) ? Css.Human.Null : ((selectedIndex != num2) ? ((Css.Human)characterBox.SelectedIndex) : Css.Human.Random));
			cssEntries[selectedIdx].HumanIdx = human;
			cssButtons[selectedIdx].Text = $"{human}";
		}
	}

	private void costumeIcon_SetIndexChangedEvents()
	{
	}

	private void costumeIcon_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private Button buttonFromContext(object sender)
	{
		Button result = new Button();
		if (sender is ToolStripMenuItem { Owner: ContextMenuStrip { SourceControl: var sourceControl } } && sourceControl is Button)
		{
			result = (Button)sourceControl;
		}
		return result;
	}

	private int CSS_Idx_From_Button(object sender)
	{
		int result = 0;
		if (sender is ToolStripMenuItem { Owner: ContextMenuStrip { SourceControl: var sourceControl } } && sourceControl is Button)
		{
			Button item = (Button)sourceControl;
			result = cssButtons.IndexOf(item);
		}
		return result;
	}

	private void copyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		int num = 0;
		Button item = buttonFromContext(sender);
		num = cssButtons.IndexOf(item);
		cssCopy = new Css.Entry(cssEntries[num]);
	}

	private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
	{
		int num = 0;
		Button button = buttonFromContext(sender);
		num = cssButtons.IndexOf(button);
		cssEntries[num] = new Css.Entry(cssCopy);
		cssButtons[num].Text = $"{cssEntries[num].HumanIdx}";
		button.PerformClick();
		button.Select();
	}

	private void characterEntryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		InfoEditor infoEditor = new InfoEditor();
		infoEditor.Owner = this;
		infoEditor.Show();
	}

	private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new AboutForm().Show();
	}

	private void SaveExe()
	{
		using FileStream fileStream = new FileStream(Css.filePath, FileMode.Open);
		using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		fileStream.Seek(Css.tableOffset, SeekOrigin.Begin);
		for (int i = 0; i < 30; i++)
		{
			Helper.writeInt16(binaryWriter, (short)cssEntries[i].HumanIdx, Css.endian);
			Helper.writeUInt16(binaryWriter, cssEntries[i].CostumeCount, Css.endian);
			Helper.writeUInt32(binaryWriter, cssEntries[i].Unk1, Css.endian);
			binaryWriter.Write(cssEntries[i].CostumeIcon);
			binaryWriter.Write(cssEntries[i].BgIcon);
			Helper.writeUInt32(binaryWriter, cssEntries[i].Unk2, Css.endian);
			Helper.writeUInt32(binaryWriter, cssEntries[i].Unk3, Css.endian);
			Helper.writeUInt16(binaryWriter, cssEntries[i].Unk4, Css.endian);
			Helper.writeUInt16(binaryWriter, cssEntries[i].Unk5, Css.endian);
		}
		long num = Css.charInfoOffset;
		long num2 = 248L;
		long num3 = 138L;
		fileStream.Seek(num, SeekOrigin.Begin);
		for (int j = 0; j < 33; j++)
		{
			long num4 = num + j * num2;
			num4 += num3;
			fileStream.Seek(num4, SeekOrigin.Begin);
			Helper.writeInt16(binaryWriter, Css.characterEntryCostumes[j], Css.endian);
		}
		fileStream.Seek(Css.cssIdxOff, SeekOrigin.Begin);
		for (int k = 0; k < 33; k++)
		{
			binaryWriter.Write(Css.cssIdx[k]);
		}
		if (Css.console == Css.Console.GC || Css.console == Css.Console.XBOX)
		{
			long offset = Css.xPosOff;
			fileStream.Seek(offset, SeekOrigin.Begin);
			if (centerCheckBox.Checked)
			{
				Helper.writeUInt32(binaryWriter, 1126236160u, Css.endian);
			}
			else
			{
				Helper.writeUInt32(binaryWriter, 1124073472u, Css.endian);
			}
		}
		fileStream.Seek(Css.wmTableOffset, SeekOrigin.Begin);
		for (int l = 0; l < 20; l++)
		{
			Helper.writeInt16(binaryWriter, Css.wmEntries[l], Css.endian);
		}
	}

	private void saveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		SaveExe();
		MessageBox.Show("File saved!");
	}

	private void costumeNumBox_ValueChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			cssEntries[selectedIdx].CostumeCount = (ushort)costumeNumBox.Value;
		}
	}

	private void unkAddressBox_TextChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			cssEntries[selectedIdx].Unk1 = Convert.ToUInt32(unkAddressBox.Text, 16);
		}
	}

	private void textBox2_TextChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			cssEntries[selectedIdx].Unk2 = Convert.ToUInt32(textBox2.Text, 16);
		}
	}

	private void textBox3_TextChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			cssEntries[selectedIdx].Unk3 = Convert.ToUInt32(textBox3.Text, 16);
		}
	}

	private void numericUpDown10_ValueChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			cssEntries[selectedIdx].Unk4 = (ushort)numericUpDown10.Value;
		}
	}

	private void stageIdBox_ValueChanged(object sender, EventArgs e)
	{
		if (slotSelected)
		{
			cssEntries[selectedIdx].Unk5 = (ushort)stageIdBox.Value;
		}
	}

	private void centerCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		columnsCentered = centerCheckBox.Checked;
	}

	private void openXboxItem_Click(object sender, EventArgs e)
	{
		if (xbeOpenDialog.ShowDialog() == DialogResult.OK)
		{
			Css.filePath = xbeOpenDialog.FileName;
			OpenExecutable(Css.Console.XBOX);
		}
	}

	private void openPS2Item_Click(object sender, EventArgs e)
	{
		if (ps2OpenDialog.ShowDialog() == DialogResult.OK)
		{
			Css.filePath = ps2OpenDialog.FileName;
			OpenExecutable(Css.Console.PS2);
		}
	}

	private void openXEXItem_Click(object sender, EventArgs e)
	{
		if (xexOpenDialog.ShowDialog() == DialogResult.OK)
		{
			Css.filePath = xexOpenDialog.FileName;
			OpenExecutable(Css.Console.X360);
		}
	}

    private void openPS3Item_Click(object sender, EventArgs e)
    {
        if (ps3OpenDialog.ShowDialog() == DialogResult.OK)
        {
            Css.filePath = ps3OpenDialog.FileName;
            OpenExecutable(Css.Console.PS3);
        }
    }


    private void weaponMasterCSSItem_Click(object sender, EventArgs e)
	{
		new WeaponMaster().Show();
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
		this.components = new System.ComponentModel.Container();
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.fileButton = new System.Windows.Forms.ToolStripDropDownButton();
		this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
		this.openGcnItem = new System.Windows.Forms.ToolStripMenuItem();
		this.openXboxItem = new System.Windows.Forms.ToolStripMenuItem();
		this.openPS2Item = new System.Windows.Forms.ToolStripMenuItem();
		this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
		this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.editButton = new System.Windows.Forms.ToolStripDropDownButton();
		this.characterEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.weaponMasterCSSItem = new System.Windows.Forms.ToolStripMenuItem();
		this.helpButton = new System.Windows.Forms.ToolStripDropDownButton();
		this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.slotxx = new System.Windows.Forms.Button();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.centerCheckBox = new System.Windows.Forms.CheckBox();
		this.exeOffsetBox = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.bgIconBox0 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox1 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox2 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox3 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox4 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox5 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox6 = new System.Windows.Forms.NumericUpDown();
		this.bgIconBox7 = new System.Windows.Forms.NumericUpDown();
		this.textBox3 = new System.Windows.Forms.TextBox();
		this.textBox2 = new System.Windows.Forms.TextBox();
		this.stageIdBox = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox4 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox5 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox6 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox7 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox3 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox2 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox1 = new System.Windows.Forms.NumericUpDown();
		this.cosIconBox0 = new System.Windows.Forms.NumericUpDown();
		this.unkAddressBox = new System.Windows.Forms.TextBox();
		this.characterBox = new System.Windows.Forms.ComboBox();
		this.costumeNumBox = new System.Windows.Forms.NumericUpDown();
		this.dolOpenDialog = new System.Windows.Forms.OpenFileDialog();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
		this.xbeOpenDialog = new System.Windows.Forms.OpenFileDialog();
		this.ps2OpenDialog = new System.Windows.Forms.OpenFileDialog();
		this.xexOpenDialog = new System.Windows.Forms.OpenFileDialog();
		this.openXEXItem = new System.Windows.Forms.ToolStripMenuItem();
        this.openPS3Item = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStrip1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox0).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.stageIdBox).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox0).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.costumeNumBox).BeginInit();
		this.contextMenuStrip1.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		base.SuspendLayout();
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.fileButton, this.editButton, this.helpButton });
		this.toolStrip1.Location = new System.Drawing.Point(0, 0);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(616, 25);
		this.toolStrip1.TabIndex = 1;
		this.toolStrip1.Text = "toolStrip1";
		this.fileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.openMenu, this.saveMenu, this.exitToolStripMenuItem });
		this.fileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.fileButton.Name = "fileButton";
		this.fileButton.ShowDropDownArrow = false;
		this.fileButton.Size = new System.Drawing.Size(29, 22);
		this.fileButton.Text = "File";
        this.openMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.openGcnItem, this.openXboxItem, this.openPS2Item, this.openXEXItem, this.openPS3Item });
        this.openMenu.Name = "openMenu";
		this.openMenu.Size = new System.Drawing.Size(180, 22);
		this.openMenu.Text = "Open";
		this.openGcnItem.Name = "openGcnItem";
		this.openGcnItem.Size = new System.Drawing.Size(180, 22);
		this.openGcnItem.Text = "main.dol";
		this.openGcnItem.Click += new System.EventHandler(dolGCN_Click);
		this.openXboxItem.Name = "openXboxItem";
		this.openXboxItem.Size = new System.Drawing.Size(180, 22);
		this.openXboxItem.Text = "Default.xbe";
		this.openXboxItem.Click += new System.EventHandler(openXboxItem_Click);
		this.openPS2Item.Name = "openPS2Item";
		this.openPS2Item.Size = new System.Drawing.Size(180, 22);
		this.openPS2Item.Text = "SLUS_206.43";
		this.openPS2Item.Click += new System.EventHandler(openPS2Item_Click);
		this.saveMenu.Enabled = false;
		this.saveMenu.Name = "saveMenu";
		this.saveMenu.Size = new System.Drawing.Size(180, 22);
		this.saveMenu.Text = "Save";
		this.saveMenu.Click += new System.EventHandler(saveToolStripMenuItem_Click);
		this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
		this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.exitToolStripMenuItem.Text = "Exit";
		this.exitToolStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
		this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.editButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.characterEntryToolStripMenuItem, this.weaponMasterCSSItem });
		this.editButton.Enabled = false;
		this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.editButton.Name = "editButton";
		this.editButton.ShowDropDownArrow = false;
		this.editButton.Size = new System.Drawing.Size(31, 22);
		this.editButton.Text = "Edit";
		this.characterEntryToolStripMenuItem.Name = "characterEntryToolStripMenuItem";
		this.characterEntryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
		this.characterEntryToolStripMenuItem.Text = "Character Info";
		this.characterEntryToolStripMenuItem.Click += new System.EventHandler(characterEntryToolStripMenuItem_Click);
		this.weaponMasterCSSItem.Name = "weaponMasterCSSItem";
		this.weaponMasterCSSItem.Size = new System.Drawing.Size(180, 22);
		this.weaponMasterCSSItem.Text = "Weapon Master CSS";
		this.weaponMasterCSSItem.Click += new System.EventHandler(weaponMasterCSSItem_Click);
		this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.helpButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.aboutToolStripMenuItem });
		this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.helpButton.Name = "helpButton";
		this.helpButton.ShowDropDownArrow = false;
		this.helpButton.Size = new System.Drawing.Size(36, 22);
		this.helpButton.Text = "Help";
		this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
		this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
		this.aboutToolStripMenuItem.Text = "About";
		this.aboutToolStripMenuItem.Click += new System.EventHandler(aboutToolStripMenuItem_Click);
		this.slotxx.Enabled = false;
		this.slotxx.Location = new System.Drawing.Point(40, 40);
		this.slotxx.Name = "slotxx";
		this.slotxx.Size = new System.Drawing.Size(64, 64);
		this.slotxx.TabIndex = 0;
		this.slotxx.Text = "MITSURUGI";
		this.slotxx.UseVisualStyleBackColor = true;
		this.slotxx.Visible = false;
		this.slotxx.Click += new System.EventHandler(slotxx_Click);
		this.groupBox1.Controls.Add(this.centerCheckBox);
		this.groupBox1.Controls.Add(this.exeOffsetBox);
		this.groupBox1.Controls.Add(this.label3);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Controls.Add(this.bgIconBox0);
		this.groupBox1.Controls.Add(this.bgIconBox1);
		this.groupBox1.Controls.Add(this.bgIconBox2);
		this.groupBox1.Controls.Add(this.bgIconBox3);
		this.groupBox1.Controls.Add(this.bgIconBox4);
		this.groupBox1.Controls.Add(this.bgIconBox5);
		this.groupBox1.Controls.Add(this.bgIconBox6);
		this.groupBox1.Controls.Add(this.bgIconBox7);
		this.groupBox1.Controls.Add(this.textBox3);
		this.groupBox1.Controls.Add(this.textBox2);
		this.groupBox1.Controls.Add(this.stageIdBox);
		this.groupBox1.Controls.Add(this.numericUpDown10);
		this.groupBox1.Controls.Add(this.cosIconBox4);
		this.groupBox1.Controls.Add(this.cosIconBox5);
		this.groupBox1.Controls.Add(this.cosIconBox6);
		this.groupBox1.Controls.Add(this.cosIconBox7);
		this.groupBox1.Controls.Add(this.cosIconBox3);
		this.groupBox1.Controls.Add(this.cosIconBox2);
		this.groupBox1.Controls.Add(this.cosIconBox1);
		this.groupBox1.Controls.Add(this.cosIconBox0);
		this.groupBox1.Controls.Add(this.unkAddressBox);
		this.groupBox1.Controls.Add(this.characterBox);
		this.groupBox1.Controls.Add(this.costumeNumBox);
		this.groupBox1.Location = new System.Drawing.Point(380, 28);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(221, 403);
		this.groupBox1.TabIndex = 2;
		this.groupBox1.TabStop = false;
		this.centerCheckBox.AutoSize = true;
		this.centerCheckBox.Enabled = false;
		this.centerCheckBox.Location = new System.Drawing.Point(35, 371);
		this.centerCheckBox.Name = "centerCheckBox";
		this.centerCheckBox.Size = new System.Drawing.Size(121, 17);
		this.centerCheckBox.TabIndex = 27;
		this.centerCheckBox.Text = "5 Columns Centered";
		this.centerCheckBox.UseVisualStyleBackColor = true;
		this.centerCheckBox.CheckedChanged += new System.EventHandler(centerCheckBox_CheckedChanged);
		this.exeOffsetBox.Enabled = false;
		this.exeOffsetBox.Location = new System.Drawing.Point(133, 56);
		this.exeOffsetBox.Name = "exeOffsetBox";
		this.exeOffsetBox.Size = new System.Drawing.Size(64, 20);
		this.exeOffsetBox.TabIndex = 26;
		this.label3.AutoSize = true;
		this.label3.Enabled = false;
		this.label3.Location = new System.Drawing.Point(31, 55);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(53, 13);
		this.label3.TabIndex = 25;
		this.label3.Text = "Costumes";
		this.label2.AutoSize = true;
		this.label2.Enabled = false;
		this.label2.Location = new System.Drawing.Point(32, 206);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(94, 13);
		this.label2.TabIndex = 24;
		this.label2.Text = "Background Icons";
		this.label1.AutoSize = true;
		this.label1.Enabled = false;
		this.label1.Location = new System.Drawing.Point(29, 121);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(77, 13);
		this.label1.TabIndex = 23;
		this.label1.Text = "Costume Icons";
		this.bgIconBox0.Enabled = false;
		this.bgIconBox0.Location = new System.Drawing.Point(31, 225);
		this.bgIconBox0.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox0.Name = "bgIconBox0";
		this.bgIconBox0.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox0.TabIndex = 22;
		this.bgIconBox0.Visible = false;
		this.bgIconBox1.Enabled = false;
		this.bgIconBox1.Location = new System.Drawing.Point(74, 225);
		this.bgIconBox1.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox1.Name = "bgIconBox1";
		this.bgIconBox1.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox1.TabIndex = 21;
		this.bgIconBox1.Visible = false;
		this.bgIconBox2.Enabled = false;
		this.bgIconBox2.Location = new System.Drawing.Point(117, 225);
		this.bgIconBox2.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox2.Name = "bgIconBox2";
		this.bgIconBox2.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox2.TabIndex = 20;
		this.bgIconBox2.Visible = false;
		this.bgIconBox3.Enabled = false;
		this.bgIconBox3.Location = new System.Drawing.Point(160, 225);
		this.bgIconBox3.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox3.Name = "bgIconBox3";
		this.bgIconBox3.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox3.TabIndex = 19;
		this.bgIconBox3.Visible = false;
		this.bgIconBox4.Enabled = false;
		this.bgIconBox4.Location = new System.Drawing.Point(31, 251);
		this.bgIconBox4.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox4.Name = "bgIconBox4";
		this.bgIconBox4.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox4.TabIndex = 18;
		this.bgIconBox4.Visible = false;
		this.bgIconBox5.Enabled = false;
		this.bgIconBox5.Location = new System.Drawing.Point(74, 251);
		this.bgIconBox5.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox5.Name = "bgIconBox5";
		this.bgIconBox5.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox5.TabIndex = 17;
		this.bgIconBox5.Visible = false;
		this.bgIconBox6.Enabled = false;
		this.bgIconBox6.Location = new System.Drawing.Point(117, 251);
		this.bgIconBox6.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox6.Name = "bgIconBox6";
		this.bgIconBox6.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox6.TabIndex = 16;
		this.bgIconBox6.Visible = false;
		this.bgIconBox7.Enabled = false;
		this.bgIconBox7.Location = new System.Drawing.Point(160, 251);
		this.bgIconBox7.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.bgIconBox7.Name = "bgIconBox7";
		this.bgIconBox7.Size = new System.Drawing.Size(37, 20);
		this.bgIconBox7.TabIndex = 15;
		this.bgIconBox7.Visible = false;
		this.textBox3.Enabled = false;
		this.textBox3.Location = new System.Drawing.Point(118, 295);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new System.Drawing.Size(64, 20);
		this.textBox3.TabIndex = 14;
		this.textBox3.TextChanged += new System.EventHandler(textBox3_TextChanged);
		this.textBox2.Enabled = false;
		this.textBox2.Location = new System.Drawing.Point(32, 295);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new System.Drawing.Size(64, 20);
		this.textBox2.TabIndex = 13;
		this.textBox2.TextChanged += new System.EventHandler(textBox2_TextChanged);
		this.stageIdBox.Enabled = false;
		this.stageIdBox.Location = new System.Drawing.Point(127, 336);
		this.stageIdBox.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		this.stageIdBox.Name = "stageIdBox";
		this.stageIdBox.Size = new System.Drawing.Size(55, 20);
		this.stageIdBox.TabIndex = 12;
		this.stageIdBox.ValueChanged += new System.EventHandler(stageIdBox_ValueChanged);
		this.numericUpDown10.Enabled = false;
		this.numericUpDown10.Location = new System.Drawing.Point(35, 336);
		this.numericUpDown10.Maximum = new decimal(new int[4] { 9999, 0, 0, 0 });
		this.numericUpDown10.Name = "numericUpDown10";
		this.numericUpDown10.Size = new System.Drawing.Size(58, 20);
		this.numericUpDown10.TabIndex = 11;
		this.numericUpDown10.ValueChanged += new System.EventHandler(numericUpDown10_ValueChanged);
		this.cosIconBox4.Enabled = false;
		this.cosIconBox4.Location = new System.Drawing.Point(31, 163);
		this.cosIconBox4.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox4.Name = "cosIconBox4";
		this.cosIconBox4.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox4.TabIndex = 10;
		this.cosIconBox4.Visible = false;
		this.cosIconBox5.Enabled = false;
		this.cosIconBox5.Location = new System.Drawing.Point(74, 163);
		this.cosIconBox5.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox5.Name = "cosIconBox5";
		this.cosIconBox5.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox5.TabIndex = 9;
		this.cosIconBox5.Visible = false;
		this.cosIconBox6.Enabled = false;
		this.cosIconBox6.Location = new System.Drawing.Point(117, 163);
		this.cosIconBox6.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox6.Name = "cosIconBox6";
		this.cosIconBox6.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox6.TabIndex = 8;
		this.cosIconBox6.Visible = false;
		this.cosIconBox7.Enabled = false;
		this.cosIconBox7.Location = new System.Drawing.Point(159, 163);
		this.cosIconBox7.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox7.Name = "cosIconBox7";
		this.cosIconBox7.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox7.TabIndex = 7;
		this.cosIconBox7.Visible = false;
		this.cosIconBox3.Enabled = false;
		this.cosIconBox3.Location = new System.Drawing.Point(160, 137);
		this.cosIconBox3.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox3.Name = "cosIconBox3";
		this.cosIconBox3.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox3.TabIndex = 6;
		this.cosIconBox3.Visible = false;
		this.cosIconBox2.Enabled = false;
		this.cosIconBox2.Location = new System.Drawing.Point(117, 137);
		this.cosIconBox2.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox2.Name = "cosIconBox2";
		this.cosIconBox2.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox2.TabIndex = 5;
		this.cosIconBox2.Visible = false;
		this.cosIconBox1.Enabled = false;
		this.cosIconBox1.Location = new System.Drawing.Point(74, 137);
		this.cosIconBox1.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox1.Name = "cosIconBox1";
		this.cosIconBox1.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox1.TabIndex = 4;
		this.cosIconBox1.Visible = false;
		this.cosIconBox0.Enabled = false;
		this.cosIconBox0.Location = new System.Drawing.Point(31, 137);
		this.cosIconBox0.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
		this.cosIconBox0.Name = "cosIconBox0";
		this.cosIconBox0.Size = new System.Drawing.Size(37, 20);
		this.cosIconBox0.TabIndex = 3;
		this.cosIconBox0.Visible = false;
		this.unkAddressBox.Enabled = false;
		this.unkAddressBox.Location = new System.Drawing.Point(31, 89);
		this.unkAddressBox.Name = "unkAddressBox";
		this.unkAddressBox.Size = new System.Drawing.Size(58, 20);
		this.unkAddressBox.TabIndex = 2;
		this.unkAddressBox.TextChanged += new System.EventHandler(unkAddressBox_TextChanged);
		this.characterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.characterBox.Enabled = false;
		this.characterBox.FormattingEnabled = true;
		this.characterBox.Items.AddRange(new object[35]
		{
			"Dummy", "Mitsurugi", "SeungMina", "Taki", "Maxi", "Voldo", "Sophitia", "Dummy2", "Dummy3", "Dummy4",
			"Dummy5", "Ivy", "Kilik", "Xianghua", "Dummy6", "Yoshimitsu", "Dummy7", "Nightmare", "Astaroth", "Inferno",
			"Cervantes", "Raphael", "Talim", "Cassandra", "Charade", "Necrid", "YunSeong", "Link", "Heihachi", "Spawn",
			"LizardMan", "Assassin", "Berserker", "Random", "Null"
		});
		this.characterBox.Location = new System.Drawing.Point(32, 19);
		this.characterBox.Name = "characterBox";
		this.characterBox.Size = new System.Drawing.Size(121, 21);
		this.characterBox.TabIndex = 1;
		this.characterBox.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
		this.costumeNumBox.Enabled = false;
		this.costumeNumBox.Location = new System.Drawing.Point(97, 53);
		this.costumeNumBox.Maximum = new decimal(new int[4] { 8, 0, 0, 0 });
		this.costumeNumBox.Name = "costumeNumBox";
		this.costumeNumBox.Size = new System.Drawing.Size(29, 20);
		this.costumeNumBox.TabIndex = 0;
		this.costumeNumBox.ValueChanged += new System.EventHandler(costumeNumBox_ValueChanged);
		this.dolOpenDialog.Filter = "DOL files|*.dol|All files|*.*";
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.copyToolStripMenuItem, this.pasteToolStripMenuItem });
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(103, 48);
		this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
		this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
		this.copyToolStripMenuItem.Text = "Copy";
		this.copyToolStripMenuItem.Click += new System.EventHandler(copyToolStripMenuItem_Click);
		this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
		this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
		this.pasteToolStripMenuItem.Text = "Paste";
		this.pasteToolStripMenuItem.Click += new System.EventHandler(pasteToolStripMenuItem_Click);
		this.contextMenuStrip2.Name = "contextMenuStrip2";
		this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.statusLabel });
		this.statusStrip1.Location = new System.Drawing.Point(0, 459);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(616, 22);
		this.statusStrip1.TabIndex = 3;
		this.statusStrip1.Text = "statusStrip1";
		this.statusLabel.Name = "statusLabel";
		this.statusLabel.Size = new System.Drawing.Size(64, 17);
		this.statusLabel.Text = "Load a file!";
		this.xbeOpenDialog.Filter = "XBE files|*.xbe|All files|*.*";
		this.ps2OpenDialog.Filter = "PS2 ELF files|*.*";
		this.xexOpenDialog.Filter = "Unencrypted XEX file|*.xex|All files|*.*";
        this.ps3OpenDialog = new System.Windows.Forms.OpenFileDialog();
        this.ps3OpenDialog.Filter = "PS3 ELF files|EBOOT.elf|All files|*.*";
        this.openXEXItem.Name = "openXEXItem";
		this.openXEXItem.Size = new System.Drawing.Size(180, 22);
		this.openXEXItem.Text = "Default.xex";
		this.openXEXItem.Click += new System.EventHandler(openXEXItem_Click);
        this.openPS3Item.Name = "openPS3Item";
        this.openPS3Item.Size = new System.Drawing.Size(180, 22);
        this.openPS3Item.Text = "EBOOT.elf";
        this.openPS3Item.Click += new System.EventHandler(openPS3Item_Click);
        base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(616, 481);
		base.Controls.Add(this.statusStrip1);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.slotxx);
		base.Controls.Add(this.toolStrip1);
		base.Name = "MainForm";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "SC2 CSS Editor";
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox0).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bgIconBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.stageIdBox).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cosIconBox0).EndInit();
		((System.ComponentModel.ISupportInitialize)this.costumeNumBox).EndInit();
		this.contextMenuStrip1.ResumeLayout(false);
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}

