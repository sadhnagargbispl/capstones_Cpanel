<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductRequestDetail.aspx.cs" Inherits="ProductRequestDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
     <!-- BEGIN PAGE HEADER-->
     <div class="row-fluid">
         <div class="span12">
             <%--  <h3 class="page-title">Change Withdrawal Password   </h3>--%>
             <ul class="breadcrumb">
                 <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span> </li>
                 <li><a href="#">Order Detail</a><span class="divider-last">&nbsp;</span></li>
             </ul>
         </div>
     </div>
     <div>
         <div class="row-fluid panelpart">

             <div class="row-fluid panelpart">



                 <%--<div class="span12">
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <a>Home</a>
                                <i class="fa fa-angle-double-right"></i>
                            </li>
                            <li>
                                <span>Order Detail</span>
                            </li>
                        </ul>
                        <div class="page-content portlet light" ng-show="ShowhideDashBoard">--%>
                            <!--Rewards start-->
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="table-responsive">
                                        <table id="customers2" class="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>SNo
                                                    </th>
                                                    <th>OrderNo/Bill NO.
                                                    </th>
                                                    <th>Order Date
                                                    </th>
                                                    <th>Request
                                                    </th>
                                                    <th>Order Amount
                                                    </th>
                                                    <th>BV
                                                    </th>
                                                    <th>Courier Name
                                                    </th>
                                                    <th>Docket No.
                                                    </th>
                                                    <th>Docket Date
                                                    </th>
                                                    <th>Website
                                                    </th>
                                                    <th>Status
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="RptDirects" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" />
                                                            </td>
                                                            <td style="color :Blue">
                                                                <%#Eval("Orderno")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("OrderDate")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("KitName")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("OrderAmount")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("BV")%>       
                                                            </td>
                                                            <td>
                                                                <%#Eval("CourierName")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("DocketNo")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("DocketDate")%>
                                                            </td>
                                                            <td style="color: Blue;">
                                                                <%#Eval("Website")%>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Status")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </tbody>
                                        </table>
                                    </div>
                                    <hr />
                                </div>
                            </div>
                       <%-- </div>
                    </div>
                </div>
            </div>
        </div>

    </div>--%>
                                 </div>
                <div class="clearfix"></div>
               <%-- <p>&nbsp;</p>
                <hr>
                <div class="clearfix"></div>--%>
            </div>
        </div>
    </div>
</div>
</asp:Content>

