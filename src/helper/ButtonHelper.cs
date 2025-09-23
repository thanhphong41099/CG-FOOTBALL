using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLeague.src.helper
{
    public static class ButtonHelper
    {
        // Phương thức InitializeButtons để dùng chung cho tất cả form
        public static void InitializeButtons(Form form)
        {
            foreach (var btn in GetAllButtons(form))
            {
                btn.Tag = 0;  // Bắt đầu với trạng thái 0
            }
        }
        public static void ClearTagButton(Button[] buttons)
        {
            foreach (var btn in buttons)
            {
                btn.Tag = 0;
                btn.Image = Properties.Resources.playicon481;  // Đặt ảnh mặc định cho mỗi Button
            }
        }
        public static void ClearTagButtonEx(Button[] buttons, Button excludeButton)
        {
            foreach (var btn in buttons)
            {
                // Nếu nút không phải là nút đang được nhấn thì reset
                if (btn != excludeButton)
                {
                    btn.Tag = 0;
                    btn.Image = Properties.Resources.playicon481;  // Đặt ảnh mặc định cho mỗi Button
                }
            }
        }

        // Phương thức GetAllButtons để lấy tất cả Button trong form
        public static IEnumerable<Button> GetAllButtons(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button)
                    yield return (Button)c;
                else if (c.HasChildren)
                {
                    foreach (var btn in GetAllButtons(c))
                    {
                        yield return btn;
                    }
                }
            }
        }

        // Phương thức UpdateButtonState để cập nhật ảnh nút
        public static void UpdateButtonState(Button btn, int x)
        {
            int currentState = (int)btn.Tag;
            currentState = (currentState + 1) % (3 - x); // 3 là số ảnh (playicon481, continue11, continue21)
            btn.Tag = currentState;

            // Chọn ảnh dựa trên trạng thái
            switch (currentState)
            {
                case 0:
                    btn.Image = Properties.Resources.playicon481;
                    break;
                case 1:
                    btn.Image = Properties.Resources.continue11;
                    break;
                case 2:
                    btn.Image = Properties.Resources.continue21;
                    break;
            }
        }
    }

}
