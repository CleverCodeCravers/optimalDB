using System.ComponentModel;

namespace optimalDb.WinForms.GridExtras
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSortedValue;
        ListSortDirection _sortDirectionValue;
        PropertyDescriptor _sortPropertyValue;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IList<T> list)
        {
            foreach (object o in list)
            {
                this.Add((T)o);
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null)
            {
                _sortPropertyValue = prop;
                _sortDirectionValue = direction;

                IEnumerable<T> query = base.Items;

                if (direction == ListSortDirection.Ascending)
                {
                    query = query.OrderBy(i => prop.GetValue(i));
                }
                else
                {
                    query = query.OrderByDescending(i => prop.GetValue(i));
                }

                int newIndex = 0;
                foreach (object item in query)
                {
                    this.Items[newIndex] = (T)item;
                    newIndex++;
                }

                _isSortedValue = true;
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortPropertyValue; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirectionValue; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return _isSortedValue; }
        }
    }
}