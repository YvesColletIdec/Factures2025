using Entities;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;

namespace Factures2025.Helpers
{
    public class Impression
    {
        public static string CreateDocumentFromTemplateWithFormat(Facture f, string template)
        {
            Document document = new Document();
            document.LoadFromFile(template);
            document.Replace("client_prenom", f.NumClientNavigation.Prenom, true, true);
            document.Replace("client_nom", f.NumClientNavigation.Nom, true, true);
            document.Replace("client_adresse", f.NumClientNavigation.Adresse, true, true);
            document.Replace("client_npa", f.NumClientNavigation.CodePostal.ToString(), true, true);
            document.Replace("client_localite", "", true, true);
            document.Replace("facture_date", f.DateFacture.ToString("dd.MM.yyyy"), true, true);
            document.Replace("facture_num", f.NumFacture.ToString(), true, true);

            //la première section est celle ou l'on trouve un titre "Titre1"
            Section s = document.Sections[0];
            Table table = s.AddTable(true);
            String[] Header = { "N°", "Article", "Quantité", "Prix unitaire", "Total" };
            table.ResetCells(f.FactureArticles.Count + 1, Header.Length);

            //Header Row
            TableRow FRow = table.Rows[0];
            FRow.IsHeader = true;
            //Row Height
            //FRow.Height = 18;
            FRow.Cells[0].SetCellWidth(20, CellWidthType.Point);
            FRow.Cells[1].SetCellWidth(200, CellWidthType.Point);
            FRow.Cells[2].SetCellWidth(60, CellWidthType.Point);
            FRow.Cells[3].SetCellWidth(80, CellWidthType.Point);
            FRow.Cells[4].SetCellWidth(40, CellWidthType.Point);
            //Header Format
            FRow.RowFormat.BackColor = Color.LightBlue;
            for (int i = 0; i < Header.Length; i++)
            {
                //Cell Alignment
                Paragraph p = FRow.Cells[i].AddParagraph();
                FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                //Data Format
                TextRange TR = p.AppendText(Header[i]);
                TR.CharacterFormat.FontName = "Calibri";
                TR.CharacterFormat.FontSize = 14;
                TR.CharacterFormat.TextColor = Color.Teal;
                TR.CharacterFormat.Bold = true;
            }

            double grandTotal = 0;
            List<FactureArticle> listLignesFactures = new List<FactureArticle>(f.FactureArticles);
            //Data Row
            for (int r = 0; r < listLignesFactures.Count; r++)
            {
                FactureArticle lf = listLignesFactures[r];
                TableRow DataRow = table.Rows[r + 1];

                //Row Height
                DataRow.Height = 15;

                //C Represents Column. 5 -> nombre de colonnes
                for (int c = 0; c < 5; c++)
                {
                    //Cell Alignment
                    DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    //Fill Data in Rows
                    Paragraph p2 = DataRow.Cells[c].AddParagraph();
                    TextRange TR2 = null;
                    double total = lf.Prix * lf.Quantite;
                    switch (c)
                    {
                        case 0:
                            TR2 = p2.AppendText(lf.NumArticleNavigation.NumArticle.ToString());
                            DataRow.Cells[c].SetCellWidth(20, CellWidthType.Point);
                            break;
                        case 1:
                            TR2 = p2.AppendText(lf.NumArticleNavigation.Nom);
                            DataRow.Cells[c].SetCellWidth(200, CellWidthType.Point);
                            break;
                        case 2:
                            TR2 = p2.AppendText(lf.Quantite.ToString());
                            DataRow.Cells[c].SetCellWidth(60, CellWidthType.Point);
                            break;
                        case 3:
                            TR2 = p2.AppendText(lf.Prix.ToString());
                            DataRow.Cells[c].SetCellWidth(80, CellWidthType.Point);
                            break;
                        case 4:
                            TR2 = p2.AppendText(total.ToString());
                            DataRow.Cells[c].SetCellWidth(40, CellWidthType.Point);
                            grandTotal += total;
                            break;
                        default:
                            Console.WriteLine("Erreur dans le numéro de colonne");
                            break;
                    }

                    //Format Cells
                    p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
                    TR2.CharacterFormat.FontName = "Calibri";
                    TR2.CharacterFormat.FontSize = 12;
                    TR2.CharacterFormat.TextColor = Color.Brown;
                }

            }
            //TOTAL
            Paragraph pa = s.AddParagraph();
            pa.AppendText("\n");
            TextRange t = pa.AppendText($"TOTAL : {f.MontantTotalCHF}");
            pa.Format.HorizontalAlignment = HorizontalAlignment.Right;
            t.CharacterFormat.FontName = "Calibri";
            t.CharacterFormat.FontSize = 16;
            t.CharacterFormat.TextColor = Color.SteelBlue;
            string save = @"c:\adi\xxx.pdf";
            document.SaveToFile(save, FileFormat.PDF);
            return save;


            //ok pour .net framework
            //System.Diagnostics.Process.Start("xxx.pdf");

            //ok pour .net core
            //var pr = new Process();
            //pr.StartInfo = new ProcessStartInfo(@"xxx.pdf")
            //{
            //    UseShellExecute = true
            //};
            //pr.Start();

            //document.SaveToFile("SpireDocTestModified.docx", FileFormat.Docx2013);
        }

    }
}
