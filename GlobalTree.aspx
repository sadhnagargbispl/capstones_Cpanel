<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GlobalTree.aspx.cs" Inherits="GlobalTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <!-- <meta name="viewport" content="width=device-width, initial-scale=1" /> -->
    <title>Tree Blocks</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        body {
            font-family: Calibri, Arial, sans-serif;
        }

        .justify-center {
            justify-content: center !important;
        }

        .items-center {
            align-items: center !important;
        }

        .min-h-screen {
            min-height: 100vh !important;
        }

        .flex {
            display: flex !important;
        }

        .flex-col {
            flex-direction: column !important;
        }

        .font-normal {
            font-size: 25px !important;
        }

        .w-6 {
            width: 3.5rem !important;
        }

        .h-6 {
            height: 3.5rem !important;
        }

        .text-\[11px\] {
            font-size: 25px !important;
        }

        .py-0\.5 {
            padding-top: 1.125rem !important;
            padding-bottom: 1.125rem !important;
        }

        .bg-yellow-700 {
            opacity: 1;
            background-color: #ffcb70 !important;
        }

        .md\:flex-row {
            flex-direction: row !important;
        }

        .gap-20 {
            gap: 5rem;
        }

        .bg-yellow-300 {
            bg-opacity: 1;
            background-color: rgb(253 224 71);
        }

        .space-x-1 > :not([hidden]) ~ :not([hidden]) {
            margin-right: 0.25rem;
            margin-left: 0.25rem;
        }
    </style>
</head>
<body class="bg-white">
    <form id="form1" runat="server">
        <div>
            <div class="flex justify-center items-center p-4">
                <div class="flex flex-col md:flex-row items-center gap-20">
                    <!-- MEMBER SELF TREE block -->
                    <div class="flex flex-col items-center">
                        <div class="text-[11px] mb-1 select-none">MEMBER SELF TREE (block)</div>
                        <table class="border-collapse border border-black" style="font-size: 11px; line-height: 1;">
                            <thead>
                                <tr>
                                    <th colspan="10" class="bg-yellow-300 border border-black py-0.5">
                                        <div class="text-center font-normal">Self ID</div>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                </tr>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                </tr>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                </tr>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                </tr>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                </tr>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                </tr>
                                <tr>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-700"></td>
                                    <td class="w-6 h-6 border border-black bg-yellow-300 text-center font-normal">1</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <!-- Arrows between blocks -->
                    <div class="flex flex-col items-center space-y-6">
                        <i class="fa fa-long-arrow-down text-black text-xl font-normal  select-none"></i>
                        <i class="fa fa-long-arrow-left text-black text-xl  font-normal select-none"></i>
                    </div>
                    <!-- GLOBLE POOL TREE block -->
                    <div class="flex flex-col items-center relative">
                        <div class="text-[11px] mb-1 select-none">GLOBLE POOL TREE (block)</div>
                        <asp:Repeater ID="Grdtotal" runat="server" OnItemDataBound="Grdtotal_ItemDataBound">
                            <HeaderTemplate>
                                <table class="border-collapse border border-black" style="font-size: 11px; line-height: 1;">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <asp:Repeater ID="InnerRepeater" runat="server">
                                        <ItemTemplate>
                                            <td class="w-6 h-6 border border-black bg-yellow-700">
                                                <%# Eval("FormNoDwn") %>
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <%--<table class="border-collapse border border-black" style="font-size: 11px; line-height: 1;">
                            <thead>
                                <tr>
                                    <th colspan="10" class="bg-yellow-300 border border-black py-0.5">
                                        <div class="text-center font-normal">1</div>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Grdtotal" runat="server" OnItemDataBound="Grdtotal_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Repeater ID="InnerRepeater" runat="server">
                                            <ItemTemplate>
                                                <div><%# Eval("FormNoDwn") %></div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>--%>
                        <div class="flex items-center mt-1 space-x-1 select-none" style="font-size: 11px;">
                            <i class="fa fa-long-arrow-left font-normal"></i>
                            <span class="font-normal">ENTRY</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js" integrity="sha384-BBtl+eGJRgqQAUMxJ7pMwbEyER4l1g+O15P+16Ep7Q9Q+zqX6gSbd85u4mG4QzX+" crossorigin="anonymous"></script>
</body>
</html>
