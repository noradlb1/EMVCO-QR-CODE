using System.Collections.Generic;

namespace EMVCO_QR_CODE
{
    public class ListBankId
    {
        //Chi tiết danh sách ở đây: https://developers.momo.vn/v3/docs/payment/api/result-handling/bankcode/
        public static List<BankID> GetList()
        {
            var lst = new List<BankID>();
            lst.Add(new BankID() { Name = "VietcomBank", Id = "970436" });
            lst.Add(new BankID() { Name = "VietinBank", Id = "970415" });
            lst.Add(new BankID() { Name = "Techcombank", Id = "970407" });
            lst.Add(new BankID() { Name = "BIDV", Id = "970418" });
            lst.Add(new BankID() { Name = "AgriBank", Id = "970405" });
            lst.Add(new BankID() { Name = "ACB", Id = "970416" });
            lst.Add(new BankID() { Name = "MBBank", Id = "970422" });
            lst.Add(new BankID() { Name = "SHB", Id = "970443" });
            lst.Add(new BankID() { Name = "Sacombank", Id = "970403" });
            return lst;
        }
    }

    public class BankID
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
