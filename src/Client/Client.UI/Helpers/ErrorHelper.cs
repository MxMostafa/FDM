﻿

using Client.Domain.Dtos;

namespace Client.UI.Helpers;

public static class ErrorHelper
{
    public static void ShowErrorAsMessageBox(Exception ex)
    {
        MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowErrorAsMessageBox(string error)
    {
        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static void ShowErrorAsMessageBox<T>(ResultPattern<T> result)
    {
        MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
