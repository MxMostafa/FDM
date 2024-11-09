

namespace Client.UI.Helpers;

public static class ErrorHelper
{
    public static void ShowErrorAsMessageBox(Exception ex)
    {
        MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
