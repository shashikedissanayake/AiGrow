<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminGreenHouses.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminGreenHouses" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphH1Main" runat="server">
    Green Houses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Small" runat="server">
    Administration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Green Houses
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
   <form runat="server">
     <dx:ASPxGridView ID="gvNetworks" runat="server" AutoGenerateColumns="False" OnDataBinding="gvNetworks_DataBinding">
        <Columns>
            <dx:GridViewDataDateColumn FieldName="greenhouse_name" Caption="Name" VisibleIndex="0"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="owner_user_id" Caption="Owner id" VisibleIndex="1"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="location_id" Caption="Location id" VisibleIndex="2"></dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
       </form>
</asp:Content>
