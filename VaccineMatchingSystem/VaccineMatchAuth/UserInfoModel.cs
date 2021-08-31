using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineMatchAuth
{
    public class UserInfoModel
    {
        #region 帳號下轄參數

        public Guid UserID { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string Area { get; set; }
        public string ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int DoseCount { get; set; }

        #endregion
    }
}
