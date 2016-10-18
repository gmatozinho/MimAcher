<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImagemParticipante.aspx.cs" Inherits="MimAcher.Apresentacao.App.ImagemParticipante" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="ImagemParticipanteWindowId" Width="400" Height="290" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="ImagemParticipanteFormPanelId" runat="server" Title="Imagem/Usuário" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="ImagemParticipanteFieldSetId" runat="server" Title="NAC/Campus" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do ImagemParticipante --%>
                        <ext:TextField ID="cod_imagemId" Name="cod_imagem"  runat="server" FieldLabel="Código" />

                        <%-- Combobox do Participante --%>
                        <ext:ComboBox ID="cod_participanteId" Width="300" Name="cod_participante" AllowBlank="false" runat="server" FieldLabel="Nome do Participante" ValueField="cod_participante_combo" DisplayField="nome_combo">
                            <Store>
                                <ext:Store ID="StoreParticipanteId" runat="server">
                                    <Model>
                                        <ext:Model ID="ModelParticipanteId" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="cod_participante_combo" Mapping="cd_participante" />
                                                <ext:ModelField Name="nome_combo" Mapping="nome" />
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
                <ext:StatusBar ID="ImagemParticipanteBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{ImagemParticipanteWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store ID="StoreImagemParticipanteId" runat="server" PageSize="31" OnReadData="List" RemoteSort="true" AutoLoad="true">
            <Model>
                <ext:Model ID="ModelImagemParticipanteId" runat="server" IDProperty="cod_imagem">
                    <Fields>
                        <ext:ModelField Name="cod_imagem" Type="Int" />
                        <ext:ModelField Name="cod_participante"  Type="Int" />
                        <ext:ModelField Name="nome" ServerMapping="MA_PARTICIPANTE.nome" />                                                                                
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="ImagemParticipanteGridPanelId"
        runat="server" 
        Title="Gerenciamento de ImagemParticipante"
        StoreID="StoreImagemParticipanteId">         
        <%--Height="1500"--%>        


        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>
                <ext:Column ID="cod_imagemColumnId" runat="server" Text="Código" DataIndex="cod_imagem" Visible="false" />                
                <ext:Column ID="nomeColumnId" runat="server" Text="Login" Flex="2" DataIndex="nome" />                                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="ImagemParticipanteRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{ImagemParticipanteFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{ImagemParticipanteWindowId}.show();#{ImagemParticipanteFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ImagemParticipanteGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_imagem" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ImagemParticipanteGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_imagem" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>
