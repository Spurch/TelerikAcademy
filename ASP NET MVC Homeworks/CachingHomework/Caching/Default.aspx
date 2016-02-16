<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Caching._Default" %>

<%@ Register TagPrefix="customUserControl" TagName="CachebleUserControl" Src="CachebleUserControl.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<asp:Label ID="CurrentTime" runat="server"></asp:Label>
		<customUserControl:CachebleUserControl id="CachebleUserControl" runat="server">
		</customUserControl:CachebleUserControl>
	</div>
	<div class="jumbotron">
		<p>There is some magic going on in the Directory Listing task. Basically what I have done is:</p>
			<p>1. I have taken three separate MSDN tutorials.</p>
			<p>2. I have reshaped/refactored and mixed them with some additional code.</p>
			<p>3. I have assembled Voltron - The Defended of the Universe.</p>
			<p>4. Voltron goes through all files and directories in this project and caches each one of them.</p>
	</div>
</asp:Content>
