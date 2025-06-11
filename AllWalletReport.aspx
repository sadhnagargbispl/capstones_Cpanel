<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AllWalletReport.aspx.cs" Inherits="AllWalletReport" %>

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
                    <li><a href="#">All Wallet Report</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <div>
            <div class="row-fluid panelpart">
                <div class="row-fluid panelpart">
                    <div class="span12">
                        <div class="row">
                            <div class="widget">
                                <div class="widget-title">
                                    <h4><i class="icon-credit-card"></i>All Wallet Report</h4>
                                    <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                    </span>
                                </div>
                                <div class="clr">
                                    <asp:Label ID="errMsg" runat="server" CssClass="error"></asp:Label>
                                </div>
                                <div class="widget-body">

                                    <div class="form-vertical">
                                        <div class="row">
                                            <div class="span6">
                                                <div class="table-responsive">
                                                    <table class="table table-hover table-bordered">
                                                        <tr>
                                                            <td>
                                                                <b>Wallet Type :</b>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlVoucherType" runat="server" CssClass="input-xxlarge">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-danger" OnClick="btnSearch_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="span6">
                                                <div class="table-responsive">
                                                    <table class="table table-hover table-bordered">

                                                        <tbody>
                                                            <tr>
                                                                <td>Deposit</td>
                                                                <td>:</td>
                                                                <td id="MCredit" runat="server">0.00</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Used</td>
                                                                <td>:</td>
                                                                <td id="MDebit" runat="server">0.00</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Balance</td>
                                                                <td>:</td>
                                                                <td id="MBal" runat="server">0.00</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>

                                        <div style="margin-bottom: 30px;">
                                            <span id="ctl00_ContentPlaceHolder1_lblMsg" style="color: #C00000;"></span>
                                            <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
                                        </div>

                                        <div id="DivSideA" runat="server">
                                            <div class="table-responsive">
                                                <div class="table mb-0" cellspacing="0" cellpadding="4" rules="all" border="1" id="ctl00_ContentPlaceHolder2_DGVReferral"
                                                    style="width: 100%; border-collapse: collapse;">
                                                    <asp:GridView ID="RptDirects" runat="server" AutoGenerateColumns="true"
                                                        CssClass="table table-bordered" EmptyDataText="No data to display." AllowPaging="true" PageSize="50" OnPageIndexChanging="RptDirects_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SNo.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <p>&nbsp;</p>
                    <hr>
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
