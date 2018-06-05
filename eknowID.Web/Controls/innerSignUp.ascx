<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="innerSignUp.ascx.cs"
	Inherits="eknowID.Controls.innerSignUp" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('.innercompare').blur(function () {
			if (!$(this).valid()) {
				if ($('#txtinnerPassword').val().length != 0) {
					$("#lblInnerError1").text("Please re-enter the correct password");
					$("#lblInnerError1").css("display", "inherit");
				}

			}

		});
	});
	function SignUphandle(code) {
		if (code == 13) {
			showinnerSignUp();
		}
	}
</script>
<!--[if gte IE 8]>
	<style type="text/css">
	.popupPosition
	{
	top:-135px !important;
	}
	</style>
<![endif]-->
<div class="SearchByRefLoginSignIn_MainDiv">
	<div class="SearchByRefLoginSignIn_HeadDiv">
		<b><span class="SearchByRefLoginSignIn_Heading">Sign up</span> or <a href="#" id="SignInLink"
			class="lnkColor" title="SignUp">Sign in</a></b>
	</div>
	<div id="singIn" class="SearchByRefLoginSignIn_SubHeading">
		<h3 class="marginBottom0 marginTop0 paddingBottom15">
			Create New Account</h3>
	</div>
    <div class="SearchByRefLoginSignIn_LoginDiv floatLeft">
		<div>
			<div class="boldText">
				Email Address</div>
			<div class="SearchByRefLoginSignIn_Logintxt">
				<asp:TextBox ID="txtinnerSignUpEmail" Width="273px" runat="server" CssClass="required email"
					onkeydown="SignUphandle(event.keyCode);" onkeypress="return (event.keyCode!=13);"
					MaxLength="50" ClientIDMode="Static"></asp:TextBox>
			</div>
		</div>
		<div>
			<div class="boldText">
				Password</div>
			<div class="SearchByRefLoginSignIn_Logintxt">
				<asp:TextBox ID="txtinnerPassword" Width="273px" runat="server" CssClass="required"
					minlength="6" onkeydown="SignUphandle(event.keyCode);" onkeypress="return (event.keyCode!=13);"
					TextMode="Password" MaxLength="15" ClientIDMode="Static"></asp:TextBox>
			</div>
			<div class="boldText">
				Confirm Password
			</div>
			<div class="SearchByRefLoginSignIn_Logintxt">
				<asp:TextBox ID="txtinnerConfirmPassword" Width="273px" runat="server" CssClass="required innercompare"
					minlength="6" equalTo="#txtinnerPassword" TextMode="Password" ClientIDMode="Static"
					MaxLength="15" onkeydown="SignUphandle(event.keyCode);" onkeypress="return (event.keyCode!=13);"></asp:TextBox>
			</div>
		</div>
		<asp:Label ID="lblInnerError1" Text="Please fill mandatory information to continue."
			runat="server" CssClass="red" Font-Size="10px" Font-Bold="true" ClientIDMode="Static"
			Style="display: none"></asp:Label>
		<div class="SearchByRefLoginSignIn_LoginBtnDiv">
			<%--<asp:ImageButton ID="imgBtnCreate" ImageUrl="~/Images/Create_Ac_btn.png"  ClientIDMode="Static"  runat="server"  OnClientClick="showinnerSignUp();return false;"  CausesValidation="false"/>--%>
			<input type="button" value="Create Account" onclick="showinnerSignUp();" class="blackBtnMiddle whiteColor"
				style="width: 120px; margin-left: -25px;" />
		</div>
    </div>
<div class="SearchByRefLoginSignIn_SeperatorDiv floatLeft">
			<div class="SearchByRefLoginSignIn_leftSeperatorDiv">
			</div>
           
		</div>
<div class="SearchByRefLoginSignIn_SocialSiteDiv floatLeft">
		<div class="bubbleInfo" style="width: 235px; height: 44px; float: left;">
		<div>
	   <asp:ImageButton ID="imgBtnFacebook" ImageUrl="~/Images/Sign_up_FB.png" runat="server" class="trigger"
					ClientIDMode="Static" OnClientClick="return login('facebook','SingUp','Inner')" />
		</div>	   
		<table id="dpop" class="popup popupPosition">
			<tbody><tr>
				<td id="topleft" class="corner"></td>
				<td class="top"></td>
				<td id="topright" class="corner"></td>
			</tr>
			<tr>
				<td class="left"></td>
				<td style="padding:0px;margin:0px;background-color:white;"><table class="popup-contents">
					<tbody>
					<tr>        			
						<td>Sign up using Facebook account and we will port</td>
					</tr>
					 <tr>
						<td> over whatever information we can to simplify your</td>
					</tr>
					 <tr>
						<td> account creation process.</td>
					</tr>  
					 <tr>
						  <td style="height:2px;"></td>
					</tr>         
					<tr>
						<td>Once done, use your Facebook account</td>
					</tr> 
					<tr>
						<td>credentials to sign in to our site!</td>
					</tr>   		
				</tbody></table>
				</td>
				<td class="right"></td>    
			</tr>
			<tr>
				<td class="corner" id="bottomleft"></td>
				<td class="bottom" style="padding-bottom: 0px !important; padding-top: 0px !important;"><img width="30" height="29" alt="popup tail" src="http://static.jqueryfordesigners.com/demo/images/coda/bubble-tail2.png"/></td>
				<td id="bottomright" class="corner"></td>
			</tr>
		</tbody></table>
	</div><br />
		   <div class="bubbleInfo" style="float:left;height:47px;margin-top:10px;width:240px;">
		<div>
		   <asp:ImageButton ID="imgBtnLinkedIn" ImageUrl="~/Images/Sign_up_Linkedin.png" runat="server" class="trigger"
					ClientIDMode="Static" OnClientClick="return login('LINKEDIN','SingUp','Inner')" />
		</div>
		<table id="Table1" class="popup popupPosition">
			<tbody><tr>
				<td id="toplefts" class="corner"></td>
				<td class="top"></td>
				<td id="toprights" class="corner"></td>
			</tr>
			<tr>
				<td class="left"></td>
				<td style="padding:0px;margin:0px;background-color:white;"><table class="popup-contents">
					<tbody>
				   <tr>        			
						<td>Sign up using Linkedin account and we will port</td>
					</tr>
					 <tr>
						<td> over whatever information we can to simplify your</td>
					</tr>
					 <tr>
						<td> account creation process.</td>
					</tr>  
					 <tr>
						  <td style="height:2px;"></td>
					</tr>         
					<tr>
						<td>Once done, use your Linkedin account</td>
					</tr> 
					<tr>
						<td>credentials to sign in to our site!</td>
					</tr>   		
				</tbody></table>
				</td>
				<td class="right"></td>    
			</tr>
			<tr>
				<td class="corner" id="bottomlefts"></td>
				<td class="bottom" style="padding-bottom: 0px !important; padding-top: 0px !important;"><img width="30" height="29" alt="popup tail" src="http://static.jqueryfordesigners.com/demo/images/coda/bubble-tail2.png"/></td>
				<td id="bottomrights" class="corner"></td>
			</tr>
		</tbody></table>
	</div>
	</div>
</div>
