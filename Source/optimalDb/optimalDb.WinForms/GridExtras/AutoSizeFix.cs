using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace optimalDb.WinForms.GridExtras
{
    public static class AutoSizeFix
    {
        public static void AutoSizeColumns(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            }

            var spaltenBreiten = new List<int>();

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                spaltenBreiten.Add(column.Width);
            }

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            for (var i = 0; i < spaltenBreiten.Count; i++)
            {
                var spaltenbreite = spaltenBreiten[i];
                dataGridView.Columns[i].Width = spaltenbreite;
            }
        }
    }
}
