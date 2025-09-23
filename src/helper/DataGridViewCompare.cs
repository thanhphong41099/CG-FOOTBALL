using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace VLeague.src.helper
{
    internal class DataGridViewCompare
    {

        //Funtional use control one DataGridView for all players of team
        public static void Load_Players(string teamCode , DataGridView dataGrid)
        {
            try
            {
                DBConfig.doGetPlayersTeam(teamCode);
                dataGrid.Rows.Clear();
                foreach (DataRow dr in DBConfig.playersTeam.Rows)
                {
                    dataGrid.Rows.Add(dr["STT"], dr["Name"].ToString(), dr["Jersey #"].ToString(), dr["Jersey Name"].ToString(),dr["PLAY"].ToString(), 
                        dr["Position"].ToString(), dr["Card"].ToString(), dr["IMAGE"].ToString(), dr["PATH"].ToString(), dr["ID"].ToString());
                    //string text = dr["Play"].ToString();
                    //switch (text)
                    //{
                    //    case "1":
                    //        dataGrid.Rows.Add(dr["STT"], dr["Name"].ToString(), dr["Jersey #"].ToString(), dr["Jersey Name"].ToString(), dr["Play"].ToString(), dr["Pos"].ToString(), dr["Info"].ToString(), dr["Image1"].ToString(), dr["Image2"].ToString(), dr["ID"].ToString());
                    //        break;
                    //    case "2":
                    //        dataGrid.Rows.Add(dr["STT"], dr["Name"].ToString(), dr["SoAo"].ToString(), dr["TenAo"].ToString(), dr["Play"].ToString(), dr["Pos"].ToString(), dr["Info"].ToString(), dr["Image1"].ToString(), dr["Image2"].ToString(), dr["ID"].ToString());
                    //        break;
                    //    default:
                    //        dataGrid.Rows.Add(dr["STT"], dr["Name"].ToString(), dr["SoAo"].ToString(), dr["TenAo"].ToString(), "3", dr["Pos"].ToString(), dr["Info"].ToString(), dr["Image1"].ToString(), dr["Image2"].ToString(), dr["ID"].ToString());
                    //        break;
                    //}
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
                Handler.handlerError("Load_Players", ex);
            }
        }

        public static void makeColorRanking(DataGridView dgv) 
        {
            int j = dgv.RowCount;
            for (int i = 0; i < j; i++)
            {
                if (i % 2 == 0)
                {
                    //dgv.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
