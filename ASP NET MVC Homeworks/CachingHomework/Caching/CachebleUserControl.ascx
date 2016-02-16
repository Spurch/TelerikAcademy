<%@ OutputCache Duration="120" VaryByParam="none"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CachebleUserControl.ascx.cs" Inherits="Caching.CachebleUserControl" %>
<p>This control was cached at:</p>
<asp:Label runat="server" id="CacheControl"></asp:Label>