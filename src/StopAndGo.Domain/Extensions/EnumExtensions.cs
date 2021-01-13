using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nymbus.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string ColumnName(this Enum value)
        {
            if (value == null) return null;

            var enumType = value.GetType();
            var field = enumType.GetField(Enum.GetName(enumType, value));
            var attr = (ColumnAttribute) Attribute.GetCustomAttribute(field, typeof(ColumnAttribute));
            return attr != null ? attr.Name : value.ToString();
        }
    }
}
