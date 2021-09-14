using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;
using VaccineMatchDBSource;
using static VaccineMatchDBSource.AccountingManager;

namespace VaccineMatchingSystem.BackEndPages.GeneralUserPages
{
    public partial class WillingVaccination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/FrontEndPages/Login.aspx");
                return;
            }

            var CurrentUser = AuthManager.GetCurrentUser();
            Guid CurrentUserGuid = CurrentUser.UserID;


            if (CurrentUser.Gender == 1)
            {
                this.lblTitleShow.Text = $"{CurrentUser.Name}先生您好";
            }
            else if (CurrentUser.Gender == 2)
            {
                this.lblTitleShow.Text = $"{CurrentUser.Name}小姐您好";
            }




            if (!IsPostBack)
            {
                if (!AccountingManager.CheckSingleWillingIsNull(CurrentUserGuid, "AZ"))
                    this.CheckBoxVaccAZ.Checked = true;
                else
                    this.CheckBoxVaccAZ.Checked = false;


                if (!AccountingManager.CheckSingleWillingIsNull(CurrentUserGuid, "Moderna"))
                    this.CheckBoxVaccMoz.Checked = true;
                else
                    this.CheckBoxVaccMoz.Checked = false;


                if (!AccountingManager.CheckSingleWillingIsNull(CurrentUserGuid, "BNT"))
                    this.CheckBoxVaccBNT.Checked = true;
                else
                    this.CheckBoxVaccBNT.Checked = false;


                this.cblNewVName.DataSource = GetRoleList();
                this.cblNewVName.DataBind();


                List<string> NewVaccineList = new List<string>();
                foreach (ListItem li in this.cblNewVName.Items)
                {
                    //if (li.Selected)
                    NewVaccineList.Add(li.Value);
                }

                if (NewVaccineList.Count > 0)
                {
                    for (int i = 0; i <= NewVaccineList.Count - 1; i++)
                    {
                        if (!AccountingManager.CheckSingleWillingIsNull(CurrentUserGuid, NewVaccineList[i]))
                            this.cblNewVName.Items[i].Selected = true;
                        else
                            this.cblNewVName.Items[i].Selected = false;
                    }

                }
            }




        }


        /// <summary> 動態加入新的疫苗 (透過 VaccineInventory 資料表)</summary>
        /// <returns></returns>
        public static List<Vaccination> GetRoleList()
        {
            try
            {
                var dt = AccountingManager.EveryVName();
                List<Vaccination> VaccineName = new List<Vaccination>();
                foreach (DataRow dr in dt.Rows)
                {
                    Vaccination item = new Vaccination();
                    //item.VGUID = dr.Field<Guid>("VGUID");
                    item.VName = dr.Field<string>("VName");
                    //item.Quantity = dr.Field<int>("Quantity");
                    //item.VBatch = dr.Field<int>("VBatch");
                    //item.IsMatched = dr.Field<int>("IsMatched");

                    VaccineName.Add(item);
                }

                VaccineName.RemoveAll(VN => VN.VName == "AZ");
                VaccineName.RemoveAll(VN => VN.VName == "Moderna");
                VaccineName.RemoveAll(VN => VN.VName == "BNT");

                return VaccineName;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex);
                return null;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var CurrentUser = AuthManager.GetCurrentUser();
            Guid CurrentUserGuid = CurrentUser.UserID;

            List<string> NewVaccineList = new List<string>();
            foreach (ListItem li in this.cblNewVName.Items)
            {
                if (li.Selected)
                    NewVaccineList.Add(li.Value);
            }



            //// 測試用
            //if (NewVaccineList.Count > 0)
            //{
            //    for (int i = 0; i <= NewVaccineList.Count - 1; i++)
            //    {
            //        Label1.Text = "";
            //        Label1.Text += NewVaccineList[i].ToString() + "<br />";
            //    }
            //}

            bool check = true;
            for (int i = 0; i <= NewVaccineList.Count - 1; i++)
            {
                if (this.cblNewVName.Items[i].Selected == true)
                    check = false;
            }


            if (!CheckBoxVaccAZ.Checked && !CheckBoxVaccMoz.Checked && !CheckBoxVaccBNT.Checked && check)
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('請點選願意施打的疫苗')</script>");


            if (!AccountingManager.CheckWillingIfChecked(CurrentUserGuid))
            {
                if (CheckBoxVaccAZ.Checked)
                    AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, "AZ");


                if (CheckBoxVaccMoz.Checked)
                    AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, "Moderna");


                if (CheckBoxVaccBNT.Checked)
                    AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, "BNT");


                if (NewVaccineList.Count > 0) // 動態加入新的疫苗意願
                {
                    for (int i = 0; i <= NewVaccineList.Count - 1; i++)
                    {
                        AccountingManager.InsertUserWillingVaccin(CurrentUserGuid, NewVaccineList[i]);
                    }
                }


                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('恭喜您，疫苗登記成功!!')</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('本批次已完成登記，欲更改請先取消')</script>");
            }

        }



        protected void btnReject_Click(object sender, EventArgs e)
        {
            
            var CurrentUser = AuthManager.GetCurrentUser();

            Guid CurrentUserGuid = CurrentUser.UserID;

            if (!MatchManager.CheckWillingIsNull(CurrentUserGuid))
            {
                MatchManager.DeleteWilling(CurrentUserGuid);
                var self = this.Request.RawUrl;
                //this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已將您的預約取消')</script>");
                Response.Write($"<Script language='JavaScript'>alert('已將您的預約取消'); location.href='{self}'; </Script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('尚無預約紀錄')</script>");
            }

        }
    }
}