using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertToDocx(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var paragraphs = ExtractParagraphs(lines);

            using (MemoryStream mem = new MemoryStream())
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body docBody = new Body();
                    foreach (var para in paragraphs)
                    {
                        Paragraph p = new Paragraph();
                        string[] parts = para.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 1)
                        {
                            Run r = new Run();
                            Text t = new Text(parts[0]);
                            r.Append(t);
                            p.Append(r);
                        }
                        else
                        {
                            for (int i = 0; i < parts.Length; i++)
                            {
                                Run r = new Run();
                                string clean = SanitizeLine(parts[i]);
                                Text t = new Text(clean);
                                if (parts[i].StartsWith("\t"))
                                {
                                    r.Append(new TabChar());
                                    parts[i] = parts[i].Substring(1);
                                }
                                r.Append(t);
                                p.Append(r);
                                if (i < parts.Length - 1)
                                {
                                    p.Append(new Break());
                                }
                            }

                        }
                        docBody.Append(p);
                    }
                    mainPart.Document.AppendChild(docBody);

                }
                mem.Position = 0;
                File.WriteAllBytes(path + ".docx", mem.ToArray());
            }
        }

        // slow, but works.
        private string SanitizeLine(string line)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in line)
            {
                if (c > 31)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


        private string[] ExtractParagraphs(string[] lines)
        {
            List<string> paragraphs = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool emptyline = true;
            bool header = true;
            bool block = false;

            foreach (string line in lines)
            {
                if (line.Trim().Length > 0)
                {
                    if (header)
                    {
                        sb.AppendLine(line);
                    }
                    else
                    {
                        if (emptyline && line.Trim().Length < 55)
                        {
                            sb.AppendLine(line.Trim());
                            block = true;
                        }
                        else if (block)
                        {
                            sb.AppendLine(line.Trim());
                        }
                        else if (!emptyline && (line.StartsWith("   ") || line.StartsWith("\t")))
                        {
                            sb.AppendLine(line);
                        }
                        else
                        {
                            sb.Append(line.Trim());
                            sb.Append(" ");
                        }
                    }
                    emptyline = false;
                    if (line.Trim().Length < 30 && (line.Trim().EndsWith(".") || line.Trim().EndsWith("?")))
                    {
                        string l = sb.ToString();
                        if (l.EndsWith("\r\n"))
                        {
                            l = l.Substring(0, l.Length - 2);
                        }
                        paragraphs.Add(l);
                        sb.Clear();
                        emptyline = true;
                        header = false;
                        block = false;
                    }
                }
                else
                {
                    if (!emptyline)
                    {
                        string l = sb.ToString();
                        if (l.EndsWith("\r\n"))
                        {
                            l = l.Substring(0, l.Length - 2);
                        }
                        paragraphs.Add(l);
                        sb.Clear();
                        emptyline = true;
                        header = false;
                        block = false;
                    }
                }
            }
            if (sb.Length > 0)
            {
                string l = sb.ToString();
                if (l.EndsWith("\r\n"))
                {
                    l = l.Substring(0, l.Length - 2);
                }
                paragraphs.Add(l);
                sb.Clear();
            }
            return paragraphs.ToArray();
        }

        private int Count = 0;
        private int Skipped = 0;
        private int Error = 0;
        private Stopwatch RefreshTimer = new Stopwatch();

        private void cmdGo_Click(object sender, EventArgs e)
        {
            RefreshTimer.Restart();
            Count = 0;
            Skipped = 0;
            Error = 0;
            txtErrors.Clear();
            WalkDirectory(txtSourcePath.Text);
            RefreshTimer.Stop();
            lblCount.Text = Count.ToString();
            lblError.Text = Error.ToString();
            lblSkip.Text = Skipped.ToString();
            lblCurrentPath.Text = "";

        }

        private void WalkDirectory(string path)
        {
            lblCurrentPath.Text = path;
            string[] files = System.IO.Directory.GetFiles(path);
            
            foreach (var file in files)
            {
                if (!file.EndsWith(".docx"))
                {
                    try
                    {
                        ConvertToDocx(file);
                        System.IO.File.Delete(file);
                        Count++;
                        if (RefreshTimer.ElapsedMilliseconds > 50)
                        {
                            lblCount.Text = Count.ToString();
                            Application.DoEvents();
                            RefreshTimer.Restart();
                        }
                    } catch
                    {
                        Error++;
                        txtErrors.AppendText(file + "\r\n");
                        lblError.Text = Error.ToString();
                        Application.DoEvents();
                    }
                }
                else
                {
                    Skipped++;
                    if (RefreshTimer.ElapsedMilliseconds > 50)
                    {
                        lblSkip.Text = Skipped.ToString();
                        Application.DoEvents();
                        RefreshTimer.Restart();
                    }
                }

            }
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                WalkDirectory(dir);
            }
        }
    }
}
