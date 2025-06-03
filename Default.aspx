<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>
        <%=Session["Title"].ToString ()%></title>
    <script type="text/javascript">
        window.history.forward();
        function noBack() {
            window.history.forward();
        }
    </script>

    <script type="text/javascript" src="highslide/highslide-full.js"></script>

    <link rel="stylesheet" type="text/css" href="highslide/highslide.css" />

    <script type="text/javascript">
        hs.graphicsDir = 'highslide/graphics/';
        hs.align = 'center';
        hs.transitions = ['expand', 'crossfade'];
        hs.fadeInOut = true;
        hs.dimmingOpacity = 0.8;
        hs.outlineType = 'rounded-white';
        hs.marginTop = 60;
        hs.marginBottom = 40;
        hs.numberPosition = '';
        hs.wrapperClassName = 'custom';
        hs.width = 600;
        hs.height = 500;
        hs.number = 'Page %1 of %2';
        hs.captionOverlay.fade = 0;

        // Add the slideshow providing the controlbar and the thumbstrip

    </script>

    <!--Slider-in icons-->
    <!--[if lt IE 9]>
<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->

    <script language="javascript" type="text/javascript">
        function PutCursor() {
            document.loginform.Txtuid.focus();
        }
    </script>

    <script type="text/javascript">
        function disableBackButton() {
            window.history.forward();
        }
        setTimeout("disableBackButton()", 0);
    </script>

    <script type="text/javascript">

        history.pushState(null, null, location.href);
        window.onpopstate = function () {
            history.go(1);
        };

    </script>
    <link href="userpanel-8/assets/cssfile/bootstrap.min.css" rel="stylesheet">
    <link href="userpanel-8/assets/cssfile/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="userpanel-8/assets/cssfile/font-awesome.css" rel="stylesheet">
    <link href="userpanel-8/assets/cssfile/style.css" rel="stylesheet">
    <link href="userpanel-8/assets/cssfile/style_responsive.css" rel="stylesheet">
    <link id="ctl00_style_color" href="userpanel-8/assets/cssfile/style_navy-blue.css" rel="stylesheet">
    <link rel="stylesheet" href="userpanel-8/assets/cssfile/font-awesome.min.css">
    <link href="userpanel-8/assets/cssfile/jquery.fancybox.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="userpanel-8/assets/cssfile/uniform.default.css">
    <link rel="stylesheet" type="text/css" href="userpanel-8/assets/cssfile/jquery.gritter.css">
    <link rel="stylesheet" href="userpanel-8/assets/cssfile/font-awesome.min.css">
    <link href="userpanel-8/assets/css" rel="stylesheet">
    <link href="userpanel-8/assets/css(1)" rel="stylesheet">
    <link href="userpanel-8/assets/cssfile/added_css_rohit.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="userpanel-8/assets/jsfile/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="userpanel-8/assets/jsfile/jquery-1.8.3.min.js"></script>
    <script src="userpanel-8/assets/jsfile/bootstrap.min.js"></script>
    <script src="userpanel-8/assets/jsfile/jquery.blockui.js"></script>
    <script src="userpanel-8/assets/jsfile/progress.js"></script>
    <script src="userpanel-8/assets/jsfile/jquery-2.0.3.js"></script>
    <script src="userpanel-8/assets/jsfile/SearchJScript.js" type="text/javascript"></script>
    <script src="userpanel-8/assets/jsfile/scripts.js"></script>

    <style>
        .row {
            width: 100% !important;
        }

        .justify-content-center {
            justify-content: center !important;
        }

        .mt-4 {
            padding: 50px;
        }

        .text-center {
            text-align: center;
        }

        .p-3 {
            padding: 10px !important;
        }

        .w-100 {
            width: 95% !important;
        }

        .p-10 {
            padding: 10px !important;
            display: block;
        }

        @media only screen and (max-width : 767px) {
            .widget {
                width: 100% !important;
            }

            .w-100 {
                width: 90.5% !important;
            }
        }
    </style>
</head>
<body style="height: 100vh;">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <form id="aspnetForm" runat="server" name="aspnetForm">
                <%--<div class="form-body without-side">--%>
                <div class="widget" style="width: 40%; margin: auto;">
                    <!-- <div class="website-logo">
         <a href="#">
             <div class="logo">
                 <img class="logo-size" src="./files/logo-light.svg" alt="">
             </div>
         </a>
     </div> -->
                    <%--  <div class="row">--%>
                    <div class="widget-title">
                        <h4><i class="icon-user"></i>Login details</h4>
                    </div>
                    <div class="form-holder">
                        <div class="form-content">

                            <div class="widget-body">
                                <!--Logo-->
                                <div class="">
                                    <div class="logo text-center">
                                        <img src="" runat="server" id="imgLogo" width="100">
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <label for="">Username</label>
                                    <input class="form-control p-3 w-100" type="text" runat="server" id="Txtuid" name="uid" placeholder="Enter Username" aria-describedby="helpId" required="">
                                </div>
                                <div class="form-group">
                                    <label for="">Password</label>
                                    <input class="form-control p-3 w-100" type="password" runat="server" id="Txtpwd" name="pwd" placeholder="Enter Password" aria-describedby="helpId" required="">
                                </div>
                                <div class="form-group">
                                    <div class="form-check" style="display: flex; justify-content: space-between;">
                                        <label class="form-check-label">
                                            <input type="checkbox" class="form-check-input" name="" id="" value="checkedValue" checked>
                                            Remember Me
                                        </label>
                                        <a href="Forgot.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe',width: 550,height: 280,marginTop : 0 } )">Forget password?</a>
                                    </div>
                                </div>
                                <br>
                                <div class="form-group">
                                    <%--       <asp:Button ID="BtnSubmit" runat="server" Text="Login" type="submit" class="ibtn" OnClick="BtnSubmit_Click" />--%>
                                    <button type="submit" class="btn btn-danger w-100 p-10" id="BtnSubmit" runat="server" onserverclick="BtnSubmit_ServerClick">
                                        Login
                                    </button>
                                    <br>
                                    <p class="text-center">Don't Have an account ? <b><a href="Newjoining1.aspx" class="text-primary">Sign Up</a></b></p>
                                </div>

                                <div class="other-links">
                                </div>
                                <div class="page-links" style="display: none;">
                                    <a href="Newjoining1.aspx">Register new account</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- </div>--%>
                </div>

            </form>
        </div>
    </div>
    <script type="text/jsfile/javascript" src="assets/jquery.gritter.js"></script>
    <script type="text/jsfile/javascript" bsrc="assets/scripts.js"></script>
    <script type="text/jsfile/javascript" src="../disable.js"></script>
</body>
</html>
