<!DOCTYPE html>
<html lang="en">
  
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Welcome to Admin Dashboard</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta name="description">
    <meta name="author">

    <link href="assets/cssfile/bootstrap.min.css" rel="stylesheet">
    <link href="assets/cssfile/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="assets/cssfile/font-awesome.css" rel="stylesheet">
    <link href="assets/cssfile/style.css" rel="stylesheet">
    <link href="assets/cssfile/style_responsive.css" rel="stylesheet">
    <link id="ctl00_style_color" href="assets/cssfile/style_navy-blue.css" rel="stylesheet">
    <link href="assets/cssfile/jquery.fancybox.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="assets/cssfile/uniform.default.css">
    <link rel="stylesheet" type="text/css" href="assets/cssfile/jquery.gritter.css">
    <link href="assets/cssfile/added_css_rohit.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <script src="assets/jsfile/jquery-1.8.3.min.js"></script>
    <script src="assets/jsfile/bootstrap.min.js"></script>
    <script src="assets/jsfile/jquery.blockui.js"></script>
    <script src="assets/jsfile/progress.js"></script>
    <script src="assets/jsfile/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="assets/jsfile/SearchJScript.js" type="text/javascript"></script>
    <script src="assets/jsfile/scripts.js"></script>
    <style>
        .bg-white{
            background-color: #fff;
            border-radius: 10px;
        }
    </style>
</head>
  
  <body class="fixed-top">

    <div id="header" class="navbar navbar-inverse navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container-fluid">
          <a class="brand" href="#"> 
            <img height="auto" src="../panel-images/demo_logo.png" alt="" class="bg-white"> 
          </a>

          <a class="btn btn-navbar collapsed" id="main_menu_trigger" data-toggle="collapse" data-target=".nav-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"> </span>
            <span class="icon-bar"></span>
            <span class="arrow"></span>
          </a>

          <div id="top_menu" class="nav notify-row">
            <ul class="nav top-menu">
              <li class="dropdown hidden"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-cog"></i></a>
                <ul class="dropdown-menu extended inbox">
                  <li>
                    <p> You have # <span id="ctl00_lblCurrencyCount">4</span> Currency</p>
                  </li>

                  <li>
                    <a href="#"> 
                      <span class="photo"> 
                        <img src="assets/4.png" alt="flag">
                      </span> 
                      <span class="subject">
                        <span class="from"> Taka</span>
                        <span class="time"> ৳ 121.94 BDT </span>
                      </span>
                      <span class="message"> Bangladesh </span>
                    </a>
                  </li>

                  <li>
                    <a href="#"> 
                      <span class="photo"> 
                        <img src="assets/1.png" alt="flag">
                      </span> 
                      <span class="subject">
                        <span class="from"> Pound</span>
                        <span class="time"> £ 1.00 GBP </span>
                      </span>
                      <span class="message"> United Kingdom </span>
                    </a>
                  </li>

                  <li>
                    <a href="#"> 
                      <span class="photo"> 
                        <img src="assets/2.png" alt="flag">
                      </span> 
                      <span class="subject">
                        <span class="from"> Rupee</span>
                        <span class="time"> Rs. 1.00 INR </span>
                      </span>
                      <span class="message"> India </span>
                    </a>
                  </li>

                  <li>
                    <a href="#"> 
                      <span class="photo"> 
                        <img src="assets/3.png" alt="flag">
                      </span> 
                      <span class="subject">
                        <span class="from"> Dollar</span>
                        <span class="time"> $ 1.58 USD </span>
                      </span>
                      <span class="message"> United States </span>
                    </a>
                  </li>
                </ul>
              </li>

              <li class="dropdown hidden" id="header_inbox_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"> <i class="icon-envelope-alt"></i><span class="badge badge-important" style="position: absolute;"> <span id="ctl00_lblNewMessage">0</span> </span></a>
                <ul class="dropdown-menu extended inbox">
                  <li>
                    <p> You have #<span id="ctl00_lblMessageCount">0</span> new messages</p>
                  </li>
                </ul>
              </li>

              <li class="dropdown hidden" id="header_notification_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-bell-alt"></i><span class="badge badge-warning" style="position: absolute;"> <span id="ctl00_notificationlebel_count1">3</span> </span></a>
                <ul class="dropdown-menu extended notification">
                  <li>
                    <p> You have #<span id="ctl00_notificationlebel_count2">3</span> new notifications</p>
                  </li>

                  <li>
                    <a href="#">
                      <span class="label label-success"> <i class="icon-bolt"></i></span> Balance Deposit 
                      <span class="badge badge-success"> 1</span> 
                      <span class="small italic">34 mins</span> 
                    </a>
                  </li>
                  <input id="hd_notificationID" type="hidden" value="1">

                  <li>
                    <a href="#">
                      <span class="label label-success"> <i class="icon-bolt"></i></span> Balance Deduct 
                      <span class="badge badge-success"> 1</span> 
                      <span class="small italic">34 mins</span> 
                    </a>
                  </li>
                  <input id="hd_notificationID" type="hidden" value="2">

                  <li>
                    <a href="#">
                      <span class="label label-success"> <i class="icon-bolt"></i></span> Primary Board income 
                      <span class="badge badge-success"> 1</span> 
                      <span class="small italic">34 mins</span> 
                    </a>
                  </li>
                  <input id="hd_notificationID" type="hidden" value="3">

                  <li>
                    <a href="#">See all notifications</a> 
                  </li>
                </ul>
              </li>
            </ul>
          </div>
    
          <div class="top-nav ">
            <ul class="nav pull-right top-menu">
              <li class="dropdown mtop7 hidden-phone">
                <a class="dropdown-toggle element" data-placement="bottom" data-toggle="tooltip" href="#" data-original-title="Dashboard">
                  <i class="icon-home"> </i>
                </a>
              </li>

              <li class="dropdown mtop7">
                <a href="#" id="ctl00_addnew" class="dropdown-toggle element" data-placement="bottom" target="_blank" data-toggle="tooltip" data-original-title="Add New Member"> 
                  <i class="icon-plus hidden-phone"></i> 
                  <span id="mobileshow"> Join Now </span>
                </a>
              </li>

              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"> 
                  <span class="username"> Welcome : <strong>Rohit Sahu </strong></span> 
                  <b class="caret"></b>
                </a>
                <ul class="dropdown-menu">
                  <li>
                    <a href="#" target="_blank">
                      <i class="icon-user"></i> My Profile
                    </a>
                  </li>
                  <li>
                    <a onClick="link_changepassword();" role="button" data-toggle="modal" href="#myModal2"> <i class="icon-key"></i> Change Password</a>
                  </li>
                  <li class="divider"></li>
                  <li>
                    <a href="#"><i class="icon-lock"></i> Log Out</a>
                  </li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    
    <div id="container" class="row-fluid">
      <div class="scroll-bar-wrap">
        <div id="sidebar" class="nav-collapse collapse">
          <div class="navbar-inverse">
            <form class="navbar-search visible-phone">
              <input type="text" class="search-query" placeholder="Member Search">
            </form>
          </div>
          <ul class="sidebar-menu">
            <li class="">
              <a href="#" class="">
                <span class="icon-box"><i class="icon-arrow"> </i></span>Dashboard
              </a>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 1 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
              <li><a class="" href="#"> Menu Level</a></li>
              <li><a class="" href="#"> Menu Level</a></li>
              <li><a class="" href="#"> Menu Level</a></li>
              <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 2 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 3 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 4 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 5 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 6 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
                <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="javascript:;" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Menu Level - 7 
                <span class="arrow"></span> 
              </a>
              <ul class="sub">
              <li><a class="" href="#"> Menu Level</a></li>
              <li><a class="" href="#"> Menu Level</a></li>
              <li><a class="" href="#"> Menu Level</a></li>
              <li><a class="" href="#"> Menu Level</a></li>
              </ul>
            </li>
            
            <li class="has-sub">
              <a href="#" class="">
                <span class="icon-box"><i class="icon-arrow-right"> </i></span> Referral Link
                <span class="arrow"></span> 
              </a> 
            </li>
          </ul>
        </div>
        <div class="cover-bar"></div>
      </div>
      
      <div id="main-content">
        <div class="container-fluid">
          <div class="row-fluid">
            <div class="span12">
              <h3 class="page-title"> Dashboard </h3>
              <ul class="breadcrumb">
                <li>
                  <a href="#">
                    <i class="icon-home"></i>
                  </a>
                  <span class="divider">&nbsp;</span> 
                </li>
                <li>
                  <a href="#">Dashboard</a>
                  <span class="divider-last">&nbsp;</span>
                </li>
              </ul>
            </div>
          </div>

          <hr>

        <div class="row-fluid">
            

            <div class="voucher d-flex gap-3" style="justify-content: flex-start;">


                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="voucherbox">
                    <div class="col-md-4 border" style="padding: 10px;">
                        <div class="text-center">
                            <img src="https://capstones.in/image/vouchers_4.png" class="img-fluid img-thumbnail" alt="Voucher Image" style="object-fit: contain;">
                        </div>
                        <div class="card-body d-flex flex-column">
                            <h4 class="card-title text-center text-primary"> Coupon: 01 </h4>
                            <p class="card-text text-muted text-center">From: 24-Jun-2025 To: 23-Jul-2025</p>
                            <div class="text-center">
                                <a href="#" class="btn btn-primary btn-sm text-uppercase"><i class="fa fa-eye" aria-hidden="true"></i> View Details</a>
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
      </div>

      <script type="text/jsfile/javascript" src="assets/jsfile/jquery.gritter.js"></script>
      <script src="assets/jsfile/scripts.js"></script>
    </div>
    
    <div id="footer"> 2019 ©  Click Trade
      <div class="span pull-right"> <span class="go-top"><i class="icon-arrow-up"></i></span> </div>
    </div>

   
     
  </body>
</html>