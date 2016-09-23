<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ensinar.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.Ensinar" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="EnsinarWindowId" Width="400" Height="180" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="EnsinarFormPanelId" runat="server" Title="Ensinar" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="EnsinarFieldSetId" runat="server" Title="Ensinar" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do Ensinar --%>
                        <ext:TextField ID="cod_eId" Name="cod_e"  runat="server" FieldLabel="Código" />

                        <%-- Nome do Ensino --%>
                        <ext:TextField ID="nomeId" Name="nome" AllowBlank="false" runat="server" FieldLabel="Nome" />
                        
                    </Items>
                </ext:FieldSet>
            </Items>

            <BottomBar>
                <ext:StatusBar ID="EnsinarBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{EnsinarWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store ID="StoreEnsinarId" runat="server" PageSize="31" OnReadData="List" RemoteSort="true" AutoLoad="true">
            <Model>
                <ext:Model ID="ModelEnsinarId" runat="server" IDProperty="cod_e">
                    <Fields>
                        <ext:ModelField Name="cod_e" Type="Int" />
                        <ext:ModelField Name="nome" Type="String" />                        
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="EnsinarGridPanelId"
        runat="server" 
        Title="Gerenciamento de Ensinar"
        StoreID="StoreEnsinarId">         
        <%--Height="1500"--%>        



        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>                
                <ext:Column ID="nomeColumnId" runat="server" Text="Descrição" Flex="2" DataIndex="nome" />                                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="EnsinarRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{EnsinarFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{EnsinarWindowId}.show();#{EnsinarFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{EnsinarGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_e" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{EnsinarGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_e" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>


