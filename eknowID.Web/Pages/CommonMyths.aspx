<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/main.master" AutoEventWireup="true"
    CodeBehind="CommonMyths.aspx.cs" Inherits="eknowID.Pages.CommonMyths" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divCommonMythsInner
        {
            height: 825px !important;
            text-align: justify;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divCommonMythsBg minWidth1000px">
        <div class="stretchDiv paddingBottom15 paddingLeft28 paddingTop10 divCommonMythsInner boxShadowIE8">
            <h1>
                Common Myths about Background Checks</h1>
            <div>
                <div class="floatLeft" style="background-image: url(../images/Myths.png); width: 84px;
                    height: 778px;">
                </div>
                <div class="floatLeft marginleft15">
                    <div class="mainCommonMythsContentDiv">
                        <div class="boldText floatLeft divCommonMythsDescription">
                            Purpose of background check is to allow Employers to find reasons not to hire you.</div>
                    </div>
                    <div class="mainCommonMythsContentDiv">
                        <div class="boldText floatLeft divCommonMythsDescription">
                            There is one big secret national database that will allow private companies and
                            the government to pull any and all data on you instantly.</div>
                    </div>
                    <div class="mainCommonMythsContentDiv">
                        <div class="boldText floatLeft divCommonMythsDescription">
                            Every criminal background check is the same - In interviewing over a 100 84% of
                            consumers believed that all background checks come from the same sources.</div>
                    </div>
                    <div class="mainCommonMythsContentDiv">
                        <div class="boldText floatLeft divCommonMythsDescription">
                            After several years, a criminal record automatically gets erased.<span class="font_weight_normal">Truth:
                                There is no such thing as an “automatic” erasure of a criminal record. Unlike a
                                credit mark that typically stays on a credit report for 7 years, an arrest record
                                stays permanently on file, even if you were never charged, or if the case was dismissed
                                and even if you were found not guilty. If you have an arrest record it is recommend
                                that you seek legal advice from an experienced attorney regarding possibly expunging
                                or other relief that may be available to you in your state or city.</span></div>
                    </div>
                    <div class="mainCommonMythsContentDiv marginTop23px">
                        <div class="boldText floatLeft divCommonMythsDescription">
                            Marijuana was legalized in my state therefore I do not have to worry about passing
                            employment drug tests anymore.</div>
                    </div>
                    <div class="mainCommonMythsContentDiv">
                        <div class="boldText floatLeft divCommonMythsDescription">
                            Employers can run your background check without you knowing it?<br />
                            <span class="font_weight_normal">There are many laws covering background checks, including
                                the federal Fair Credit Reporting Act (FCRA) and anti-discrimination statutes. Your
                                state might also have its own laws governing background screening. For example,
                                Oregon doesn't allow employers to use credit reports as a basis for hiring decisions,
                                but most states allow reasonable background checks as long as two simple rules are
                                followed:</span>                            
                            <div class="marginTop10">
                                <div class="width100per height25px">
                                    <div class="floatLeft listMenu marginTop1">
                                    </div>
                                    <div class="floatLeft marginLeft5 font_weight_normal" style="width:765px;">
                                        Make sure the candidate for screening has given consent for the background check;
                                        and knows that information disclosed in the check may be used to deny employment,
                                        credit, or other services.</div>
                                </div>
                                <div class="width100per height25px">
                                    <div class="floatLeft listMenu marginTop1">
                                    </div>
                                    <div class="floatLeft marginLeft5 font_weight_normal" style="width:765px;">
                                        Provide the candidate with the results of any reports that were the cause for rejection,
                                        along with information on how this individual can contact the screening agency to
                                        contest or correct negative information.</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
