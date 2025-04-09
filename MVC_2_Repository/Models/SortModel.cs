namespace MVC_2_Repository.Models
{
    public class SortModel
    {
        public string SortedProperty { get; set; }
        public SortOrder SortedOrder { get; set; }

        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

        public void AddColumn(string columnName)
        {
            SortableColumn sortableColumn = sortableColumns.Where(c => c.ColumnName.ToLower() == columnName.ToLower()).SingleOrDefault();

            if (sortableColumn == null)
                sortableColumns.Add(new SortableColumn { ColumnName = columnName});
        }

        public SortableColumn GetColumn(string columnName)
        {
            SortableColumn sortableColumn = sortableColumns.Where(c => c.ColumnName.ToLower() == columnName.ToLower()).SingleOrDefault();

            if (sortableColumn == null)
                sortableColumns.Add(new SortableColumn { ColumnName = columnName });

            return sortableColumn;
        }

        public void ApplySort(string sortExpression)
        {
            //ViewData["SortParamName"] = "name";
            //ViewData["SortParamDesc"] = "description";

            //ViewData["SortIconName"] = "";
            //ViewData["SortIconDesc"] = "";

            GetColumn("name").SortIcon = "";
            GetColumn("name").SortExpression = "name";

            GetColumn("description").SortIcon = "";
            GetColumn("description").SortExpression = "description";

            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    this.SortedOrder = SortOrder.Descending;
                    this.SortedProperty = "name";
                    GetColumn("name").SortExpression = "name";
                    GetColumn("name").SortIcon = "fa fa-arrow-up";
                    break;
                case "description":
                    this.SortedOrder = SortOrder.Ascending;
                    this.SortedProperty = "description";
                    GetColumn("description").SortExpression = "description_desc";
                    GetColumn("description").SortIcon = "fa fa-arrow-down";
                    break;
                case "description_desc":
                    this.SortedOrder = SortOrder.Descending;
                    this.SortedProperty = "description";
                    GetColumn("description").SortExpression = "description";
                    GetColumn("description").SortIcon = "fa fa-arrow-up";
                    break;
                default:
                    this.SortedOrder = SortOrder.Ascending;
                    this.SortedProperty = "name";
                    GetColumn("name").SortExpression = "name_desc";
                    GetColumn("name").SortIcon = "fa fa-arrow-down";
                    break;
            }
        }
    }
}
