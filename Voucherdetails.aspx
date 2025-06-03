<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Voucherdetails.aspx.cs" Inherits="Voucherdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/css/bootstrap.min.css" rel="stylesheet">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.1/dist/js/bootstrap.bundle.min.js"></script>--%>

<%-- <link href="css/admin.css" rel="stylesheet" type="text/css" />--%>
    <link href="userpanel-8/assets/cssfile/added_css_rohit.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <%--  <div class="row">
        
            <div class="col-lg-7 col-sm-6 col-12">
                <asp:Repeater ID="RepVouDetail" runat="server" OnItemCommand ="RepVouDetail_ItemCommand" >
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-lg-7 col-sm-6 col-12">
                                <div class="voucher-detail bg-light">
                                    <div class="p-3">
                                        <h3 class="text-left text-uppercase mt-0 text-success fw-bolder">
                                            Use Voucher
                                        </h3>
                                        <p align="justify">
                                            Click on redeem now and get <%#Eval("Amount1")%> points for utilization on shopping. You will get
                                            coupons according to the package.
                                        </p>
                                        <p align="justify">
                                            Only one coupon can be redeemed in a month.
                                        </p>
                                        <asp:HiddenField ID="hdnKitiD" runat="server" Value='<%#Eval("KitiD")%>' />
                                        <asp:Button ID="btnUse" runat="server" Text="Use Voucher" CssClass="btn btn-primary"
                                            CommandName="USED" Visible='<%# Convert.ToBoolean(Eval("IsVible")) %>' OnClientClick="return confirm('Are you sure about this action ?')" />
                                        <hr>
                                        <h3 class="text-left text-uppercase mt-0 text-success fw-bolder">
                                            Cancel Voucher
                                        </h3>
                                        <p align="justify">
                                            If you want to cancel voucher and return to Company. Then Company can pay current
                                            cancellation value of <%#Eval("Amount")%> . Cancellation value always depend on current
                                            market situation & Season & Conditions.
                                        </p>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel Voucher" class="btn btn-danger"
                                            CommandName="CANCEL" Visible='<%# Convert.ToBoolean(Eval("IsVible")) %>' OnClientClick="return confirm('Are you sure about this action ?')"/>
                                            
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-sm-6 col-12">
                                <div class="image-section bg-light p-3 mb-4">
                                    <div class="image">
                                        <img src="image/shopping.jpg" alt="img-fluid" class="img-responsive imglight" width="100%">
                                    </div>
                                    <div class="buttons mt-1">
                                        <span class="badge rounded-pill bg-success" align="left">
                                            <%#Eval("VouCpDAte")%>
                                            <strong>
                                                <%#Eval("UsedDate")%>
                                            </strong></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>--%>
   <%--<div id="main-content">--%>
   <div class="container-fluid"> 
  <br />
            <asp:Repeater ID="RepVouDetail" runat="server" OnItemCommand="RepVouDetail_ItemCommand">
                <ItemTemplate>
                      <div class="row-fluid" >
                       <div class="span7">
                    <div class="voucher-detail bg-light">
                        <div class="p-3" >
                            <h3 class="text-left text-uppercase mt-0 text-success fw-bolder">Use Voucher
                            </h3>
                            <p align="justify" >
                                Click on redeem now and get <%#Eval("Amount1")%> points for utilization on shopping. You will get
   coupons according to the package.
                            </p>
                            <p align="justify" >
                                Only one coupon can be redeemed in a month.
                            </p>
                            <asp:HiddenField ID="hdnKitiD" runat="server" Value='<%#Eval("KitiD")%>' />
                            <asp:Button ID="btnUse" runat="server" Text="Use Voucher" CssClass="btn btn-primary"
                                CommandName="USED" Visible='<%# Convert.ToBoolean(Eval("IsVible")) %>' OnClientClick="return confirm('Are you sure about this action ?')" />
                            <hr>
                            <h3 class="text-left text-uppercase mt-0 text-success fw-bolder">Cancel Voucher
                            </h3>
                            <p align="justify"  >
                                If you want to cancel voucher and return to Company. Then Company can pay current
     cancellation value of <%#Eval("Amount")%> . Cancellation value always depend on current
     market situation & Season & Conditions.
                            </p>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel Voucher" class="btn btn-danger"
                                CommandName="CANCEL" Visible='<%# Convert.ToBoolean(Eval("IsVisibleCancel")) %>' OnClientClick="return confirm('Are you sure about this action ?')" />


                            <hr>
                        </div>
                    </div>
                    </div>
                    
                       <div class="span5" >
                           <%--<img src="https://capstones.in/image/shopping.jpg" class="img-responsive img-thumbnail" alt="">--%>
                           <img src="image/shopping.jpg" alt="img-fluid" class="img-responsive img-thumbnail" width="100%">
                           <hr>



                          <%-- <span class="badge rounded-pill bg-info" style="background-color: aquamarine; color: black;" align="left">
                               <%#Eval("VouCpDAte")%>
                               <strong>
                                   <%#Eval("UsedDate")%>
                               </strong>
                           </span>--%>
                            <span class="badge rounded-pill" align="left"
      style='<%# "background-color:" + (Eval("BackColor").ToString()) %>'>
    <%# Eval("VouCpDAte") %>
    <strong>
        <%# Eval("UsedDate") %>
    </strong>
</span>
                            </div>
                            </div>
                </ItemTemplate>
            </asp:Repeater>
      

 </div>
 <%--</div>--%>






   
     <%--  <div class="row">

    <div class="col-lg-7 col-sm-6 col-12">
        <asp:Repeater ID="RepVouDetail" runat="server" OnItemCommand ="RepVouDetail_ItemCommand" >
            <ItemTemplate>
                <div class="row">
                    <div class="col-lg-7 col-sm-6 col-12">
                        <div class="voucher-detail bg-light">
                            <div class="p-3">
                                <h3 class="text-left text-uppercase mt-0 text-success fw-bolder">
                                    Use Voucher
                                </h3>
                                <p align="justify">
                                    Click on redeem now and get <%#Eval("Amount1")%> points for utilization on shopping. You will get
                                    coupons according to the package.
                                </p>
                               
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 col-sm-6 col-12">
                        <div class="image-section bg-light p-3 mb-4">
                            <div class="image">
                                
                            </div>
                            <div class="buttons mt-1">
                                
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>--%>
    <script>
            function myFunctionone() {
              alert('Thank You!\nYour Shoping Point will be credited in your shopping portal.');
            }
    </script>

    <script>
            function myFunctionaa() {
                alert('Thank You!\nYour amount will be credited in your main wallet.');
            }
    </script>
</asp:Content>

