using System.Text;

namespace EMVCO_QR_CODE
{
    public class EMVCO
    {
        private string _bankid;
        private string _sotaikhoan;
        private string _sotien;
        private string _noidung;

        public EMVCO(string bankId, string sotaikhoan, string sotien, string noidung)
        {
            _bankid = bankId;
            _sotaikhoan = sotaikhoan;
            _sotien = sotien;
            _noidung = noidung;
        }
        public string GetData
        {
            get
            {
                string _pre_Crc = _Consumer_Account_Information;
                string _calc_Crc = Crc16Ccitt(_pre_Crc);
                return $"{_pre_Crc}{_calc_Crc}";
            }
        }

        private string _Consumer_Account_Information
        {
            get
            {
                string _pre_bankid = $"000{_bankid.Length}{_bankid}"; //bank id
                string _pre_sotaikhoan = $"01{_sotaikhoan.Length}{_sotaikhoan}"; // so tai khoan
                string _pre_bankid_sotaikhoan = $"01{_pre_bankid.Length + _pre_sotaikhoan.Length}{_pre_bankid}{_pre_sotaikhoan}";
                string _content = $"0010A000000727{_pre_bankid_sotaikhoan}0208QRIBFTTA"; //napas247 -> account number

                _content = $"38{_content.Length}{_content}";
                _content = $"000201010212{_content}";
                _content = $"{_content}5303704"; //vnd
                _content = $"{_content}54{((_sotien.Length > 9) ? "" + _sotien.Length : "0" + _sotien.Length)}{_sotien}"; //so tien
                _content = $"{_content}5802VN"; //quoc gia
                int _nd = _noidung.Length;
                _content = $"{_content}62{_nd + 4:00}08{_nd:00}{_noidung}6304"; //noi dung
                return _content;
            }
        }


        //CRC - Checksum được tính theo ISO/IEC 13239 bằng cách
        //sử dụng đa thức '1021' (hex) và giá trị ban đầu 'FFFF' (hex)
        private string Crc16Ccitt(string strInput)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(strInput);
            const ushort poly = 4129;
            ushort[] table = new ushort[256];
            ushort initialValue = 0xffff;
            ushort temp, a;
            ushort crc = initialValue;
            for (int i = 0; i < table.Length; ++i)
            {
                temp = 0;
                a = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((temp ^ a) & 0x8000) != 0)
                        temp = (ushort)((temp << 1) ^ poly);
                    else
                        temp <<= 1;
                    a <<= 1;
                }
                table[i] = temp;
            }
            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ table[((crc >> 8) ^ (0xff & bytes[i]))]);
            }
            return crc.ToString("X");
        }


    }
}
