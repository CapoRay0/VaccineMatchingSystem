using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VaccineMatchAuth;
using VaccineMatchDBSource;

namespace VaccineMatchingSystem.FrontEndPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//判斷頁面是不是第一次顯示
            {
                this.lblCode.Text = RandomCode(5);

                Session.RemoveAll();
                txtAccount.Text = "";
                txtPWD.Text = "";
            }

        }

        protected void btnForgetPWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPWD.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inp_Account = this.txtAccount.Text; // inp 為 input
            string inp_PWD = this.txtPWD.Text;
            string msg;
            if (!AuthManager.TryLogin(inp_Account, inp_PWD, out msg))
            {
                this.ltlMsg.Text = msg;
                return;
            }
            else
            {
                if (this.txtConfirmCode.Text.Trim() != lblCode.Text)
                {
                    this.ClientScript.RegisterStartupScript
                        (this.GetType(), "", "<script>alert('驗證碼不正確')</script>");
                    return;
                }
                else
                {
                    if (inp_Account == inp_PWD)
                    {
                        Response.Redirect("ChangePWD.aspx");
                    }
                    else
                    {
                        var dr = UserInfoManager.GetAccountUserLevel(inp_Account);
                        if (dr == 0)
                        {
                            Response.Redirect("/BackEndPages/SystemAdminPages/LoginDefaultS.aspx");
                        }
                        else
                        {
                            Response.Redirect("/BackEndPages/GeneralUserPages/LoginDefaultG.aspx");
                        }
                    }
                }
            }
        }

        public string RandomCode(int n)
        {
            //定義一個包含數字 大寫 小寫英文字母
            string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
            //將strchar 字串轉化為陣列
            //String.Split 方法放回包含此例項中的子字串（由指定Char陣列的元素分割）的String陣列
            string[] VcArray = strchar.Split(',');
            string VNum = "";
            //記錄上次隨機陣列，避免產生幾個一樣的
            int temp = -1;
            //採用一個簡單的演算法以保證 生產隨機數的不同
            Random rand = new Random();
            for (int i = 1; i < n + 1; i++)
            {
                if (temp != -1)
                {
                    //unchecked 關鍵字用於取消整型算術運算和轉換的溢位檢查。
                    //DataTime.Ticks 屬性獲取表示此例項的日期和時間的刻度數。
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                //Random.Next 方法返回一個小於所指定最大值的非負數隨機數。
                int t = rand.Next(61);
                if (temp != -1 && temp == t)
                {
                    return RandomCode(n);
                }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;//返回生成的隨機數
        }
    }
}