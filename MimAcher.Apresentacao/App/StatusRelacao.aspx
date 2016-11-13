<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusRelacao.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.StatusRelacao" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="StatusRelacaoWindowId" Width="400" Height="180" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="StatusRelacaoFormPanelId" runat="server" Title="Área de Atuação" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="StatusRelacaoFieldSetId" runat="server" Title="StatusRelacao" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do StatusRelacao --%>
                        <ext:TextField ID="cod_status_relacaoId" Name="cod_status_relacao"  runat="server" FieldLabel="Código" />

                        <%-- Nome do StatusRelacao --%>
                        <ext:TextField ID="nomeId" Name="nome" AllowBlank="false" runat="server" FieldLabel="Nome" />
                        
                    </Items>
                </ext:FieldSet>
            </Items>

            <BottomBar>
                <ext:StatusBar ID="StatusRelacaoBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{StatusRelacaoWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="StatusRelacaoGridPanelId"
        runat="server" 
        Title="Gerenciamento de Área de Atuação">         
        <%--Height="1500"--%>        

         <Store>
            <ext:Store ID="StoreStatusRelacaoId" runat="server" PageSize="31" OnReadData="List" RemoteSort="true" AutoLoad="true">
                <Model>
                    <ext:Model ID="ModelStatusRelacaoId" runat="server" IDProperty="cod_status_relacao">
                        <Fields>
                            <ext:ModelField Name="cod_status_relacao" Type="Int" />
                            <ext:ModelField Name="nome" Type="String" />                        
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>

        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>                
                <ext:Column ID="nomeColumnId" runat="server" Text="Descrição" Flex="2" DataIndex="nome" />                                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="StatusRelacaoRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{StatusRelacaoFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{StatusRelacaoWindowId}.show();#{StatusRelacaoFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{StatusRelacaoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_status_relacao" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{StatusRelacaoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_status_relacao" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>


