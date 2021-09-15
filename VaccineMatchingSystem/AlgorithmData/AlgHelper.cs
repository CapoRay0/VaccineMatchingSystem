using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmData
{
    public class AlgHelper
    {
        #region 計算總分
        /// <summary>
        /// 計算總分
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="algP"></param>
        /// <returns></returns>
        public static double GetTotalScore(UserInfo userInfo, AlgorithmParameter algP)
        {
            //計算年齡
            int ansAge = GetAgeScore(userInfo.Age, algP.age_direction, algP.age_targetAgeButtom, algP.age_targetAgeTop);
            //計算職業
            double ansJob = GetJobScore(userInfo.Job, algP.job_dict);
            //計算狀態
            double ansState = GetStateWeight(userInfo.Status, algP.state_dict);
            //計算計次
            int ansOrdinal = GetOrdinalScore(userInfo.DoseCount, algP.ordinal_dict);
            //計算地區
            var Area = CityModel.CreateCityModel();
            var ansArea = GetAreaScore(userInfo.Area, algP.area_area, Area);

            //給出總分
            return (ansAge + ansJob + ansOrdinal) * ansState * ansArea;
        }
        #endregion


        #region 計算個別分數
        /// <summary>
        /// 計算年齡分數
        /// </summary>
        /// <param name="age">民眾年齡</param>
        /// <param name="targetAgeButtom">目標年齡層-底(預設0)</param>
        /// <param name="targetAgeTop">目標年齡層-頂(預設100)</param>
        /// <param name="_direction">小的先/老的先(0/1)(預設1)</param>
        /// <param name="limit">滿分(預設100)</param>
        /// <returns></returns>
        public static int GetAgeScore(int age, int direction, int targetAgeButtom = 0, int targetAgeTop = 100, int limit = 100)
        {
            int answer = 0;
            if (age >= targetAgeButtom && age <= targetAgeTop)
            {
                switch (direction)
                {
                    case 0:
                        answer = limit - (age - targetAgeButtom);
                        break;
                    case 1:
                        answer = limit - (targetAgeTop - age);
                        break;
                    default:
                        break;
                }
            }
            else if (age > targetAgeTop)
            {
                switch (direction)
                {
                    case 0:
                        answer = limit - age + 1;
                        break;
                    case 1:
                        //answer = 100 - (targetAgeTop - targetAgeButtom) - (100 - age);
                        answer = targetAgeButtom - targetAgeTop + age - 1;
                        break;
                    default:
                        break;
                }
            }
            else if (age < targetAgeButtom)
            {
                switch (direction)
                {
                    case 0:
                        answer = 100 - (targetAgeTop - targetAgeButtom) - age;
                        break;
                    case 1:
                        answer = age;
                        break;
                    default:
                        break;
                }
            }

            return answer;
        }

        /// <summary>
        /// 計算職業分數
        /// </summary>
        /// <param name="job">民眾職業</param>
        /// <param name="job_dict">職業權重表</param>
        ///  /// <param name="limit">預設值(預設為滿)</param>
        /// <returns></returns>
        public static double GetJobScore(string job, Dictionary<string, double> job_dict, int limit = 100)
        {
            //如果有對應到指定職業，則分數*權重
            if (true == job_dict.ContainsKey(job))
            {
                double ans = job_dict[job] * limit;
                return ans;
            }
            else
            {
                return limit;
            }

        }

        /// <summary>
        /// 計算特殊狀態權重
        /// </summary>
        /// <param name="state">民眾特殊狀態</param>
        /// <param name="state_dict">特殊狀態權重表</param>
        /// <returns></returns>
        public static double GetStateWeight(string[] state, Dictionary<string, double> state_dict)
        {
            //如果有對應到指定狀態，則給出權重，重複者相乘
            double ans = 1;
            foreach (var item in state)
            {
                if (state_dict.ContainsKey(item))
                {
                    ans *= state_dict[item];
                }
            }

            return ans;
        }

        /// <summary>
        /// 計算計次分數
        /// </summary>
        /// <param name="DoseCount">民眾打了n劑</param>
        /// <param name="ordinal_dict">讓要打第n劑的先</param>
        /// ///  /// <param name="limit">預設值</param>
        /// <returns></returns>
        public static int GetOrdinalScore(int DoseCount, int ordinal_dict = 1, int limit = 100)
        {
            //補正: 民眾打了n劑-匹配-現在要打第n+1劑
            DoseCount++;
            //每相差一個劑次，就少5%優先度
            return limit - (Math.Abs(ordinal_dict - DoseCount) * (limit / 20));
        }

        /// <summary>
        /// 計算地區分數
        /// </summary>
        /// <param name="queryCity">民眾的縣市</param>
        /// <param name="targetCity">疫苗的縣市</param>
        /// <param name="Area">地區模組(在TryAlg.CityModel.CreateCityModel)</param>
        /// <returns></returns>
        public static double GetAreaScore(string queryCity, string targetCity, List<string[]> Area)
        {
            int? targetArea = null;
            int? queryArea = null;

            //如果同縣市就滿分
            if (queryCity == targetCity)
                return 1;

            //foreach (var cityList in Area)
            for (int i = 0; i < Area.Count; i++)
            {
                foreach (var city in Area[i])
                {
                    //找targetCity是哪區，找到給區域的碼(第n輪)
                    if (targetCity == city)
                    {
                        targetArea = i;
                    }
                    //找queryCity是哪區，找到給區域的碼(第n輪)
                    if (queryCity == city)
                    {
                        queryArea = i;
                    }
                }
            }

            //如果區域找不到說明輸入有問題
            if (targetArea == null || queryArea == null)
                return 0;

            //不同縣市則比對兩個區域是不是一樣，一樣就是同區不同市
            if (targetArea == queryArea)
                return 0.95;

            return 0.9;
        }
        #endregion
    }
}
