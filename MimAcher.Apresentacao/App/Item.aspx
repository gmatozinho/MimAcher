<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.Item" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="ItemWindowId" Width="400" Height="180" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="ItemFormPanelId" runat="server" Title="Item" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="ItemFieldSetId" runat="server" Title="Item" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do Item --%>
                        <ext:TextField ID="cod_itemId" Name="cod_item"  runat="server" FieldLabel="Código" />

                        <%-- Nome do Item --%>
                        <ext:TextField ID="nomeId" Name="nome" AllowBlank="false" runat="server" FieldLabel="Nome" />
                        
                    </Items>
                </ext:FieldSet>
            </Items>

            <BottomBar>
                <ext:StatusBar ID="ItemBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{ItemWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store 
            ID="StoreItemId" 
            runat="server" 
            PageSize="31" 
            OnReadData="List" 
            RemoteSort="true" 
            AutoLoad="true">
            <Model>
                <ext:Model ID="ModelItemId" runat="server" IDProperty="cod_item">
                    <Fields>
                        <ext:ModelField Name="cod_item" Type="Int" />
                        <ext:ModelField Name="nome" Type="String" />                        
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="ItemGridPanelId"
        runat="server" 
        Title="Gerenciamento de Item"
        StoreID="StoreItemId">         
        <%--Height="1500"--%>  

        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>                
                <ext:Column ID="nomeColumnId" runat="server" Text="Descrição" Flex="2" DataIndex="nome" />                                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="ItemRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{ItemFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{ItemWindowId}.show();#{ItemFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ItemGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_item" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ItemGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_item" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>


