using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

public partial class SearchResult : System.Web.UI.Page
{
    Clsconnection cls = new Clsconnection();
    public string srchtext;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["Srch"]))
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            lblSearch.Text = Request.QueryString["Srch"].ToString();
            srchtext = "%" + Request.QueryString["Srch"].ToString() + "%";
        }

        if (!IsPostBack)
        {
           
            ViewState["Display"] = "Grid";
            this.BindItemsList();
            //BindProduct(cid, scid);
        }
    }

    #region Private Properties
    private int CurrentPage
    {
        get
        {
            object objPage = ViewState["_CurrentPage"];
            int _CurrentPage = 0;
            if (objPage == null)
            {
                _CurrentPage = 0;
            }
            else
            {
                _CurrentPage = (int)objPage;
            }
            return _CurrentPage;
        }
        set { ViewState["_CurrentPage"] = value; }
    }
    private int fistIndex
    {
        get
        {

            int _FirstIndex = 0;
            if (ViewState["_FirstIndex"] == null)
            {
                _FirstIndex = 0;
            }
            else
            {
                _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
            }
            return _FirstIndex;
        }
        set { ViewState["_FirstIndex"] = value; }
    }
    private int lastIndex
    {
        get
        {

            int _LastIndex = 0;
            if (ViewState["_LastIndex"] == null)
            {
                _LastIndex = 0;
            }
            else
            {
                _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
            }
            return _LastIndex;
        }
        set { ViewState["_LastIndex"] = value; }
    }
    #endregion

    #region PagedDataSource
    PagedDataSource _PageDataSource = new PagedDataSource();
    #endregion

    #region Private Methods
    /// <summary>
    /// Build DataTable to bind Main Items List
    /// </summary>
    /// <returns>DataTable</returns>
    private DataTable GetDataTable()
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        //for sorting if value =1 then sort price from low to high
        // if value =2 sort price from high to low
        //if value =3 sort name a to z asc
        //if value =4 sort name z to a desc

        dt = cls.ReturnDataTable("Select_SearchResult", new SqlParameter("@searchtext", srchtext), new SqlParameter("@Flag", Convert.ToInt32(drpSort.SelectedValue.ToString())));

        if (ViewState["Display"].ToString() == "Grid")
        {
            dt1.Columns.Add("id1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName11", Type.GetType("System.String"));
            dt1.Columns.Add("Image1", Type.GetType("System.String"));
            dt1.Columns.Add("ProductCode1", Type.GetType("System.String"));
            dt1.Columns.Add("FinalSellingPrice1", Type.GetType("System.Double"));

            dt1.Columns.Add("id2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName22", Type.GetType("System.String"));
            dt1.Columns.Add("Image2", Type.GetType("System.String"));
            dt1.Columns.Add("ProductCode2", Type.GetType("System.String"));
            dt1.Columns.Add("FinalSellingPrice2", Type.GetType("System.Double"));

            dt1.Columns.Add("id3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName33", Type.GetType("System.String"));
            dt1.Columns.Add("Image3", Type.GetType("System.String"));
            dt1.Columns.Add("ProductCode3", Type.GetType("System.String"));
            dt1.Columns.Add("FinalSellingPrice3", Type.GetType("System.Double"));

            dt1.Columns.Add("id4", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName4", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName44", Type.GetType("System.String"));
            dt1.Columns.Add("Image4", Type.GetType("System.String"));
            dt1.Columns.Add("ProductCode4", Type.GetType("System.String"));
            dt1.Columns.Add("FinalSellingPrice4", Type.GetType("System.Double"));

            dt1.Columns.Add("id5", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName5", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName55", Type.GetType("System.String"));
            dt1.Columns.Add("Image5", Type.GetType("System.String"));
            dt1.Columns.Add("ProductCode5", Type.GetType("System.String"));
            dt1.Columns.Add("FinalSellingPrice5", Type.GetType("System.Double"));

            dt1.Columns.Add("id6", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName6", Type.GetType("System.String"));
            dt1.Columns.Add("ProductName66", Type.GetType("System.String"));
            dt1.Columns.Add("Image6", Type.GetType("System.String"));
            dt1.Columns.Add("ProductCode6", Type.GetType("System.String"));
            dt1.Columns.Add("FinalSellingPrice6", Type.GetType("System.Double"));

            if (dt.Rows.Count > 0)
            {
                //binding breadcrumb
                //DataTable dttile = new DataTable();
                //dttile = dt.DefaultView.ToTable(true, "ProductCategoryId", "ProductSubCategoryId", "SubCategoryName", "CategoryName");
                //rptrBreadCrumb.DataSource = dttile;
                //rptrBreadCrumb.DataBind();


                for (int i = 0; i < dt.Rows.Count; i = i + 6)
                {
                    if (i + 1 < dt.Rows.Count)
                    {
                        if (i + 2 < dt.Rows.Count)
                        {
                            if (i + 3 < dt.Rows.Count)
                            {
                                if (i + 4 < dt.Rows.Count)
                                {
                                    if (i + 5 < dt.Rows.Count)
                                    {
                                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["ProductName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["pname"].ToString(), dt.Rows[i + 3]["ProductName"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 3]["ProductCode"].ToString(), dt.Rows[i + 3]["FinalSellingPrice"].ToString(), dt.Rows[i + 4]["id"].ToString(), dt.Rows[i + 4]["pname"].ToString(), dt.Rows[i + 4]["ProductName"].ToString(), dt.Rows[i + 4]["Image"].ToString(), dt.Rows[i + 4]["ProductCode"].ToString(), dt.Rows[i + 4]["FinalSellingPrice"].ToString(), dt.Rows[i + 5]["id"].ToString(), dt.Rows[i + 5]["pname"].ToString(), dt.Rows[i + 5]["ProductName"].ToString(), dt.Rows[i + 5]["Image"].ToString(), dt.Rows[i + 5]["ProductCode"].ToString(), dt.Rows[i + 5]["FinalSellingPrice"].ToString());
                                    }
                                    else
                                    {
                                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["ProductName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["pname"].ToString(), dt.Rows[i + 3]["ProductName"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 3]["ProductCode"].ToString(), dt.Rows[i + 3]["FinalSellingPrice"].ToString(), dt.Rows[i + 4]["id"].ToString(), dt.Rows[i + 4]["pname"].ToString(), dt.Rows[i + 4]["ProductName"].ToString(), dt.Rows[i + 4]["Image"].ToString(), dt.Rows[i + 4]["ProductCode"].ToString(), dt.Rows[i + 4]["FinalSellingPrice"].ToString(), "", "", "", "", "", 0);
                                        //  dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["pname"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 3]["ProductCode"].ToString(), dt.Rows[i + 3]["FinalSellingPrice"].ToString(), dt.Rows[i + 4]["id"].ToString(), dt.Rows[i + 4]["pname"].ToString(), dt.Rows[i + 4]["Image"].ToString(), dt.Rows[i + 4]["ProductCode"].ToString(), dt.Rows[i + 4]["FinalSellingPrice"].ToString(), "","", "", "", "", 0);
                                    }
                                }
                                else
                                {
                                    //  dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["pname"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 3]["ProductCode"].ToString(), dt.Rows[i + 3]["FinalSellingPrice"].ToString(), "", "", "", "", 0, "", "", "", "", 0);
                                    dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["ProductName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), dt.Rows[i + 3]["id"].ToString(), dt.Rows[i + 3]["pname"].ToString(), dt.Rows[i + 3]["ProductName"].ToString(), dt.Rows[i + 3]["Image"].ToString(), dt.Rows[i + 3]["ProductCode"].ToString(), dt.Rows[i + 3]["FinalSellingPrice"].ToString(), "", "", "", "", "", 0, "", "", "", "", "", 0);
                                }
                            }
                            else
                            {
                                //  dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), "", "", "", "", 0, "", "", "", "", 0, "", "", "", "", 0);
                                dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["ProductName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), dt.Rows[i + 2]["id"].ToString(), dt.Rows[i + 2]["pname"].ToString(), dt.Rows[i + 2]["ProductName"].ToString(), dt.Rows[i + 2]["Image"].ToString(), dt.Rows[i + 2]["ProductCode"].ToString(), dt.Rows[i + 2]["FinalSellingPrice"].ToString(), "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", "", "", 0);
                            }
                        }
                        else
                        {
                            dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["ProductName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), dt.Rows[i + 1]["id"].ToString(), dt.Rows[i + 1]["pname"].ToString(), dt.Rows[i + 1]["ProductName"].ToString(), dt.Rows[i + 1]["Image"].ToString(), dt.Rows[i + 1]["ProductCode"].ToString(), dt.Rows[i + 1]["FinalSellingPrice"].ToString(), "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", "", "", 0);
                        }
                    }
                    else
                    {
                        dt1.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["pname"].ToString(), dt.Rows[i]["ProductName"].ToString(), dt.Rows[i]["Image"].ToString(), dt.Rows[i]["ProductCode"].ToString(), dt.Rows[i]["FinalSellingPrice"].ToString(), "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", "", "", 0, "", "", "", "", "", 0);
                    }
                }
            }
        }
        else
        {
            dt1 = dt;
        }
        return dt1;
    }
    /// <summary>
    /// Binding Main Items List
    /// </summary>
    private void BindItemsList()
    {

        DataTable dataTable = this.GetDataTable();
        _PageDataSource.DataSource = dataTable.DefaultView;
        _PageDataSource.AllowPaging = true;
        if (ViewState["Display"].ToString() == "Grid")
        {
            _PageDataSource.PageSize = Convert.ToInt32(drpPageSize.SelectedValue);
        }
        else
        {
            int pageSize = 0;
            pageSize = Convert.ToInt32(drpPageSize.SelectedValue);
            if (pageSize == 2)
            {
                _PageDataSource.PageSize = 12;
            }
            else if (pageSize == 4)
            {
                _PageDataSource.PageSize = 24;
            }
            else if (pageSize == 6)
            {
                _PageDataSource.PageSize = 36;
            }
            else if (pageSize == 8)
            {
                _PageDataSource.PageSize = 48;
            }
        }
        if (_PageDataSource.PageCount == 1)
        {
            _PageDataSource.CurrentPageIndex = 0;
            CurrentPage = 0;
        }
        else
        {
            _PageDataSource.CurrentPageIndex = CurrentPage;
        }
        ViewState["TotalPages"] = _PageDataSource.PageCount;

        //this.lblPageInfo.Text = "Page " + (CurrentPage + 1) + " of " + _PageDataSource.PageCount;
        this.lbtnPrevious.Enabled = !_PageDataSource.IsFirstPage;
        this.lbtnNext.Enabled = !_PageDataSource.IsLastPage;
        //this.lbtnFirst.Enabled = !_PageDataSource.IsFirstPage;
        //this.lbtnLast.Enabled = !_PageDataSource.IsLastPage;
        if (ViewState["Display"].ToString() == "Grid")
        {
            this.rptrProduct.DataSource = _PageDataSource;
            this.rptrProduct.DataBind();
            rptrProductList.Visible = false;
            rptrProduct.Visible = true;
        }
        else
        {
            this.rptrProductList.DataSource = _PageDataSource;
            this.rptrProductList.DataBind();
            rptrProductList.Visible = true;
            rptrProduct.Visible = false;
        }
        this.doPaging();
    }

    /// <summary>
    /// Binding Paging List
    /// </summary>
    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");

        fistIndex = CurrentPage - 5;


        if (CurrentPage > 5)
        {
            lastIndex = CurrentPage + 5;
        }
        else
        {
            lastIndex = 10;
        }
        if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            fistIndex = lastIndex - 10;
        }

        if (fistIndex < 0)
        {
            fistIndex = 0;
        }

        for (int i = fistIndex; i < lastIndex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        this.dlPaging.DataSource = dt;
        this.dlPaging.DataBind();
    }
    #endregion

    protected void lbtnNext_Click(object sender, EventArgs e)
    {

        CurrentPage += 1;
        this.BindItemsList();

    }
    protected void lbtnPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        this.BindItemsList();

    }
    protected void dlPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            this.BindItemsList();
        }
    }

    protected void drpPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindItemsList();
    }


    protected void dlPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
        HtmlGenericControl liparent = (HtmlGenericControl)e.Item.FindControl("liparent");

        if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Style.Add("fone-size", "14px");
            lnkbtnPage.Font.Bold = true;
            liparent.Attributes["class"] = "active";
        }
    }
    protected void drpSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.BindItemsList();
    }
    protected void lnkGrid_Click(object sender, EventArgs e)
    {
        rptrProductList.Visible = false;
        rptrProduct.Visible = true;
        ViewState["Display"] = "Grid";
        this.BindItemsList();
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        rptrProductList.Visible = true;
        rptrProduct.Visible = false;
        ViewState["Display"] = "List";
        this.BindItemsList();
    }
}