<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewProductDetail.aspx.cs" Inherits="ViewProductDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="LblNo" runat="server" ForeColor="Black" Font-Size="14px"></asp:Label>
    </div>

    
    <div style="margin-bottom: 20px">
        <asp:GridView ID="GvData" runat="server" AutoGenerateColumns="False" RowStyle-Height="25px"
            GridLines="Both" AllowPaging="true" class="table datatable dataTable no-footer"
            ShowHeader="true" PageSize="20" EmptyDataText="No data to display.">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvdatagenesis" runat="server" AutoGenerateColumns="False" RowStyle-Height="25px"
            GridLines="Both" AllowPaging="true" class="table datatable dataTable no-footer"
            ShowHeader="true" PageSize="20" EmptyDataText="No data to display." OnPageIndexChanging="gvdatagenesis_PageIndexChanging" >
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="Rate" HeaderText="Rate" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalAmount" HeaderText="Amount" />
                 <asp:BoundField DataField="Size" HeaderText="size" />
                 <asp:BoundField DataField="color" HeaderText="color" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />
    </form>
</body>
</html>
