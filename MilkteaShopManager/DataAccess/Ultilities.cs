using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class Ultilities
    {
        private static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        public static string LoaiNuoc_GetAll = "LoaiNuoc_GetAll";
        public static string LoaiNuoc_InsertUpdateDelete = "LoaiNuoc_InsertUpdateDelete";

        public static string NuocUong_GetAll = "NuocUong_GetAll";
        public static string NuocUong_InsertUpdateDelete = "NuocUong_InsertUpdateDelete";

        public static string Table_GetAll = "Table_GetAll";
    }
}
