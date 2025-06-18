<!DOCTYPE html>
<html lang="en">

<head>
    <title> Global Pool Tree</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        table{
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
    </style>


</head>

<body>

    <div class="jumbotron text-center">
        <p>
            <a href="#" class="btn btn-primary btn-sm">
                <span class="glyphicon glyphicon-home" aria-hidden="true"></span> BACK TO HOME
            </a>
        </p>
    </div>

    <div class="container-fluid" style="max-width: 1800px;">
        <div class="row">

        <div class="col-sm-12">
            <div class="table-responsive" style="max-width:400px; margin:auto; margin-bottom:20px;">
                <table class="table table-bordered text-center" style="font-size:14px;">
                    <thead>
                        <tr>
                         <th colspan="2" style="background:#f5f5f5;">Global Pool Tree (999)</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="text-align:left;">Total Entry In Pool</td>
                            <td>500</td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">Today Entry In Pool</td>
                            <td>10</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

            <hr>

            <div class="col-sm-5">
                <h3 class="text-center"> Global Pool Tree (999) </h3>
                <hr>
                <div class="table-responsive" style="background-color: #ebebeb; padding: 10px;">
                    <table class="globalpooltree table table-bordered text-center global-pool-table">
                        <tbody>
                            <tr style="background-color: antiquewhite;">
                                <td colspan="10" class="global-pool-header"><span class="text-dark">   </span></td>
                            </tr>
                            <!-- 8 empty rows -->
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">-</td>
                                <td class="global-pool-cell">123456</td>
                                <td class="global-pool-cell">111111</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">820693</td>
                                <td class="global-pool-cell">676791</td>
                                <td class="global-pool-cell">780918</td>
                                <td class="global-pool-cell">702679</td>
                                <td class="global-pool-cell">726019</td>
                                <td class="global-pool-cell">445455</td>
                                <td class="global-pool-cell">987663</td>
                                <td class="global-pool-cell">433987</td>
                                <td class="global-pool-cell">945858</td>
                                <td class="global-pool-cell">931186</td>
                            </tr>
                            <tr>
                                <td class="global-pool-cell">536669</td>
                                <td class="global-pool-cell">763397</td>
                                <td class="global-pool-cell">621631</td>
                                <td class="global-pool-cell">972727</td>
                                <td class="global-pool-cell">331221</td>
                                <td class="global-pool-cell">349418</td>
                                <td class="global-pool-cell">923444</td>
                                <td class="global-pool-cell">606814</td>
                                <td class="global-pool-cell">678963</td>
                                <td class="global-pool-cell">567728</td>
                            </tr>
                        </tbody>
                    </table>


                </div>




            </div>

            <div class="col-sm-2">
                <div class="leftarrow"
                    style="display: flex; justify-content: center; align-items: center; height: 100%;">
                    <i class="fa fa-arrow-right" style="font-size:48px;color:#337ab7;"></i>
                </div>



                <div class="clearfix"> </div>



                <!-- Only show this arrow on mobile (max-width: 767px) -->
                <div class="downarrow"
                    style="display: flex; flex-direction: column; justify-content: center; align-items: center; height: 100%;">
                    <i class="fa fa-arrow-down" style="font-size:48px;color:#337ab7;"></i>
                </div>

            </div>

            <div class="col-sm-5">

                <h3 class="text-center">Member Self Tree - (1999) </h3>
                <hr>
                <div class="table-responsive" style="background-color: #ebebeb; padding: 10px;">
                    <table class="selftree table table-bordered text-center" style="font-size: 11px;">

                        <tbody>
                            <tr style="background-color: antiquewhite;">
                                <td colspan="10" class="global-pool-header"><span class="text-dark"> </span>
                                </td>
                            </tr>
                            <!-- 10 rows, 10 columns, empty cells -->
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>
                </div>


            </div>



        </div>
    </div>

</body>

</html>