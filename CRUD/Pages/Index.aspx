<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width: 300px;"">
            <h2>Listado de registros</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Create" OnClick="BtnCreateClick"/>
                </div>
            </div>
        </div>
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvUsuarios" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" CssClass="btn btn-info form-control-sm" ID="BtnRead" OnClick="BtnReadClick"/>
                                <asp:Button runat="server" Text="Update" CssClass="btn btn-warning form-control-sm" ID="BtnUpdate" OnClick="BtnUpdateClick"/>
                                <asp:Button runat="server" Text="Delete" CssClass="btn btn-danger form-control-sm" ID="BtnDelete" OnClick="BtnDeleteClick"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
