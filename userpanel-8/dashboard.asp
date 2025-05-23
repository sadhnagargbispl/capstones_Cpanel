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
    <link rel="stylesheet" href="assets/cssfile/font-awesome.min.css">
    <link href="assets/cssfile/jquery.fancybox.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="assets/cssfile/uniform.default.css">
    <link rel="stylesheet" type="text/css" href="assets/cssfile/jquery.gritter.css">
    <link rel="stylesheet" href="assets/cssfile/font-awesome.min.css">
    <link href="assets/css" rel="stylesheet">
    <link href="assets/css(1)" rel="stylesheet">
    <link href="assets/cssfile/added_css_rohit.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="assets/jsfile/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="assets/jsfile/jquery-1.8.3.min.js"></script>
    <script src="assets/jsfile/bootstrap.min.js"></script>
    <script src="assets/jsfile/jquery.blockui.js"></script>
    <script src="assets/jsfile/progress.js"></script>
    <script src="assets/jsfile/jquery-2.0.3.js"></script>
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

          <marquee behavior="alternate" onMouseOver="this.stop()" onMouseOut="this.start()" style="background:linear-gradient(to bottom, rgb(0, 30, 111) 0%, rgb(3, 27, 94) 100%) !important; font-family: Book Antiqua; color: #FFFFFF" bgcolor="#a20a3a" scrollamount="5">
            <span id="ctl00_ContentPlaceHolder1_lblmarquee" style="color:White;font-size:Medium;">
              <span>
                <span id="ctl00_ContentPlaceHolder1_lblnews">
                  <strong>News :</strong> Sample Text here... Sample Text here... Sample Text here... Sample Text here... Sample Text here... 
                  <blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">
                    <b><i>Hello dear leader good morning all of you</i></b>
                  </blockquote> |
                  <blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">
                    <b><i>Hello dear leader good morning all of you</i></b>
                  </blockquote> | 
                </span>
              </span>
            </span>
          </marquee>
          
          <div class="row-fluid panelpart">
            <div class="span12">
              <div class="span2">
                <a href="#">
                  <div class="small-box bg-aqua">
                    <div class="inner">
                      <h3> <span id="ctl00_ContentPlaceHolder1_lblTotalMember">3</span></h3>
                      <p>Direct Member </p>
                      <div class="progress my-3" style="height: 3px;">
                        <div class="progress-bar" style="width: 55%"></div>
                      </div>
                    </div>
                    <div class="icon"> <i class="icon-user" aria-hidden="true"></i> </div>
                  </div>
                </a> 
              </div>

              <div class="span2"> 
                <a href="#">
                  <div class="small-box bg-greena">
                    <div class="inner two">
                      <h3> <span id="ctl00_ContentPlaceHolder1_lblTodayMember">1852</span> </h3>
                      <p>Downline Member</p>
                      <div class="progress my-3" style="height: 3px;">
                        <div class="progress-bar" style="width: 55%"></div>
                      </div>
                    </div>
                    <div class="icon"> <i class="fa fa-users" aria-hidden="true"></i> </div>
                  </div>
                </a> 
              </div>

              <div class="span2"> 
                <a href="#">
                  <div class="small-box bg-sds">
                    <div class="inner">
                      <h3> <span id="ctl00_ContentPlaceHolder1_lblmessage">0</span> </h3>
                      <p>Total Message</p>
                      <div class="progress my-3" style="height: 3px;">
                        <div class="progress-bar" style="width: 55%"></div>
                      </div>
                    </div>
                    <div class="icon"> <i class="fa fa-envelope" aria-hidden="true"></i> </div>
                  </div>
                </a> 
              </div>

              <div class="span2">
                <div class="small-box bg-aquas4">
                  <div class="inner">
                    <h3> <span id="ctl00_ContentPlaceHolder1_lbltotalincome">1080.00</span></h3>
                    <p>Total Income</p>
                    <div class="progress my-3" style="height: 3px;">
                      <div class="progress-bar" style="width: 55%"></div>
                    </div>
                    <div class="icon"> <i class="fa fa-calculator"></i> </div>
                  </div>
                </div>
              </div>

              <div class="span2">
                <div class="small-box bg-aquas3">
                  <div class="inner">
                    <h3> <span id="ctl00_ContentPlaceHolder1_lblWithdraw">0.00</span></h3>
                    <p>Total Withdraw</p>
                    <div class="progress my-3" style="height: 3px;">
                      <div class="progress-bar" style="width: 55%"></div>
                    </div>
                    <div class="icon"> <i class="fa fa-money" aria-hidden="true"></i> </div>
                  </div>
                </div>
              </div>

              <div class="span2">
                <div class="small-box bg-aqua2">
                  <div class="inner">
                    <h3> <span id="ctl00_ContentPlaceHolder1_lblnetincome">68.00</span></h3>
                    <p> Net Income</p>
                    <div class="progress my-3" style="height: 3px;">
                      <div class="progress-bar" style="width: 55%"></div>
                    </div>
                    <div class="icon"> <i class="icon-bar-chart" aria-hidden="true"></i> </div>
                  </div>
                </div>
                <div class="span2" style="display:none;"> <a href="#">
                  <div class="small-box bg-sdsa">
                    <div class="inner">
                      <h3> <span id="ctl00_ContentPlaceHolder1_lblKycstatus">NO Kyc</span></h3>
                      <p>member</p>
                      <div class="progress my-3" style="height: 3px;">
                        <div class="progress-bar" style="width: 55%"></div>
                      </div>
                    </div>
                    <div class="icon"> <i class="fa fa-user-plus" aria-hidden="true"></i> </div>
                  </div>
                  </a> </div>
              </div>
            </div>

            <div class="row-fluid panelpart" style="display:none;">
              <div class="span12">
                <div class="span3" style="display: none;">
                  <div class="small-box bg-sds">
                    <div class="inner">
                      <h3> 
                        <span id="ctl00_ContentPlaceHolder1_Label3"></span> 
                        <span id="ctl00_ContentPlaceHolder1_Label4"></span> &nbsp;INR
                      </h3>
                      <p>Total Income</p>
                    </div>
                    <div class="icon"> <i class="fa fa-user-plus" aria-hidden="true"></i> </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a> </div>
                </div>

                <div class="span3" style="display: none;">
                  <div class="small-box bg-sds">
                    <div class="inner">
                      <h3>&nbsp;INR</h3>
                      <p>Total Income</p>
                    </div>
                    <div class="icon"> <i class="fa fa-user-plus" aria-hidden="true"></i> </div>
                    <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a> </div>
                </div>
              </div>
            </div>

            <div class="row" style="margin-bottom: 0em;">
              <div class="span12">
                <div class="span3 packeviti">
                  <div class="box box-widget widget-user-2 box2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style="background:#97b85d!important;">
                        <div class="widget-user-image"> 
                          <i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> 
                        </div>
                        <h3 class="widget-user-username headd">Total Cashback</h3>
                      </div>
                    </a>

                    <div class="widgetleftright barset">
                      <div class="span12">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id=""> <span id="ctl00_ContentPlaceHolder1_lblreturnhelp">0.00</span> </span>
                          </h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="span3 packeviti">
                  <div class="box box-widget widget-user-2 box2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style="background:#97b85d!important;">
                        <div class="widget-user-image"> <i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> </div>
                        <h3 class="widget-user-username headd">Total PV</h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_LPVT">0000.00</span> </span></h5>
                          <span class="description-text">Left</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_RPVT">0000.00</span></span></h5>
                          <span class="description-text">Right</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_totalPV">0000.00</span> </span></h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="span3 packeviti">
                  <div class="box box-widget widget-user-2 box2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style="background:#97b85d!important;">
                        <div class="widget-user-image"> <i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> </div>
                        <h3 class="widget-user-username headd">Today Network </h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_todaylnetwork">0</span> </span></h5>
                          <span class="description-text">Left</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_todayRnetwork">0</span></span></h5>
                          <span class="description-text">Right</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_todayLRnetwork">0</span> </span></h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="span3 packeviti">
                  <div class="box box-widget widget-user-2 box2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style="background:#97b85d!important;">
                        <div class="widget-user-image"> <i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> </div>
                        <h3 class="widget-user-username headd">Today PV Business </h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_TodayLBusiness">0.00</span> </span></h5>
                          <span class="description-text">Left</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_TodayRBusiness">0.00</span></span></h5>
                          <span class="description-text">Right</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header"><span id=""> <span id="ctl00_ContentPlaceHolder1_TodayLRBusiness">0.00</span> </span></h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>

                    </div>
                  </div>
                </div>
              </div>
            </div>
  
            <div class="row" style="margin-bottom: 0em;">
              <div class="span12">
                <div class="span4 packeviti">
                  <div class="box box-widget widget-user-2"> 
                    <a href="#">
                      <div class="widget-user-header bg-green" style="background:#b5984d!important;">
                        <div class="widget-user-image"> <i class="fa fa-gift" aria-hidden="true"></i> </div>
                        <h3 class="widget-user-username">e-Pin Packages</h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblleftmem"> <span id="ctl00_ContentPlaceHolder1_lbl_soldevoucher">00</span></span>
                          </h5>
                          <span class="description-text">Used</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblritmem"> <span id="ctl00_ContentPlaceHolder1_lbl_freeevoucher">00</span></span>
                          </h5>
                          <span class="description-text">Available</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lbllrtotal"> <span id="ctl00_ContentPlaceHolder1_lbl_totalevoucher">00</span></span>
                          </h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>

                    </div>
                  </div>
                </div>

                <div class="span4 packeviti">
                  <div class="box box-widget widget-user-2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style="background:#97b85d!important;">
                        <div class="widget-user-image"> <i class="fa fa-user" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #2f90d9; padding: 10px 20px; position: absolute; top: -41px; left: 38%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> </div>
                        <h3 class="widget-user-username">Direct Member</h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblleftgroup"> <span id="ctl00_ContentPlaceHolder1_lblleftcount">00</span> </span>
                          </h5>
                          <span class="description-text">Left</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblrightgroup"> <span id="ctl00_ContentPlaceHolder1_lblrigtcount">00</span></span>
                          </h5>
                          <span class="description-text">Right</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lbltotalgroup"> <span id="ctl00_ContentPlaceHolder1_lbltotalcount">00</span> </span>
                          </h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="span4 packeviti">
                  <div class="box box-widget widget-user-2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style=" background:linear-gradient(45deg,#314b55,#304a54)!important;">
                        <div class="widget-user-image"> <i class="fa fa-users" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #4f9030; padding: 10px 9px; position: absolute; top: -41px; left: 34%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> </div>
                        <h3 class="widget-user-username">Group Member</h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblleftgroup"> <span id="ctl00_ContentPlaceHolder1_lblleftgroup">00</span> </span>
                          </h5>
                          <span class="description-text">Left</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblrightgroup"> <span id="ctl00_ContentPlaceHolder1_lblrightgroup">00</span></span>
                          </h5>
                          <span class="description-text">Right</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lbltotalgroup"> <span id="ctl00_ContentPlaceHolder1_lbltotalgroup">00</span></span>
                          </h5>
                          <span class="description-text">TOTAL</span> 
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class="span3 packeviti" style="display:none;">
                  <div class="box box-widget widget-user-2">
                    <a href="#">
                      <div class="widget-user-header bg-aqua" style="background: linear-gradient(50deg,#b31615,#df0f0d)!important;">
                        <div class="widget-user-image"> <i class="fa fa-users" aria-hidden="true" style="font-size: 60px; color: rgb(247, 247, 248); background: #c31413; padding: 10px 9px; position: absolute; top: -41px; left: 34%; border-radius: 50%; border: 2px solid rgba(48, 95, 182, 0.14); opacity: .8;"></i> </div>
                        <h3 class="widget-user-username">Level Member Status</h3>
                      </div>
                    </a>
                    <div class="widgetleftright barset">
                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblleftgroup"> <span id="ctl00_ContentPlaceHolder1_lbllevelmem">0</span> </span>
                          </h5>
                          <span class="description-text">Level</span> 
                        </div>
                      </div>

                      <div class="span4 border-right">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lblrightgroup"> <span id="ctl00_ContentPlaceHolder1_lblpercentage">0</span></span>
                          </h5>
                          <span class="description-text">%</span> 
                        </div>
                      </div>

                      <div class="span4">
                        <div class="description-block">
                          <h5 class="description-header">
                            <span id="ctl00_ContentPlaceHolder1_lbltotalgroup"> <span id="ctl00_ContentPlaceHolder1_Label5"></span></span>
                          </h5>
                          <span class="description-text"></span> 
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            
            <div class="row-fluid panelpart">
              <div class="span12">
                <div id="ctl00_ContentPlaceHolder1_Distributor1_TbBoard">
                  <div class="row-fluid">
                    <div class="span12">
                      <div class="widget">
                        <div class="widget-title">
                          <h4> <i class="icon-user"></i>Distributor Details</h4>
                          <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span> 
                        </div>
                        <div class="widget-body">
                          <div class="row-fluid"> 
                            <span class="span12">
                              <table class="table table-striped table-bordered table-advance table-hover">
                                <tbody>
                                  <tr>
                                    <td width="15%"><strong>Username / User Id</strong> </td>
                                    <td width="35%">
                                      <span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_userid"> BHILWARA</span> / 
                                      <span id="ctl00_ContentPlaceHolder1_Distributor1_lblusername">00112233</span> 
                                    </td>
                                    <td width="15%"><strong> Name</strong> </td>
                                    <td width="35%"><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_usrename"> Rohit Kumar Sahu</span> </td>
                                  </tr>
                                  <tr>
                                    <td><strong>Date of Joining </strong> </td>
                                    <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_doj">09/05/2020</span> </td>
                                    <td><strong>Designation </strong> </td>
                                    <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_designation">Distributor</span> </td>
                                  </tr>
                                  <tr>
                                    <td><strong>Sponsor Username</strong> </td>
                                    <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_suserid">N/A</span> </td>
                                    <td><strong>Sponsor Name</strong> </td>
                                    <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbl_susername">N/A</span> </td>
                                  </tr>
                                  <tr>
                                    <td><strong>Direct Member</strong> </td>
                                    <td><span id="ctl00_ContentPlaceHolder1_Distributor1_lbldirectred">3</span>/<span id="ctl00_ContentPlaceHolder1_Distributor1_lblgreen">3</span> </td>
                                    <td></td>
                                    <td></td>
                                  </tr>
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

            <div class="row-fluid" style="display: none;">
              <div class="span12">
                <div class="widget ">
                  <div class="widget-title">
                    <h4> <i class="icon-globe"></i>News</h4>
                    <div class="row-fluid">
                      <div class="span12">
                        <marquee behavior="alternate" onMouseOver="this.stop()" onMouseOut="this.start()" style="background: #7dbc00; font-family: Book Antiqua; color: #FFFFFF" bgcolor="#a20a3a" scrollamount="5">
                          <span id="ctl00_ContentPlaceHolder1_lblmarquee" style="color:White;font-size:Medium;">
                            <span> 
                              <span id="ctl00_ContentPlaceHolder1_lblannocument">Announcement</span>
                            </span>
                          </span>
                        </marquee>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            
            <div class="row-fluid circle-state-overview hidden-phone" style="display: none;">
              <div class="span4 responsive clearfix" data-tablet="span3" data-desktop="span4">
                <div class="circle-wrap">
                  <div class="stats-circle turquoise-color"> <i class="icon-group"></i> </div>
                  <p> <strong></strong>Total Sponsor </p>
                </div>
              </div>

              <div class="span4 responsive" data-tablet="span3" data-desktop="span4">
                <div class="circle-wrap">
                  <div class="stats-circle red-color"> <i class="icon-user"></i> </div>
                  <p> <strong></strong> Total Team Size </p>
                </div>
              </div>

              <div class="span4 responsive" data-tablet="span3" data-desktop="span4">
                <div class="circle-wrap">
                  <div class="stats-circle green-color"> <i class="icon-bar-chart"></i> </div>
                  <p> <strong></strong>Total Income </p>
                </div>
              </div>
            </div>
            
            <div class="row-fluid">
              <div class="span6">
                <div class="widget">
                  <div class="widget-title">
                    <h4> <i class="icon-list-ol"></i>Sponsor Members</h4>
                    <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span> 
                  </div>
                  <div class="widget-body">
                    <table class="table table-striped table-bordered table-advance table-hover">
                      <thead>
                        <tr>
                          <th> <i class="icon-list"></i> </th>
                          <th> <i class="icon-user"></i>User Name </th>
                          <th> <i class="icon-user-md"></i>Name </th>
                          <th> <i class="icon-tags"></i>Date </th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td> 1 </td>
                          <td> 00000 </td>
                          <td> Sample Text here.. </td>
                          <td> 27-02-2021 </td>
                        </tr>
                        <tr>
                          <td> 2 </td>
                          <td> 00000 </td>
                          <td> Sample Text here.. </td>
                          <td> 27-02-2021 </td>
                        </tr>
                        <tr>
                          <td> 3 </td>
                          <td> 00000 </td>
                          <td> Sample Text here.. </td>
                          <td> 27-02-2021 </td>
                        </tr>
                      </tbody>
                    </table>
                    <div class="space7"> </div>
                    <div class="clearfix"> <a href="#" class="btn btn-mini pull-right">More</a> </div>
                  </div>
                </div>
              </div>

              <div class="span6 column sortable">
                <div class="widget">
                  <div class="widget-title">
                    <h4> <i class="icon-external-link"></i>Transcation History</h4>
                    <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span> 
                  </div>
                  <div class="widget-body">
                    <table class="table table-striped table-bordered table-advance table-hover">
                      <thead>
                        <tr>
                          <th> <i class="icon-list"></i> </th>
                          <th> <i class=""></i>Transaction Type </th>
                          <th> <i class="icon-user"></i>Credit </th>
                          <th> <i class="icon-user-md"></i>Debit </th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <td> 1 </td>
                          <td><a href="#"> Sample Text Here </a></td>
                          <td> 0.00 </td>
                          <td> 1000.00 </td>
                        </tr>
                        <tr>
                          <td> 2 </td>
                          <td><a href="#"> Sample Text Here </a></td>
                          <td> 1000.00 </td>
                          <td> 0.00 </td>
                        </tr>
                        <tr>
                          <td> 3 </td>
                          <td><a href="#"> Sample Text Here </a></td>
                          <td> 0.00 </td>
                          <td> 2.00 </td>
                        </tr>
                        <tr>
                          <td> 4 </td>
                          <td><a href="#"> Sample Text Here </a></td>
                          <td> 0.00 </td>
                          <td> 4.00 </td>
                        </tr>
                      </tbody>
                    </table>
                    <div class="space7"> </div>
                    <div class="clearfix"> <a href="#"> </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="row-fluid" style="display: none;">
              <div class="span12">
                <div class="widget">
                  <div class="widget-title">
                    <h4> <i class="icon-external-link"></i>Top Achievers</h4>
                    <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a></span> 
                  </div>
                  <div class="widget-body">
                    <div class="space7"> </div>
                    <div class="clearfix"> <a href="#" class="btn btn-mini pull-right">More</a> </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="row-fluid" style="display: none;">
              <div class="span12">
                <div class="widget ">
                  <div class="widget-title">
                    <h4> <i class="icon-globe"></i>Announcement</h4>
                    <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a> </span> 
                  </div>
                  <div class="widget-body" id="repMsg">.
                    <blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;"><b><i>Hello dear leader good morning all of you</i></b></blockquote>
                    <br> .
                    <blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;"><b><i>Hello dear leader good morning all of you</i></b></blockquote>
                    <br>
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

    <div id="GOOGLE_INPUT_CHEXT_FLAG" input="" input_stat="{&quot;tlang&quot;:true,&quot;tsbc&quot;:true,&quot;pun&quot;:true,&quot;mk&quot;:true,&quot;ss&quot;:true}" style="display: none;"></div>
  
    <script src="../disable.js"></script>
    
  </body>
</html>