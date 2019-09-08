// Decompiled with JetBrains decompiler
// Type: TseClient.UCInstruments
// Assembly: TseClient, Version=2.0.16.0, Culture=neutral, PublicKeyToken=null
// MVID: 55DBD486-C597-460B-B54A-EAFCAFB4B891
// Assembly location: D:\Program Files\TseClient 2.0\TseClient.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TseClient.Properties;

namespace TseClient {
	public class UCInstruments : UserControl {
		private IContainer components;
		private GroupBox groupBox2;
		protected Button btnRemoveAll;
		protected Button btnSelectAll;
		protected Label label31;
		protected DataGridView dgvUnSelected;
		protected Label label30;
		protected DataGridView dgvSelected;
		private TextBox txtSearchSelected;
		private Label label1;
		private TextBox txtSearchUnSelected;
		private Label label2;
		protected Button btnRemove;
		protected Button btnSelect;

		protected override void Dispose(bool disposing) {
			if (disposing && this.components != null)
				this.components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent() {
			this.groupBox2 = new GroupBox();
			this.btnRemove = new Button();
			this.btnSelect = new Button();
			this.txtSearchUnSelected = new TextBox();
			this.label2 = new Label();
			this.txtSearchSelected = new TextBox();
			this.label1 = new Label();
			this.btnRemoveAll = new Button();
			this.btnSelectAll = new Button();
			this.label31 = new Label();
			this.dgvUnSelected = new DataGridView();
			this.label30 = new Label();
			this.dgvSelected = new DataGridView();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.dgvUnSelected).BeginInit();
			((ISupportInitialize)this.dgvSelected).BeginInit();
			this.SuspendLayout();
			this.groupBox2.BackColor = SystemColors.Control;
			this.groupBox2.Controls.Add((Control)this.btnRemove);
			this.groupBox2.Controls.Add((Control)this.btnSelect);
			this.groupBox2.Controls.Add((Control)this.txtSearchUnSelected);
			this.groupBox2.Controls.Add((Control)this.label2);
			this.groupBox2.Controls.Add((Control)this.txtSearchSelected);
			this.groupBox2.Controls.Add((Control)this.label1);
			this.groupBox2.Controls.Add((Control)this.btnRemoveAll);
			this.groupBox2.Controls.Add((Control)this.btnSelectAll);
			this.groupBox2.Controls.Add((Control)this.label31);
			this.groupBox2.Controls.Add((Control)this.dgvUnSelected);
			this.groupBox2.Controls.Add((Control)this.label30);
			this.groupBox2.Controls.Add((Control)this.dgvSelected);
			this.groupBox2.Location = new Point(1, -2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(775, 324);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "انتخاب نمادها";
			this.btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.btnRemove.Location = new Point(320, 193);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new Size(129, 23);
			this.btnRemove.TabIndex = 16;
			this.btnRemove.Text = "حذف >";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new EventHandler(this.btnRemove_Click);
			this.btnSelect.Location = new Point(320, 164);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new Size(129, 23);
			this.btnSelect.TabIndex = 15;
			this.btnSelect.Text = "< انتخاب";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new EventHandler(this.btnSelect_Click);
			this.txtSearchUnSelected.Location = new Point(6, 284);
			this.txtSearchUnSelected.Name = "txtSearchUnSelected";
			this.txtSearchUnSelected.Size = new Size(253, 21);
			this.txtSearchUnSelected.TabIndex = 14;
			this.txtSearchUnSelected.KeyUp += new KeyEventHandler(this.txtSearchUnSelected_KeyUp);
			this.label2.AutoSize = true;
			this.label2.Location = new Point(265, 287);
			this.label2.Name = "label2";
			this.label2.Size = new Size(49, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "جستجو :";
			this.txtSearchSelected.Location = new Point(455, 286);
			this.txtSearchSelected.Name = "txtSearchSelected";
			this.txtSearchSelected.Size = new Size(253, 21);
			this.txtSearchSelected.TabIndex = 12;
			this.txtSearchSelected.KeyUp += new KeyEventHandler(this.txtSearchSelected_KeyUp);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(714, 289);
			this.label1.Name = "label1";
			this.label1.Size = new Size(49, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "جستجو :";
			this.btnRemoveAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			this.btnRemoveAll.Location = new Point(320, 251);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new Size(129, 23);
			this.btnRemoveAll.TabIndex = 10;
			this.btnRemoveAll.Text = "حذف همه >>";
			this.btnRemoveAll.UseVisualStyleBackColor = true;
			this.btnRemoveAll.Click += new EventHandler(this.btnRemoveAll_Click);
			this.btnSelectAll.Location = new Point(320, 222);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new Size(129, 23);
			this.btnSelectAll.TabIndex = 9;
			this.btnSelectAll.Text = "<< انتخاب همه";
			this.btnSelectAll.UseVisualStyleBackColor = true;
			this.btnSelectAll.Click += new EventHandler(this.btnSelectAll_Click);
			this.label31.AutoSize = true;
			this.label31.Location = new Point(99, 17);
			this.label31.Name = "label31";
			this.label31.Size = new Size(220, 13);
			this.label31.TabIndex = 6;
			this.label31.Text = "سایر نمادها ( برای انتخاب نماد دبل کلیک کنید )";
			this.dgvUnSelected.ColumnHeadersVisible = false;
			this.dgvUnSelected.Location = new Point(6, 33);
			this.dgvUnSelected.Name = "dgvUnSelected";
			this.dgvUnSelected.RowHeadersVisible = false;
			this.dgvUnSelected.Size = new Size(308, 245);
			this.dgvUnSelected.TabIndex = 5;
			this.label30.AutoSize = true;
			this.label30.Location = new Point(507, 17);
			this.label30.Name = "label30";
			this.label30.Size = new Size(256, 13);
			this.label30.TabIndex = 4;
			this.label30.Text = "نمادهای انتخاب شده ( برای حذف نماد دبل کلیک کنید )";
			this.dgvSelected.ColumnHeadersVisible = false;
			this.dgvSelected.Location = new Point(455, 33);
			this.dgvSelected.Name = "dgvSelected";
			this.dgvSelected.RowHeadersVisible = false;
			this.dgvSelected.Size = new Size(308, 245);
			this.dgvSelected.TabIndex = 3;
			this.AutoScaleDimensions = new SizeF(6f, 13f);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Control;
			this.Controls.Add((Control)this.groupBox2);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
			this.Name = nameof(UCInstruments);
			this.RightToLeft = RightToLeft.Yes;
			this.Size = new Size(784, 324);
			this.Load += new EventHandler(this.UCInstruments_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize)this.dgvUnSelected).EndInit();
			((ISupportInitialize)this.dgvSelected).EndInit();
			this.ResumeLayout(false);
		}

		public UCInstruments() {
			this.InitializeComponent();
		}

		private void UCInstruments_Load(object sender, EventArgs e) {
			this.dgvSelected.DoubleClick += new EventHandler(this.dgvSelected_DoubleClick);
			this.dgvUnSelected.DoubleClick += new EventHandler(this.dgvUnSelected_DoubleClick);
			this.FillControls();
		}

		private void dgvSelected_DoubleClick(object sender, EventArgs e) {
			int scrollingRowIndex = this.dgvSelected.FirstDisplayedScrollingRowIndex;
			string str = this.dgvSelected.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
			StaticData.SelectedInstruments.Remove(str);
			FileService.WriteSelectedInstruments();
			this.ReFillInstrumentsGrids();
			try {
				if (this.dgvSelected.Rows.Count < scrollingRowIndex || this.dgvSelected.Rows.Count == 0)
					return;
				this.dgvSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex;
			} catch {
			}
		}

		private void dgvUnSelected_DoubleClick(object sender, EventArgs e) {
			int scrollingRowIndex = this.dgvUnSelected.FirstDisplayedScrollingRowIndex;
			string str = this.dgvUnSelected.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
			StaticData.SelectedInstruments.Add(str);
			FileService.WriteSelectedInstruments();
			this.ReFillInstrumentsGrids();
			try {
				if (this.dgvUnSelected.Rows.Count < scrollingRowIndex || this.dgvUnSelected.Rows.Count == 0)
					return;
				this.dgvUnSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex;
			} catch {
			}
		}

		protected void FillControls() {
			// ISSUE: object of a compiler-generated type is created
			// ISSUE: variable of a compiler-generated type
			Settings settings = new Settings();
			this.dgvSelected.Columns.Add("InsCode", "InsCode");
			this.dgvSelected.Columns[0].Visible = false;
			this.dgvSelected.Columns.Add("Instrument", "");
			this.dgvSelected.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dgvSelected.AllowUserToAddRows = false;
			this.dgvSelected.ReadOnly = true;
			this.dgvUnSelected.Columns.Add("InsCode", "InsCode");
			this.dgvUnSelected.Columns[0].Visible = false;
			this.dgvUnSelected.Columns.Add("Instrument", "");
			this.dgvUnSelected.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			this.dgvUnSelected.AllowUserToAddRows = false;
			this.dgvUnSelected.ReadOnly = true;
			this.ReFillInstrumentsGrids();
		}

		protected void ReFillInstrumentsGrids() {
			StaticData.Instruments = FileService.Instruments();
			StaticData.SelectedInstruments = FileService.SelectedInstruments();
			this.dgvSelected.Rows.Clear();
			this.dgvUnSelected.Rows.Clear();
			string str1 = this.txtSearchSelected.Text.Replace(Convert.ToChar(1705), Convert.ToChar(1603)).Replace(Convert.ToChar(1740), Convert.ToChar(1610));
			string str2 = this.txtSearchUnSelected.Text.Replace(Convert.ToChar(1705), Convert.ToChar(1603)).Replace(Convert.ToChar(1740), Convert.ToChar(1610));
			StaticData.Instruments.Sort((Comparison<InstrumentInfo>)((s1, s2) => s1.Symbol.CompareTo(s2.Symbol)));
			foreach (InstrumentInfo instrument in StaticData.Instruments) {
				if (StaticData.SelectedInstruments.Contains(instrument.InsCode.ToString())) {
					if (string.IsNullOrEmpty(str1))
						this.dgvSelected.Rows.Add((object)instrument.InsCode, (object)(instrument.Symbol + " ( " + instrument.Name + " ) "));
					else if (instrument.Symbol.Contains(str1) || instrument.Name.Contains(str1))
						this.dgvSelected.Rows.Add((object)instrument.InsCode, (object)(instrument.Symbol + " ( " + instrument.Name + " ) "));
				} else if (string.IsNullOrEmpty(str2))
					this.dgvUnSelected.Rows.Add((object)instrument.InsCode, (object)(instrument.Symbol + " ( " + instrument.Name + " ) "));
				else if (instrument.Symbol.Contains(str2) || instrument.Name.Contains(str2))
					this.dgvUnSelected.Rows.Add((object)instrument.InsCode, (object)(instrument.Symbol + " ( " + instrument.Name + " ) "));
			}
		}

		private void btnSelectAll_Click(object sender, EventArgs e) {
			StaticData.SelectedInstruments.Clear();
			foreach (InstrumentInfo instrument in StaticData.Instruments)
				StaticData.SelectedInstruments.Add(instrument.InsCode.ToString());
			FileService.WriteSelectedInstruments();
			this.ReFillInstrumentsGrids();
		}

		private void btnRemoveAll_Click(object sender, EventArgs e) {
			StaticData.SelectedInstruments.Clear();
			FileService.WriteSelectedInstruments();
			this.ReFillInstrumentsGrids();
		}

		private void txtSearchSelected_KeyUp(object sender, KeyEventArgs e) {
			int scrollingRowIndex1 = this.dgvSelected.FirstDisplayedScrollingRowIndex;
			int scrollingRowIndex2 = this.dgvUnSelected.FirstDisplayedScrollingRowIndex;
			this.ReFillInstrumentsGrids();
			try {
				if (this.dgvSelected.Rows.Count >= scrollingRowIndex1) {
					if (this.dgvSelected.Rows.Count != 0)
						this.dgvSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex1;
				}
			} catch {
			}
			try {
				if (this.dgvUnSelected.Rows.Count < scrollingRowIndex2 || this.dgvUnSelected.Rows.Count == 0)
					return;
				this.dgvUnSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex2;
			} catch {
			}
		}

		private void txtSearchUnSelected_KeyUp(object sender, KeyEventArgs e) {
			int scrollingRowIndex1 = this.dgvSelected.FirstDisplayedScrollingRowIndex;
			int scrollingRowIndex2 = this.dgvUnSelected.FirstDisplayedScrollingRowIndex;
			this.ReFillInstrumentsGrids();
			try {
				if (this.dgvSelected.Rows.Count >= scrollingRowIndex1) {
					if (this.dgvSelected.Rows.Count != 0)
						this.dgvSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex1;
				}
			} catch {
			}
			try {
				if (this.dgvUnSelected.Rows.Count < scrollingRowIndex2 || this.dgvUnSelected.Rows.Count == 0)
					return;
				this.dgvUnSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex2;
			} catch {
			}
		}

		private void btnSelect_Click(object sender, EventArgs e) {
			int scrollingRowIndex = this.dgvUnSelected.FirstDisplayedScrollingRowIndex;
			foreach (DataGridViewCell selectedCell in (BaseCollection)this.dgvUnSelected.SelectedCells) {
				string str = selectedCell.OwningRow.Cells[0].Value.ToString();
				StaticData.SelectedInstruments.Add(str);
				FileService.WriteSelectedInstruments();
			}
			this.ReFillInstrumentsGrids();
			try {
				if (this.dgvUnSelected.Rows.Count < scrollingRowIndex || this.dgvUnSelected.Rows.Count == 0)
					return;
				this.dgvUnSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex;
			} catch {
			}
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			int scrollingRowIndex = this.dgvSelected.FirstDisplayedScrollingRowIndex;
			foreach (DataGridViewCell selectedCell in (BaseCollection)this.dgvSelected.SelectedCells) {
				string str = selectedCell.OwningRow.Cells[0].Value.ToString();
				StaticData.SelectedInstruments.Remove(str);
				FileService.WriteSelectedInstruments();
			}
			this.ReFillInstrumentsGrids();
			try {
				if (this.dgvSelected.Rows.Count < scrollingRowIndex || this.dgvSelected.Rows.Count == 0)
					return;
				this.dgvSelected.FirstDisplayedScrollingRowIndex = scrollingRowIndex;
			} catch {
			}
		}
	}
}
