<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoogleAPIWebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Google API Homework </h1><h6>Dr. Ahmad Rawashdeh's class</h6>
    <header>
        <script type="text/javascript" >           
        </script>    
    </header>
    <main>
        <br />
        input any query, the cx of your program search, and the key of your google developers account, then click on search and save the returned file. 
        <br />
        <br />
        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <asp:Label runat="server" Text="Input Query" ID="Label1">Input Query</asp:Label>
                <asp:TextBox runat="server" ID="queryTextBox"></asp:TextBox>
            </section>
            <section class="col-md-4" style="align-content:center" aria-labelledby="gettingStartedTitle">
                <asp:Label runat="server" Text="Input cx" ID="Label4">Input cx</asp:Label>
                <asp:TextBox runat="server" ID="cxTextBox"></asp:TextBox>
                <br />
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                 <asp:Label runat="server" Text="Input key" ID="Label3">Input key</asp:Label>
                <asp:TextBox runat="server" ID="keyTextBox"></asp:TextBox>
                <br />
            </section>
        </div>
        <asp:Button runat="server" Text="Search" style="align-content:center" onClientClick="search();" onclick="Unnamed2_Click"></asp:Button>
              
        <div style="align-content:center" >
            <asp:Label runat="server" ID="outputLabel">...</asp:Label>
        </div>

    </main>

</asp:Content>
