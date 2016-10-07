using System.IO;
using System.Text;
using System.Windows.Forms;
using HistoryFiles;

namespace HistoryFiles
{
    public class History
    {
        public void HistoryLoad(ref RichTextBox rtb1)
        {
            StreamReader text = new StreamReader("history.txt", Encoding.GetEncoding("windows-1251"));
            while (!text.EndOfStream)
            {
                string str = text.ReadLine();
                rtb1.AppendText(str + "\n");
            }
            text.Close();
        }

        public void HistorySave(ref RichTextBox rtb1)
        {
            StreamWriter writers = new StreamWriter("history.txt", false, Encoding.GetEncoding(1251));
            for (int i = 0; rtb1.Lines.Length > i; i++)
            {
                if (rtb1.Lines[i].ToString() != "")
                    writers.WriteLine(rtb1.Lines[i].ToString());
            }
            writers.Close();
        }
    }
}
