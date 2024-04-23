using sale_app.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace sale_app.Utils
{
    public class NumberComon
    {
        private static NumberComon instance;

        public static NumberComon Instance
        {
            get { if (instance == null) instance = new NumberComon(); return NumberComon.instance; }
            private set => NumberComon.instance = value;
        }

        private NumberComon() { }

        public string ConvertToCurrency(int number)
        {
            return string.Format("{0:#,##0}", number);
        }
        public int ConvertToInteger(string input)
        {
            // Loại bỏ dấu chấm và dấu phẩy phân tách hàng nghìn
            string cleanInput = input.Replace(".", "").Replace(",", "");

            // Thực hiện phân tích chuỗi thành số nguyên
            if (int.TryParse(cleanInput, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out int number))
            {
                return number;
            }
            else
            {
                return -1; // Trả về -1 nếu không thể chuyển đổi
            }
        }
    }
}
