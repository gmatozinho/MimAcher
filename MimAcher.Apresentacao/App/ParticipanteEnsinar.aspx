<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParticipanteEnsinar.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.ParticipanteEnsinar" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
	<ext:Window ID="ParticipanteEnsinarWindowId" Width="600" Height="247" Modal="true" runat="server" Hidden="true">
		<Items>

		<%-- Form --%>
		<ext:FormPanel ID="ParticipanteEnsinarFormPanelId" runat="server" Title="ParticipanteEnsinar" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
							   
			<FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100"  AllowBlank="false" />
														
			<Items> 
			
				<ext:FieldSet ID="ParticipanteEnsinarFieldSetId" runat="server" Title="ParticipanteEnsinar" MarginSpec="0 0 0 10">                                                      
					<Defaults>
						<ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
						<ext:Parameter Name="MsgTarget" Value="side" />                                
					</Defaults>
					<Items>

						<%-- Código do Participante Ensinar --%>
						<ext:TextField ID="cod_p_ensinarId" Name="cod_p_ensinar"  runat="server" FieldLabel="Código" />


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
						
						<%-- Combobox do Status da Relação --%>
						<ext:ComboBox ID="cod_s_relacaoId" Width="300" Name="cod_s_relacao" AllowBlank="false" runat="server" FieldLabel="Status" ValueField="cod_s_relacao_combo" DisplayField="nome_combo">
							<Store>
								<ext:Store ID="StoreStatusRelacaoId" runat="server">
									<Model>
										<ext:Model ID="ModelStatusRelacaoId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_s_relacao_combo" Mapping="cod_s_relacao" />
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
				<ext:StatusBar ID="ParticipanteEnsinarBarId" runat="server" />
			</BottomBar>

			<%-- Botões do Form --%>
			<Buttons>
				<ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
				<ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{ParticipanteEnsinarWindowId}.hide()"/>
			</Buttons>

			</ext:FormPanel>
		</Items>   
	</ext:Window>

	<%-- Store da Grid --%>
	<Store>
		<ext:Store 
			ID="StoreParticipanteEnsinarId" 
			runat="server" 
			PageSize="31" 
			OnReadData="List" 
			RemoteSort="true" 
			AutoLoad="true">
			<Model>
				<ext:Model ID="ModelParticipanteEnsinarId" runat="server" IDProperty="cod_p_ensinar">
					<Fields>
						<ext:ModelField Name="cod_p_ensinar" Type="Int" />												
						<ext:ModelField Name="cod_participante"  Type="Int" />
						<ext:ModelField Name="nome_participante" Mapping="nome_participante" ServerMapping="MA_PARTICIPANTE.nome" />                                                                                
						<ext:ModelField Name="cod_item" Type="Int" />
						<ext:ModelField Name="nome_item" Mapping="nome_item" ServerMapping="MA_ITEM.nome" />  
						<ext:ModelField Name="cod_s_relacao" Type="Int" />
						<ext:ModelField Name="nome_statusrelacao" Mapping="nome_statusrelacao" ServerMapping="MA_STATUS_RELACAO.nome" />                                                                                                                                                              
					</Fields>
				</ext:Model>
			</Model>
		</ext:Store>
	</Store>

 <%-- Grid --%> 
 <ext:GridPanel 
		ID="ParticipanteEnsinarGridPanelId"
		runat="server" 
		Title="Gerenciamento de Participante Ensinar"
		StoreID="StoreParticipanteEnsinarId">         
		<%--Height="1500"--%>    

		<%-- Colunas da Grid --%>
		<ColumnModel>
			<Columns>
				<ext:Column ID="codParticipanteEnsinarColumnId" runat="server" Text="Código" DataIndex="cod_p_ensinar" Visible="false" />
				<ext:Column ID="nomeParticipanteColumnId" runat="server" Text="Participante" Flex="2" DataIndex="nome_participante" />                                  
				<ext:Column ID="nomeItemColumnId" runat="server" Text="Item" Flex="2" DataIndex="nome_item" />                                  								
				<ext:Column ID="nomeStatusRelacaoColumnId" runat="server" Text="Item" Flex="2" DataIndex="nome_statusrelacao" />                                  								
			</Columns>            
		</ColumnModel>    
		   
		<SelectionModel>
			<ext:RowSelectionModel ID="ParticipanteEnsinarRowSelectionModelId" Mode="Single" runat="server" >
					<Listeners>                        
						<Select Handler="#{ParticipanteEnsinarFormPanelId}.getForm().loadRecord(record); 
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
					<ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{ParticipanteEnsinarWindowId}.show();#{ParticipanteEnsinarFormPanelId}.getForm().reset();" />

					<%-- Edit --%>
					<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Edit">
								<ExtraParams>
									<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ParticipanteEnsinarGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_p_ensinar" />                                
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
					<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{ParticipanteEnsinarGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_p_ensinar" />                                
				</ExtraParams>
			</ItemDblClick>
		</DirectEvents>

		<BottomBar>
			<ext:PagingToolbar ID="PagingToolbarId" runat="server" />
		</BottomBar>

	</ext:GridPanel>

</asp:Content>
