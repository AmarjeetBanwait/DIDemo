<%@ Page Title="Contact" Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DIDemo.Web.Contact" %>
<head runat="server" />
    <h2 runat="server"><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        <strong runat="server"><%= Name %></strong><br /><br />
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
