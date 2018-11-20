using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PM.Entity;
using S_.WindowsForms;
using S_;
using IM.Functions;
using IM.Hierarchy;
using IM.Hierarchy.Forms;

namespace PM.Forms
{
    public partial class fm_Remark : FormForExperiments
    {
        public fm_Remark()
        {
            InitializeComponent();

            tb_Tree.Click += new EventHandler(tb_Tree_Click);

            IM.Functions.FuncWF.AddButtonOnToolStrip(bd_Navigator, "tb_Tree", "sp_select", true, s_Application.Image16List.Images["u_Tree"]);
        }

        void tb_Tree_Click(object sender, EventArgs e)
        {
            if (Node.Value.IsEmpty()) return;

            build_and_show_Tree(Node.Value);
        }

        protected override void ClearFormEvents()
        {
            base.ClearFormEvents();

            tb_Tree.Click -= tb_Tree_Click;
            checkBoxInFavorite.CheckedChanged -= checkBoxInFavorite_CheckedChanged;
        }

        private SrRemarkEntity E_SRRM = null;
        public override s_EntityObject CreateEntity()
        {
            E_SRRM = new SrRemarkEntity();
            E_SRRM.FullList(s_EntityAction.Prepare);

            return E_SRRM;
        }

        protected override bool s_Prepare()
        {
            if (!base.s_Prepare())
                return false;

            View.DataView.CellImageClick += View_CellImageClick;
            View.DataView.Initialization += DataView_Initialization;
            View.DataView.CellImageGet += DataView_CellImageGet;

            if (!View.Prepare())
                return false;

            if (Node != null)
            {
                SynchronizeViewAttrs(Node.ViewColumns, false);
            }

            _deleteOnlyByOwner = true;

            if (IsFirstRun)
            {
                View.Attributes[SrRemarkEntity.ColumnRemark].WrapMode = View.Attributes[SrRemarkEntity.ColumnRemark].WrapMode | DataGridViewTriState.True;
                View.Attributes[SrRemarkEntity.ColumnCommentExecut].WrapMode = View.Attributes[SrRemarkEntity.ColumnCommentExecut].WrapMode | DataGridViewTriState.True;
            }

            tb_copy_by_card.Visible = true;

            s_Status = s_FormStatus.Browse;

            if (Graph != null)
            {
                Graph.NodeValueSelectingEvent += graf_Select_objects;

                Graph.ParentTabControlForMaster.SelectedIndexChanged += ParentTabControlForMaster_TabIndexChanged;
            }

            return true;
        }

        void ParentTabControlForMaster_TabIndexChanged(object sender, EventArgs e)
        {
            if (Node.UID == "055")
            {
                Reopen();
            }
        }

        void DataView_Initialization(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, s_ViewColumn> kvp in View.Attributes)
            {
                if (kvp.Key.SameStr(SrRemarkEntity.ColumnIsFavorite))
                {
                    kvp.Value.IsImaging = true;
                    kvp.Value.Image = PM.Properties.Resources.checkbox_unchecked;
                }
            }
        }

        /// <summary>
        /// Поменять значение "В избранном" на противоположное
        /// </summary>
        void SwitchInFavorite()
        {
            int idCurrentUser = SrRExecutiveEntity.GetIdCurrentUser();

            if (View.CurrentDataRow == null || idCurrentUser == -1 || string.IsNullOrEmpty(CurrentID)) return;

            string contrValue = View.CurrentDataRow[SrRemarkEntity.ColumnIsFavorite].ObjToStr();
            if (contrValue.Equals("Д"))
            {
                // удалить
                using (SrFavoriteEntity ent = new SrFavoriteEntity())
                {
                    ent.Data.AddCondition("ByIdRemarkAndIdExecutor", SrFavoriteEntity.ColumnIdSrRemark + "=" + CurrentID +
                        " and " + SrFavoriteEntity.ColumnIdSrRExecutive + "=" + idCurrentUser);

                    if (ent.Data.Open() && ent.Data.Rows.Count > 0)
                    {
                        ent.Data.DeleteRow(ent.Data.Rows[0]);
                        ent.Data.Save();
                        ent.Data.Close();
                    }
                }
            }
            else
            {
                // добавить
                using (SrFavoriteEntity ent = new SrFavoriteEntity())
                {
                    ent.ById(-1, s_EntityAction.Open);
                    {
                        var row = ent.Data.NewRow();
                        if (row != null)
                        {
                            row[SrFavoriteEntity.ColumnIdSrRemark] = CurrentID;
                            row[SrFavoriteEntity.ColumnSrRemarkName] = " ";
                            row[SrFavoriteEntity.ColumnIdSrRExecutive] = idCurrentUser;
                            row[SrFavoriteEntity.ColumnSrRExecutiveName] = " ";
                            if (!ent.Data.Save())
                                ent.Data.UnSave();
                            ent.Data.Close();
                        }
                    }
                }
            }
            if (s_Status == s_FormStatus.Browse)
            {
                s_DbConnection.CommitTransaction();
            }

            View.Data.RefreshRow(View.CurrentDataRow);
        }

        void View_CellImageClick(object sender, s_ViewCellImageClickEventArgs e)
        {
            if (View.CurrentDataGridViewRow != e.ViewRow) return;

	        if (!e.ViewColumn.Name.SameStr(SrRemarkEntity.ColumnIsFavorite)) return;

            // актуализируем текущую строку
            AfterScroll();

            SwitchInFavorite();
			// fix 14579
            /*if (Node.UID == "055")
            {
                //Reopen();
            }
            else*/
            {
                View.Data.RefreshRow(View.CurrentDataRow);
            }
        }
        void DataView_CellImageGet(object sender, s_ViewCellImageGetEventArgs e)
        {
            s_DataColumn idAttr = Data.Attributes[SrRemarkEntity.ColumnIsFavorite];
            if (idAttr == null) return;

            string contrValue = idAttr[s_View.RowByGridViewRow(e.ViewRow)].ObjToStr();
            if (contrValue.Equals("Д"))
            {
                e.Image = PM.Properties.Resources.checkbox_checked;
            }
            else
            {
                e.Image = PM.Properties.Resources.checkbox_unchecked;
            }
            if (e.ViewAttribute.GridColumn.DefaultCellStyle.BackColor != Color.White)
            {
                e.ViewAttribute.GridColumn.DefaultCellStyle.BackColor = Color.White;
            }
        }

        protected override void s_UnPrepare()
        {
            if (f_LE_SRRM != null)
            {
                f_LE_SRRM.Dispose();
                f_LE_SRRM = null;
            }

            base.s_UnPrepare();
        }

        void graf_Select_objects(object sender, NodeEventArgs e)
        {
            WFNode p_node = e.Node as WFNode;
            if (p_node == null || !p_node.UID.SameStr("11")) return;

            FormInput fm_ask = new FormInput();
            fm_ask.Text = "Введите ID заданий через \",\"";
            fm_ask.richTextBox.WordWrap = true;
            fm_ask.richTextBox.Multiline = true;
            fm_ask.richTextBox.Text = p_node.Value;

            TextBox txbx = p_node.TextBox;

            Point pnt = txbx.PointToScreen(txbx.Location);
            fm_ask.Left = pnt.X;
            fm_ask.Top = pnt.Y + txbx.Height;

            fm_ask.ShowDialog();
            if (fm_ask.Result.IsEmpty()) return;

            string IDs = fm_ask.Result.Trim();

            IDs = IDs.Replace(",", " ");
            string[] list = IDs.Split(' ');
            int i;
            IDs = "";
            foreach (string s in list)
            {
                i = s.ObjToID();
                if (i <= 0) continue;

                IDs += i.ToString() + ", ";
            }
            Func.CutLastItem(ref IDs, 2);

            if (Func.CheckIsIDList(IDs, ","))
            {
                GraphSelectionListInternal.SelectionDone = true;
                GraphSelectionListInternal.Push(IDs);
                GraphSelectionListInternal.Push(Const.selected_name, IDs);
            }
            else
            {
                s_MessageBox.Show("Вы должны ввести ID заданий через \",\"!");
            }
        }

        protected override void SetupView(s_View p_View)
        {
            if (p_View == null) return;
            base.SetupView(p_View);
            p_View.Options = p_View.Options
                | s_ViewOption.ConfSave
                | s_ViewOption.ImportFile;

            p_View.Attributes[SrRemarkEntity.ColumnFromWhomName].ControlView = i_LookupEntry_Author;

            p_View.Attributes[SrRemarkEntity.ColumnSrRProjectName].ControlView = i_LookupEntry_project;
            p_View.Attributes[SrRemarkEntity.ColumnSrRStatusName].ControlView = i_LookupEntry_Status;
            p_View.Attributes[SrRemarkEntity.ColumnWhomName].ControlView = i_LookupEntry_Executor;
            p_View.Attributes[SrRemarkEntity.ColumnSrRPromptnessName].ControlView = i_LookupEntry_Promptness;

            p_View.Attributes[SrRemarkEntity.ColumnParentRemarkSrrmName].ControlView = i_LookupEntry_Parent_Remark;
            p_View.Attributes[SrRemarkEntity.ColumnRemark].ControlView = textBox_remark;
            p_View.Attributes[SrRemarkEntity.ColumnRemark].ControlCaption = label1;

            p_View.Attributes[SrRemarkEntity.ColumnDateCreate].ControlView = textBox_date_create;
            p_View.Attributes[SrRemarkEntity.ColumnDateCreate].ControlCaption = label2;

            p_View.Attributes[SrRemarkEntity.ColumnDateExecute].ControlView = textBox_date_exec;
            p_View.Attributes[SrRemarkEntity.ColumnDateExecute].ControlCaption = label3;

            p_View.Attributes[SrRemarkEntity.ColumnDateChecked].ControlView = textBox_date_commit;
            p_View.Attributes[SrRemarkEntity.ColumnDateChecked].ControlCaption = label4;

            p_View.Attributes[SrRemarkEntity.ColumnCommentExecut].ControlView = textBox_exec_comment;
            p_View.Attributes[SrRemarkEntity.ColumnCommentExecut].ControlCaption = label9;

            p_View.Attributes[SrRemarkEntity.ColumnNumberPp].ControlView = textBox_NPP;
            p_View.Attributes[SrRemarkEntity.ColumnNumberPp].ControlCaption = label10;

            p_View.Attributes[SrRemarkEntity.ColumnDateChange].ControlView = textBox_date_change;
            p_View.Attributes[SrRemarkEntity.ColumnDateChange].ControlCaption = label8;

            p_View.Attributes[SrRemarkEntity.ColumnDateInput].ControlView = textBox_date_input;
            p_View.Attributes[SrRemarkEntity.ColumnDateInput].ControlCaption = label7;

            p_View.Attributes[SrRemarkEntity.ColumnChangeIdContractor].ControlView = textBox_change_contr;
            p_View.Attributes[SrRemarkEntity.ColumnChangeIdContractor].ControlCaption = label6;

            p_View.Attributes[SrRemarkEntity.ColumnVvodIdContractor].ControlView = textBox_vvod_contr;
            p_View.Attributes[SrRemarkEntity.ColumnVvodIdContractor].ControlCaption = label5;

            p_View.Attributes[SrRemarkEntity.ColumnNameDb].ControlView = textBox_name_DB;
            p_View.Attributes[SrRemarkEntity.ColumnNameDb].ControlCaption = label11;

            p_View.Attributes[SrRemarkEntity.ColumnProgram].ControlView = textBox_program;
            p_View.Attributes[SrRemarkEntity.ColumnProgram].ControlCaption = label12;

            p_View.Attributes[SrRemarkEntity.ColumnPlaceError].ControlView = textBox_place;
            p_View.Attributes[SrRemarkEntity.ColumnPlaceError].ControlCaption = label13;

            p_View.Attributes[SrRemarkEntity.ColumnLink].ControlView = textBox_link;
            p_View.Attributes[SrRemarkEntity.ColumnLink].ControlCaption = label14;

            p_View.Attributes[SrRemarkEntity.ColumnDateComplete].ControlView = textBox_date_complete;
            p_View.Attributes[SrRemarkEntity.ColumnDateComplete].ControlCaption = label16;

            p_View.Attributes[SrRemarkEntity.ColumnIdSrRemark].ControlView = textBox_ID;
            p_View.Attributes[SrRemarkEntity.ColumnIdSrRemark].ControlCaption = label17;

            Label lb;
            s_LookupEntry le;
            foreach (KeyValuePair<string, s_ViewColumn> kvp in p_View.Attributes)
            {
                lb = kvp.Value.ControlCaption as Label;
                if (lb != null)
                {
                    lb.Font = new Font(lb.Font.FontFamily, lb.Font.Size, FontStyle.Bold);
                }
                le = kvp.Value.ControlViewLookupEntry;
                if (le != null)
                {
                    le.s_Font = new Font(le.s_Font.FontFamily, le.s_Font.Size, FontStyle.Bold);
                }
            }
        }

        private void textBox_link_TextChanged(object sender, EventArgs e)
        {
            linkLabel_link.Text = textBox_link.Text;
        }

        private void linkLabel_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link_text = linkLabel_link.Text;

            bool dir_exists = System.IO.Directory.Exists(link_text);

            if (!dir_exists && !System.IO.File.Exists(link_text) && !link_text.StartsWith("http"))
            {
                link_text = "http:\\" + link_text;
            }

            try
            {
                System.Diagnostics.Process.Start(link_text);
            }
            catch //(Exception x)
            {
            }
        }

        private void button_select_link_Click(object sender, EventArgs e)
        {
            if (Graph == null) return;

            if (!textBox_link.Text.IsEmpty())
            {
                openFileDialog_link.FileName = textBox_link.Text;
                string str = textBox_link.Text;

                if (!System.IO.Directory.Exists(str))
                    Func.GetLastItem(ref str, "\\", true);

                if (System.IO.Directory.Exists(str))
                {
                    openFileDialog_link.RestoreDirectory = true;
                    openFileDialog_link.InitialDirectory = str;
                }
            }
            openFileDialog_link.ShowDialog();
            if (String.IsNullOrEmpty(openFileDialog_link.FileName)) return;

            if (Graph.IsEditing)
            {
                textBox_link.Text = openFileDialog_link.FileName;
                textBox_link.Focus();
            }
        }

        SrRemarkEntity f_LE_SRRM = null;
        SrRemarkEntity LE_SRRM
        {
            get
            {
                if (f_LE_SRRM == null)
                    f_LE_SRRM = new SrRemarkEntity();
                return f_LE_SRRM;
            }
        }

        void CreateRemarkChildren(object sender, CreateNodeChildrenEventArgs e)
        {
            if (e.NodeUID.IsEmpty() || LE_SRRM == null) return;

            int ID_SRRM = e.NodeIDinTree.ObjToID();
            if (ID_SRRM <= 0) return;

            SNode child_node;
            int child_ID;
            LE_SRRM.ByIdParent(ID_SRRM, s_EntityAction.Open);
            for (int i = 0; i < LE_SRRM.Data.Rows.Count; i++)
            {
                LE_SRRM.Instance.Row = LE_SRRM.Data.Rows[i];
                child_ID = LE_SRRM.Instance.IdSrRemark.ObjToID();
                if (child_ID <= 0) continue;

                child_node = new SNode();
                child_node.NodeProp[Const.UID] = e.NodeUID + child_ID.ToString();
                child_node.IDinTree = child_ID.ToString();
                string txt = LE_SRRM.Instance.Remark;
                child_node.Caption = child_ID + ": " + txt;

                s_NamedObjects no = new s_NamedObjects();
                child_node.NodeProp[Const.par_node_tree_properties] = no;

                add_node_description(no);

                e.Children.Add(child_node);
            }
            LE_SRRM.Data.Close();

            e.Result = true;
        }

        void add_node_description(s_NamedObjects no)
        {
            if (LE_SRRM == null || !LE_SRRM.Data.Active || LE_SRRM.Instance.Row == null) return;

            GraphDescriptionAttribute da;

            da = new GraphDescriptionAttribute();
            da.Npp = "1";
            da.CurrentValue = Func.StrToDate(LE_SRRM.Instance.DateCreate.ObjToStr());
            da.ShortDescr = LE_SRRM.Instance.Data.AttrDateCreate.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "2";
            da.CurrentValue = LE_SRRM.Instance.NumberPp.ObjToStr();
            da.ShortDescr = LE_SRRM.Instance.Data.AttrNumberPp.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "3";
            da.CurrentValue = LE_SRRM.Instance.SrRProjectName;
            da.ShortDescr = LE_SRRM.Instance.Data.AttrSrRProjectName.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "4";
            da.CurrentValue = LE_SRRM.Instance.SrRPromptnessName;
            da.ShortDescr = LE_SRRM.Instance.Data.AttrSrRPromptnessName.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "5";
            da.CurrentValue = LE_SRRM.Instance.FromWhomName;
            da.ShortDescr = LE_SRRM.Instance.Data.AttrFromWhomName.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "6";
            da.CurrentValue = LE_SRRM.Instance.WhomName;
            da.ShortDescr = LE_SRRM.Instance.Data.AttrWhomName.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "7";
            da.CurrentValue = LE_SRRM.Instance.SrRStatusName;
            da.ShortDescr = LE_SRRM.Instance.Data.AttrSrRStatusName.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "8";
            da.CurrentValue = LE_SRRM.Instance.Remark;
            da.ShortDescr = LE_SRRM.Instance.Data.AttrRemark.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "9";
            da.CurrentValue = Func.StrToDate(LE_SRRM.Instance.DateExecute.ObjToStr());
            da.ShortDescr = LE_SRRM.Instance.Data.AttrDateExecute.Title;
            no[da.Npp] = da;

            da = new GraphDescriptionAttribute();
            da.Npp = "10";
            da.CurrentValue = LE_SRRM.Instance.IdSrRemark.ObjToStr();
            da.ShortDescr = "ID";
            no[da.Npp] = da;
        }

        FormTree fm_tree = null;

        void build_and_show_Tree(string curr_ID)
        {
            if (Node == null || curr_ID.IsEmpty()) return;

            s_NamedObjects no;

            SGraph Tree = new SGraph();
            Tree.IsTree = true;
            Tree.Caption = "Связи между заданиями";

            Tree.AddNode("roote");
            SNode roote_node = Tree.Node_("roote");
            roote_node.IDinTree = curr_ID;

            int? ID_parent = curr_ID.ObjToID();
            while (ID_parent > 0)
            {
                LE_SRRM.ById(ID_parent.ObjToID(), s_EntityAction.Open);
                if (LE_SRRM.Data.Rows.Count > 0)
                {
                    LE_SRRM.Instance.Row = LE_SRRM.Data.Rows[0];
                    if (!(LE_SRRM.Instance.ParentRemark > 0)) break;

                    ID_parent = LE_SRRM.Instance.ParentRemark;
                }
                LE_SRRM.Data.Close();
            }

            LE_SRRM.ById(ID_parent.ObjToID(), s_EntityAction.Open);
            if (LE_SRRM.Data.Rows.Count > 0)
            {
                LE_SRRM.Instance.Row = LE_SRRM.Data.Rows[0];

                roote_node.IDinTree = ID_parent.ObjToStr();
                roote_node.Caption = ID_parent + ": " + LE_SRRM.Instance.Remark;

                no = new s_NamedObjects();
                roote_node.NodeProp[Const.par_node_tree_properties] = no;
                add_node_description(no);
            }
            LE_SRRM.Data.Close();

            Tree.CreateNodeChildrenEvent += CreateRemarkChildren;
            bool result = Tree.BuildTree(new[] { roote_node }, false);

            if (!result) return;

            no = new s_NamedObjects();
            no[Const.par_graph] = Tree;
            no[Const.par_active_node_ID] = curr_ID;

            Tree.Status = GraphStatus.gs_browse;

            fm_tree = new FormTree();
            fm_tree.OuterPrepare(no);

            fm_tree.tb_card.Visible = true;
            fm_tree.tb_card.Click += tb_card_Click;
            fm_tree.tb_add_by_card.Visible = true;
            fm_tree.tb_add_by_card.Enabled = Node.PrivilegInsert;
            fm_tree.tb_add_by_card.Click += tb_add_by_card_Click;

            fm_tree.ShowModal();

            if (fm_tree.SelectedNode != null)
            {
                SaveActiveRow(fm_tree.SelectedNode.IDinTree);
            }

            fm_tree.tb_card.Click -= tb_card_Click;
            fm_tree.tb_add_by_card.Click -= tb_add_by_card_Click;
            fm_tree.Dispose();

            Tree.CreateNodeChildrenEvent -= CreateRemarkChildren;
            no.Clear();
            Tree.Dispose();

            Reopen();
        }

        public override void SetButtonsEnability()
        {
            base.SetButtonsEnability();

            updatingInFavorite = true;

            checkBoxInFavorite.Checked = View_(SrRemarkEntity.ColumnIsFavorite).SameStr("Д");

            updatingInFavorite = false;

            switch (s_Status)
            {
                case s_FormStatus.Inactive:
                    tb_Tree.Enabled = false;
                    break;

                case s_FormStatus.Browse:
                    tb_Tree.Enabled = RecExists;
                    break;

                case s_FormStatus.Insert:
                    tb_Tree.Enabled = false;
                    break;

                case s_FormStatus.Edit:
                    tb_Tree.Enabled = false;
                    break;

                case s_FormStatus.None:
                    tb_Tree.Enabled = false;
                    break;
            }
        }

        protected override void AcCopy()
        {
            if (!CanChangeViewRows()) return;

            if (View.CurrentDataRowView == null
                || (View.CurrentDataRowView.Row.RowState == DataRowState.Unchanged)
                || View.Data.CommitNewRow())
            {
                List<string> clone_attr_list = new List<string>();
                clone_attr_list.Add(SrRemarkEntity.ColumnIdSrRPromptness);
                clone_attr_list.Add(SrRemarkEntity.ColumnSrRPromptnessName);

                CloneRow(true, clone_attr_list);
            }

            SetButtonsEnability();
        }

        void tb_card_Click(object sender, EventArgs e)
        {
            if (fm_tree == null || fm_tree.treeView_main.SelectedNode == null) return;
            SNode clicked_node = fm_tree.treeView_main.SelectedNode.Tag as SNode;

            if (clicked_node == null || clicked_node.IDinTree.IsEmpty()) return;

            Graph.ShowClonedGraphAsCard(Node, clicked_node.IDinTree, false);
        }

        void tb_add_by_card_Click(object sender, EventArgs e)
        {
            if (fm_tree == null || fm_tree.treeView_main.SelectedNode == null) return;
            SNode clicked_node = fm_tree.treeView_main.SelectedNode.Tag as SNode;

            if (clicked_node == null || clicked_node.IDinTree.IsEmpty()) return;

            s_NamedObjects no = new s_NamedObjects();
            no[SrRemarkEntity.ColumnParentRemarkSrrm] = clicked_node.IDinTree;

            Graph.ShowClonedGraphAsCard(Node, "", true, false, false, no);

            fm_tree.tb_refresh_Click(null, null);
            TreeNode trn = fm_tree.FindNodeByID(Node.Value);
            if (trn != null)
            {
                fm_tree.treeView_main.SelectedNode = trn;
            }
        }

        bool updatingInFavorite = false;

        private void checkBoxInFavorite_CheckedChanged(object sender, EventArgs e)
        {
            if (updatingInFavorite) return;

            updatingInFavorite = true;

            SwitchInFavorite();

            updatingInFavorite = false;
        }
    }
}