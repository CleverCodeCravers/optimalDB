namespace optimalDb.WinForms.UiExtensions;

public static class ListBoxExtensions
{
    public static bool TryGetSelectedItemAs<T>(this ListBox listBox, out T? value) where T : class
    {
        value = listBox.SelectedItem as T;

        if (value == null)
            return false;

        return true;
    }
}