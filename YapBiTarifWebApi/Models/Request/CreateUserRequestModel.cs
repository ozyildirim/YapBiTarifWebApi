using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YapBiTarifWebApi.Models.Enums;

namespace YapBiTarifWebApi.Models.Request
{
    public class CreateUserRequestModel
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public AccountTypeEnum? AccountType { get; set; }
    }
}
