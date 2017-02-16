using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

/// <summary>
/// Summary description for clsAddToCart
/// </summary>
public class clsAddToCart
{
    private string ProductId, CategoryName, SubCategoryName, ProductName, Productdescp, BrandName, SupplierName, Unit, ColourName, SizeName, ProductCode, SupplierProductCode, PackSize, ProductCost, ProductWeight, Image, Certification, Description, ShippingDays;
    private double Margin, SalePrice, Tax, SalesPrice_Incl, MRP, Discount, CalDiscount, ShippingCost, FinalSellingPrice, TaxFinalPrice, Qty;
    private bool IsCOD;
    //private bool IsDiscount;
    //private double DiscountAmount;

    DataTable CartTable;
    Clsconnection clsCon = new Clsconnection();

    public clsAddToCart()
    {
        try
        {
            if (HttpContext.Current.Session["Cart"] == null)
            {
                AddColumn();
            }
            CartTable = GetFromSession();
        }
        catch (Exception ex)
        {
        }
    }
    //public void AddToCart(string ProductId, string productname, double prodprice,string CategoryName, string SubCategoryName, string ProductCode, string ProductDesc, string DirectionOfUse, string Ingredients, string SmallImg, double price, string Size, string ForWhom, string ColourCode, double Qty)
    public void AddToCart(string ProductId, string CategoryName, string SubCategoryName, string ProductName, string Productdescp, string BrandName, string SupplierName, string Unit, string ColourName, string SizeName, string ProductCode, string SupplierProductCode, string PackSize, double ProductCost, double ProductWeight, string Image, string Certification, string Description, double Margin, double SalePrice, double Tax, double SalesPrice_Incl, double MRP, double Discount, double CalDiscount, double ShippingCost, double FinalSellingPrice, double TaxFinalPrice, double Qty, string ShippingDays, bool IsCOD, double price)
    {
        CartTable = GetFromSession();
        DataRow Drow = CartTable.NewRow();
        Drow["SrNo"] = CartTable.Rows.Count + 1;
        Drow["ProductId"] = ProductId;
        Drow["CategoryName"] = CategoryName;
        Drow["SubCategoryName"] = SubCategoryName;
        Drow["ProductName"] = ProductName;
        Drow["Productdescp"] = Productdescp;
        Drow["BrandName"] = BrandName;
        Drow["SupplierName"] = SupplierName;
        Drow["Unit"] = Unit;
        Drow["ColourName"] = ColourName;
        Drow["SizeName"] = SizeName;
        Drow["ProductCode"] = ProductCode;
        Drow["SupplierProductCode"] = SupplierProductCode;
        Drow["PackSize"] = PackSize;
        Drow["ProductCost"] = ProductCost;
        Drow["ProductWeight"] = ProductWeight;
        Drow["Image"] = Image;
        Drow["Certification"] = Certification;
        Drow["Description"] = Description;
        Drow["Margin"] = Margin;
        Drow["SalePrice"] = SalePrice;
        Drow["Tax"] = Tax;
        Drow["SalesPrice_Incl"] = SalesPrice_Incl;
        Drow["MRP"] = MRP;
        Drow["Discount"] = Discount;
        Drow["CalDiscount"] = CalDiscount;
        Drow["ShippingCost"] = ShippingCost;
        Drow["FinalSellingPrice"] = FinalSellingPrice;
        Drow["TaxFinalPrice"] = TaxFinalPrice;
        Drow["Qty"] = Qty;
        Drow["ShippingDays"] = ShippingDays;
        Drow["IsCOD"] = IsCOD;
        Drow["Price"] = price;
        CartTable.Rows.Add(Drow);
        AddToSession();
    }
    public void UpdateQtyAndPrice(string pid, double intQty, double price)
    {
        //DataRow Drow = CartTable.Rows[intIndex];
        DataRow[] Drow = CartTable.Select("ProductID='" + pid + "'");
        Drow[0]["Qty"] = Convert.ToDouble(intQty) + Convert.ToInt32(Drow[0]["Qty"]);
        Drow[0]["Price"] = (Convert.ToDouble(intQty) * price) + Convert.ToDouble(Drow[0]["Price"]);
        AddToSession();
    }
    public void SetQtyAndPrice(string pid, double intQty, double price)
    {
        DataRow[] Drow = CartTable.Select("ProductID='" + pid + "'");
        Drow[0]["Qty"] = Convert.ToDouble(intQty);
        Drow[0]["Price"] = Convert.ToDouble(intQty) * price;
        AddToSession();
    }
    public void UpdateQtyAndPriceWithSizeColor(string pid, double intQty, double price, string SizeName, string ColourName)
    {
        //DataRow Drow = CartTable.Rows[intIndex];
        DataRow[] Drow = CartTable.Select("ProductID='" + pid + "' and SizeName='" + SizeName + "' and ColourName='" + ColourName + "'");
        Drow[0]["Qty"] = Convert.ToDouble(intQty) + Convert.ToInt32(Drow[0]["Qty"]);
        Drow[0]["Price"] = (Convert.ToDouble(intQty) * price) + Convert.ToDouble(Drow[0]["Price"]);
        AddToSession();
    }
    public void SetQtyAndPriceWithSizeColor(string pid, double intQty, double price, string SizeName, string ColourName)
    {
        DataRow[] Drow = CartTable.Select("ProductID='" + pid + "' and SizeName='" + SizeName + "' and ColourName='" + ColourName + "'");
        Drow[0]["Qty"] = Convert.ToDouble(intQty);
        Drow[0]["Price"] = Convert.ToDouble(intQty) * price;
        AddToSession();
    }
    public int TotalQty()
    {
        int intqty = 0;
        foreach (DataRow Drow in CartTable.Rows)
        {
            intqty = intqty + Convert.ToInt32(Drow["Qty"]);
        }
        return intqty;
    }
    public int TotalItems()
    {
        int intqty = 0;
        if (CartTable != null)
        {
            intqty = CartTable.Rows.Count;
        }
        return intqty;
    }
    //public double TotalPrice([Optional] double discount)
    //{
    //    double price = 0;
    //    foreach (DataRow Drow in CartTable.Rows)
    //    {
    //        price = price + Convert.ToDouble(Drow["Price"]);
    //    }
    //    price = price - discount;
    //    return price;
    //}
    public double TotalPriceWithoutDiscount()
    {
        double price = 0;
        foreach (DataRow Drow in CartTable.Rows)
        {
            price = price + Convert.ToDouble(Drow["Price"]);
        }
        return price;
    }
    public double TotalPrice()
    {
        double price = 0;
        double discount = 0;

        foreach (DataRow Drow in CartTable.Rows)
        {
            price = price + Convert.ToDouble(Drow["Price"]);
        }
        if (HttpContext.Current.Session["Discount"] != null)
        {
            discount = (price * Convert.ToDouble(HttpContext.Current.Session["Discount"])) / 100;
            price = price - discount;
        }

        return price;
    }
    //public double TotalPrice()
    //{
    //    double price = 0;
    //    double discount = 0;

    //    foreach (DataRow Drow in CartTable.Rows)
    //    {
    //        price = price + Convert.ToDouble(Drow["Price"]);
    //    }

    //    return price;
    //}
    public double SingleItemPrice()
    {
        double price = 0;
        foreach (DataRow Drow in CartTable.Rows)
        {
            price = Convert.ToDouble(Drow["ProdPrice"]);
        }
        return price;
    }
    public void RemoveItem(int intIndex)
    {
        CartTable.Rows.RemoveAt(intIndex);
        int i = 0;
        foreach (DataRow Drow in CartTable.Rows)
        {
            i = i + 1;
            Drow["SrNo"] = i;
        }
        AddToSession();
    }
    public DataTable BindCart()
    {
        return GetFromSession();
    }
    private void AddColumn()
    {
        CartTable = new DataTable();
        DataColumn col = new DataColumn("ProductId", Type.GetType("System.Int64"));
        CartTable.Columns.Add(col);
        CartTable.Columns.Add(new DataColumn("SrNo", Type.GetType("System.Int64")));
        CartTable.Columns.Add(new DataColumn("CategoryName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("SubCategoryName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("ProductName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("Productdescp", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("BrandName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("SupplierName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("Unit", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("ColourName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("SizeName", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("ProductCode", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("SupplierProductCode", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("PackSize", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("ProductCost", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("ProductWeight", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("Image", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("Certification", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("Description", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("Margin", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("SalePrice", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("Tax", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("SalesPrice_Incl", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("MRP", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("Discount", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("CalDiscount", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("ShippingCost", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("FinalSellingPrice", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("TaxFinalPrice", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("Qty", Type.GetType("System.Double")));
        CartTable.Columns.Add(new DataColumn("ShippingDays", Type.GetType("System.String")));
        CartTable.Columns.Add(new DataColumn("IsCOD", Type.GetType("System.Boolean")));
        CartTable.Columns.Add(new DataColumn("Price", Type.GetType("System.Double")));
        AddToSession();
    }
    private void AddToSession()
    {
        HttpContext.Current.Session["Cart"] = CartTable;
        HttpContext.Current.Session.Timeout = 525600;
    }
    private DataTable GetFromSession()
    {
        return (DataTable)System.Web.HttpContext.Current.Session["Cart"];
    }
    public void RemoveFromSession()
    {
        System.Web.HttpContext.Current.Session.Remove("Cart");
    }
    public bool CheckExistItem(string SubProductId, double qty)
    {
        foreach (DataRow drow in CartTable.Rows)
        {
            if (SubProductId.ToString() == drow["ProductId"].ToString())
            {
                drow["Qty"] = Convert.ToInt32(drow["Qty"]) + qty;
                return true;
            }
        }
        AddToSession();
        return false;
    }
    public bool FindExistItem(string ProductId)
    {
        foreach (DataRow drow in CartTable.Rows)
        {
            if (ProductId.ToString() == drow["ProductId"].ToString())
            {
                return true;
            }
        }
        AddToSession();
        return false;
    }
    public bool FindExistItemWithSizeColor(string ProductId, string SizeName, string ColourName)
    {
        foreach (DataRow drow in CartTable.Rows)
        {
            if (ProductId.ToString() == drow["ProductId"].ToString() && SizeName == drow["SizeName"].ToString() && ColourName == drow["ColourName"].ToString())
            {
                return true;
            }
        }
        AddToSession();
        return false;
    }
    public bool CheckIsCod()
    {
        foreach (DataRow drow in CartTable.Rows)
        {
            if (!Convert.ToBoolean(drow["IsCOD"]))
            {
                return false;
            }
        }
        AddToSession();
        return true;
    }
    public void RemoveCartLogout()
    {
        RemoveFromSession();
    }
}