

namespace Client.UI.Forms.MasterForms;

public partial class MasterForm : XtraForm
{
    private readonly IServiceProvider _serviceProvider;
    public MasterForm(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private TForm GetForm<TForm>() where TForm : Form
    {
        return _serviceProvider.GetRequiredService<TForm>();
    }
}
