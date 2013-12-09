using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Avery
{
    public partial class MainTool : Form
    {
       
        public MainTool()
        {
            InitializeComponent();         

        }

        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            HttpWebRequest requestMainUrl = (HttpWebRequest)WebRequest.Create(txtUrl.Text);
            HttpWebResponse responseMainUrl = (HttpWebResponse)requestMainUrl.GetResponse();
            StreamReader mainReader = new StreamReader(responseMainUrl.GetResponseStream(), Encoding.GetEncoding("windows-1251"));
            string content = mainReader.ReadToEnd();
            mainReader.Close();

            string pageName = content;
            int startIndex = pageName.IndexOf("escape(") + 8;
            pageName = pageName.Remove(0, startIndex);
            int endIndex = pageName.IndexOf(");") - 1;
            pageName = pageName.Remove(endIndex);

            startIndex = content.IndexOf("javascript:scene7Popup(") + 23;
            content = content.Remove(0, startIndex);
            endIndex = content.IndexOf(")") - 1;
            content = content.Remove(endIndex);

            string paramsString = "";
            for (int i = 0; i < content.Length; i++)
            {
                if (Char.IsLetter(content, i) || Char.IsDigit(content[i]) || (char)content[i] == ',' || (char)content[i] == '/' || (char)content[i] == '-' || (char)content[i] == '_' || (char)content[i] == '.' || (char)content[i] == ' ')
                {
                    paramsString += content[i];
                }
            }
            string[] srcriptParams = paramsString.Split(',');
            pageName = System.Uri.EscapeDataString(pageName);

            string pictureNumbers = "";
            int imageMunbersCount = 0;
            for (int i = 0; i < srcriptParams.Length; i++)
            {
                if (srcriptParams[i].Contains("AveryDennison"))
                {
                    pictureNumbers += srcriptParams[i];
                    imageMunbersCount++;
                    if (i != srcriptParams.Length - 3)
                        pictureNumbers += ",";
                }
            }

            if (imageMunbersCount == 1)
            {
                pictureNumbers = pictureNumbers.Trim(",".ToCharArray());
            }
            string averyMainUrlLocale = txtUrl.Text.Split('/')[2];
            content = @"http://" + averyMainUrlLocale + srcriptParams[0] + "?name=" + pageName + "&image=" + pictureNumbers + "&locale=" + srcriptParams[srcriptParams.Length - 1];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(content);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("windows-1251"));
            content = sr.ReadToEnd();
            sr.Close();
            startIndex = content.IndexOf("data=") + 6;
            endIndex = content.IndexOf(",http:");
            int count = endIndex - startIndex;
            content = content.Substring(startIndex, count);
            webBrowser1.Navigate(content);
            btnShowSelectionForm.Enabled = true;
            ShowSelectionForm();
        }

        private void ShowSelectionForm()
        {           
            SelectionScreen prs = new SelectionScreen();
            prs.ShowInTaskbar = false;
            prs.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SelectionScreen prs = new SelectionScreen();
            prs.ShowDialog();
        }
    }
}
