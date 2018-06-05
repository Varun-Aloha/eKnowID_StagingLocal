<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/newMain.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="eknowID.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style style="text/css">
        body {
            background: url(../images/header.png) no-repeat fixed;
            background-size: cover;
            background-size: 100% 100%;            
        }

    </style>    


    <link href="../Styles/Index-ProgressBar.css" rel="stylesheet" />
    <script src="../Scripts/pie-chart.js"></script>
    <script src="../Scripts/UserScripts/Index-ProgressBar.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <section class="middle-content-box topBar">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2 col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 col-xs-12">
                    <div class="inner-content">
                        <h2>Build Great Teams.</h2>
                        <p>The <b>Intuitive</b> Employment Screening Solution.</p>

                        <input type="button" class="btn getstart" value="Get Started" data-keyboard="true" data-toggle="modal" data-target="#mainModal" />
                        <div class="list">
                            <ul>
                                <li>No Sign up or monthly Fee</li>
                                <li>BBB Accredited</li>
                                <li>100% FCRA-Compliant</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="section-1">
        <section>
            <div class="container">
                <div class="row" style="padding:15px 0;margin-left:-65px;">
                        <div class="topseclogo">
                            <div class="col-lg-2">                                
                                <a href="PressLink.aspx"><img src="../images/PressLink.jpg" /></a>
                            </div>
                            <div class="col-lg-2">                                                     
                                <a href="PressLink.aspx"><img src="../images/MoneyWatch.jpg" onmouseover="this.src='../images/MoneyWatchhover.png'"; onmouseout="this.src='../images/MoneyWatch.jpg'"/></a>
                            </div>
                            <div class="col-lg-2">                                                                
                                <a href="PressLink.aspx"><img src="../images/Forbes.jpg" onmouseover="this.src='../images/Forbeshover.png'"; onmouseout="this.src='../images/Forbes.jpg'"/></a>
                            </div>
                            <div class="col-lg-2">                                                                
                                <a href="PressLink.aspx"><img src="../images/HfGate.jpg" onmouseover="this.src='../images/HfGatehover.png'"; onmouseout="this.src='../images/HfGate.jpg'"/></a>
                            </div>
                            <div class="col-lg-2">                                
                                <a href="PressLink.aspx"><img src="../images/InformationWeek.jpg" onmouseover="this.src='../images/InformationWeekhover.png'"; onmouseout="this.src='../images/InformationWeek.jpg'"/></a>
                            </div>
                            <div class="col-lg-2" style="text-align:right;padding:0">                                
                                <a href="PressLink.aspx"><img src="../images/EreNet.jpg" onmouseover="this.src='../images/EreNethover.png'"; onmouseout="this.src='../images/EreNet.jpg'"/ style="margin:0;"/></a>
                            </div>
                        </div>
                </div>                
            </div>
        </section>
        <div id="section3" class="background-image" style="height:325px;">
            <section>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-7 col-md-6 col-sm-12 col-xs-12 margin-top-5px">
                            <p style="font-size: 25px; color: white;margin-top:20px;margin-left:-15px;font-weight:600;">What People Say About'us</p>
                            <div id="peopleSay">
                                <div id="peopleImage">
                                    <img width="100" height="100" class="margin-top-15px" alt="Testimonials about eKnowID background checks" src="../Images/image_1_testimonial.png" />
                                </div>

                                <div class="people-description">
                                    <span class="font-bold font-size-20px">Melanie Bates</span><br />
                                    Accede Technology
                                </div>
                                <div id="peopleThaughtBeforeElement"><span class="peopeThaughtTriangle"></span></div>
                                <div id="peopleThaught">
                                    <div>I was having trouble landing a job, so I used eKnowID to see what my potential employers were seeing in my background check. eKnowID investigators checked my history, and I was surprised to see false information under my name. I was able to use the information eKnowID gave me in order fix these issues and ensure better job prospects in the future! </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-lg-offset-1 col-md-6  col-sm-12 col-xs-12">
                            <div class="row">
                                <div id="latestBlogs">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <span class="sectionTitle">Latest Blog Posts</span>
                                        </div>
                                    </div>

                                    <div class="row margin-top-10px">                                    
                                        <div class="col-lg-12 col-sm-12">
                                            <span class="color-white font-size-18px">AP IMPACT: When your criminal past <br />isn't yours</span>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="color-white margin-top-10px font-size-15px" style="line-height:27px;">It was just over two years ago when my brother, 
                                                    after being unemployed for a year and a half, found his new job. 
                                                    It was a long grueling process but he was relieved to finally be employed again. <br />
                                                    <a target="_blank" href="http://eknowid.wordpress.com/" class="btn btn-default read-more btn-read-more">Read More ></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>                    
    </div>    

    <div id="partner-section">        
        <section id="progressBar">
            <div class="container" style="padding:0;">
                <div class="row" style="padding-top:20px;margin-left:-45px;">
                    <div class="col-lg-2">
                        <div class="row text-center">

                            <div id="Progress-70" class="pie-title-center" data-percent="70">
                                <span class="progress-70"></span>
                            </div>

                        </div>
                        <div class="text-center">
                            <p class="font-arial">Employers requiring background <br />checks</p>
                        </div>
                    </div>

                    <div class="col-lg-4">
                        <div class="row text-center">
                            <div id="Progress-50" class="pie-title-center" data-percent="50">
                                <span class="progress-50"></span>
                            </div>
                        </div>
                        <div class="text-center">
                            <p>Background check containing <br />errors</p>
                        </div>
                    </div>

                    <div class="col-lg-4">
                        <div class="row text-center">
                            <div id="Progress-65" class="pie-title-center" data-percent="65">
                                <span class="progress-65"></span>
                            </div>
                        </div>
                        <div class="text-center">
                            <p>Consumers unaware of background <br />errors and outdated information</p>
                        </div>
                    </div>

                    <div class="col-lg-2">
                        <div class="row" style="margin-left:60px;">
                            <div id="Progress-100" class="pie-title-center" data-percent="100">
                                <span class="progress-100"></span>
                            </div>
                        </div>
                        <div class="text-center" style="margin-left:41px;">
                            <p>eKnowID Satisfaction <br />Guarantee</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <div class="section-1 padding-15px">
        <section class="partnersec">
            <div class="container">
                <div class="row" style="margin-left:-45px;">         
                    <div class="col-lg-2"><img src="../images/pimg1.jpg" /></div>
                    <div class="col-lg-2 margin-0px-20px"><img src="../images/pimg2.jpg" /></div>
                    <div class="col-lg-2 margin-0px-20px"><img src="../images/pimg3.jpg" /></div>
                    <div class="col-lg-2 margin-0px-50px"><img src="../images/pimg4.jpg" /></div>
                    <div class="col-lg-2 text-right padding-right-0px"><img src="../images/pimg5.jpg" /></div>
                </div>
            </div>
        </section>
    </div>    
</asp:Content>