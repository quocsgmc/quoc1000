using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using QLHTDT.FormChinh;

namespace QLHTDT.FormPhu.QLKienTruc
{
    class WWord
    {
        private Word.Application _app;
        Word.Document _doc;
        private object _pathFile;
        public WWord(string vPath, bool vCreateApp)
        {
            _pathFile = vPath;
            _app = new Word.Application();
            _app.Visible = vCreateApp;
            object ob = System.Reflection.Missing.Value;
            _doc = _app.Documents.Add(ref _pathFile, ref ob, ref ob, ref ob);

            
        }
        public void WriteFields(Dictionary<string, string> vValues)
        {
            foreach (Word.Field field in _doc.Fields)
            {
                string fieldName = field.Code.Text.Substring(11, field.Code.Text.IndexOf("\\") - 12).Trim();
                if (vValues.ContainsKey(fieldName))
                {
                    field.Select();
                    _app.Selection.TypeText(vValues[fieldName]);
                    
                }
            }
        }
        public void print(Dictionary<string, string> vValues)
        {
            foreach (Word.Field field in _doc.Fields)
            {
                string fieldName = field.Code.Text.Substring(11, field.Code.Text.IndexOf("\\") - 12).Trim();
                if (vValues.ContainsKey(fieldName))
                {
                    field.Select();
                    _app.Selection.TypeText(vValues[fieldName]);
                }
            }
            _doc.PrintOut();
        }
        public void WriteTable(DataTable vDataTable, int vIndexTable)
        {
            Word.Table tbl = _doc.Tables[vIndexTable];
            int lenrow = vDataTable.Rows.Count;
            int lencol = vDataTable.Columns.Count;
            for (int i = 0; i < lenrow; ++i)
            {
                object ob = System.Reflection.Missing.Value;
                tbl.Rows.Add(ref ob);
                for (int j = 0; j < lencol; ++j)
                {
                    tbl.Cell(i + 2, j + 1).Range.Text = vDataTable.Rows[i][j].ToString();
                }
            }
        }
        public void Addpicture(string imgPath)
        {
            Bitmap img = new Bitmap(imgPath);
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Image = img;


            Object myEndOfDoc = "\\endofdoc";
            Object oMissed = _doc.Bookmarks.get_Item(ref myEndOfDoc).Range;
            var range = _doc.Range();
            while (range.Find.Execute("6."))
            { oMissed = range; }
                

            //Word.Range start_range = _doc.Bookmarks.get_Item(ref myEndOfDoc).Range;

             //the position you want to insert
            Object oLinkToFile = false;  //default
            Object oSaveWithDocument = true;//default
            
            Word.InlineShape map = _doc.InlineShapes.AddPicture(imgPath, ref oLinkToFile, ref oSaveWithDocument, ref oMissed);
            map.Height = 190;
            map.Width = 268.48F;
            while (range.Find.Execute("6."))
            { oMissed = range; }
            

            Word.Range rng = range;
            rng.Text = Environment.NewLine+ "6.";
            //_doc.InlineShapes.AddHorizontalLineStandard( oMissed);


        }

    }            
}