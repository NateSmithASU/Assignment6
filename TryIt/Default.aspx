<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt.TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;Top 10 Words in Page</p>
        <p>
            This Service Accesses an html page specified by a URL and then returns a list of the 10 most frequent words in the text content of that page, in descending order</p>
        <p>
            Service Address: http://localhost:65067/Service1.svc</p>
        <p>
            URL:<asp:TextBox ID="top10URL" runat="server" Width="698px">http://www.abrahamlincolnonline.org/lincoln/speeches/gettysburg.htm</asp:TextBox>
        </p>
        <asp:Button ID="top10Submit" runat="server" Text="Submit" OnClick="top10Submit_Click1" />
        <p>
            <asp:TextBox ID="top10Results" runat="server" Height="163px" TextMode="MultiLine" Width="728px"></asp:TextBox>
        </p>
        <p>
            Filter Words</p>
        <p>
            This service filters function words out of a string of text and returns the remaining words as a space delimited string normalized to lower-case.</p>
        <p>
            Service address: http://localhost:49395/Service1.svc</p>
        <p>
            <asp:Button ID="FilterSubmit" runat="server" OnClick="FilterSubmit_Click" Text="Filter" />
        </p>
        <p>
            <asp:TextBox ID="FilterText" runat="server" Height="222px" TextMode="MultiLine" Width="726px">Four score and seven years ago our fathers brought forth on this continent, a new nation, conceived in Liberty, and dedicated to the proposition that all men are created equal. </asp:TextBox>
        </p>
    </form>
</body>
</html>
