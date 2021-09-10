﻿using AlgorithmData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.BackEndPages.SystemAdminPages
{
    public partial class UserMatchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["vaccName"] = null;
            Session["vaccNum"] = null;
            Session["vaccID"] = null;
            #region 抓取已匹配之疫苗by選擇疫苗名
            if (ddlVaccName.Items.Count == 1)
            {
                DataTable availableVacc = MatchManager.GetAvailableVaccName(1);
                foreach (DataRow item in availableVacc.Rows)
                {
                    ddlVaccName.Items.Add(item[0].ToString());
                }
            }
            #endregion
        }

        /// <summary>
        /// 抓取選中之疫苗名，show出批次選擇
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetVaccData_Click(object sender, EventArgs e)
        {
            //DataTable ds = ExcelDataManager.GetCurrentVaccInfo();
            //this.RepeaterShowVacc.DataSource = ds;
            //this.RepeaterShowVacc.DataBind();

            if (ddlVaccName.SelectedIndex != 0)
            {
                Session["vaccName"] = ddlVaccName.SelectedItem.Text;
                //以疫苗名抓取 已 匹配的疫苗批次
                DataTable availableVacc = MatchManager.GetAvailableVaccBatch((string)Session["vaccName"], 1);
                int counter = 0;
                foreach (DataRow item in availableVacc.Rows)
                {
                    ddlVaccBatch.Items.Add("第" + item[0].ToString() + "批次");
                    ddlVaccBatch.Items[counter].Value = item[0].ToString();
                    counter++;
                }
                ddlVaccBatch.Visible = true;
                btnGetVaccData.Visible = true;
                btnGetVaccDataCancel.Visible = true;
                btnGetVaccName.Visible = false;
            }
        }

        /// <summary>
        /// 查詢DB內的演算法參數，展開演算法參數填寫區
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetVaccData_Click1(object sender, EventArgs e)
        {
            Session["vaccName"] = ddlVaccName.SelectedItem.Text;
            int vaccBatch = Convert.ToInt32(ddlVaccBatch.SelectedItem.Value);
            DataRow dataRow = MatchManager.GetVaccIDAndNumByBatch((string)Session["vaccName"], vaccBatch, 1);
            Session["vaccID"] = (Guid)dataRow[0];
            Session["vaccNum"] = (int)dataRow[1];

            //取得演算法流水號
            int algID = MatchManager.GetAlgID((Guid)dataRow[0]);
            //以演算法流水號取得配對結果紀錄表
            DataTable matchResult = MatchManager.GetMatchingRecord(algID);


            this.GridViewMatchResult.DataSource = matchResult;
            this.GridViewMatchResult.DataBind();


            btnGetVaccData.Visible = false;
        }

        protected void btnGetVaccDataCancel_Click(object sender, EventArgs e)
        {
            btnGetVaccName.Visible = true;
            Response.Redirect(this.Request.RawUrl);
        }

        protected void btnVaccineMatch_Click(object sender, EventArgs e)
        {
            Response.Redirect("VaccineMatch.aspx");
        }


    }
}