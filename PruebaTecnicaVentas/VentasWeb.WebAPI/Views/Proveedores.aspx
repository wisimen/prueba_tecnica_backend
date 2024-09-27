<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="VentasWeb.WebAPI.Views.Proveedores" %>

<asp:Content ID="Content1" ViewStateMode="Disabled" ContentPlaceHolderID="MainContent" runat="server">


    <%--Tarea: Rodear con un update panel iniciando aquí--%>
    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" RenderMode="Block" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <div class="bg-light rounded h-100 p-4">
                        <h2 class="mb-4">Proveedores</h2>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" CssClass="table table-hover" OnDataBinding="GridView1_DataBinding">
                                <Columns>
                                    <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                                    <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-sm bg-info btn-lg-square" />
                                    <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-sm bg-danger btn-lg-square" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:VentasWebConnectionString %>" 
                                SelectCommand="SELECT * FROM [Proveedores]" 
                                DeleteCommand="DELETE FROM [Proveedores] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [Proveedores] ([Nombre], [Direccion], [Telefono]) VALUES (@Nombre, @Direccion, @Telefono)" 
                                UpdateCommand="UPDATE [Proveedores] SET [Nombre] = @Nombre, [Direccion] = @Direccion, [Telefono] = @Telefono WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="String" DbType="Guid" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Nombre" Type="String" />
                                    <asp:Parameter Name="Direccion" Type="String" />
                                    <asp:Parameter Name="Telefono" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Nombre" Type="String" />
                                    <asp:Parameter Name="Direccion" Type="String" />
                                    <asp:Parameter Name="Telefono" Type="String" />
                                    <asp:Parameter Name="Id"  DbType="Guid" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </div>
                        <hr />
                        <%--reload btn--%>
                        <asp:Button ID="ReloadBtn" runat="server" Text="Recargar" OnClick="ReloadBtn_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowEditing" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowUpdating" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDeleting" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
