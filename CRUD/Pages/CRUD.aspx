<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px;">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEdad"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEmail"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Fec. Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbDate" TextMode="Date"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCreate" Text="Create" Visible="false" OnClick="BtnCreateClick" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnUpdate" Text="Update" Visible="false" OnClick="BtnUpdateClick"/>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnDelete" Text="Delete" Visible="false" OnClick="BtnDeleteClick"/>
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnVolver" Text="Volver" Visible="true" OnClick="BtnVolverClick" />
        </div>
    </form>
</asp:Content>
