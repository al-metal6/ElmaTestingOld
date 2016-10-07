using Calc;
using HistoryFiles;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class formCalculator : Form
    {
        private Helper Calc { get; set; }
        private History HistoryFiles { get; set; }
        private string ActiveOperation { get; set; }

        public formCalculator()
        {
            InitializeComponent();
            Calc = new Helper();
            HistoryFiles = new History();

            var methods = Calc.metods();
            var count = 0;
            this.panel1.SuspendLayout();
            foreach (var m in methods)
            {
                CreateRadioButton(m.Name, count++);
            }
            this.panel1.ResumeLayout();
            HistoryFiles.HistoryLoad(ref rtbHistory);
        }

        private void CreateRadioButton(string Name, int index)
        {
            var rbBtn = new RadioButton();
            this.panel1.Controls.Add(rbBtn);

            rbBtn.AutoSize = true;
            rbBtn.Location = new System.Drawing.Point(2, 1 + index * 18);
            rbBtn.Name = "rbBtn" + index.ToString();
            rbBtn.Size = new System.Drawing.Size(53, 17);
            rbBtn.TabIndex = 5;
            rbBtn.TabStop = true;
            rbBtn.Tag = Name;
            rbBtn.Text = Name;
            rbBtn.UseVisualStyleBackColor = true;
            rbBtn.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            double x = 0;
            double y = 0;

            if (!double.TryParse(txtX.Text, out x) || !double.TryParse(txtY.Text, out y) || ActiveOperation == null)
            {
                rtbHistory.Text += string.Format("При вводе данных была ошибка " + Environment.NewLine);
                return;
            }
            var calcType = Calc.GetType();
            var method = calcType.GetMethod(ActiveOperation);
            var result = method.Invoke(Calc, new object[] { x, y });

            lblResult.Text = result.ToString();
            rtbHistory.Text += string.Format("{0} {1} {2} = {3}{4}", x, ActiveOperation, y, result, Environment.NewLine);
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            ActiveOperation = rb.Tag.ToString();
        }

        private void formCalculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            HistoryFiles.HistorySave(ref rtbHistory);
        }
    }
}
