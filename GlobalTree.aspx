<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GlobalTree.aspx.cs" Inherits="GlobalTree" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Global Pool Tree</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        table {
            font-size: 11px;
        }

        .globalpooltree th .globalpooltree th {
            width: 30px;
            height: 20px;
            min-width: 30px;
            min-height: 30px;
            text-align: center;
            vertical-align: middle;
        }

        .globalpooltree tr {
            height: 30px;
        }

        .selftree td,
        .selftree th {
            width: 30px;
            height: 20px;
            min-width: 30px;
            min-height: 30px;
            text-align: center;
            vertical-align: middle;
        }

        .selftree tr {
            height: 33px;
        }


        .leftarrow {
            margin-top: 200px;
            ;
        }

        .text-dark {
            color: black;
        }

        .selftree tr {
            background: linear-gradient(90deg, #372475 0%, #5e4fa2 100%);
            color: white;
        }

        .globalpooltree tr {
            background: linear-gradient(90deg, #372475 0%, #5e4fa2 100%);
            color: white;
        }

        @media (max-width: 767px) {
            .leftarrow {
                display: none !important;
            }
        }


        @media (min-width: 768px) {
            .downarrow {
                display: none !important;
            }
        }

        .global-pool-cell {
            padding: 8px;
            line-height: 1.42857143;
            vertical-align: top;
            border-top: 1px solid #ddd;
            width: 50px;
            height: auto !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="jumbotron text-center">
                <p>
                    <a href="index.aspx" class="btn btn-primary btn-sm">
                        <span class="glyphicon glyphicon-home" aria-hidden="true"></span>BACK TO HOME
                    </a>
                </p>
            </div>
            <div class="container-fluid" style="max-width: 1800px;">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="table-responsive" style="max-width: 400px; margin: auto; margin-bottom: 20px;">
                            <table class="table table-bordered text-center" style="font-size: 14px;">
                                <thead>
                                    <tr>
                                        <th colspan="2" style="background: #f5f5f5;">Global Pool Tree (999)</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="text-align: left;">Total Entry In Pool</td>
                                        <td>
                                            <asp:Literal ID="LblTotalEntryInPool" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">Today Entry In Pool</td>
                                        <td>
                                            <asp:Literal ID="LblTodayEntryInPool" runat="server" /></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <hr>
                    <div class="col-sm-5">
                        <h3 class="text-center">Global Pool Tree (999) </h3>
                        <hr>
                        <div class="table-responsive" style="background-color: #ebebeb; padding: 10px;">
                            <table class="globalpooltree table table-bordered text-center global-pool-table">
                                <asp:Repeater ID="rptTreeGrid" runat="server">
                                    <HeaderTemplate>
                                        <tr style="background-color: antiquewhite;">
                                            <td colspan="10" class="global-pool-header">
                                                <span class="text-dark"><%= RootFormNo %></span>
                                            </td>
                                        </tr>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="global-pool-cell"><%# Eval("Col1") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col2") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col3") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col4") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col5") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col6") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col7") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col8") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col9") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col10") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <%--<tr style="background-color: antiquewhite;">
                                    <td colspan="10" class="global-pool-header text-center">
                                        <span class="text-dark">
                                            <asp:Literal ID="litRootID" runat="server" /></span>
                                    </td>
                                </tr>
                                <asp:Repeater ID="rptRows" runat="server" OnItemDataBound="rptRows_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <asp:Repeater ID="rptCols" runat="server">
                                                <ItemTemplate>
                                                    <td class="global-pool-cell"><%# Container.DataItem %></td>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                            </table>
                        </div>
                    </div>

                    <div class="col-sm-2">
                        <div class="leftarrow"
                            style="display: flex; justify-content: center; align-items: center; height: 100%;">
                            <i class="fa fa-arrow-right" style="font-size: 48px; color: #337ab7;"></i>
                        </div>



                        <div class="clearfix"></div>



                        <!-- Only show this arrow on mobile (max-width: 767px) -->
                        <div class="downarrow"
                            style="display: flex; flex-direction: column; justify-content: center; align-items: center; height: 100%;">
                            <i class="fa fa-arrow-down" style="font-size: 48px; color: #337ab7;"></i>
                        </div>

                    </div>

                    <div class="col-sm-5">

                        <h3 class="text-center">Member Self Tree - (1999) </h3>
                        <hr>
                        <div class="table-responsive" style="background-color: #ebebeb; padding: 10px;">
                            <table class="selftree table table-bordered text-center" style="font-size: 11px;">
                                <asp:Repeater ID="RptSlefTree" runat="server">
                                    <HeaderTemplate>
                                        <tr style="background-color: antiquewhite;">
                                            <td colspan="10" class="global-pool-header">
                                                <span class="text-dark"><%= RootFormNo %></span>
                                            </td>
                                        </tr>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr>
                                            <td class="global-pool-cell"><%# Eval("Col1") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col2") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col3") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col4") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col5") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col6") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col7") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col8") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col9") %></td>
                                            <td class="global-pool-cell"><%# Eval("Col10") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--   <tbody>
                                    <tr style="background-color: antiquewhite;">
                                        <td colspan="10" class="global-pool-header">
                                            <span class="text-dark">
                                                <asp:Literal ID="litRootID1" runat="server" /></span>
                                        </td>
                                    </tr>
                                
                                    <asp:Repeater ID="RptMemberselfTree" runat="server" OnItemDataBound="RptMemberselfTree_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <asp:Repeater ID="rptColsMemberselfTree" runat="server">
                                                    <ItemTemplate>
                                                        <td><%# Container.DataItem %></td>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>--%>
                            </table>
                        </div>


                    </div>


                </div>
            </div>
        </div>
    </form>
</body>
</html>
