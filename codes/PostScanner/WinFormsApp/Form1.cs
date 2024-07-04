using System.Net;
using ScannerLib;

namespace WinFormsApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void scanBtn_Click(object sender, EventArgs e)
    {
        // 获取控件值 
        var ipStr = IPBox.Text;
        var startPortStr = startBox.Text;
        var endPortStr = endBox.Text;

        // 判断用户输入
        if (string.IsNullOrWhiteSpace(ipStr))
        {
            MessageBox.Show("ip不可为空");
        }

        if (string.IsNullOrWhiteSpace(startPortStr) || string.IsNullOrWhiteSpace(endPortStr))
        {
            MessageBox.Show("端口不可为空");
        }

        if (int.TryParse(startPortStr, out var startPort) && int.TryParse(endPortStr, out var endPort))
        {
            if (startPort > endPort)
            {
                MessageBox.Show("起始端口不可大于结束端口");
            }

            if (IPAddress.TryParse(ipStr, out var ip))
            {
                scanBtn.Enabled = false;
                resultBox.Text = "扫描中..";
                // 开始端口扫描
                var helper = new ScannerHelper(ip, startPort, endPort);

                // 使用Task.Run来异步执行ScanPortsTask方法
                var ports = await Task.Run(() => helper.ScanPortsTask());

                if (ports.Count > 0)
                {
                    var content = string.Join(Environment.NewLine, ports);
                    resultBox.Text = "开放的端口" + Environment.NewLine + content;
                }
                else
                {
                    resultBox.Text = "扫描结束，没有开放的端口";
                }
                scanBtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("ip地址不合法");
            }
        }
        else
        {
            MessageBox.Show("端口必须为数字");
        }
    }
}
