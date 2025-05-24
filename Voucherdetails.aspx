<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Voucherdetails.aspx.cs" Inherits="Voucherdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%-- <div class="detail-section p-3 mb-3">--%>
        <div class="row">
        
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
                                            Click on redeem now and get <%#Eval("Amount")%> points for utilization on shopping. You will get
                                            coupons according to the package.
                                        </p>
                                        <p align="justify">
                                            Only one coupon can be redeemed in a month.
                                        </p>
                                        <asp:HiddenField ID="hdnKitiD" runat="server" Value='<%#Eval("KitiD")%>' />
                                        <%--<button type="button" runat="server" id="btnUse" class="btn btn-primary" CommandName="USED" >
                                        Use Voucher</button>--%>
                                        <asp:Button ID="btnUse" runat="server" Text="Use Voucher" CssClass="btn btn-primary"
                                            CommandName="USED" Visible='<%#Eval("IsVible")%>' OnClientClick="return confirm('Are you sure about this action ?')" />
                                        <hr>
                                        <h3 class="text-left text-uppercase mt-0 text-success fw-bolder">
                                            Cancel Voucher
                                        </h3>
                                        <p align="justify">
                                            If you want to cancel voucher and return to Company. Then Company can pay current
                                            cancellation value of <%#Eval("Amount")%> . Cancellation value always depend on current
                                            market situation & Season & Conditions.
                                        </p>
                                        <%-- <button type="button" class="btn btn-danger" onclick="CancelNow()">
                                        Cancel Voucher</button>--%>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel Voucher" class="btn btn-danger"
                                            CommandName="CANCEL" Visible='<%#Eval("IsVible")%>' OnClientClick="return confirm('Are you sure about this action ?')"/>
                                            
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 col-sm-6 col-12">
                                <div class="image-section bg-light p-3 mb-4">
                                    <div class="image">
                                        <img src="image/shopping.jpg" alt="img-fluid" class="img-responsive imglight" width="100%">
                                        <!-- <h3 class="vouchertext text-uppercase text-center" align="center"> Used </h3> -->
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
        </div>
   <%-- </div>--%>

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

