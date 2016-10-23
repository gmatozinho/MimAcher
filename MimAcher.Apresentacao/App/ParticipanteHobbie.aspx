<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParticipanteHobbie.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.ParticipanteHobbie" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
	<ext:Window ID="ParticipanteHobbieWindowId" Width="600" Height="220" Modal="true" runat="server" Hidden="true">
		<Items>

		<%-- Form --%>
		<ext:FormPanel ID="ParticipanteHobbieFormPanelId" runat="server" Title="ParticipanteHobbie" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
							   
			<FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100"  AllowBlank="false" />
														
			<Items> 
			
				<ext:FieldSet ID="ParticipanteHobbieFieldSetId" runat="server" Title="ParticipanteHobbie" MarginSpec="0 0 0 10">                                                      
					<Defaults>
						<ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
						<ext:Parameter Name="MsgTarget" Value="side" />                                
					</Defaults>
					<Items>

						<%-- Código do Participante Hobbie --%>
						<ext:TextField ID="cod_p_hobbieId" Name="cod_p_hobbie"  runat="server" FieldLabel="Código" />


						<%-- Combobox do Participante --%>
						<ext:ComboBox ID="cod_participanteId" Width="300" Name="cod_participante" AllowBlank="false" runat="server" FieldLabel="Nome do Participante" ValueField="cod_participante_combo" DisplayField="nome_participante_combo">
							<Store>
								<ext:Store ID="StoreParticipanteId" runat="server">
									<Model>
										<ext:Model ID="ModelParticipanteId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_participante_combo" Mapping="cod_participante" />
												<ext:ModelField Name="nome_participante_combo" Mapping="nome" />
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
						</ext:ComboBox>   

						<%-- Combobox do Item --%>
						<ext:ComboBox ID="cod_itemId" Width="300" Name="cod_item" AllowBlank="false" runat="server" FieldLabel="Item" ValueField="cod_item_combo" DisplayField="nome_item_combo">
							<Store>
								<ext:Store ID="StoreItemId" runat="server">
									<Model>
										<ext:Model ID="ModelItemId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_item_combo" Mapping="cod_item" />
												<ext:ModelField Name="nome_item_combo" Mapping="nome" />
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
				<ext:StatusBar ID="ParticipanteHobbieBarId" runat="server" />
			</BottomBar>

			<%-- Botões do Form --%>
			<Buttons>
				<ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
				<ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{ParticipanteHobbieWindowId}.hide()"/>
			</Buttons>

			</ext:FormPanel>
		</Items>   
	</ext:Window>

	<%-- Store da Grid --%>
	<Store>
		<ext:Store 
			ID="StoreParticipanteHobbieId" 
			runat="server" 
			PageSize="31" 
			OnReadData="List" 
			RemoteSort="true" 
			AutoLoad="true">
			<Model>
				<ext:Model ID="ModelParticipanteHobbieId" runat="server" IDProperty="cod_p_hobbie">
					<Fields>
						<ext:ModelField Name="cod_p_hobbie" Type="Int" />												
						<ext:ModelField Name="cod_participante"  Type="Int" />
						<ext:ModelField Name="nome_participante" Mapping="nome" ServerMapping="MA_PARTICIPANTE.nome" />                                                                                
						<ext:ModelField Name="cod_item" Type="Int" />
						<ext:ModelField Name="nome_item" Mapping="nome" ServerMapping="MA_ITEM.nome" />                                                                                
					</Fields>
				</ext:Model>
			</Model>
		</ext:Store>
	</Store>

 <%-- Grid --%> 
 <ext:GridPanel 
		ID="ParticipanteHobbieGridPanelId"
		runat="server" 
		Title="Gerenciamento de ParticipanteHobbie"
		StoreID="StoreParticipanteHobbieId">         
		<%--Height="1500"--%>    

		<%-- Colunas da Grid --%>
		<ColumnModel>
			<Columns>
				<ext:Column ID="codParticipanteHobbieColumnId" runat="server" Text="Código" DataIndex="cod_p_hobbie" Visible="false" />
				<ext:Column ID="nomeParticipanteColumnId" runat="server" Text="Participante" Flex="2" DataIndex="nome_participante" />                                  
				<ext:Column ID="nomeItemColumnId" runat="server" Text="Item" Flex="2" DataIndex="nome_item" />                                  								
			</Columns>            
		</ColumnModel>    
		   
		<SelectionModel>
			<ext:RowSelectionModel ID="ParticipanteHobbieRowSelectionModelId" Mode="Single" runat="server" >
					<Listeners>                        
						<Select Handler="#{ParticipanteHobbieFormPanelId}.getForm().loadRecord(record); 
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
					<ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{ParticipanteHobbieWindowId}.show();#{ParticipanteHobbieFormPanelId}.getForm().reset();" />

					<%-- Edit --%>
					<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Edit">
								<ExtraParams>
									<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ParticipanteHobbieGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_p_hobbie" />                                
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
					<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ParticipanteHobbieGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_p_hobbie" />                                
				</ExtraParams>
			</ItemDblClick>
		</DirectEvents>

		<BottomBar>
			<ext:PagingToolbar ID="PagingToolbarId" runat="server" />
		</BottomBar>

	</ext:GridPanel>

</asp:Content>
