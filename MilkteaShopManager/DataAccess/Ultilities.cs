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

        public static string GetUncheckBillIdByTableId = "GetUncheckBillIdByTableId";

        public static string GetListDrinkDetailsByTableId = "GetListDrinkDetailsByTableId";
        public static string GetListDrinkByCategoryId = "GetListDrinkByCategoryId";
        public static string GetListCategory = "GetListCategory";

        public static string Insert_Bill = "Insert_Bill";
        public static string InsertBillInfoForTable = "InsertBillInfoForTable";
        public static string GetMaxBillId = "GetMaxBillId";
        public static string CheckOut = "CheckOut";
        public static string SwitchTable = "SwitchTable";
        public static string MergeTable = "MergeTable";
        public static string ShowBillInTheDay = "ShowBillInTheDay";
        public static string GetListBillByDate = "GetListBillByDate";
    }
}
