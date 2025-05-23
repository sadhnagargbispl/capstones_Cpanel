<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>--%>

    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

    <style>
        .tblpadding {
            padding-top: 5px !important;
            padding-bottom: 0px !important;
        }

        .tblpadding1 {
            padding-top: 5px !important;
            padding-bottom: 0px !important;
            text-align: right;
        }

        .infocolor {
            background-color: #ff2b3f;
        }
    </style>
    <style type="text/css">
        .infoclr {
            background-color: #ffe3ed;
        }

        .backclr {
            background-color: #efefef;
        }

        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 500px;
            height: 550px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        function copyText() {

            var range, selection, worked;
            var element = document.getElementById("ContentPlaceHolder1_lblLink");
            if (document.body.createTextRange) {
                range = document.body.createTextRange();
                range.moveToElementText(element);
                range.select();
            } else if (window.getSelection) {
                selection = window.getSelection();
                range = document.createRange();
                range.selectNodeContents(element);
                selection.removeAllRanges();
                selection.addRange(range);
            }

            try {
                document.execCommand('copy');
                alert('link copied');
            }
            catch (err) {
                alert('unable to copy link');
            }
            return false;
        }

    </script>

    <script type="text/javascript">
        function copyText1() {
            debugger;
            var range, selection, worked;
            var element = document.getElementById("ContentPlaceHolder1_lblLinkClient");
            if (document.body.createTextRange) {
                range = document.body.createTextRange();
                range.moveToElementText(element);
                range.select();
            } else if (window.getSelection) {
                selection = window.getSelection();
                range = document.createRange();
                range.selectNodeContents(element);
                selection.removeAllRanges();
                selection.addRange(range);
            }

            try {
                document.execCommand('copy');
                alert('link copied');
            }
            catch (err) {
                alert('unable to copy link');
            }
            return false;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span12">
                <h3 class="page-title">Dashboard </h3>
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Dashboard</a><span class="divider-last">&nbsp;</span></li>
                </ul>
            </div>
        </div>
        <div class="row-fluid panelpart">
            <div class="span12">
                <asp:Repeater runat="server" ID="RptDirectList">
                    <ItemTemplate>
                        <div class="span3">
                            <%#Eval("div")%>
                            <div class="inner">
                                <h3><span id="ctl00_ContentPlaceHolder1_lblTotalMember"><%#Eval("Direct")%></span></h3>
                                <p><%#Eval("Name")%></p>
                                <div class="progress my-3" style="height: 3px;">
                                    <div class="progress-bar" style="width: 55%"></div>
                                </div>
                            </div>
                            <div class="icon"><%#Eval("Icon")%> </div>
                        </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row" style="margin-bottom: 0em;">
                <div class="span12">
                    <asp:Repeater runat="server" ID="RptTotalWithdrawallist">
                        <ItemTemplate>
                            <div class="span3 packeviti">
                                <div class="box box-widget widget-user-2 box2">
                                    <div class="widget-user-header bg-aqua" style="background: #97b85d!important;">
                                        <div class="widget-user-image"><i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i></div>
                                        <h3 class="widget-user-username headd"><%#Eval("Name")%></h3>
                                    </div>
                                    <div class="widgetleftright barset">
                                        <div class="span12">
                                            <div class="description-block">
                                                <h5 class="description-header"><span id=""><span id="ctl00_ContentPlaceHolder1_lblreturnhelp">
                                                    <%#Eval("Income")%></span> </span></h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row" style="margin-bottom: 0em;">
                <div class="span12">
                    <asp:Repeater ID="gvBalance" runat="server">
                        <ItemTemplate>
                            <div class="span6 packeviti">
                                <div class="box box-widget widget-user-2">
                                    <a href="#">
                                        <div class="widget-user-header bg-green gradientclr">
                                            <div class="widget-user-image"><i class="fa fa-gift" aria-hidden="true"></i></div>
                                            <h3 class="widget-user-username"><%#Eval("WalletName")%></h3>
                                        </div>
                                    </a>
                                    <div class="widgetleftright barset">
                                        <div class="span4 border-right">
                                            <div class="description-block">
                                                <h5 class="description-header"><span id="ctl00_ContentPlaceHolder1_lblleftgroup"><span id="ctl00_ContentPlaceHolder1_lblleftgroup"><%#Eval("Credit")%></span> </span></h5>
                                                <span class="description-text">Credit</span>
                                            </div>
                                        </div>
                                        <div class="span4 border-right">
                                            <div class="description-block">
                                                <h5 class="description-header"><span id="ctl00_ContentPlaceHolder1_lblrightgroup"><span id="ctl00_ContentPlaceHolder1_lblrightgroup"><%#Eval("Debit")%></span></span></h5>
                                                <span class="description-text">Debit </span>
                                            </div>
                                        </div>
                                        <div class="span4">
                                            <div class="description-block">
                                                <h5 class="description-header"><span id="ctl00_ContentPlaceHolder1_lbltotalgroup"><span id="ctl00_ContentPlaceHolder1_lbltotalgroup"><%#Eval("Balance")%></span></span></h5>
                                                <span class="description-text">Balance</span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            </div>
            <div class="row-fluid panelpart">
              
                <div class="span12 packeviti">
                    <div class="box box-widget widget-user-2">
                        <div class="widget-user-header bg-aqua gradientclr">
                            <div class="widget-user-image"><i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i></div>
                            <h3 class="widget-user-username"><%=Session["Title"].ToString ()%> : Referral Link </h3>
                        </div>

                        <div class="widgetleftright barset">
                            <div class="span8 border-right">
                                <div class="description-block">
                                    <h5 class="description-header"><span id="ctl00_ContentPlaceHolder1_lblleftgroup">Referral Link : <a runat="server" target="_blank" id="aRfLink">
                                        <asp:Label ID="lblLink" Style="color: blue;" runat="server"></asp:Label></a></span></h5>

                                </div>
                            </div>
                            <div class="span4 border-right">
                                <div class="description-block">
                                    <h5 class="description-header">
                                        <span id="ctl00_ContentPlaceHolder1_lblrightgroup">
                                            <span id="ctl00_ContentPlaceHolder1_lblrightgroup">
                                                <asp:Button ID="btncopy" class="btn btn-danger" OnClientClick="return copyText();"
                                                    runat="server" Text="Copy URL" />
                                                <%-- <button type="button" class="btn btn-danger">Copy URL</button>--%>
                                            </span>
                                        </span>
                                    </h5>
                                </div>
                            </div>
                        </div>
                        <%-- -----For Sadhana--%>
                        <div class="widgetleftright barset" style ="display:none;">
                            <div class="span8 border-right">
                                <div class="description-block">
                                    <h5 class="description-header"><span id="ctl00_ContentPlaceHolder1_lblleftgroup">For Client : <a runat="server" target="_blank" id="aRfLinkClient">
                                        <asp:Label ID="lblLinkClient" Style="color: blue;" runat="server"></asp:Label></a></span></h5>

                                </div>
                            </div>
                            <div class="span4 border-right">
                                <div class="description-block">
                                    <h5 class="description-header">
                                        <span id="ctl00_ContentPlaceHolder1_lblrightgroup">
                                            <span id="ctl00_ContentPlaceHolder1_lblrightgroup">
                                                <asp:Button ID="Button1" class="btn btn-danger" OnClientClick="return copyText1();"
                                                    runat="server" Text="Copy URL" />
                                                <%-- <button type="button" class="btn btn-danger">Copy URL</button>--%>
                                            </span>
                                        </span>
                                    </h5>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
              
                <div class="clearfix"></div>

                <div class="row-fluid panelpart">
                   
                    <div class="span12">
                        <div id="ctl00_ContentPlaceHolder1_Distributor1_TbBoard">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-title">
                                            <h4><i class="icon-user"></i>Distributor Details</h4>
                                            <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                                        </div>
                                        <div class="widget-body">
                                            <div class="row-fluid">
                                                <span class="span12">
                                                    <table class="table table-striped table-bordered table-advance table-hover">
                                                        <tbody>
                                                            <tr>
                                                                <td width="15%"><strong>CIN No.</strong> </td>
                                                                <td width="35%"><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_userid">
                                                                    <asp:Label ID="LblUserID" runat="server" Text=""></asp:Label></span></td>
                                                                <td width="15%"><strong>Name</strong> </td>
                                                                <td width="35%"><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_usrename">
                                                                    <asp:Label ID="LblUserName" runat="server" Text=""></asp:Label></span> </td>
                                                            </tr>
                                                            <tr>
                                                                <td><strong>Starting Date </strong></td>
                                                                <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_doj">
                                                                    <asp:Label ID="LbldateOfJoining" runat="server" Text=""></asp:Label></span> </td>
                                                               <td><%--<strong>Designation </strong>--%></td>
                                                                <td><%--<span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_designation">
                                                                    <asp:Label ID="LblRank" runat="server" Text=""></asp:Label></span> --%></td>
                                                            </tr>
                                                            <tr>
                                                                <td><strong>Distributor Code</strong> </td>
                                                                <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_suserid">
                                                                    <asp:Label ID="LblSponsorID" runat="server" Text=""></asp:Label></span> </td>
                                                                <td><strong>Distributor Name</strong> </td>
                                                                <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_susername">
                                                                    <asp:Label ID="LblSponsorName" runat="server" Text=""></asp:Label></span> </td>
                                                            </tr>
                                                            <%--   <tr>
                                                                <td><strong>Direct Member</strong> </td>
                                                                <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbldirectred">3</span>/<span id="ctl00_ContentPlaceHolder1_Distributor1_lblgreen">3</span> </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>--%>
                                                        </tbody>
                                                    </table>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                   
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-list-ol"></i>
                                    Sponsor Members
                                </h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                            </div>
                            <div class="widget-body">
                                <table class="table table-striped table-bordered table-advance table-hover">
                                    <thead>
                                        <tr>
                                            <th><i class="icon-list"></i></th>
                                            <th><i class="icon-user"></i>User Name </th>
                                            <th><i class="icon-user-md"></i>Name </th>
                                            <th><i class="icon-tags"></i>Date </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RptDirects" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("SNo")%></td>
                                                    <td><%#Eval("Member ID")%></td>
                                                    <td><%#Eval("Member Name")%></td>
                                                    <td><%#Eval("Activation Date")%></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                                <div class="space7"></div>
                                <div class="clearfix"><a href="#" class="btn btn-mini pull-right btn-danger">More</a> </div>
                            </div>
                        </div>
                    </div>
                    <div class="span6 column sortable">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="fa fa-envelope"></i>Latest News</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                            </div>
                            <div class="widget-body">

                                <marquee direction="up" scrollamount="3" style="height: 165px;">
                                    <asp:Repeater runat="server" ID="RptNews">
                                        <ItemTemplate>
                                            <h4><%#Eval("NewHeding")%></h4>
                                            <p><%#Eval("NewsDetail")%></p>
                                            <p><%#Eval("NewsDate")%></p>
                                            <hr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </marquee>

                                <div class="space7"></div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid" style="display: none;">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-title">
                                <h4><i class="icon-external-link"></i>Top Achievers</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                            </div>
                            <div class="widget-body">
                                <div class="space7"></div>
                                <div class="clearfix"><a href="#" class="btn btn-mini pull-right">More</a> </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid" style="display: none;">
                    <div class="span12">
                        <div class="widget ">
                            <div class="widget-title">
                                <h4><i class="icon-globe"></i>Announcement</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
