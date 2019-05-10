using System.ServiceModel.Channels;

namespace BerryCore.WCF.BaseBehavior
{
    /// <summary>
    /// 返回用于指定内容类型的消息格式
    /// </summary>
    public class JsonContentTypeMapper : WebContentTypeMapper
    {
        /// <summary>在派生类中重写时,返回用于指定内容类型的消息格式。</summary>
        /// <returns>
        /// <see cref="T:System.ServiceModel.Channels.WebContentFormat" />,指定将消息内容类型映射到的格式。</returns>
        /// <param name="contentType">用于指示要解释的数据为 MIME 类型的内容类型。</param>
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            if (contentType == "application/json")
            {
                return WebContentFormat.Json;
            }
            else
            {
                return WebContentFormat.Default;
            }
        }
    }
}