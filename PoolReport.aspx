<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PoolReport.aspx.cs" Inherits="PoolReport" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <%--  <h3 class="page-title">Change Withdrawal Password   </h3>--%>
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Pool Report</a><span class="divider-last">&nbsp;</span></li>
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
                                    <h4><i class="icon-credit-card"></i>Pool Report</h4>
                                    <span class="tools">
                                        <a href="javascript:;" class="icon-chevron-down"></a>
                                    </span>
                                </div>
                                <div class="clr">
                                    <asp:Label ID="errMsg" runat="server" CssClass="error"></asp:Label>
                                </div>
                                <div class="widget-body">
                                    <div class="form-vertical">
                                        <div style="margin-bottom: 30px;">
                                            <span id="ctl00_ContentPlaceHolder1_lblMsg" style="color: #C00000;"></span>
                                            <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
                                        </div>
                                        <div class="row">
                                            <div class="span3">
                                                <div class="control-group">
                                                    <label class="control-label">
                                                        Search By</label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="rbtnsearch" runat="server" class="input-xlarge">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="span3">
                                                <div class="control-group " style="margin-top: 25px;">
                                                    <div class="controls">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="BtnSubmit" runat="server" Text="Search" TabIndex="3" class="btn btn-danger" OnClick="BtnSubmit_Click" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div id="DivSideA" runat="server">
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <div style="overflow: scroll;">
                                                        <asp:Label ID="Label1" runat="server" Text="Total Records"></asp:Label>
                                                        <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                        <asp:GridView ID="RptDirects" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered table-striped"
                                                            AllowPaging="true" PageSize="10" OnPageIndexChanging="RptDirects_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SNo">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="BtnSubmit" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
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

