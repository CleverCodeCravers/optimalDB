namespace optimalDb.WinForms.UiExtensions;

public class FulltextSearchableListBoxBehaviour<T> where T:class
{
    private readonly ListBox _listBox;
    private readonly TextBox _searchBox;
    private readonly List<T> _variableWithAllValues;

    public FulltextSearchableListBoxBehaviour(ListBox listBox, TextBox searchBox, ref List<T> variableWithAllValues)
    {
        _listBox = listBox;
        _searchBox = searchBox;
        _variableWithAllValues = variableWithAllValues;

        _searchBox.KeyDown += SearchBoxOnKeyDown;
        _searchBox.TextChanged += SearchBoxOnTextChanged;
    }

    private void SearchBoxOnTextChanged(object? sender, EventArgs e)
    {
        UpdateView();
    }

    public void UpdateView()
    {
        var searchQuery = _searchBox.Text;

        var queryParts = searchQuery.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var newValueList = _variableWithAllValues.Where(x => FulltextMatches(queryParts, x.ToString())).ToArray();

        _listBox.Items.Clear();
        _listBox.Items.AddRange(newValueList);
    }

    private bool FulltextMatches(string[] queryParts, string? value)
    {
        if (queryParts.Length == 0)
            return true;

        if (string.IsNullOrWhiteSpace(value))
            return false;

        var valueAsLowercase = value.ToLower();

        foreach (var part in queryParts)
        {
            if (!valueAsLowercase.Contains(part))
                return false;
        }

        return true;
    }

    private void SearchBoxOnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyData == Keys.Up)
        {
            if (_listBox.SelectedIndex > 0)
            {
                _listBox.SelectedIndex -= 1;
                e.Handled = true;
            }
        }

        if (e.KeyData == Keys.Down)
        {
            if (_listBox.SelectedIndex < _listBox.Items.Count - 1)
            {
                _listBox.SelectedIndex += 1;
                e.Handled = true;
            }
        }
    }
}