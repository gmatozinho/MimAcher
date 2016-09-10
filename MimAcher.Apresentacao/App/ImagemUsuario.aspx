<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagemUsuario.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.ImagemUsuarioUsuario" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="ImagemUsuarioWindowId" Width="400" Height="290" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="ImagemUsuarioFormPanelId" runat="server" Title="NAC/Campus" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="ImagemUsuarioFieldSetId" runat="server" Title="NAC/Campus" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do ImagemUsuario --%>
                        <ext:TextField ID="cod_iId" Name="cod_i"  runat="server" FieldLabel="Código" />

                        <%-- Combobox do Usuário --%>
                        <ext:ComboBox ID="cod_usId" Width="300" Name="cod_us" AllowBlank="false" runat="server" FieldLabel="Login do Usuário" ValueField="cod_us_combo" DisplayField="login_combo">
                            <Store>
                                <ext:Store ID="StoreUsuarioId" runat="server">
                                    <Model>
                                        <ext:Model ID="ModelUsuarioId" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="cod_us_combo" Mapping="tp_usuario" />
                                                <ext:ModelField Name="login_combo" Mapping="ds_tp_usuario" />
                                            </Fields>
                                        </ext:Model>
                                    </Model>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>   
                        
                    </Items>
                </ext:FieldSet>
            </Items>

            <BottomBar>
                <ext:StatusBar ID="ImagemUsuarioBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{ImagemUsuarioWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store ID="StoreImagemUsuarioId" runat="server" PageSize="31" OnReadData="List" RemoteSort="true" AutoLoad="true">
            <Model>
                <ext:Model ID="ModelImagemUsuarioId" runat="server" IDProperty="cod_i">
                    <Fields>
                        <ext:ModelField Name="cod_i" Type="Int" />
                        <ext:ModelField Name="cod_us"  Type="Int" />
                        <ext:ModelField Name="login" ServerMapping="MA_USUARIO.login" />                                                                                
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="ImagemUsuarioGridPanelId"
        runat="server" 
        Title="Gerenciamento de ImagemUsuario"
        StoreID="StoreImagemUsuarioId">         
        <%--Height="1500"--%>        


        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>
                <ext:Column ID="cod_iColumnId" runat="server" Text="Código" DataIndex="cod_us" Visible="false" />                
                <ext:Column ID="loginColumnId" runat="server" Text="Login" Flex="2" DataIndex="login" />                                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="ImagemUsuarioRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{ImagemUsuarioFormPanelId}.getForm().loadRecord(record); 
                                         #{EditButtonId}.setDisabled(false);
                                         #{DeleteButtonId}.setDisabled(false);" />                      
                    </Listeners>                    
            </ext:RowSelectionModel>                        
        </SelectionModel>  

        <%-- Botões da Grid --%>
        <TopBar>
            <ext:Toolbar ID="ToolbarId" runat="server">
                <Items>
                    <%-- Incluir --%>
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{ImagemUsuarioWindowId}.show();#{ImagemUsuarioFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ImagemUsuarioGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_i" />                                
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>

                    <%-- Delete --%>
                    <ext:Button ID="DeleteButtonId" runat="server" Text="Excluir Registro" Icon="Delete" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Delete">
                                <Confirmation ConfirmRequest="true" Message="Deseja excluir este registro?" />                                
                            </Click>
                        </DirectEvents>
                    </ext:Button>

                    <%-- Atualizar --%>
                    <ext:Button ID="AtualizarButtonId" runat="server" Text="Atualizar" Icon="Reload" OnDirectClick="List" /> 
                </Items>
            </ext:Toolbar>
        </TopBar>

        <%-- Double Click --%>
        <DirectEvents>
            <ItemDblClick OnEvent="Edit">
                <ExtraParams>                    
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ImagemUsuarioGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_i" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>