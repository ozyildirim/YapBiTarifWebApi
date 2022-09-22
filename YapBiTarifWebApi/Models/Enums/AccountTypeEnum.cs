using System.ComponentModel;

namespace YapBiTarifWebApi.Models.Enums
{
    public enum AccountTypeEnum
    {
        /// <summary>
        /// Admin
        /// </summary>
        [Description("Admin")]
        Admin = 1,

        /// <summary>
        /// Editor
        /// </summary>
        [Description("Editor")]
        Editor = 2,

        /// <summary>
        /// SimpleUser
        /// </summary>
        [Description("SimpleUser")]
        SimpleUser = 3,
    }
}
