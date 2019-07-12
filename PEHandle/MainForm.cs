using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PEHandle
{
    /// <summary>
    /// 此项目开始于7月5日
    /// </summary>
    public partial class MainForm : Form
    {
        private PEFile nowFEFile;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listViewMain.Columns.Add( new ColumnHeader() { Text = "名称" ,Width = 100 } );
            listViewMain.Columns.Add(new ColumnHeader() { Text = "值", Width = 100 });
            listViewMain.Columns.Add(new ColumnHeader() { Text = "解释", Width = 300 });
        }


        private void ToolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ValidateNames = true; // 验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true; //验证路径的有效性
            ofd.CheckPathExists = true;//验证路径的有效性
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PEParser parser = new PEParser(ofd.FileName);

                nowFEFile = parser.GetPEFile();

                RefreshForm();

                ShowImageDosHeader();
            }

        }

        #region 控件操作
        private void ShowDataInListView(object obj)
        {
            listViewMain.Items.Clear();
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                //注释
                string desc = "";
                string format = "";
                int color = 0;
                if (prop.GetCustomAttributes(true).Length != 0)
                {
                    desc = ((PEHandle.DescriptionAttribute)(prop.GetCustomAttributes(true)[0])).desc;
                    format = ((PEHandle.DescriptionAttribute)(prop.GetCustomAttributes(true)[0])).format;
                    color = ((PEHandle.DescriptionAttribute)(prop.GetCustomAttributes(true)[0])).RGBA;
                }

                //值
                string val = ((Element)prop.GetValue(obj, null)).Value;
                //string val = ConvertToHexStr(prop.GetValue(obj, null), format);

                ListViewItem item = new ListViewItem(new string[] { prop.Name, val, desc });
                item.Tag = prop;
                if (color != 0)
                    item.ForeColor = Color.FromArgb(color);

                listViewMain.Items.Add(item);
            }
        }

        private void ShowImageDosHeader()
        {
            ShowDataInListView(nowFEFile.image_dos_header);
            listViewMain.Tag = nowFEFile.image_dos_header;
        }

        private void ShowImageNtHeader()
        {
            listViewMain.Items.Clear();
            PropertyInfo[] properties = nowFEFile.image_dos_header.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                //注释
                string desc = "";
                string format = "";
                int color = 0;
                if (prop.GetCustomAttributes(true).Length != 0)
                {
                    desc = ((PEHandle.DescriptionAttribute)(prop.GetCustomAttributes(true)[0])).desc;
                    format = ((PEHandle.DescriptionAttribute)(prop.GetCustomAttributes(true)[0])).format;
                    color = ((PEHandle.DescriptionAttribute)(prop.GetCustomAttributes(true)[0])).RGBA;
                }

                //值
                string val = ConvertToHexStr(prop.GetValue(nowFEFile.image_dos_header, null), format);

                ListViewItem item = new ListViewItem(new string[] { prop.Name, val, desc });
                if (color != 0)
                    item.ForeColor = Color.FromArgb(color);

                listViewMain.Items.Add(item);
            }
        }

        private void RefreshForm()
        {
            treeViewMain.CollapseAll();
            treeViewMain.SelectedNode = treeViewMain.Nodes[0];
            treeViewMain.Focus();
        }

        #endregion

        private string ConvertToHexStr(object val,string format)
        {
            string type = val.GetType().ToString();
            switch (type)
            {
                case "System.UInt16[]":
                    string tempStr = "";
                    UInt16[] temp = (UInt16[])val;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        tempStr += temp[i].ToString(format);
                    }
                    return tempStr;
                case "PEHandle.IMAGE_FILE_HEADER":
                    return "IMAGE_FILE_HEADER";
                case "PEHandle.IMAGE_OPTIONAL_HEADER":
                    return "IMAGE_OPTIONAL_HEADER";
                    
            }
            return Convert.ToUInt64(val).ToString(format);
        }

        private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //获取点击的节点
            TreeNode node = treeViewMain.SelectedNode;
            if (nowFEFile == null)
                return;
            switch (node.Name)
            {
                case "dosHeader":
                    ShowDataInListView(nowFEFile.image_dos_header);
                    break;
                case "ntHeader":
                    ShowDataInListView(nowFEFile.image_nt_header);
                    break;
                case "fileHeader":
                    ShowDataInListView(nowFEFile.image_nt_header.image_file_header);
                    break;
                case "optionalHeader":
                    ShowDataInListView(nowFEFile.image_nt_header.image_optional_header);
                    break;
                case "dataDirectories":
                    ShowDataInListView(nowFEFile.image_data_directory);
                    break;
                default:
                    break;
            }
        }

        private void listViewMain_DoubleClick(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;

            ListViewItem item = ((ListView)sender).SelectedItems[0];
            PropertyInfo info = item.Tag as PropertyInfo;
            Element ele = info.GetValue(listView.Tag, null) as Element;

            ValChangeForm valForm = new ValChangeForm(ele.Value);
            if (valForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ele.Value = valForm.Value;
                info.SetValue(listView.Tag, ele, null);
                item.SubItems[1].Text = ele.Value;
                //修改peBytes
                for (int i = 0; i < ele.Length; i++)
                {
                    int strIndex = ele.Length - (i*2);
                    nowFEFile.peBytes[ele.Offset + i] = Convert.ToByte(ele.Value.Substring(strIndex, 2));
                }
            }
            

            //MessageBox.Show(ele.Value);
            //info.SetValue(,null)

        }


    }
}
