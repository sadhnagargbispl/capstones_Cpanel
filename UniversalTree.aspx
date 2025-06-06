<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UniversalTree.aspx.cs" Inherits="UniversalTree" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12">
        <div id="ctl00_ContentPlaceHolder1_divgenexbusiness" class="clearfix gen-profile-box">
            <div class="profile-bar-simple red-border clearfix">
                <h6>Pool Tree
                </h6>
            </div>
            <div class="clearfix gen-profile-box" style="min-height: auto;">
                <div class="profile-bar clearfix" style="background: #fff;">
                    <div class="clearfix">
                        <br>
                        <div class="centered">
                            <div class="clr">
                                <asp:Label ID="Label2" runat="server" CssClass="error"></asp:Label>
                            </div>
                            <div class="clr">
                            </div>
                            <div class="form-horizontal">
                                <div class="col-md-12">
                                    <table>
                                        <tr>
                                            <td>Pool Tree
                                            </td>
                                            <td style="width: 70%">
                                                <asp:DropDownList ID="ddllist" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="Button1_Click" />
                                                <asp:Button ID="cmdBack" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="cmdBack_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-sm-12 pull-none" style="position: inherit">
                                    <div class="form-group ">
                                        <iframe name="TreeFrame" frameborder="0" scrolling="auto" src="UniTree.aspx" width="100%"
                                            height="500" id="TreeFrame" runat="server"></iframe>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
