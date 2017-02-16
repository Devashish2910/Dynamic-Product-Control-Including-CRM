using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BillingShippingDetails
/// </summary>
public class BillingShippingDetails
{

    DataTable BillShipTable;
    Clsconnection clsCon = new Clsconnection();

    public BillingShippingDetails()
    {
        try
        {
            if (HttpContext.Current.Session["BillShipTable"] == null)
            {
                AddColumn();
            }
            BillShipTable = GetFromSession();
        }
        catch (Exception ex)
        {
        }
    }

    public void AddToBillShipTable(string Name, string Email, string Company, string Contact, string Address1, string Address2, string City, string State, string Country, string Zipcode, string SName, string SEmail, string SCompany, string SContact, string SAddress1, string SAddress2, string SCity, string SState, string SCountry, string SZipcode)
    {
        //if (FindExistItem())
        //{
        //    RemoveItem();
        //}
        BillShipTable = GetFromSession();
        DataRow Drow = BillShipTable.NewRow();
        Drow["SrNo"] = BillShipTable.Rows.Count + 1;
        Drow["Name"] = Name;
        Drow["Email"] = Email;
        Drow["Company"] = Company;
        Drow["Contact"] = Contact;
        Drow["Address1"] = Address1;
        Drow["Address2"] = Address2;
        Drow["City"] = City;
        Drow["State"] = State;
        Drow["Country"] = Country;
        Drow["Zipcode"] = Zipcode;
        Drow["SName"] = SName;
        Drow["SEmail"] = SEmail;
        Drow["SCompany"] = SCompany;
        Drow["SContact"] = SContact;
        Drow["SAddress1"] = SAddress1;
        Drow["SAddress2"] = SAddress2;
        Drow["SCity"] = SCity;
        Drow["SState"] = SState;
        Drow["SCountry"] = SCountry;
        Drow["SZipcode"] = SZipcode;
        BillShipTable.Rows.Add(Drow);
        AddToSession();
    }

    public DataTable BindBillShip()
    {
        return GetFromSession();
    }

    private void AddColumn()
    {
        BillShipTable = new DataTable();
        BillShipTable.Columns.Add(new DataColumn("SrNo", Type.GetType("System.Int64")));
        BillShipTable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Email", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Company", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Contact", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Address1", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Address2", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("City", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("State", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Country", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("Zipcode", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SName", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SEmail", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SCompany", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SContact", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SAddress1", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SAddress2", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SCity", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SState", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SCountry", Type.GetType("System.String")));
        BillShipTable.Columns.Add(new DataColumn("SZipcode", Type.GetType("System.String")));
        AddToSession();
    }

    private void AddToSession()
    {
        HttpContext.Current.Session["BillShipTable"] = BillShipTable;
        HttpContext.Current.Session.Timeout = 525600;
    }

    private DataTable GetFromSession()
    {
        return (DataTable)System.Web.HttpContext.Current.Session["BillShipTable"];
    }

    public void RemoveFromSession()
    {
        System.Web.HttpContext.Current.Session.Remove("BillShipTable");
    }
    public void RemoveCartLogout()
    {
        RemoveFromSession();
    }
    public void RemoveItem(int intIndex)
    {
        BillShipTable.Rows.RemoveAt(intIndex);
        int i = 0;
        foreach (DataRow Drow in BillShipTable.Rows)
        {
            i = i + 1;
            Drow["SrNo"] = i;
        }
        AddToSession();
    }
    public void RemoveItem()
    {
        foreach (DataRow Drow in BillShipTable.Rows)
        {
            BillShipTable.Rows.Remove(Drow);
        }
        AddToSession();
    }
    public bool FindExistItem()
    {
        int cnt = 0;
        foreach (DataRow drow in BillShipTable.Rows)
        {
            cnt++;
            break;
        }
        if (cnt > 0)
        {
            return true;
        }
        AddToSession();
        return false;
    }
}