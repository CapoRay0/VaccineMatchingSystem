using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmData
{
    //使用者的model
    public class UserInfo
    {
        //名字
        public string Name { get; set; } = "TempGuest";
        //性別
        public int Gender { get; set; } = 0;
        //年齡
        public int Age { get; set; } = 30;
        //職業(廢棄)
        //public string Occupation { get; set; } 
        //職業
        public string Job { get; set; }
        //地區
        public string Area { get; set; }
        //狀態
        public string[] Status { get; set; }
        //打了第幾劑
        public int DoseCount { get; set; } = 0;
        //public Dictionary<string, bool> VaccineWilling { get; set; }
    }

    //演算法參數的model
    public class AlgorithmParameter
    {
        //目標年齡層-底(預設0)
        public int age_targetAgeButtom { get; set; } = 0;
        //目標年齡層-頂(預設100)
        public int age_targetAgeTop { get; set; } = 100;
        //小的先/老的先(0/1)(預設1)
        public int age_direction { get; set; } = 1;
        //職業權重表
        public Dictionary<string, double> job_dict { get; set; }
        //狀態權重表
        public Dictionary<string, double> state_dict { get; set; }
        //疫苗所在地區
        public string area_area { get; set; }
        //讓要打第n劑的先
        public int ordinal_dict { get; set; } = 1;
    }

    public class CityModel
    {
        //地區的結構(創建地區)
        public static List<string[]> CreateCityModel()
        {
            //定義各區下轄縣市
            string[] listNorth = { "台北", "新北", "桃園", "基隆", "新竹", "苗栗" };
            string[] listWest = { "台中", "彰化", "南投" };
            string[] listSouth = { "雲林", "嘉義", "台南", "高雄", "屏東" };
            string[] listEast = { "宜蘭", "花蓮", "台東" };
            string[] listOut = { "離島" };
            //加入list
            List<string[]> Area = new List<string[]> { listNorth, listWest, listSouth, listEast, listOut };
            //丟出
            return Area;
        }
    }
}
