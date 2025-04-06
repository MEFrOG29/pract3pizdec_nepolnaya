using Word = Microsoft.Office.Interop.Word;
namespace pract3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Word.Application app = new();
            app.Visible = false;
            var doc = app.Documents.Add();
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Документ Word(*.docx)|*.docx|PDF(*.pdf)|*.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog.FileName) == ".docx")
                {
                    doc.SaveAs(saveFileDialog.FileName, Word.WdSaveFormat.wdFormatDocumentDefault);
                    app.Quit();
                    return;
                }                
                doc.SaveAs(saveFileDialog.FileName, Word.WdSaveFormat.wdFormatPDF);
                app.Quit();
            }
        }
    }
}
