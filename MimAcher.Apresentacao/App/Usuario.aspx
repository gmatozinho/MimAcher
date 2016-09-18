﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.Usuario" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
    <%-- Window --%>
    <ext:Window ID="UsuarioWindowId" Width="540" Height="240" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="UsuarioFormPanelId" runat="server" Title="Usuário" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="UsuarioFieldSetId" runat="server" Title="Usuário" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>
                        
                        <%-- Código do Usuário --%>
                        <ext:TextField ID="cod_usId" Name="cod_us"  runat="server" FieldLabel="Código" />                       
                         
                        <%-- Login do Usuário --%>
                        <ext:TextField ID="loginId" Name="login" Width="470" AllowBlank="false" runat="server" FieldLabel="Login" />

                        <%-- Senha do Usuário --%>
                        <ext:TextField InputType="Password" ID="senhaId" Name="senha" Width="470" AllowBlank="false" runat="server" FieldLabel="Senha" />

                        <%-- Identificador do Usuário --%>
                        <ext:TextField ID="identificadorId" Name="identificador" Width="470"  runat="server" FieldLabel="Identificador" />
                                                

                    </Items>
                </ext:FieldSet>
            </Items>

            <BottomBar>
                <ext:StatusBar ID="UsuarioBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{UsuarioWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <ext:Hidden ID="FormatType" runat="server" />

    <%-- Store da Grid --%>
    <Store>
        <ext:Store 
            ID="StoreUsuarioId" 
            runat="server" 
            PageSize="31" 
            OnReadData="List" 
            RemoteSort="true" 
            AutoLoad="true">
            <Model>
                <ext:Model ID="ModelUsuarioId" runat="server" IDProperty="cod_us">
                    <Fields>                   
                        <ext:ModelField Name="cod_us" Type="Int" />     
                        <ext:ModelField Name="login" Type="String" />
                        <ext:ModelField Name="senha" Type="String" />
                        <ext:ModelField Name="identificador" Type="Int" />                                                
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="UsuarioGridPanelId"
        runat="server" 
        Title="Unidademento de Usuário"
        StoreID="StoreUsuarioId">         
        <%--Height="1500"--%>        

        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>                
                <ext:Column ID="cod_usColumnId" runat="server" Text="Código" DataIndex="cod_us" Visible="false" />
                <ext:Column ID="loginColumnId" runat="server" Text="Login" Flex="1" DataIndex="login" />                  
                <ext:Column ID="senhaColumnId" runat="server" Text="Senha" Flex="1" DataIndex="senha" Visible="false" />                                                  
                <ext:Column ID="identificadorColumnId" runat="server" Text="Identificador" DataIndex="identificador" Visible="false" />                            
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="UsuarioRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{UsuarioFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{UsuarioWindowId}.show();#{UsuarioFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{UsuarioGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_us" />                                
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <%-- <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" StandOut="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button> --%>

                    <%--<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" OnClientClick="Edit" Disabled="true" />--%>

                    <%--<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" OnClientClick="#{UsuarioWindowId}.show();#{cd_setorId}.setDisabled(true)" Disabled="true">--%>
                    

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
                    <%--<ext:Parameter Name="grow" Value="record.get('Id')" Mode="Raw" />--%>
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{UsuarioGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_us" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <%-- <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar> --%>

    </ext:GridPanel>

</asp:Content>


