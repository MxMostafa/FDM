

namespace Client.UI.Helpers;

public static class CommonHelper
{
    public static bool GetConfirm(string message)
    {
        var res = MessageBox.Show(message, @"هشدار", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
        return res == DialogResult.Yes;
    }
}
