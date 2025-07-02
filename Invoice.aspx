<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receipt</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
        rel="stylesheet">

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .invoice {
            box-shadow: 0px 0px 20px 0px #616161;
            border-radius: 5px;
            padding: 20px;
            background: white;
            width: 100%;
            max-width: 800px;
            margin: auto;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid black;
            text-align: left;
            padding: 8px;
        }

        th {
            background-color: #f2f2f2;
        }

        .header, .footer {
            font-weight: bold;
        }

        .right {
            text-align: right;
        }
        /* Print Styles */ @media print {
            body {
                background: none;
                -webkit-print-color-adjust: exact;
                print-color-adjust: exact;
            }

            .container {
                width: 100%;
                margin: 0;
                padding: 0;
            }

            .invoice {
                box-shadow: none;
                border: none;
                width: 100%;
                margin: 0;
                padding: 10px;
            }

            table, th, td {
                border: 1px solid black;
            }

            .no-print {
                display: none;
            }

            .page-break {
                page-break-before: always;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container mt-5">
                <div class="row justify-content-center">
                    <div class="col-lg-10 col-md-12">
                        <div class="invoice">
                            <div class="d-flex justify-content-between">
                                <div class="name">
                                    <h3><%=Session["CompName"] %></h3>
                                    <p>
                                        For pickup center or product delivery challan Complete payment receipt
                                    </p>
                                </div>
                                <div class="logo mt-4">
                                    <img src='<%= Session["LogoUrl"]%>' alt="Logo" class="img-responsive"
                                        height="50">
                                </div>
                            </div>
                            <hr>
                            <p>
                                Address : Ground Floor, Plot No. B14/10/18, MIDC Main Road, Colgate Chowk, Near Bank of India & Union Bank, Waluj, Chhatrapati Sambhaji Nagar - 431136 - Maharashtra, India
                            </p>
                            <p>
                                GST No. : 
                            </p>
                            <p>
                                This is not GST bill, Only Automated Payment Receipt
                            </p>
                            <table>
                                <tr>
                                    <td class="header">Date:
                                    </td>
                                    <td>
                                        <asp:Label ID="LblDate" runat="server"></asp:Label>
                                    </td>
                                    <td class="header">Receipt No.:
                                    </td>
                                    <td>
                                        <asp:Label ID="LblOderNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="header">Customer:
                                    </td>
                                    <td>
                                        <asp:Label ID="LblName" runat="server"></asp:Label>
                                    </td>
                                    <td class="header">User ID:
                                    </td>
                                    <td>
                                        <asp:Label ID="LblID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="header">Customer Mobile No.:
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="LblMobileNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="header">Customer Address:
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="LblAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br>

                            <table>
                                <tr>
                                    <td class="header">Total Amount:
                                    </td>
                                    <td >
                                        <asp:Label ID="LblTOtalAmount" runat="server"></asp:Label>
                                    </td>
                                    
                                </tr>
                            </table>
                            <br>
                           
                            <asp:Button ID="btnBack" runat="server" Text="Back" class="btn btn-primary no-print"
                                OnClientClick="return confirmRedirect();" />
                            <button class="btn btn-primary no-print" onclick="window.print()">
                                Print</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        function confirmRedirect() {
            if (confirm("Do you want to go back to the homepage?")) {
                window.location.href = "index.aspx";
                return false; // Prevents postback
            }
            return false; // Stay on the page if the user cancels
        }
    </script>
</body>
</html>
