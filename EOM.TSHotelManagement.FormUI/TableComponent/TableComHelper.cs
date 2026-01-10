using AntdUI;
using EOM.TSHotelManagement.Common;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace EOM.TSHotelManagement.FormUI
{
    public class TableComHelper
    {
        private XDocument _xmlDoc;

        public TableComHelper(string resourceType = ".xml", string? specificFileName = null)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                string[] resourceNames = assembly.GetManifestResourceNames();

                // 根据传入的参数筛选资源
                string? resourceName = null;

                if (!string.IsNullOrEmpty(specificFileName))
                {
                    // 如果有特定的文件名，精确匹配
                    resourceName = resourceNames.FirstOrDefault(name =>
                        name.EndsWith(specificFileName, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    // 否则根据资源类型筛选
                    resourceName = resourceNames.FirstOrDefault(name =>
                        name.EndsWith(resourceType, StringComparison.OrdinalIgnoreCase) ||
                        name.Contains(resourceType, StringComparison.OrdinalIgnoreCase));
                }

                if (string.IsNullOrEmpty(resourceName))
                {
                    // 如果没有找到，尝试其他常见名称模式
                    if (resourceType.ToLower() == ".xml")
                    {
                        resourceName = resourceNames.FirstOrDefault(name =>
                            name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) ||
                            name.Contains("Contract.xml") ||
                            name.Contains(".contract."));
                    }
                }

                if (string.IsNullOrEmpty(resourceName))
                {
                    // 记录可用的资源名称以便调试
                    var availableResources = string.Join(", ", resourceNames);
                    throw new FileNotFoundException($"未找到指定的嵌入资源。资源类型: {resourceType}, 特定文件名: {specificFileName}。可用资源: {availableResources}");
                }

                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                        throw new FileNotFoundException($"无法加载资源流: {resourceName}");

                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        _xmlDoc = XDocument.Load(reader);
                        Console.WriteLine($"成功加载嵌入资源: {resourceName}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("无法加载嵌入的XML内容", ex);
            }
        }

        /// <summary>
        /// 转换字段为AntdUI Table组件的Column类型
        /// </summary>
        /// <param name="tableColumns"></param>
        /// <returns></returns>
        public ColumnCollection ConvertToAntdColumns(List<TableColumn> tableColumns)
        {
            var columnCollection = new ColumnCollection();

            foreach (var tableColumn in tableColumns)
            {
                var column = new Column(
                    tableColumn.Field,                 // 列名
                    tableColumn.Description,              // 列标题
                    ColumnAlign.Center                // 对齐方式
                )
                {
                    Visible = tableColumn.Visible,
                    SortOrder = true,
                    Align = ColumnAlign.Center,
                    ColAlign = ColumnAlign.Center,
                    LineBreak = true
                };

                columnCollection.Add(column);
            }

            return columnCollection;
        }

        /// <summary>
        /// 转换字段为AntdUI Table组件的AntItem类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <returns></returns>
        public List<AntdUI.AntItem[]> ConvertToAntdItems<T>(List<T> datas)
        {
            var listTableData = new List<AntdUI.AntItem[]>();
            var properties = typeof(T).GetProperties();

            foreach (var data in datas)
            {
                var antItems = new List<AntdUI.AntItem>();

                foreach (var prop in properties)
                {
                    var displayAttribute = prop.GetCustomAttribute<UIDisplayAttribute>();

                    if (displayAttribute == null)
                    {
                        continue;
                    }

                    var propName = prop.Name;
                    var propValue = prop.GetValue(data);
                    var propType = prop.PropertyType;

                    if (propType == typeof(bool) || propType == typeof(int))
                    {
                        if (displayAttribute.IsNumber)
                        {
                            antItems.Add(new AntdUI.AntItem(propName, propValue?.ToString()));
                        }
                        else
                        {
                            var boolValue = Convert.ToBoolean(propValue);
                            var cellTag = boolValue ? new AntdUI.CellTag("是", AntdUI.TTypeMini.Error) : new AntdUI.CellTag("否", AntdUI.TTypeMini.Success);
                            antItems.Add(new AntdUI.AntItem(propName, cellTag));
                        }
                    }
                    else if (propType == typeof(string))
                    {
                        antItems.Add(new AntdUI.AntItem(propName, propValue?.ToString()));
                    }
                    else if (propType == typeof(DateTime))
                    {
                        var dateValue = (DateTime)propValue;

                        if (dateValue.Hour == 0 && dateValue.Minute == 0 && dateValue.Second == 0)
                        {
                            antItems.Add(new AntdUI.AntItem(propName, dateValue.ToString("yyyy-MM-dd")));
                        }
                        else
                        {
                            antItems.Add(new AntdUI.AntItem(propName, dateValue.ToString("yyyy-MM-dd HH:mm:ss")));
                        }
                    }
                    else if (propType == typeof(decimal))
                    {
                        var decimalValue = Convert.ToDecimal(propValue);
                        antItems.Add(new AntdUI.AntItem(propName, Math.Round(decimalValue, 2)));
                    }
                    else
                    {
                        antItems.Add(new AntdUI.AntItem(propName, propValue?.ToString()));
                    }
                }

                listTableData.Add(antItems.ToArray());
            }
            return listTableData;
        }

        public string GetValue(IList<AntdUI.AntItem> items, string key)
        {
            var item = items.SingleOrDefault(x => x.key == key);
            if (item == null || item.value == null)
            {
                return string.Empty;
            }
            return item.value?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// 获取实体字段名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<TableColumn> GenerateDataColumns<T>() where T : class
        {
            var tableColumns = new List<TableColumn>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // 获取 UIDisplay 特性
                var displayAttribute = property.GetCustomAttribute<UIDisplayAttribute>();

                // 如果没有 UIDisplay 特性，则跳过
                if (displayAttribute == null)
                {
                    continue;
                }
                var propertyName = property.Name;
                string comment;
                try
                {
                    comment = GetPropertyComment(_xmlDoc, typeof(T).FullName, propertyName);
                }
                catch (Exception ex)
                {
                    comment = $"注释获取失败: {ex.Message}";
                }

                tableColumns.Add(new TableColumn(propertyName, displayAttribute.DisplayName ?? comment, displayAttribute.IsVisible));
            }

            return tableColumns;
        }

        /// <summary>
        /// 获取字段对应注释
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="typeName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string GetPropertyComment(XDocument xmlDoc, string typeName, string propertyName)
        {
            var propertyNameInXml = $"{typeName}.{propertyName}";
            var commentElement = xmlDoc
                .Descendants("member")
                .FirstOrDefault(x => x.Attribute("name")?.Value == $"P:{propertyNameInXml}")
                ?.Descendants("summary")
                .FirstOrDefault();

            return commentElement?.Value.Trim() ?? "No comment";
        }

        /// <summary>
        /// 表字段
        /// </summary>
        public class TableColumn
        {
            public TableColumn(string field, string description, bool visible = true)
            {
                Field = field;
                Description = description;
                Visible = visible;
            }

            public string Field { get; set; }
            public string Description { get; set; }
            public bool Visible { get; set; } = true;
        }
    }
}
