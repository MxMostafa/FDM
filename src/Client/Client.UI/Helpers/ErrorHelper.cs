

using Client.Domain.Dtos;

namespace Client.UI.Helpers;

public static class ErrorHelper
{
    public static void ShowErrorAsMessageBox(Exception ex)
    {
        new ErrorDialogForm(ex.InnerException?.Message ?? ex.Message).ShowDialog();
        //  MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowErrorAsMessageBox(string error)
    {
        new ErrorDialogForm(error).ShowDialog();
        //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowErrorAsMessageBox<T>(ResultPattern<T> result)
    {
        new ErrorDialogForm(result.ErrorMessage).ShowDialog();
        //MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
