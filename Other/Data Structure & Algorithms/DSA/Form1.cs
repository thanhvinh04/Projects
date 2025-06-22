using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Collections;
using iTextSharp.text.xml;
using System.Text.RegularExpressions;

namespace DSA_CTDLGT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }
       public void read()
        {         
            readkeywords(pdfpathnk, 1);// đọc file stop-key
            readkeywords(pdfpatht, 2);// đọc file tail of word
            TopDirectories(pdfpathf);// đọc folder chứa pdf
        }
        public string pdfpathnk = "C:\\Users\\The Anh\\OneDrive\\Máy tính\\NHÓM 1 BÀI 5\\stop word.pdf";
        public string pdfpatht = "C:\\Users\\The Anh\\OneDrive\\Máy tính\\NHÓM 1 BÀI 5\\Tail of word.pdf";
        public string pdfpathf = "C:\\Users\\The Anh\\OneDrive\\Máy tính\\PDF";

        static public int[] uutien = new int[10005];
        public static List<List<int>> kiemtra2 = new List<List<int>>();
        public static int[,] kiemtralap = new int[1005, 100005];
        public static List<List<string>> textpdf = new List<List<string>>();
        static public string[] tail = new string[1005];
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public static List<string> Link = new List<string>();
        public static int kw;
        public static string[][] s = new string[3][];
        public static string search;
        static public string[] stopword = new string[2000];
        static public List<List<int>> xh = new List<List<int>>();
        static public float[] score = new float[100];
        static public int fileth = 0;
        public static string[] luutam = new string[100];
        static public string[] mangkeyword = new string[30];
        public bool ch = false;
        public int demtongfile=0;
        public Hashtable history = new Hashtable();
        static void search_words()
        {
            Regex regex = new Regex("[()[\\!#$^&*(){};:\"<>.,?/\\]]");
            search = regex.Replace(search, " ");

            Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
            search = trimmer.Replace(search, " ");
            search = search.Trim().ToLower();
            s[0] = search.Split(new char[] {' ','\n'});
            s[1] = new string[s[0].Length];
            s[2] = new string[s[0].Length];
            for (int i = 0; i < s[0].Length; i++)
            {
                s[1][i] = i.ToString();
                s[0][i] = s[0][i].ToLower();
            }
            bool kt = true;
            for (int i = 0; i < s[0].Length; i++)
            {
                kt = true;
                for (int j = 0; j < i; j++)
                {
                    if (s[0][i] == s[0][j])
                    {
                        s[1][i] = s[1][j];
                        s[2][i] = s[2][j];
                        kt = false;
                        break;
                    }
                }
                if (kt)
                {
                    for (int j = 0; j < stopword.Length; j++)
                    {
                        s[2][i] = "K";
                        if (s[0][i] == stopword[j])
                        {
                            s[2][i] = "N";
                            break;
                        }
                    }
                }
            }
            kw = 0;
            for (int i = 0; i < s[0].Length; i++)
            {
                if (s[2][i] == "K") kw++;
            }        
        }
        public static void readkeywords(string path,int x)//non-keywords
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            // Đọc theo từng trang
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
                text += "\n";
            }
            if (x == 1)
            {
                stopword = text.Split(new char[] { '\n' });
                for (int i = 0; i < stopword.Length - 1; i++) // Xử lý dấu cách cuối mỗi từ trong file stop word
                {
                    stopword[i] = stopword[i].Substring(0, stopword[i].Length - 1);
                }
            }
            else
            {
                tail = text.Split(new char[] { '\n' });
                for (int i = 0; i < tail.Length - 1; i++) // Xử lý dấu cách cuối mỗi từ trong file stop word
                {
                    tail[i] = tail[i].Substring(0, tail[i].Length - 1);
                }
                Array.Sort(tail);
            }
            reader.Close();
        }
        public Dictionary<string, List<string>> textf = new Dictionary<string, List<string>>();
        private void TopDirectories(string path)
        {
            textpdf.Add(new List<string>());
            textpdf[0] = new List<string>();
            kiemtra2.Add(new List<int>());
            kiemtra2[0] = new List<int>();
            textpdf[0].Add("name");

            string[] filePahts2 = System.IO.Directory.GetFiles(path, "*.pdf", SearchOption.TopDirectoryOnly);
            demtongfile = filePahts2.Length;//dongho
            foreach (string filePaht in filePahts2)
            {
                string text = pdfText(filePaht);
                // Lấy tên của file
                var name = System.IO.Path.GetFileName(filePaht);

                fileth++;
                textpdf[0].Add(name);
                textpdf.Add(new List<string>());
                textpdf[fileth] = new List<string>();
                kiemtra2.Add(new List<int>());
                kiemtra2[fileth] = new List<int>();

                SplitText(text);

            }
        }  
        public void saveresult()
        {
            string[] namefile = new string[100];
            float[] diem = new float[100];
            diem = score;
            for (int i = 1; i <= fileth; i++)
            {
                List<int> kiemtra = new List<int>(kiemtra2[i]);
                DuyetSearch_textPdf(i,kiemtra);
                namefile[i] = textpdf[0][i];
                
            }
            xapxep();
        }
        static public void SetScore(int[] scxh, string[] sctext, float[] scoreword, string[] key, int n, int fileth2)
        {            
            quickSort(scxh, sctext, scoreword, key, 1, n);
            string text = "";
            int countkey = 0, length = 0;
            scxh[0] = -1000;
            scxh[n + 1] = -100000;
            int pre = 1;
            int demkey = 0;
            string[] mangkeyword = new string[30];
            mangkeyword[0] = "";
            bool kiemtrakey = false;
            string chuoi = "";
            for (int i = 0; i < s[0].Length; i++)
            {
                chuoi += s[0][i] + " ";
            }
            for (int i = 1; i <= n + 1; i++)
            {
                if (scxh[i] != scxh[i - 1] + 1)
                {
                    bool check = search.Contains(text.Trim());
                    if (check)
                    {

                        float tong = 0;
                        for (int j = pre; j <= length; j++) tong += scoreword[j];
                        if (countkey == 0) score[fileth2] += 0;
                        else if (countkey == 1) score[fileth2] += 1;
                        else score[fileth2] += tong * countkey * 10;
                    }
                    text = "";
                    countkey = 0;
                    length = 0;
                    text += sctext[i] + " ";
                    pre = i;
                    length++;
                    if (key[i] == "K")  countkey++;                 
                    if (key[i] == "K" && !check) score[fileth2] += 1;
                }
                else
                {
                    text += sctext[i] + " ";
                    length++;
                    if (key[i] == "K")
                    {
                        countkey++;
                        score[fileth2] += 1;
                    }
                    if (text.Trim() == chuoi.Trim()) uutien[fileth2]++;                   
                }
            }
            // tinh diem khi du keyword
            for (int k = 1; k <= n + 1; k++)
            {
                if (key[k] == "K")
                {
                    if (mangkeyword.Contains(sctext[k]) == false)
                    {
                        mangkeyword[demkey] = sctext[k];
                        demkey++;
                    }
                    if (demkey == kw)
                    {
                        score[fileth2] += 3*1000000;
                        kiemtrakey = true;
                        break;
                    }
                }
            }
            // tinh diem khi khong du key word 
            if (kiemtrakey == false)
            {
                score[fileth2] += demkey * 100000;
            }
        }

         public static void quickSort(int[] scxh, string[] sctext, float[] scoreword, string[] key, int l, int r)
        {
            int i = l, j = r;
            int p = scxh[(l + r) / 2];
            while (i < j)
            {
                while (scxh[i] < p) i++;
                while (scxh[j] > p) j--;
                if (i <= j)
                {
                    int tg = scxh[i];
                    scxh[i] = scxh[j];
                    scxh[j] = tg;
                    string temp = sctext[i];
                    sctext[i] = sctext[j];
                    sctext[j] = temp;
                    temp = key[i];
                    key[i] = key[j];
                    key[j] = temp;
                    float sw = scoreword[i];
                    scoreword[i] = scoreword[j];
                    scoreword[j] = sw;
                    i++; j--;
                }
            }
            if (j > l) quickSort(scxh, sctext, scoreword, key, l, j);
            if (i < r) quickSort(scxh, sctext, scoreword, key, i, r);
        }
        static public int Binary_Search1(int d, int c, List<string> pdftext, char x, int pos)
        {
            int ans = -1;
            while (d <= c)
            {
                int mid = (d + c) / 2;
                if (pdftext[mid][pos] >= x)
                {
                    ans = mid;
                    c = mid - 1;
                }
                else d = mid + 1;
            }
            return ans;
        }
        static public int Binary_Search2(int d, int c, List<string> pdftext, char x, int pos)
        {
            int m, ans = -1;
            while (d <= c)
            {
                m = (d + c) / 2;
                if (pdftext[m][pos] <= x)
                {
                    ans = m;
                    d = m + 1;
                }
                else c = m - 1;
            }
            return ans;
        }
        static public bool SameMean(string cat)
        {
            bool flag = false;
            if (cat.Length == 0) return flag;
            List<string> temp = tail.ToList<string>();
            temp.Insert(0, "aaa");
            temp.Insert(0, "aaa");
            temp.Insert(0, "aaa");
            temp.Add("zzz");
            temp.Add("zzz");
            temp.Add("zzz");
            int posStart = Binary_Search1(4, temp.Count - 3, temp, cat[0], 0);
            int posEnd = Binary_Search2(4, temp.Count - 3, temp, cat[0], 0);
            if (posStart != -1)
            {
                //Console.WriteLine(temp[posStart] + " " + temp[posEnd]);
                for (int i = posStart; i <= posEnd; i++)
                {
                    if (cat.Equals(temp[i]))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        static public void DuyetSearch_textPdf(int fileth2, List<int> chongtrung)
        {
            xh.Clear();
            int[] scxh = new int[1000005];
            string[] sctext = new string[1000005];
            string[] key = new string[1000005];
            float[] scoreword = new float[1000005];
            int dem = 0;
            for (int i = 0; i < s[0].Length; i++)
            {
                xh.Add(new List<int>());
                if (s[1][i] != i.ToString()) continue;

                int posStart = Binary_Search1(3, textpdf[fileth2].Count - 3, textpdf[fileth2], s[0][i][0], 0);
                int posEnd = Binary_Search2(3, textpdf[fileth2].Count - 3, textpdf[fileth2], s[0][i][0], 0);
                if (posStart != -1)
                {
                    for (int j = posStart; j <= posEnd; j++)
                    {
                        string[] temp1 = new string[2];
                        temp1 = textpdf[fileth2][j].Split(' ');
                        string cat = String.Empty;
                        string ans = temp1[0];
                        int count = 0;
                        if (temp1[0].Length < s[0][i].Length) ans = s[0][i];
                        // TH 2 thèn bằng nhau thì xét cả 2 đuôi (hên xui có)
                        bool kt = true;
                        for (int c = 0; c < Math.Min(temp1[0].Length, s[0][i].Length); c++)
                        {
                            
                            if (temp1[0][c] != s[0][i][c]) break;
                            if (kt) count++;
                        }
                        if (count < ans.Length) cat = ans.Substring(count, ans.Length - count).ToLower();
                        kt = SameMean(cat);
                        // 2 tu bang nhau hoan toan hoac bang nhau khi them duoi (Tail)
                        if (count == ans.Length && temp1[0].Length == s[0][i].Length && chongtrung[j] == 0)
                        {
                            xh[i].Add(Convert.ToInt32(temp1[1]));
                            dem++;
                            sctext[dem] = s[0][i];
                            scxh[dem] = Convert.ToInt32(temp1[1]);
                            chongtrung[j] = 1;                           
                            key[dem] = s[2][i];
                            if (key[dem] == "K") scoreword[dem] += 1;
                            else scoreword[dem] += 0.01f;
                            continue;
                        }
                        else if (kt && s[2][i] == "K" && chongtrung[j] == 0)
                        {
                            xh[i].Add(Convert.ToInt32(temp1[1]));
                            dem++;
                            sctext[dem] = s[0][i];
                            chongtrung[j] = 1;
                            scxh[dem] = Convert.ToInt32(temp1[1]);
                            key[dem] = s[2][i];
                            if (key[dem] == "K") scoreword[dem] += 1;
                            else scoreword[dem] += 0.01f;
                            continue;
                        }
                    }
                }
            }
            SetScore(scxh, sctext, scoreword, key, dem, fileth2);
        }
        static public string pdfText(string path)
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            // Đọc theo từng trang
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);
                text += "\n";
            }
            Regex regex = new Regex("[()[\\!#$^&*(){};:\"<>.,?/\\]]");
            text = text.Replace("\n", " ");
            text = regex.Replace(text, "").ToLower();
            return text;
        }
        public static void xapxep()
        {
            List<string> print = new List<string>();
            List<string> print1 = new List<string>();
            for (int i = 1; i <= fileth; i++)
            {
                if (uutien[i] > 0)
                {
                    print.Add(textpdf[0][i ] + ":" + score[i]  + "_" + uutien[i]);
                }
                else
                {
                    if (score[i]>0)
                    print1.Add(textpdf[0][i] + ":" + score[i]);

                }
            }
            Array.Clear(uutien, 0, fileth);
            print = print
            .OrderByDescending(Chuyendoiuutien)
            .ThenByDescending(Chuyendoiscore)
            .ToList();
            print1 = print1
            .OrderByDescending(Chuyendoiscore)
            .ToList();
            int m = 0;
            int stt = 1;
            for (int i = 0; i < print.Count; i++) 
            {
                luutam[m] = stt+" "+print[i].Substring(0, print[i].IndexOf(":"));
                m++;
                stt++;
            }
            for (int i = 0; i < print1.Count; i++)
            {                
                luutam[m] = stt + " " + print1[i].Substring(0, print1[i].IndexOf(":"));
                m++;
                stt++;
            }
        }
        static int Chuyendoiuutien(string chuoi)
        {
            // Tìm uutien trong chuỗi và chuyển đổi thành số nguyên
            string[] manguutien = chuoi.Split(new char[] {':','_'});
             int.TryParse(manguutien[manguutien.Length-1], out int uutien);
            {
                return uutien;
            }
        }
        static int Chuyendoiscore(string chuoi)
        {
            // Tìm score trong chuỗi và chuyển đổi thành số nguyên
            string[] mangscore = chuoi.Split(new char[] { ':', '_' });          
            {
                int.TryParse(mangscore[1], out int score);
                {
                    return score;
                }
            }
        }


        public static void SplitText(string text)
        {
            string A = string.Empty;
            List<string> lines = new List<string>(text.Split(new char[] { ' ', '\n', }));
            int dem = 0;
            int count = 0;
            lines.RemoveAll(item => string.IsNullOrEmpty(item));
            for (int i = 0; i < lines.Count; i++)
            {
                count++;
                textpdf[fileth].Add(lines[i] + " " + count.ToString());
                kiemtra2[fileth].Add(0);
                kiemtra2[fileth].Add(0);
                textpdf[fileth][dem] = textpdf[fileth][dem].ToLower();
                dem++;               
            }     
            textpdf[fileth].Sort();
            textpdf[fileth].Insert(0, "zzz");
            textpdf[fileth].Insert(0, "zzz");
            textpdf[fileth].Insert(0, "zzz");
            textpdf[fileth].Add("zzz");
            textpdf[fileth].Add("zzz");
            textpdf[fileth].Add("zzz");
        }

        private void checknhap()
        {            
            string r1 = txttimkiem.Text;
            string r2 = txttimkiem.Text.Replace(" ", "");
            double r3 = r1.Length - r2.Length;           
            search = txttimkiem.Text;
            search_words();
            if (ch)
            {
                if (kw == 0) MessageBox.Show($"Câu bạn nhập không có keyword", "ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); 
                else
                {
                    Search_list.Items.Clear();
                    saveresult();
                    foreach (string item in luutam.Where(x => x != null))
                    {
                        Search_list.Items.Add(item);
                    }
                    Regex regex = new Regex("[()[\\!#$^&*(){};:\"<>.,?/\\]]");
                    string timkiem = regex.Replace(txttimkiem.Text, " ");
                    timkiem = timkiem.Trim().ToLower();
                    Regex trimmer = new Regex(@"\s\s+"); // Xóa khoảng trắng thừa trong chuỗi
                    timkiem = trimmer.Replace(timkiem," ");
                    // lưu lại history nè
                    if (!History_list.Items.Contains(timkiem))
                    {
                        History_list.Items.Add(search);
                        AddHistoryItems(search, luutam);
                    }
                }
                luutam = new string[100];
                score = new float[100];
            }
        }
        Dictionary<string, List<string>> history_items = new Dictionary<string, List<string>>();
        private void AddHistoryItems(string history_search, string[] items)
        {
            if (!history_items.ContainsKey(history_search))
            {
                items = Search_list.Items.Cast<string>().ToArray();
                history_items[history_search] = new List<string>();
                history_items[history_search].AddRange(items);
            }
        }
       
        // an nut quay lai
        private void btquaylai_Click(object sender, EventArgs e)
        {
            if (History_list.Items.Count > 0)
            {
                if (History_list.SelectedIndex == -1)
                    History_list.SelectedIndex = History_list.Items.Count - 2;
                else if (History_list.SelectedIndex > 0)
                    History_list.SelectedIndex -= 1;
                else History_list.SelectedIndex = History_list.Items.Count - 1;
            }
        }
        // an nut tien len
        private void bttienlen_Click(object sender, EventArgs e)
        {
            if (History_list.Items.Count > 0)
            {
                if (History_list.SelectedIndex < History_list.Items.Count - 1)
                    History_list.SelectedIndex += 1;
                else if (History_list.SelectedIndex == History_list.Items.Count - 1)
                    History_list.SelectedIndex = 0;
            }
        }
        // an nut tim
        private void bttim_Click(object sender, EventArgs e)
        {          
            if (History_list.Items.Contains(txttimkiem.Text))
            {
                Search_list.Items.Clear();
                List<string> items = history_items[txttimkiem.Text];
                foreach (string item in items) Search_list.Items.Add(item);
            }
            else
            {
                Search_list.Items.Clear();
                checknhap();
            }
            History_list.SelectedIndex = -1;
        }
       
        private  void thoat()
        {

            DialogResult kqthoat = MessageBox.Show($"Bạn chắc chắn muốn thoát", "ERROR!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (kqthoat == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }           
        }
       

        private void History_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search_list.Items.Clear();
            if(History_list.SelectedItem!= null)
            {
                string selectedHistoryItem = History_list.SelectedItem.ToString().ToLower();
                List<string> items = history_items[selectedHistoryItem];
                foreach (string item in items) Search_list.Items.Add(item);
            }
           
        }

        private void Search_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Search_list.SelectedItem != null)
            {
                string item = Search_list.SelectedItem.ToString();
                item = item.Substring(item.IndexOf(' ')+1,item.Length-item.IndexOf(' ')-1);

                string name_file = (pdfpathf+"\\*").Replace("*",item);
                Process goi_file = new Process();
                goi_file.StartInfo.FileName = name_file;
                goi_file.Start(); 
            }
        }

        private void Pbackground_Click(object sender, EventArgs e)
        {

        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            ch = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thoat();
        }
    }
}
