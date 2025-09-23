using System.Collections;
using System.Windows.Forms;

namespace VLeague.src.helper
{
    internal class ImageTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare;

        public ImageTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }

        public int Compare(object x, object y)
        {
            ListViewItem listviewX = (ListViewItem)x;
            int image1 = listviewX.ImageIndex;
            ListViewItem listviewY = (ListViewItem)y;
            int image2 = listviewY.ImageIndex;
            if (image1 < image2)
            {
                return -1;
            }
            if (image1 == image2)
            {
                return ObjectCompare.Compare(listviewX.Text, listviewY.Text);
            }
            return 1;
        }
    }
}
