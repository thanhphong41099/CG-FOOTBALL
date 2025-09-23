
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLeague.src.helper
{
    internal class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private NumberCaseInsensitiveComparer ObjectCompare;

        private ImageTextComparer FirstObjectCompare;

        public int SortColumn
        {
            get
            {
                return ColumnToSort;
            }
            set
            {
                ColumnToSort = value;
            }
        }

        public SortOrder Order
        {
            get
            {
                return OrderOfSort;
            }
            set
            {
                OrderOfSort = value;
            }
        }

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.Ascending;
            ObjectCompare = new NumberCaseInsensitiveComparer();
            FirstObjectCompare = new ImageTextComparer();
        }

        public int Compare(object x, object y)
        {
            ListViewItem listviewX = (ListViewItem)x;
            ListViewItem listviewY = (ListViewItem)y;
            int compareResult = ((ColumnToSort != 0) ? ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text) : FirstObjectCompare.Compare(x, y));
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            if (OrderOfSort == SortOrder.Descending)
            {
                return -compareResult;
            }
            return 0;
        }
    }
}
