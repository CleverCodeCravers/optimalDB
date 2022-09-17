namespace optimalDb.WinForms.UiExtensions;

public static class MouseCursorTools
{
    public static void WithWaitCursor(Action action, bool showExceptionInMessageBox = true)
    {
        Cursor.Current = Cursors.WaitCursor;

        try
        {
            action();
        }
        catch (Exception e)
        {
            if (showExceptionInMessageBox)
                MessageBox.Show(e.Message);
            else
                throw;
        }

        Cursor.Current = Cursors.Default;
    }

    public static T? WithWaitCursor<T>(Func<T> action, bool showExceptionInMessageBox = true)
    {
        Cursor.Current = Cursors.WaitCursor;

        try
        {
            return action();
        }
        catch (Exception e)
        {
            if (showExceptionInMessageBox)
                MessageBox.Show(e.Message);
            else
                throw;
        }

        Cursor.Current = Cursors.Default;
        return default(T);
    }
}