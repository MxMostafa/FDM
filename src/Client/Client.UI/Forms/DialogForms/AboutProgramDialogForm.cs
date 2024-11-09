
namespace Client.UI.Forms.DialogForms;

public partial class AboutProgramDialogForm : MasterFixedDialogForm
{
    public AboutProgramDialogForm(ILogger<AboutProgramDialogForm> logger) : base(logger)
    {
        InitializeComponent();
    }

    private void AboutProgramDialogForm_Load(object sender, EventArgs e)
    {
        richTextBox1.Text = ".هشدار: اين برنامه کامپيوتري تحت حمايت قوانين کپي رايت و عهود بين المللي ميباشد. تکثير غيرمجاز، توزيع يا اشتراک آن با غير، به هر نحو با اشد مجازات مدني و جزائي روبرو خواهد شد-- --وبسايت نمايندگي رسمي در ايران www.downloadmanager.ir--";
    }
}
