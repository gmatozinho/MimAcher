<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.Erro" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="ErroWindowId" Width="400" Height="280" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="ErroFormPanelId" runat="server" Title="Inserir/Editar Erro" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="ErroFieldSetId" runat="server" Title="Erro" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do Erro --%>
                        <ext:TextField ID="cod_erroId" Name="cod_erro"  runat="server" FieldLabel="Código" ReadOnly="true"/>

                        <%-- Tipo do Erro --%>
                        <ext:TextField ID="tipoId" Name="tipo" AllowBlank="false" runat="server" FieldLabel="Tipo" />

                        <%-- O que aconteceu --%>
                        <ext:TextField ID="aconteceuId" Name="aconteceu" AllowBlank="false" runat="server" FieldLabel="O que aconteceu?" />

                        <%-- Incidência --%>
                        <ext:TextField ID="incidenciaId" Name="incidencia" AllowBlank="false" runat="server" FieldLabel="Incidência" />

                        <%-- Data do Acontecimento --%>
                        <ext:DateField ID="dt_acontecimentoId" Name="dt_acontecimento" AllowBlank="false" runat="server" FieldLabel="Data" />
                        
                    </Items>
                </ext:FieldSet>
            </Items>

            <BottomBar>
                <ext:StatusBar ID="ErroBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{ErroWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store 
            ID="StoreErroId" 
            runat="server" 
            PageSize="31" 
            OnReadData="List" 
            RemoteSort="true" 
            AutoLoad="true">
            <Model>
                <ext:Model ID="ModelErroId" runat="server" IDProperty="cod_erro">
                    <Fields>
                        <ext:ModelField Name="cod_erro" Type="Int" />
                        <ext:ModelField Name="tipo" Type="String" />                        
                        <ext:ModelField Name="aconteceu" Type="String" />                        
                        <ext:ModelField Name="incidencia" Type="Int" />                        
                        <ext:ModelField Name="dt_acontecimento" Type="Date" />                        
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="ErroGridPanelId"
        runat="server" 
        Title="Gerenciamento de Erro"
        StoreID="StoreErroId">         
        <%--Height="1500"--%>  

        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>                
                <ext:Column ID="tipoColumnId" runat="server" Text="Tipo do Erro" Flex="2" DataIndex="tipo" />                                                  
                <ext:Column ID="aconteceuColumnId" runat="server" Text="O que aconteceu?" Flex="2" DataIndex="aconteceu" />
                <ext:Column ID="incidenciaColumnId" runat="server" Text="Incidência" Flex="2" DataIndex="incidencia" />
                <ext:DateColumn ID="dt_acontecimentoColumnId" runat="server" Text="Data do acontecimento" Flex="2" DataIndex="dt_acontecimento" />
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="ErroRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{ErroFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{ErroWindowId}.show();#{ErroFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ErroGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_erro" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ErroGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_erro" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>

