using System;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace SurperSocket.Core
{
    /// <summary>
    /// 自定义扩展
    /// </summary>
    public static class CustomExtension
    {
        /// <summary>
        /// 返回枚举项的描述信息
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项</param>
        /// <returns>枚举想的描述信息</returns>
        public static string GetDescription(this Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return "无说明信息。";
        }

        /// <summary>
        /// 对象序列化成Json字符串
        /// </summary>
        /// <param name="obj">需要序列化的对象</param>
        /// <param name="isIgnoreNullValue">是否忽略值为NULL的属性，默认false</param>
        /// <param name="dateFormatString">自定义日期格式化字符串</param>
        /// <param name="hasIpEndPoint">是否包含IP地址（IPEndPoint类型）</param>
        /// <param name="hasFormat">是否需要格式化Json字符串</param>
        /// <returns></returns>
        public static string TryToJson(this object obj, bool isIgnoreNullValue = false, string dateFormatString = "", bool hasIpEndPoint = false, bool hasFormat = false)
        {
            JsonSerializerSettings jsetting = new JsonSerializerSettings();

            JsonConvert.DefaultSettings = () =>
            {
                //日期类型默认格式化处理
                //不做转换，在属性上添加：[JsonConverter(typeof(IsoDateTimeConverter))]
                jsetting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;

                //自定义日期格式化字符串
                if (!string.IsNullOrEmpty(dateFormatString))
                {
                    //yyyy-MM-dd HH:mm:ss
                    jsetting.DateFormatString = dateFormatString;
                }

                //空值处理,忽略值为NULL的属性
                if (isIgnoreNullValue)
                {
                    jsetting.NullValueHandling = NullValueHandling.Ignore;
                }
                
                return jsetting;
            };

            string res = JsonConvert.SerializeObject(obj, hasFormat ? Formatting.Indented : Formatting.None, jsetting);

            return res;
        }
    }
}