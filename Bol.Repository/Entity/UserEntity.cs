using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Mysql;

namespace Bol.Repositorys.Entity
{
    [Table("tbl_user")]
    public class UserEntity: BaseEntity
    {
        [Column("user_name",TypeName = "varchar(20)")]
        public string UserName { get; set; }

        [Column("nick_name", TypeName = "varchar(64)")]
        public string NickName { get; set; }

        [Column("state", TypeName = "int(4)")]
        public int State { get; set; }
    }
}
