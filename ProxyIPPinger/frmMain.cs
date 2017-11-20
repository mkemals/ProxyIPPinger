using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using ProxyIPPinger.Model;

namespace ProxyIPPinger
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private List<IPList> ipList = new List<IPList>();
        private Setting SavedSettings = new Setting(); // Kayıtlı ayarlar, değişikliklerden önceki halinin saklanması için bunda tutuluyor
        private Setting setting = new Setting();
        private string CurrentProxyAddress { get; set; }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadPreferences();
            gvIPStatus.AutoGenerateColumns = false;
            BindData();
        }

        private void LoadPreferences()
        {
            try
            {
                string xmlFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Preferences.xml";
                if (File.Exists(xmlFilePath))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);
                    // xml decleration ile başlıyorsa bunu sil
                    if (xmlDoc.ChildNodes[0].NodeType == XmlNodeType.XmlDeclaration)
                    {
                        xmlDoc.RemoveChild(xmlDoc.ChildNodes[0]);
                    }
                    // Settings Node
                    this.setting.TimerInterval = int.Parse(xmlDoc.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText);
                    this.setting.PingForUsedIPOnly = bool.Parse(xmlDoc.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[1].InnerText);
                    this.setting.AutoChangeProxy = bool.Parse(xmlDoc.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[2].InnerText);
                    this.SavedSettings = this.setting; // Kayıtlı ayarlar, değişikliklerden önceki halinin saklanması için bunda tutuluyor
                    chkAutoChangeProxy.Checked = this.setting.AutoChangeProxy;
                    nudInterval.Value = this.setting.TimerInterval;
                    timer1.Interval = this.setting.TimerInterval * 1000; // sn -> ms
                                                                         // ProxyIPList Node
                    foreach (XmlNode node in xmlDoc.ChildNodes[0].ChildNodes[1])
                    {
                        IPList ip = new IPList();
                        ip.IP = node.Attributes["IP"].InnerText;
                        ip.Status = 0;
                        ip.StatusImage = imageList1.Images[0];
                        ip.Enable = node.Attributes.GetNamedItem("Enable") == null ? true : bool.Parse(node.Attributes["Enable"].InnerText);
                        ip.InUse = node.Attributes.GetNamedItem("InUse") == null ? false : bool.Parse(node.Attributes["InUse"].InnerText);
                        ip.UseCount = node.Attributes.GetNamedItem("UseCount") == null ? 0 : int.Parse(node.Attributes["UseCount"].InnerText);
                        ip.PingCount = node.Attributes.GetNamedItem("PingCount") == null ? 0 : int.Parse(node.Attributes["PingCount"].InnerText);
                        ip.FailCount = node.Attributes.GetNamedItem("FailCount") == null ? 0 : int.Parse(node.Attributes["FailCount"].InnerText);
                        this.ipList.Add(ip);
                    }
                }
                else
                {
                    this.setting.TimerInterval = (int)nudInterval.Value;
                    this.setting.PingForUsedIPOnly = false;
                    this.setting.AutoChangeProxy = chkAutoChangeProxy.Checked;

                    this.CurrentProxyAddress = GetCurrentProxyAddress();
                    if (this.CurrentProxyAddress != "")
                    {
                        this.ipList.Add(new IPList
                        {
                            IP = this.CurrentProxyAddress,
                            Enable = true,
                            InUse = true,
                            StatusImage = imageList1.Images[0],
                        });
                    }
                    SaveToXml(this.ipList, this.setting);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Preferences.xml dosya formatı hatalı!", "Proxy IP Pinger");
            }
        }

        private void BindData()
        {
            this.CurrentProxyAddress = GetCurrentProxyAddress();
            IPList currentIP = ipList.FirstOrDefault(f => f.IP == this.CurrentProxyAddress);
            if (currentIP != null)
                currentIP.UseCount++;
            gvIPStatus.DataSource = ipList;
            for (int i = 0; i < gvIPStatus.Rows.Count; i++)
            {
                gvIPStatus.Rows[i].Cells["clmnIP"].Style.Font = new Font(gvIPStatus.Font, FontStyle.Bold);
                gvIPStatus.Rows[i].Cells["clmnIP"].Style.ForeColor = Color.Black;
            }
            if (this.CurrentProxyAddress != "")
            {
                int index = this.ipList.FindIndex(f => f.IP == this.CurrentProxyAddress);
                if (index > -1)
                {
                    gvIPStatus.Rows[index].Cells["clmnIP"].Style.ForeColor = Color.Red;
                    this.ipList.ForEach(w => w.InUse = false);
                    this.ipList[index].InUse = true;
                }
            }
            gvIPStatus.Refresh();
        }

        private string GetCurrentProxyAddress()
        {
            RegistryKey regPROXY = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            string proxyServer = regPROXY.GetValue("ProxyServer").ToString();
            regPROXY.Close();
            int commaIndex = proxyServer.IndexOf(":");
            if (commaIndex > -1)
            {
                proxyServer = proxyServer.Substring(0, commaIndex);
            }
            return proxyServer;
        }
        private void ChangeProxy(string newProxyIP)
        {
            if (newProxyIP.IndexOf(":") == -1)
            {
                newProxyIP = newProxyIP + ":8080";
            }
            RegistryKey regPROXY = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            regPROXY.SetValue("ProxyServer", newProxyIP);
            regPROXY.Close();
        }

        private void btnPingAll_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public bool Ping(string ip)
        {
            PingReply pingReply = new Ping().Send(ip);
            return (pingReply.Status.ToString().Equals("Success"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void PingAll()
        {
            int progressValue = 0;
            int step = 100 / this.ipList.Count;
            this.CurrentProxyAddress = GetCurrentProxyAddress();
            foreach (IPList ipItem in this.ipList)
            {
                ipItem.StatusImage = imageList1.Images[0]; // reset

                if (!ipItem.Enable) continue;
                if (this.setting.PingForUsedIPOnly
                    && !ipItem.InUse 
                    && this.ipList.FirstOrDefault(f=>f.IP == this.CurrentProxyAddress) != null) continue;

                ipItem.PingCount++;
                ipItem.StatusImage = imageList1.Images[0]; // reset
                bool pingReply = Ping(ipItem.IP);
                if (!pingReply)
                {
                    ipItem.Status = 1;
                    ipItem.StatusImage = imageList1.Images[1];
                    ipItem.FailCount++;
                }
                else
                {
                    ipItem.Status = 2;
                    ipItem.StatusImage = imageList1.Images[2];
                }
                progressValue += step;
                backgroundWorker1.ReportProgress(progressValue);
            }
            progressValue = 0;
            backgroundWorker1.ReportProgress(progressValue);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PingAll();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkAutoChangeProxy.Checked)
            {
                IPList ip = ipList.FirstOrDefault(f => f.IP == this.CurrentProxyAddress);
                // Mevcut proxy IP'si Fail durumundaysa..
                if (ip == null || ip.Status == 1)
                {
                    // .. Success olan ve an az Fail Sayısına sahip IP'yi ata
                    IPList ip2 = ipList.Where(f => f.Enable && f.Status == 2).OrderBy(o => o.FailCount).FirstOrDefault();
                    ChangeProxy(ip2.IP);
                }
            }
            BindData();
        }

        private void SaveToXml(List<IPList> ipList, Setting setting)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Preferences");
            xmlDoc.AppendChild(rootNode);
            XmlAttribute attr;
            #region " Settings Node "
            XmlNode SettingsNode = xmlDoc.CreateElement("Settings");
            XmlNode SettingNode = xmlDoc.CreateElement("Setting");

            XmlNode node = xmlDoc.CreateElement("TimerInterval");
            node.InnerText = setting.TimerInterval.ToString();
            SettingNode.AppendChild(node);

            node = xmlDoc.CreateElement("PingForUsedIPOnly");
            node.InnerText = setting.PingForUsedIPOnly.ToString();
            SettingNode.AppendChild(node);

            node = xmlDoc.CreateElement("AutoChangeProxy");
            node.InnerText = setting.AutoChangeProxy.ToString();
            SettingNode.AppendChild(node);

            SettingsNode.AppendChild(SettingNode);
            rootNode.AppendChild(SettingsNode);
            #endregion
            #region " ProxyIPList Node "
            XmlNode ProxyIPListNode = xmlDoc.CreateElement("ProxyIPList");
            foreach (IPList ip in this.ipList)
            {
                XmlNode ProxyIPNode = xmlDoc.CreateElement("ProxyIP");

                attr = xmlDoc.CreateAttribute("Enable");
                attr.InnerText = ip.Enable.ToString();
                ProxyIPNode.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("InUse");
                attr.InnerText = ip.InUse.ToString();
                ProxyIPNode.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("IP");
                attr.InnerText = ip.IP;
                ProxyIPNode.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("UseCount");
                attr.InnerText = ip.UseCount.ToString();
                ProxyIPNode.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("PingCount");
                attr.InnerText = ip.PingCount.ToString();
                ProxyIPNode.Attributes.Append(attr);

                attr = xmlDoc.CreateAttribute("FailCount");
                attr.InnerText = ip.FailCount.ToString();
                ProxyIPNode.Attributes.Append(attr);

                ProxyIPListNode.AppendChild(ProxyIPNode);
            }
            rootNode.AppendChild(ProxyIPListNode);
            #endregion
            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "\\Preferences.xml");
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Setting _setting = this.setting;
            if (this.setting._HasChanged)
            {
                if (MessageBox.Show("Settings has changed. Do you want to save all changes?", "Settings Has Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    _setting = this.SavedSettings;
                }
            }
            SaveToXml(this.ipList, _setting);
        }

        private void llCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            progressBar1.Value = 0;
        }

        private void btnTimerPause_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                btnTimerPause.ImageIndex = 4;
            }
            else
            {
                timer1.Enabled = true;
                btnTimerPause.ImageIndex = 3;
            }
        }

        private void chkAutoChangeProxy_CheckedChanged(object sender, EventArgs e)
        {
            this.setting.AutoChangeProxy = chkAutoChangeProxy.Checked;
            this.setting._HasChanged = true;
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            if (nudInterval.Value > 0)
            {
                this.setting.TimerInterval = (int)Math.Ceiling(nudInterval.Value);
                timer1.Interval = this.setting.TimerInterval * 1000;
                this.setting._HasChanged = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.chkPingForUsedIPOnly.Checked = this.setting.PingForUsedIPOnly;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.setting.PingForUsedIPOnly = frm.chkPingForUsedIPOnly.Checked;
                this.setting._HasChanged = true;
            }
        }

        private void tmsiSetToProxy_Click(object sender, EventArgs e)
        {
            ChangeProxy(gvIPStatus.CurrentRow.Cells["clmnIP"].Value.ToString());
            BindData();
        }
    }
}
