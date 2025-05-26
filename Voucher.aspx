<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Voucher.aspx.cs" Inherits="Voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<link href="css/admin.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="userpanel-8/assets/cssfile/added_css_rohit.css" rel="stylesheet" type="text/css" />--%>
    <link href="userpanel-8/assets/cssfile/added_css_rohit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
  <%--   <div class="row-fluid panelpart">

         <div class="row-fluid panelpart">
  
            <div class="row">
                <div class="col-lg-2 col-sm-2 col-12">
                </div>
                <div class="col-lg-8 col-sm-8 col-12">
                    <div class="Benefits border text-center p-3 mt-1">
                        
                        <h6>
                            <strong>You Have Instant Monthly Benefits</strong></h6>
                        <p class="mb-0 text-danger">
                            <strong style=" display:none;">
                                <asp:Label ID="lblShopPoint" runat="server" Text="Label" Visible="false"></asp:Label>
                                X
                                <asp:Label ID="lblCoupon" runat="server" Text="Label" Visible="false"></asp:Label>
                                Coupons</strong></p>
                        <br />
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <a href="#" type="button" class="btn btn-danger" target="_blank">View Shopping Portal</a>
                            &nbsp; &nbsp; <a href="VoucherReport.aspx" type="button" class="btn btn-warning">
                                View Coupons Detail</a>
                        </div>
                        <br>
                    </div>
                </div>
                <div class="col-lg-2 col-sm-2 col-12">
                </div>
            </div>
    <div class="voucher-section p-2">
        <div class="container">
            <div class="row">
                <asp:Repeater ID="RptCOupon" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-sm-6 col-12">
                            <div class="card p-1">
                                <div class="relative-box">
                                    <div class="absolute-box">
                                        From :
                                        <%#Eval("FromDAte")%>
                                        <br>
                                        To :
                                        <%#Eval("ToDate")%>
                                    </div>
                                </div>
                                <div class="image">
                                    <div class="image">
                                        <img src="<%#Eval("Vouimg")%>" class="img-responsive img-thumbnail" alt="">
                                    </div>
                                </div>
                                <div class="relative-box-1">
                                    <div class="absolute-box-1">
                                        <%#Eval("CouponNo")%>
                                    </div>
                                </div>
                                <div class="buttons mt-1">
                                    <a href="Voucherdetails.aspx?FormNo=<%#Eval("Formno")%>&VNo=<%#Eval("CouponNo")%>&kID=<%#Eval("KitID")%>&ID=<%#Eval("ID")%>"
                                        type="button" class="btn btn-primary buttonwd  text-uppercase">View Details</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</div>
</div>--%>
     <div class="row-fluid">
     <div class="Benefits border text-center p-3 mt-1">
    
   <h6>
    <strong>You Have Instant Monthly Benefits</strong></h6>
<p class="mb-0 text-danger">
    <strong style=" display:none;">
        <asp:Label ID="lblShopPoint" runat="server" Text="Label" Visible="false"></asp:Label>
        X
        <asp:Label ID="lblCoupon" runat="server" Text="Label" Visible="false"></asp:Label>
        Coupons</strong></p>
<br />
<div class="btn-group" role="group" aria-label="Basic example">
    <a href="#" type="button" class="btn btn-danger" target="_blank">View Shopping Portal</a>
    &nbsp; &nbsp; <a href="VoucherReport.aspx" type="button" class="btn btn-warning">
        View Coupons Detail</a>
</div>
<br />
         <br />
              <div class="voucher d-flex gap-3" style="justify-content: flex-start; padding-left:10px">

<asp:Repeater ID="RptCOupon" runat="server">
    <ItemTemplate>
         <div class="voucherbox">
             <div class="col-md-4 border" style="padding: 10px;">
                
        <div class="text-center">
             <img src="<%#Eval("Vouimg")%>" class="img-responsive img-thumbnail"  alt="Voucher Image" style="object-fit: contain;" >
                 </div>
                 <div class="card-body d-flex flex-column">
                     <h4 class="card-title text-center text-primary">  <%#Eval("CouponNo")%> </h4>
                     <p class="card-text text-muted text-center">  From :
  <%#Eval("FromDAte")%>
  <br>
  To :
  <%#Eval("ToDate")%></p>
                     <div class="text-center">
                          <a href="Voucherdetails.aspx?FormNo=<%#Eval("Formno")%>&VNo=<%#Eval("CouponNo")%>&kID=<%#Eval("KitID")%>&ID=<%#Eval("ID")%>"
     type="button" class="btn btn-primary buttonwd  text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i>View Details</a>
                     </div>
                 </div>
   
             </div>
         </div>
            </ItemTemplate>
</asp:Repeater>
           </div>
</div>

     
 
 
  
  </div>
</asp:Content>

