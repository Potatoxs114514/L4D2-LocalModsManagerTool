using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 求生之路2Mod管理工具
{
    public partial class Form1 : Form
    {
        string ext = ".vpk";
        string steamPath = null;
        string modType = null;
        DirectoryInfo addonsPath = null;
        DirectoryInfo workshopPath = null;
        DirectoryInfo disablePath = null;
        List<string> enableFileList = new List<string>();
        List<string> disableFileList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void GetSteamState_Tick(object sender, EventArgs e)
        {
            //检查Steam当前是否在运行
            CheckSteamState();

            if (steamPath != null && workshopPath == null)
            {
                this.Text = "求生之路2本地Mod管理工具 --> 未寻找到游戏";
                Log("未在库中寻找到游戏，请检查是否已经安装游戏后再重启软件重试 ><");
                return;
            }
            else
            {
                this.Text = "求生之路2本地Mod管理工具";
                tabControl1.SelectedIndex = 0;
                tabControl1.Enabled = true;
                GetLocalMods();
            }
        }

        private void CheckSteamState()
        {
            Process[] pro = Process.GetProcesses();
            for (int i = 0; i < pro.Length; i++)
            {
                if (pro[i].ProcessName == "steam")  //进程名字
                {

                    steamPath = pro[i].MainModule.FileName;
                    Log("获取到Staem路径: " + steamPath);
                    GetSteamState.Enabled = false;
                    GetSteamLibrary();  //获取Steam游戏库路径
                    return;
                }
            }
        }

        private void GetSteamLibrary()
        {
            string libraryPathFile = steamPath.Replace("steam.exe", "") + "config\\libraryfolders.vdf";
            Log("定位到Staem游戏库路径文件: " + libraryPathFile);
            string libraryInfo;
            using (StreamReader sr = new StreamReader(libraryPathFile, Encoding.Default))
            {
                libraryInfo = sr.ReadToEnd();
            }
            int libraryCount = libraryInfo.Split(new string[] { "\"path\"" }, StringSplitOptions.None).Length - 1;
            Log("获取到的Steam库数量: " + libraryCount);
            int libraryIndex = 0;
            string currentLibraryInfo = "";
            string currentLibraryPath = "";
            for (int i = 0; i <= libraryCount; i++)
            {
                try
                {
                    currentLibraryInfo = libraryInfo.Substring(libraryIndex, libraryInfo.IndexOf("\"path\"", libraryInfo.IndexOf("\"path\"") + 10));
                }
                catch
                {
                    currentLibraryInfo = libraryInfo.Substring(libraryIndex);
                }
                currentLibraryPath = currentLibraryInfo.Substring(6, currentLibraryInfo.IndexOf("\"label\"") - 7).Trim().Replace("\"", "").Replace("\\\\", "\\");
                if (i != 0)
                {
                    Log("正在从第" + i + "个库中寻找L4D2...");
                    Log(currentLibraryPath);
                }
                if (Directory.Exists(currentLibraryPath + "\\steamapps\\common\\Left 4 Dead 2\\left4dead2\\addons"))
                {
                    string l4d2Path = currentLibraryInfo.Substring(6, currentLibraryInfo.IndexOf("\"label\"") - 7).Trim().Replace("\"", "").Replace("\\\\", "\\");
                    l4d2Path += "\\steamapps\\common\\Left 4 Dead 2";
                    Log("已寻找到游戏路径: " + l4d2Path);
                    addonsPath = new DirectoryInfo(l4d2Path + "\\left4dead2\\addons\\");
                    Log("本地MOD路径: " + addonsPath);
                    workshopPath = new DirectoryInfo(addonsPath + "workshop\\");
                    Log("创意工坊路径: " + workshopPath);
                    disablePath = new DirectoryInfo(addonsPath + "disable\\");
                    return;
                }
                libraryIndex = libraryInfo.IndexOf("\"path\"", libraryIndex + 10);
            }
        }

        private void GetLocalMods()
        {
            Log("更新本地Mod列表...\n");
            enableFileList = new List<string>();
            disableFileList = new List<string>();
            GetFileList(addonsPath, "*.vpk", ref enableFileList, enableModsList);
            if(Directory.Exists(disablePath.ToString()))
                GetFileList(disablePath, "*.vpk", ref disableFileList, disableModsList);
            else
                Directory.CreateDirectory(disablePath.ToString());
        }

        private void GetFileList(DirectoryInfo directory, string pattern, ref List<string> fileList, ListBox listBox)
        {
            try
            {
                listBox.Items.Clear();
                foreach (FileInfo info in directory.GetFiles(pattern))
                {
                    string name = info.Name.Substring(0, info.Name.LastIndexOf(ext));
                    listBox.Items.Add(name);
                    fileList.Add(info.FullName.ToString());
                }
            }
            catch { }
        }

        private void Log(string text)
        {
            Console.WriteLine(text);
            _log.AppendText(text + "\r\n");
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            GetLocalMods();
        }

        private void enableModsList_DoubleClick(object sender, EventArgs e)
        {
            DisableMod(enableModsList.SelectedIndex);
        }

        private void DisableMod(int index)
        {
            File.Move(enableFileList[index], disablePath.ToString() + enableModsList.SelectedItem + ext);
            Log("禁用Mod: " + enableModsList.SelectedItem);
            GetLocalMods();
        }

        private void disableModsList_DoubleClick(object sender, EventArgs e)
        {
            EnableMod(disableModsList.SelectedIndex);
        }

        private void EnableMod(int index)
        {
            File.Move(disableFileList[index], addonsPath.ToString() + disableModsList.SelectedItem + ext);
            Log("启用Mod: " + disableModsList.SelectedItem);
            GetLocalMods();
        }

        private void openAddons_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", addonsPath.ToString());
        }

        private void btn_disable_Click(object sender, EventArgs e)
        {
            if (enableModsList.SelectedIndex == -1) return;
            DisableMod(enableModsList.SelectedIndex);
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {
            if (disableModsList.SelectedIndex == -1) return;
            EnableMod(disableModsList.SelectedIndex);
        }

        private void enableModsList_Click(object sender, EventArgs e)
        {
            disableModsList.SelectedIndex = -1;
        }

        private void disableModsList_Click(object sender, EventArgs e)
        {
            enableModsList.SelectedIndex = -1;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (disableModsList.SelectedIndex != -1)
            {
                File.Delete(disableFileList[disableModsList.SelectedIndex]);
                Log("删除Mod: " + disableModsList.SelectedItem);
            }
            if (enableModsList.SelectedIndex != -1)
            { 
                File.Delete(enableFileList[enableModsList.SelectedIndex]);
                Log("删除Mod: " + enableModsList.SelectedItem);
            }
                

            GetLocalMods();
        }

        private void startGame_Click(object sender, EventArgs e)
        {
            Process.Start("steam://rungameid/550");
            Log("启动游戏");
        }

        private void closeGame_Click(object sender, EventArgs e)
        {
            Process.Start("taskkill.exe", "/f /im left4dead2.exe");
            Log("关闭游戏");
        }

        private void enableModsList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void enableModsList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            MoveMods(files, addonsPath.ToString());
        }

        private void disableModsList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, true);
            MoveMods(files, disablePath.ToString());
        }

        private void MoveMods(string[] files, string path)
        {
            try
            {
                foreach (string file in files)
                {
                    string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                    File.Move(file, path + fileName);
                    Log("将文件 <" + file + "> 移动到 <" + path + fileName + ">");
                    GetLocalMods();
                }
            }
            catch { }
        }

        private void Rename(DirectoryInfo directory, string pattern)
        {
            if (directory.Exists || pattern.Trim() != string.Empty)
            {
                try
                {
                    foreach (FileInfo info in directory.GetFiles(pattern))
                    {
                        string name = info.Name.Substring(0, info.Name.LastIndexOf(ext));
                        string itemName = GetSteamWorksItemName(name);
                        if (itemName != "")
                        {
                            itemName = itemName.Replace(":", "：");
                            itemName = itemName.Replace("\\", "");
                            itemName = itemName.Replace("/", "of");
                            itemName = itemName.Replace("*", "x");
                            itemName = itemName.Replace("?", "？");
                            itemName = itemName.Replace("\"", "");
                            itemName = itemName.Replace("<", "[");
                            itemName = itemName.Replace(">", "]");
                            itemName = itemName.Replace("|", "-");
                            itemName = itemName.Replace("\n", "");
                            itemName = itemName.Replace("\r", "");
                            itemName = itemName.Replace("\t", "");
                            itemName = itemName.Replace("【", "[");
                            itemName = itemName.Replace("】", "]");
                            itemName = itemName.Replace("（", "(");
                            itemName = itemName.Replace("）", ")");
                            itemName = itemName.Replace("—", "-");
                            while (itemName.IndexOf("  ") != -1)
                            {
                                itemName = itemName.Replace("  "," ");
                            }
                            while (Encoding.Default.GetByteCount(itemName) + 4 >= 60)
                            {
                                itemName = itemName.Substring(0, itemName.Length - 1);
                            }
                            string filePath = addonsPath + itemName + ext;
                            if (!File.Exists(filePath))
                            {
                                info.MoveTo(filePath);
                                Log(name + "\t > 已移动到 " + addonsPath + itemName + ext);
                            }
                            else
                            {
                                Log("文件已存在: " + addonsPath + itemName + ext);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Log(ex.ToString());
                }
            }
        }

        private string GetSteamWorksItemName(string id)
        {
            modType = "";
            string Web = "https://steamcommunity.com/sharedfiles/filedetails/?id=" + id;
            try
            {
                WebClient MyWebClient = new WebClient();
                MyWebClient.Credentials = CredentialCache.DefaultCredentials;
                Byte[] pageData = MyWebClient.DownloadData(Web);
                string page = Encoding.UTF8.GetString(pageData);
                if (page.IndexOf("<title>Steam Workshop::") != -1)
                {
                    string name = page.Substring(page.IndexOf("<title>Steam Workshop::") + "<title>Steam Workshop::".Length, 100);
                    name = name.Substring(0, name.IndexOf("</title>"));
                    string tag = page.Substring(page.IndexOf("<span class=\"workshopTagsTitle\">") + "<span class=\"workshopTagsTitle\">".Length, page.IndexOf("<div class=\"detailsStatsContainerLeft\">") - page.IndexOf("<span class=\"workshopTagsTitle\">"));
                    GetModType(tag);
                    Log(id + "\t > " + modType + name.Trim());
                    return modType + name;
                }
                else
                {
                    Log(id + "\t > " + "获取失败(物品不存在或被隐藏)");
                    return id;
                }
            }
            catch
            {
                Log(id + "\t > " + "获取失败(无法连接到Steam创意工坊)");
                return id;
            }
        }

        private void Cover_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            tabControl1.Enabled = false;
            Log("开始将创意工坊Mod移动到本地...");
            Rename(workshopPath, "*.vpk");
            tabControl1.Enabled = true;
            tabControl1.SelectedIndex = 0;
            Log("已完成移动");
            GetLocalMods();
        }

        private void GetModType(string text)
        {
            if (text.IndexOf("Bill") != -1 ||
                text.IndexOf("Francis") != -1 ||
                text.IndexOf("Louis") != -1 ||
                text.IndexOf("Zoey") != -1 ||
                text.IndexOf("Coach") != -1 ||
                text.IndexOf("Ellis") != -1 ||
                text.IndexOf("Nick") != -1 ||
                text.IndexOf("Rochelle") != -1)
            {
                modType = "[C]";
            }
            else if (text.IndexOf("Boomer") != -1 ||
                    text.IndexOf("Charger") != -1 ||
                    text.IndexOf("Hunter") != -1 ||
                    text.IndexOf("Jockey") != -1 ||
                    text.IndexOf("Smoker") != -1 ||
                    text.IndexOf("Spitter") != -1 ||
                    text.IndexOf("Tank") != -1 ||
                    text.IndexOf("Witch") != -1)
            {
                modType = "[S]";
            }
            else if (text.IndexOf("Campaigns") != -1)
            {
                modType = "[Map]";
            }
            else if (text.IndexOf("Weapons") != -1)
            {
                modType = "[W]";
            }
            else if (text.IndexOf("Items") != -1)
            {
                modType = "[Item]";
            }
            else if (text.IndexOf("Sounds") != -1)
            {
                modType = "[Sound]";
            }
            else if (text.IndexOf("Scripts") != -1)
            {
                modType = "[Script]";
            }
            else if (text.IndexOf("UI") != -1)
            {
                modType = "[UI]";
            }
            else if (text.IndexOf("Textures") != -1)
            {
                modType = "[Tex]";
            }
            else
            {
                modType = "[Z]";
            }
        }

        private void enableModsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawItemColor(e, enableModsList);
        }

        private void disableModsList_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawItemColor(e, disableModsList);
        }

        private void DrawItemColor(DrawItemEventArgs e, ListBox listbox)
        {
            try
            {
                e.DrawBackground();
                Brush mybsh = Brushes.Black;
                // 判断是什么类型的标签
                if (listbox.Items[e.Index].ToString().IndexOf("[C]") == 0)
                {
                    mybsh = Brushes.Orange;
                }
                else if (listbox.Items[e.Index].ToString().IndexOf("[W]") == 0)
                {
                    mybsh = Brushes.Red;
                }
                else if (listbox.Items[e.Index].ToString().IndexOf("[S]") == 0)
                {
                    mybsh = Brushes.YellowGreen;
                }
                else if (listbox.Items[e.Index].ToString().IndexOf("[Map]") == 0)
                {
                    mybsh = Brushes.Violet;
                }
                //文本
                e.Graphics.DrawString(listbox.Items[e.Index].ToString(), e.Font, mybsh, e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
            catch { }
        }
    }
}
