<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UniversalTree.aspx.cs" Inherits="UniversalTree" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <%--  <h3 class="page-title">Change Withdrawal Password   </h3>--%>
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Pool Tree</a><span class="divider-last">&nbsp;</span></li>
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
                                    <h4><i class="icon-credit-card"></i>Pool Tree</h4>
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
                                                        Pool Tree</label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddllist" runat="server" CssClass="input-xlarge">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="span3">
                                                <div class="control-group " style="margin-top: 25px;">
                                                    <div class="controls">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-danger" OnClick="Button1_Click" />
                                                        <asp:Button ID="cmdBack" runat="server" Text="Back" CssClass="btn btn-danger" OnClick="cmdBack_Click" Visible="false" />
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div id="DivSideA" runat="server">
                                            <iframe name="TreeFrame" frameborder="0" scrolling="auto" src="UniTree.aspx" width="100%"
                                                height="500" id="TreeFrame" runat="server"></iframe>
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
