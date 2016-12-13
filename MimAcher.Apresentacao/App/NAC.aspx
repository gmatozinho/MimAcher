<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nac.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.Nac" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
	<ext:Window ID="NacWindowId" Width="600" Height="275" Modal="true" runat="server" Hidden="true">
		<Items>

		<%-- Form --%>
		<ext:FormPanel ID="NacFormPanelId" runat="server" Title="Inserir/Editar Nac" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
							   
			<FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100"  AllowBlank="false" />
														
			<Items> 
			
				<ext:FieldSet ID="NacFieldSetId" runat="server" Title="Nac" MarginSpec="0 0 0 10">                                                      
					<Defaults>
						<ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
						<ext:Parameter Name="MsgTarget" Value="side" />                                
					</Defaults>
					<Items>

						<%-- Código do Nac --%>
						<ext:TextField ID="cod_nacId" Name="cod_nac"  runat="server" FieldLabel="Código" ReadOnly="true"/>

						<%-- Nome do representante do Nac --%>
						<ext:TextField ID="nome_representanteId" Name="nome_representante" AllowBlank="false" runat="server" FieldLabel="Nome do Representante" />

						<%-- Telefone --%>
						<ext:TextField ID="telefoneId" Name="telefone" AllowBlank="false" runat="server" FieldLabel="Telefone" />

						<%-- Combobox do Usuário --%>
						<ext:ComboBox ID="cod_usuarioId" Width="300" Name="cod_usuario" AllowBlank="false" runat="server" FieldLabel="Email do Usuário" ValueField="cod_usuario_combo" DisplayField="e_mail_combo">
							<Store>
								<ext:Store ID="StoreUsuarioId" runat="server">
									<Model>
										<ext:Model ID="ModelUsuarioId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_usuario_combo" Mapping="cod_usuario" />
												<ext:ModelField Name="e_mail_combo" Mapping="e_mail" />
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
						</ext:ComboBox>   

						<%-- Combobox do Campus --%>
						<ext:ComboBox ID="cod_campusId" Width="300" Name="cod_campus" AllowBlank="false" runat="server" FieldLabel="Campus" ValueField="cod_campus_combo" DisplayField="local_combo">
							<Store>
								<ext:Store ID="StoreCampusId" runat="server">
									<Model>
										<ext:Model ID="ModelCampusId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_campus_combo" Mapping="cod_campus" />
												<ext:ModelField Name="local_combo" Mapping="local" />
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
				<ext:StatusBar ID="NacBarId" runat="server" />
			</BottomBar>

			<%-- Botões do Form --%>
			<Buttons>
				<ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
				<ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{NacWindowId}.hide()"/>
			</Buttons>

			</ext:FormPanel>
		</Items>   
	</ext:Window>

	<%-- Store da Grid --%>
	<Store>
		<ext:Store 
			ID="StoreNacId" 
			runat="server" 
			PageSize="31" 
			OnReadData="List" 
			RemoteSort="true" 
			AutoLoad="true">
			<Model>
				<ext:Model ID="ModelNacId" runat="server" IDProperty="cod_nac">
					<Fields>
						<ext:ModelField Name="cod_nac" Type="Int" />
						<ext:ModelField Name="nome_representante" Type="String" />
						<ext:ModelField Name="telefone" Type="String" />						
						<ext:ModelField Name="cod_usuario"  Type="Int" />
						<ext:ModelField Name="e_mail" ServerMapping="MA_USUARIO.e_mail" />                                                                                
						<ext:ModelField Name="cod_campus"  Type="Int" />
						<ext:ModelField Name="local" ServerMapping="MA_CAMPUS.local" />                                                                                
					</Fields>
				</ext:Model>
			</Model>
		</ext:Store>
	</Store>

 <%-- Grid --%> 
 <ext:GridPanel 
		ID="NacGridPanelId"
		runat="server" 
		Title="Gerenciamento de Nac"
		StoreID="StoreNacId">         
		<%--Height="1500"--%>    

		<%-- Colunas da Grid --%>
		<ColumnModel>
			<Columns>
				<ext:Column ID="cod_nacColumnId" runat="server" Text="Código" DataIndex="cod_nac" Visible="false" />
				<ext:Column ID="nomeRepresentanteColumnId" runat="server" Text="Nome do Representante" Flex="2" DataIndex="nome_representante" />                                  
				<ext:Column ID="localColumnId" runat="server" Text="Local" Flex="2" DataIndex="local" />                                  
				<ext:Column ID="e_mailColumnId" runat="server" Text="Email" Flex="2" DataIndex="e_mail" />                                                  
				<ext:Column ID="telefoneColumnId" runat="server" Text="Telefone" DataIndex="telefone" />                                  
			</Columns>            
		</ColumnModel>    
		   
		<SelectionModel>
			<ext:RowSelectionModel ID="NacRowSelectionModelId" Mode="Single" runat="server" >
					<Listeners>                        
						<Select Handler="#{NacFormPanelId}.getForm().loadRecord(record); 
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
					<ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{NacWindowId}.show();#{NacFormPanelId}.getForm().reset();" />

					<%-- Edit --%>
					<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Edit">
								<ExtraParams>
									<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NacGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nac" />                                
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
					<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NacGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nac" />                                
				</ExtraParams>
			</ItemDblClick>
		</DirectEvents>

		<BottomBar>
			<ext:PagingToolbar ID="PagingToolbarId" runat="server" />
		</BottomBar>

	</ext:GridPanel>

</asp:Content>
