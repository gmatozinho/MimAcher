<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aluno.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.Aluno" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="AlunoWindowId" Width="600" Height="400" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="AlunoFormPanelId" runat="server" Title="Aluno" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100"  AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="AlunoFieldSetId" runat="server" Title="Aluno" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do Aluno --%>
                        <ext:TextField ID="cod_alId" Name="cod_al"  runat="server" FieldLabel="Código" />

                        <%-- Nome do Aluno --%>
                        <ext:TextField ID="nomeId" Name="nome" AllowBlank="false" runat="server" FieldLabel="Nome" />

                        <%-- Data de Nascimento --%>
                        <ext:DateField ID="dt_nascimentoId" Name="dt_nascimento" AllowBlank="false" runat="server" FieldLabel="Data de Nascimento" Width="250"/>

                        <%-- Telefone --%>
                        <ext:TextField ID="telefoneId" Name="telefone" AllowBlank="false" runat="server" FieldLabel="Telefone" />

                        <%-- Email --%>
                        <ext:TextField ID="e_mailId" Name="e_mail" AllowBlank="false" runat="server" FieldLabel="Email" />

                        <%-- Latitude --%>
						<ext:TextField ID="latitudeId" Name="latitude" AllowBlank="true" runat="server" FieldLabel="Latitude" />                                        

						<%-- Longitude --%>
						<ext:TextField ID="longitudeId" Name="longitude" AllowBlank="true" runat="server" FieldLabel="Longitude"/>                                        

                        <%-- Combobox do Usuário --%>
                        <ext:ComboBox ID="cod_usId" Width="300" Name="cod_us" AllowBlank="false" runat="server" FieldLabel="Login do Usuário" ValueField="cod_us_combo" DisplayField="login_combo">
                            <Store>
                                <ext:Store ID="StoreUsuarioId" runat="server">
                                    <Model>
                                        <ext:Model ID="ModelUsuarioId" runat="server">
                                            <Fields>
                                                <ext:ModelField Name="cod_us_combo" Mapping="cod_us" />
                                                <ext:ModelField Name="login_combo" Mapping="login" />
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
                <ext:StatusBar ID="AlunoBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{AlunoWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store 
            ID="StoreAlunoId" 
            runat="server" 
            PageSize="31" 
            OnReadData="List" 
            RemoteSort="true" 
            AutoLoad="true">
            <Model>
                <ext:Model ID="ModelAlunoId" runat="server" IDProperty="cod_al">
                    <Fields>
                        <ext:ModelField Name="cod_al" Type="Int" />
                        <ext:ModelField Name="nome" Type="String" />
                        <ext:ModelField Name="dt_nascimento" Type="Date" />
                        <ext:ModelField Name="e_mail" Type="String" />
                        <ext:ModelField Name="telefone" Type="String" />
                        <ext:ModelField Name="latitude" Type="String" ServerMapping="geolocalizacao.Latitude" />
						<ext:ModelField Name="longitude" Type="String" ServerMapping="geolocalizacao.Longitude" />
                        <ext:ModelField Name="cod_us"  Type="Int" />
                        <ext:ModelField Name="login" ServerMapping="MA_USUARIO.login" />                                                                                
                    </Fields>
                </ext:Model>
            </Model>
        </ext:Store>
    </Store>

 <%-- Grid --%> 
 <ext:GridPanel 
        ID="AlunoGridPanelId"
        runat="server" 
        Title="Gerenciamento de Aluno"
        StoreID="StoreAlunoId">         
        <%--Height="1500"--%>    

        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>
                <ext:Column ID="cod_usColumnId" runat="server" Text="Código" DataIndex="cod_us" Visible="false" />
                <ext:Column ID="nomeColumnId" runat="server" Text="Descrição" Flex="2" DataIndex="nome" />                                  
                <ext:Column ID="loginColumnId" runat="server" Text="Login" Flex="2" DataIndex="login" />                                  
                <ext:Column ID="e_mailColumnId" runat="server" Text="Email" Flex="2" DataIndex="e_mail" />                                                  
                <ext:Column ID="telefoneColumnId" runat="server" Text="Telefone" DataIndex="telefone" />                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="AlunoRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{AlunoFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{AlunoWindowId}.show();#{AlunoFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{AlunoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_al" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{AlunoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_al" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>

