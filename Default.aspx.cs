using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    RectangleHotSpot hotSpot;
    Class1 cl = new Class1();
    static string memberid="";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                memberid = Session["Memberid"].ToString();
                BindSpecialOffer();
                BindHomeDec();
                BindNewArrival();
                BindBestSelling();
                BindAdd();
                BindImageBanner();
            }
        }
        catch
        {
            Response.Redirect("Register.aspx");
        }
    }
    protected void BindSpecialOffer()
    {
        DataTable dt = new DataTable();
        dt = cl.getdataset("select * from  Product p inner join crm c on c.productid=p.id inner join members m on m.memberid=c.cusotmerid where p.IsActive=1 and p.IsSpecialOffer=1 and c.cusotmerid='" + memberid + "'  order by p.ProductName");

        if (dt.Rows.Count > 0)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName11", Type.GetType("System.String"));
            dt1.Columns.Add("Image1", Type.GetType("System.String"));
            dt1.Columns.Add("sp1", Type.GetType("System.String"));
            dt1.Columns.Add("Code1", Type.GetType("System.String"));
            dt1.Columns.Add("Price1", Type.GetType("System.String"));

            dt1.Columns.Add("id2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName22", Type.GetType("System.String"));
            dt1.Columns.Add("Image2", Type.GetType("System.String"));
            dt1.Columns.Add("sp2", Type.GetType("System.String"));
            dt1.Columns.Add("Code2", Type.GetType("System.String"));
            dt1.Columns.Add("Price2", Type.GetType("System.String"));

            dt1.Columns.Add("id3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName33", Type.GetType("System.String"));
            dt1.Columns.Add("Image3", Type.GetType("System.String"));
            dt1.Columns.Add("sp3", Type.GetType("System.String"));
            dt1.Columns.Add("Code3", Type.GetType("System.String"));
            dt1.Columns.Add("Price3", Type.GetType("System.String"));


            for (int i = 0; i < dt.Rows.Count; i = i + 3)
            {
                if (i + 1 < dt.Rows.Count)
                {
                    if (i + 2 < dt.Rows.Count)
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Productdescp"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["IsSpecialOffer"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["netsaleprice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Productdescp"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["IsSpecialOffer"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["netsaleprice"].ToString());
                    }
                    else
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Productdescp"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["IsSpecialOffer"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["netsaleprice"].ToString(), "", "", "", "", "", "", "");
                    }
                }
                else
                {
                    dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
            }
            rptSpecialoffer.DataSource = dt1;
            rptSpecialoffer.DataBind();
        }
    }
    protected void BindHomeDec()
    {
        //DataSet ds = new DataSet();
        //ds = cls.ReturnDataSet("Select_HomeDescription");
        //rptrHomeContent.DataSource = ds;
        //rptrHomeContent.DataBind();
    }
    protected void BindNewArrival()
    {
        DataTable dt = new DataTable();
        dt = cl.getdataset("select * from  Product p inner join crm c on c.productid=p.id where IsActive=1 and IsNewArrival=1 and c.cusotmerid='" + memberid + "'  order by ProductName");

        if (dt.Rows.Count > 0)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName11", Type.GetType("System.String"));
            dt1.Columns.Add("Image1", Type.GetType("System.String"));
            dt1.Columns.Add("sp1", Type.GetType("System.String"));
            dt1.Columns.Add("Code1", Type.GetType("System.String"));
            dt1.Columns.Add("Price1", Type.GetType("System.String"));

            dt1.Columns.Add("id2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName22", Type.GetType("System.String"));
            dt1.Columns.Add("Image2", Type.GetType("System.String"));
            dt1.Columns.Add("sp2", Type.GetType("System.String"));
            dt1.Columns.Add("Code2", Type.GetType("System.String"));
            dt1.Columns.Add("Price2", Type.GetType("System.String"));

            dt1.Columns.Add("id3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName33", Type.GetType("System.String"));
            dt1.Columns.Add("Image3", Type.GetType("System.String"));
            dt1.Columns.Add("sp3", Type.GetType("System.String"));
            dt1.Columns.Add("Code3", Type.GetType("System.String"));
            dt1.Columns.Add("Price3", Type.GetType("System.String"));


            for (int i = 0; i < dt.Rows.Count; i = i + 3)
            {
                if (i + 1 < dt.Rows.Count)
                {
                    if (i + 2 < dt.Rows.Count)
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Productdescp"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["IsSpecialOffer"].ToString(), dt.Rows[i+1]["ProductCode"].ToString(), dt.Rows[i+1]["netsaleprice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Productdescp"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["IsSpecialOffer"].ToString(),dt.Rows[i+2]["ProductCode"].ToString(), dt.Rows[i+2]["netsaleprice"].ToString());
                    }
                    else
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Productdescp"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["IsSpecialOffer"].ToString(), dt.Rows[i+1]["ProductCode"].ToString(), dt.Rows[i+1]["netsaleprice"].ToString(), "", "", "", "", "","","");
                    }
                }
                else
                {
                    dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), "", "", "", "", "", "", "", "", "", "","","","","");
                }
            }
            rptNewArrival.DataSource = dt1;
            rptNewArrival.DataBind();
        }
    }
    protected void BindBestSelling()
    {
        DataTable dt = new DataTable();
        dt = cl.getdataset("select top 9 Product.Id,product.ProductName,product.Productdescp,Product.Image,product.IsSpecialOffer,product.ProductCode,c.netsaleprice from Product inner join InvoiceProduct on Product.Id=InvoiceProduct.ProductId  inner join crm c on c.productid=product.id where Product.IsActive=1 and c.cusotmerid='" + memberid + "' group by Product.Id,product.ProductName,product.Productdescp,Product.Image,product.IsSpecialOffer,product.ProductCode,c.netsaleprice ");

        if (dt.Rows.Count > 0)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName11", Type.GetType("System.String"));
            dt1.Columns.Add("Image1", Type.GetType("System.String"));
            dt1.Columns.Add("sp1", Type.GetType("System.String"));
            dt1.Columns.Add("Code1", Type.GetType("System.String"));
            dt1.Columns.Add("Price1", Type.GetType("System.String"));

            dt1.Columns.Add("id2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName22", Type.GetType("System.String"));
            dt1.Columns.Add("Image2", Type.GetType("System.String"));
            dt1.Columns.Add("sp2", Type.GetType("System.String"));
            dt1.Columns.Add("Code2", Type.GetType("System.String"));
            dt1.Columns.Add("Price2", Type.GetType("System.String"));

            dt1.Columns.Add("id3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName33", Type.GetType("System.String"));
            dt1.Columns.Add("Image3", Type.GetType("System.String"));
            dt1.Columns.Add("sp3", Type.GetType("System.String"));
            dt1.Columns.Add("Code3", Type.GetType("System.String"));
            dt1.Columns.Add("Price3", Type.GetType("System.String"));


            for (int i = 0; i < dt.Rows.Count; i = i + 3)
            {
                if (i + 1 < dt.Rows.Count)
                {
                    if (i + 2 < dt.Rows.Count)
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Productdescp"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["IsSpecialOffer"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["netsaleprice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Productdescp"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["IsSpecialOffer"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["netsaleprice"].ToString());
                    }
                    else
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Productdescp"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["IsSpecialOffer"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["netsaleprice"].ToString(), "", "", "", "", "", "", "");
                    }
                }
                else
                {
                    dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["ProductName"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["IsSpecialOffer"].ToString(), dt.Rows[i]["ProductCode"].ToString(), Convert.ToDouble(dt.Rows[i]["netsaleprice"].ToString()).ToString("N2"), "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                }
            }
            rptrBestSelling.DataSource = dt1;
            rptrBestSelling.DataBind();
        }
    }
    protected void BindAdd()
    {
        DataSet ds = new DataSet();
        ds = cls.ReturnDataSet("Select_Add");
        rptrAdd.DataSource = ds;
        rptrAdd.DataBind();
    }

    protected void rptrAdd_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageMap mapAreas = (ImageMap)e.Item.FindControl("mapAreas");
            Label lblId = (Label)e.Item.FindControl("lblId");
            BindHotSpot(mapAreas, lblId.Text);
        }
    }
    protected void BindImageBanner()
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_HomeAddImageMap");
        if (dt.Rows.Count > 0)
        {
            mapAreas.ImageUrl = dt.Rows[0]["ImageBanner"].ToString();
            BindHotSpot1(mapAreas);
        }
        else
        {
            mapAreas.Visible = false;
        }
        //rptrImageMap.DataSource = dt;
        //rptrImageMap.DataBind();
    }
    protected void BindHotSpot(ImageMap mapAreas, string id)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_AdvImageMap", new SqlParameter("@AdvId", id));

        if (dt.Rows.Count > 0)
        {
            //mapAreas.ImageUrl = dt.Rows[0]["ImageBanner"].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                hotSpot = new RectangleHotSpot();
                hotSpot.HotSpotMode = HotSpotMode.Inactive;
                hotSpot.Left = Convert.ToInt32(dr["left_co"]);
                hotSpot.Top = Convert.ToInt32(dr["top_co"]);
                hotSpot.Right = Convert.ToInt32(dr["right_co"]);
                hotSpot.Bottom = Convert.ToInt32(dr["bottom_co"]);
                if (dr["ProductId"].ToString() == "0")
                {
                    hotSpot.NavigateUrl = dr["Url"].ToString();
                    hotSpot.Target = "_blank";
                }
                else
                {
                    hotSpot.NavigateUrl = "ProductDetail.aspx?pid=" + Convert.ToInt32(dr["ProductId"]) + "";
                }
                hotSpot.HotSpotMode = HotSpotMode.Navigate;
                mapAreas.HotSpots.Add(hotSpot);
            }
        }
    }
    protected void BindHotSpot1(ImageMap mapAreas)
    {
        DataTable dt = new DataTable();
        dt = cls.ReturnDataTable("Select_HomeAddImageMap");

        if (dt.Rows.Count > 0)
        {
            mapAreas.ImageUrl = dt.Rows[0]["ImageBanner"].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                hotSpot = new RectangleHotSpot();
                hotSpot.HotSpotMode = HotSpotMode.Inactive;
                hotSpot.Left = Convert.ToInt32(dr["left_co"]);
                hotSpot.Top = Convert.ToInt32(dr["top_co"]);
                hotSpot.Right = Convert.ToInt32(dr["right_co"]);
                hotSpot.Bottom = Convert.ToInt32(dr["bottom_co"]);
                if (dr["ProductId"].ToString() == "0")
                {
                    hotSpot.NavigateUrl = dr["Url"].ToString();
                    hotSpot.Target = "_blank";
                }
                else
                {
                    hotSpot.NavigateUrl = "ProductDetail.aspx?pid=" + Convert.ToInt32(dr["ProductId"]) + "";
                }
                hotSpot.HotSpotMode = HotSpotMode.Navigate;
                mapAreas.HotSpots.Add(hotSpot);
            }
        }
    }
}