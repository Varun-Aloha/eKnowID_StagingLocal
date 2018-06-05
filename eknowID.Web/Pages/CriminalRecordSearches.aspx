<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="CriminalRecordSearches.aspx.cs" Inherits="eknowID.Pages.CriminalRecordSearches" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mainContentDiv
        {
            height: 100px;
            width: 100%;
            clear: both;
        }
        .divListImage
        {
            float: left;
            background-repeat: no-repeat;
            float: left;
            height: 100px;
            width: 100px;
        }
        .divCommonMythsDescription
        {
            margin-left: 5px;
            margin-top: 15px;
            width: 795px;
        }
       .divCommonMythsInner {
    height: 590px !important;
    text-align:justify;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divCommonMythsBg minWidth1000px">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divCommonMythsInner boxShadowIE8">
            <h1>
                5 Types of Criminal Record Searches
            </h1>
            <div class="marginTop30px">
                <div class="mainContentDiv">
                    <div class="divListImage" style="background-image: url(../images/1.png);">
                    </div>
                    <div class="boldText floatLeft divCommonMythsDescription">
                        County Criminal Search - <span class="font_weight_normal">Many records are kept at the
                            county level in the U.S., and they don't always percolate up into state or federal
                            records checks. These include such things as marriage and divorce records, adoption
                            records, and violations of county laws or regulations. </span>
                    </div>
                </div>
                <div class="mainContentDiv">
                    <div class="divListImage" style="background-image: url(../images/2.png);">
                    </div>
                    <div class="boldText floatLeft divCommonMythsDescription">
                        State Criminal Search - <span class="font_weight_normal">Includes a variety of records
                            kept by state courts.</span>
                    </div>
                </div>
                <div class="mainContentDiv">
                    <div class="divListImage" style="background-image: url(../images/3.png);">
                    </div>
                    <div class="boldText floatLeft divCommonMythsDescription">
                        Federal Criminal Search - <span class="font_weight_normal">Sometimes mistaken as a national
                            search a federal database of criminal convictions have become fairly fast and routine.
                            Typical crimes found in a federal search include most white collar crimes or those
                            committed across state lines eg drug trafficking kidnapping, wire tapping or fraud.
                        </span>
                    </div>
                </div>
                <div class="mainContentDiv">
                    <div class="divListImage" style="background-image: url(../images/4.png);">
                    </div>
                    <div class="boldText floatLeft divCommonMythsDescription">
                        National Criminal Search - <span class="font_weight_normal">Although the search is mostly
                            referred to as a national criminal search this is misleading. There is no such thing
                            as a national search as the search is comprised of only limited data accessible
                            and or scraped from various courthouses around the U.S. The proper names is multi-state
                            search. Therefore if you are searching for a national criminal search on the internet
                            and come across a site that offer a national search close your browser quickly!
                            The only available national search is conducted by the FBI using the NCIS database
                            which is limits its use to law enforcement and other approved agencies only.
                        </span>
                    </div>
                </div>
                <div class="mainContentDiv">
                    <div class="divListImage" style="background-image: url(../images/5.png);">
                    </div>
                    <div class="boldText floatLeft divCommonMythsDescription">
                        Arrest and Other Offender Data - <span class="font_weight_normal">Registries of those
                            convicted of various crimes. Many states maintain sex-offender and drunk-driver
                            registries, and lists detailing other kinds of offenders. Military Records known
                            as DD214 may include record and offenses while an applicant was in the military.
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
