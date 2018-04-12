using System;


namespace Fonlow.Poco2Client
{
    /// <summary>
    /// Flagged options for cherry picking in various development processes.
    /// </summary>
    [Flags]
    public enum CherryPickingMethods
    {
        /// <summary>
        /// 包括所有公共类，属性和属性
        /// </summary>
        All = 0,

        /// <summary>
        /// 包括由DataContractAttribute装饰的所有公共类以及由DataMemberAttribute装饰的公共属性或字段。
        ///并使用DataMemberAttribute.IsRequired
        /// </summary>
        DataContract = 1,

        /// <summary>
        /// 包括由JsonObjectAttribute装饰的所有公共类，以及由JsonPropertyAttribute装饰的公共属性或字段。
        ///并使用JsonPropertyAttribute.Required
        /// </summary>
        NewtonsoftJson = 2,

        /// <summary>
        /// 包含由SerializableAttribute装饰的所有公共类，以及所有公共属性或字段，但不包括由NonSerializedAttribute装饰的公共属性。
        ///并使用System.ComponentModel.DataAnnotations.RequiredAttribute
        /// </summary>
        Serializable = 4,

        /// <summary>
        /// 包括所有公共类，属性和属性。
        ///并使用System.ComponentModel.DataAnnotations.RequiredAttribute。
        /// </summary>
        AspNet = 8,
    }

    /// <summary>
    /// How significant the cherry is
    /// </summary>
    public enum CherryType
    {
        None,

        Cherry,
        BigCherry,
    }

}
