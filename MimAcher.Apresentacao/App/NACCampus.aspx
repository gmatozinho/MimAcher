<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NACCampus.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.NACCampus" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
    <ext:Window ID="NACCampusWindowId" Width="600" Height="350" Modal="true" runat="server" Hidden="true">
        <Items>

        <%-- Form --%>
        <ext:FormPanel ID="NACCampusFormPanelId" runat="server" Title="NAC/Campus" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
                               
            <FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100" AllowBlank="false" />
                                                        
            <Items> 
            
                <ext:FieldSet ID="NACCampusFieldSetId" runat="server" Title="NAC/Campus" MarginSpec="0 0 0 10">                                                      
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />                                
                    </Defaults>
                    <Items>

                        <%-- Código do NACCampus --%>
                        <ext:TextField ID="cod_ncId" Name="cod_nc"  runat="server" FieldLabel="Código" />

                        <%-- Nome do Representante --%>
                        <ext:TextField ID="nomerepresentanteId" Name="nomerepresentante" AllowBlank="false" runat="server" FieldLabel="Nome" />

                        <%-- Latitude --%>
						<ext:TextField ID="latitudeId" Name="latitude" AllowBlank="true" runat="server" FieldLabel="Latitude" Margins="0 10 0 0"  LabelAlign="Top" Width="144" />                                        

						<%-- Longitude --%>
						<ext:TextField ID="longitudeId" Name="longitude" AllowBlank="true" runat="server" FieldLabel="Longitude" Margins="0 10 0 0"  LabelAlign="Top" Width="144" />                                        

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
                <ext:StatusBar ID="NACCampusBarId" runat="server" />
            </BottomBar>

            <%-- Botões do Form --%>
            <Buttons>
                <ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
                <ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{NACCampusWindowId}.hide()"/>
            </Buttons>

            </ext:FormPanel>
        </Items>   
    </ext:Window>

    <%-- Store da Grid --%>
    <Store>
        <ext:Store ID="StoreNACCampusId" runat="server" PageSize="31" OnReadData="List" RemoteSort="true" AutoLoad="true">
            <Model>
                <ext:Model ID="ModelNACCampusId" runat="server" IDProperty="cod_nc">
                    <Fields>
                        <ext:ModelField Name="cod_nc" Type="Int" />
                        <ext:ModelField Name="nomerepresentante" Type="String" />                        
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
        ID="NACCampusGridPanelId"
        runat="server" 
        Title="Gerenciamento de NACCampus"
        StoreID="StoreNACCampusId">         
        <%--Height="1500"--%>        


        <%-- Colunas da Grid --%>
        <ColumnModel>
            <Columns>
                <ext:Column ID="cod_ncColumnId" runat="server" Text="Código" DataIndex="cod_us" Visible="false" />
                <ext:Column ID="nomerepresentanteColumnId" runat="server" Text="Descrição" Flex="2" DataIndex="nomerepresentante" />                                  
                <ext:Column ID="loginColumnId" runat="server" Text="Login" Flex="2" DataIndex="login" />                                                  
            </Columns>            
        </ColumnModel>    
           
        <SelectionModel>
            <ext:RowSelectionModel ID="NACCampusRowSelectionModelId" Mode="Single" runat="server" >
                    <Listeners>                        
                        <Select Handler="#{NACCampusFormPanelId}.getForm().loadRecord(record); 
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
                    <ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{NACCampusWindowId}.show();#{NACCampusFormPanelId}.getForm().reset();" />

                    <%-- Edit --%>
                    <ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
                        <DirectEvents>
                            <Click OnEvent="Edit">
                                <ExtraParams>
                                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NACCampusGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nc" />                                
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
                    <ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NACCampusGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nc" />                                
                </ExtraParams>
            </ItemDblClick>
        </DirectEvents>

        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbarId" runat="server" />
        </BottomBar>

    </ext:GridPanel>

</asp:Content>