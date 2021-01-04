namespace ShoppingListHelper
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_addProduct = new System.Windows.Forms.Label();
            this.checkBox_possibleProducts = new System.Windows.Forms.CheckedListBox();
            this.entry_product = new System.Windows.Forms.TextBox();
            this.btn_addProduct = new System.Windows.Forms.Button();
            this.btn_makeExcelSheet = new System.Windows.Forms.Button();
            this.dropdown_productCategories = new System.Windows.Forms.ComboBox();
            this.lbl_dropdown = new System.Windows.Forms.Label();
            this.btn_checkAll = new System.Windows.Forms.Button();
            this.buttonDeleteItems = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_addProduct
            // 
            this.lbl_addProduct.AutoSize = true;
            this.lbl_addProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_addProduct.ForeColor = System.Drawing.Color.White;
            this.lbl_addProduct.Location = new System.Drawing.Point(249, 27);
            this.lbl_addProduct.Name = "lbl_addProduct";
            this.lbl_addProduct.Size = new System.Drawing.Size(180, 31);
            this.lbl_addProduct.TabIndex = 1;
            this.lbl_addProduct.Text = "Novo Produto";
            // 
            // checkBox_possibleProducts
            // 
            this.checkBox_possibleProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.checkBox_possibleProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_possibleProducts.CheckOnClick = true;
            this.checkBox_possibleProducts.ColumnWidth = 250;
            this.checkBox_possibleProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_possibleProducts.ForeColor = System.Drawing.Color.White;
            this.checkBox_possibleProducts.FormattingEnabled = true;
            this.checkBox_possibleProducts.Location = new System.Drawing.Point(63, 141);
            this.checkBox_possibleProducts.MultiColumn = true;
            this.checkBox_possibleProducts.Name = "checkBox_possibleProducts";
            this.checkBox_possibleProducts.Size = new System.Drawing.Size(1112, 550);
            this.checkBox_possibleProducts.Sorted = true;
            this.checkBox_possibleProducts.TabIndex = 2;
            // 
            // entry_product
            // 
            this.entry_product.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entry_product.Location = new System.Drawing.Point(445, 27);
            this.entry_product.Name = "entry_product";
            this.entry_product.Size = new System.Drawing.Size(541, 38);
            this.entry_product.TabIndex = 3;
            // 
            // btn_addProduct
            // 
            this.btn_addProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addProduct.Location = new System.Drawing.Point(1011, 33);
            this.btn_addProduct.Name = "btn_addProduct";
            this.btn_addProduct.Size = new System.Drawing.Size(112, 31);
            this.btn_addProduct.TabIndex = 4;
            this.btn_addProduct.Text = "Adicionar";
            this.btn_addProduct.UseVisualStyleBackColor = true;
            this.btn_addProduct.Click += new System.EventHandler(this.btn_addProduct_Click);
            // 
            // btn_makeExcelSheet
            // 
            this.btn_makeExcelSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_makeExcelSheet.Location = new System.Drawing.Point(1221, 707);
            this.btn_makeExcelSheet.Name = "btn_makeExcelSheet";
            this.btn_makeExcelSheet.Size = new System.Drawing.Size(197, 42);
            this.btn_makeExcelSheet.TabIndex = 5;
            this.btn_makeExcelSheet.Text = "Fazer Lista Excel";
            this.btn_makeExcelSheet.UseVisualStyleBackColor = true;
            this.btn_makeExcelSheet.Click += new System.EventHandler(this.btn_makeExcelSheet_Click);
            // 
            // dropdown_productCategories
            // 
            this.dropdown_productCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown_productCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdown_productCategories.FormattingEnabled = true;
            this.dropdown_productCategories.Items.AddRange(new object[] {
            "Geral",
            "Rúben",
            "Mãe",
            "Lígia",
            "José"});
            this.dropdown_productCategories.Location = new System.Drawing.Point(445, 83);
            this.dropdown_productCategories.Name = "dropdown_productCategories";
            this.dropdown_productCategories.Size = new System.Drawing.Size(541, 33);
            this.dropdown_productCategories.TabIndex = 6;
            // 
            // lbl_dropdown
            // 
            this.lbl_dropdown.AutoSize = true;
            this.lbl_dropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dropdown.ForeColor = System.Drawing.Color.White;
            this.lbl_dropdown.Location = new System.Drawing.Point(263, 80);
            this.lbl_dropdown.Name = "lbl_dropdown";
            this.lbl_dropdown.Size = new System.Drawing.Size(166, 31);
            this.lbl_dropdown.TabIndex = 7;
            this.lbl_dropdown.Text = "Para Quem?";
            // 
            // btn_checkAll
            // 
            this.btn_checkAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkAll.Location = new System.Drawing.Point(1221, 141);
            this.btn_checkAll.Name = "btn_checkAll";
            this.btn_checkAll.Size = new System.Drawing.Size(184, 31);
            this.btn_checkAll.TabIndex = 8;
            this.btn_checkAll.Text = "Selecionar Todos";
            this.btn_checkAll.UseVisualStyleBackColor = true;
            this.btn_checkAll.Click += new System.EventHandler(this.btn_checkAll_Click);
            // 
            // buttonDeleteItems
            // 
            this.buttonDeleteItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteItems.Location = new System.Drawing.Point(1221, 192);
            this.buttonDeleteItems.Name = "buttonDeleteItems";
            this.buttonDeleteItems.Size = new System.Drawing.Size(184, 31);
            this.buttonDeleteItems.TabIndex = 9;
            this.buttonDeleteItems.Text = "Eliminar Selecionados";
            this.buttonDeleteItems.UseVisualStyleBackColor = true;
            this.buttonDeleteItems.Click += new System.EventHandler(this.buttonDeleteItems_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_addProduct;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.ClientSize = new System.Drawing.Size(1430, 761);
            this.Controls.Add(this.buttonDeleteItems);
            this.Controls.Add(this.btn_checkAll);
            this.Controls.Add(this.lbl_dropdown);
            this.Controls.Add(this.dropdown_productCategories);
            this.Controls.Add(this.btn_makeExcelSheet);
            this.Controls.Add(this.btn_addProduct);
            this.Controls.Add(this.entry_product);
            this.Controls.Add(this.checkBox_possibleProducts);
            this.Controls.Add(this.lbl_addProduct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Construtor de Lista de Compras";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_addProduct;
        private System.Windows.Forms.TextBox entry_product;
        private System.Windows.Forms.Button btn_addProduct;
        private System.Windows.Forms.Button btn_makeExcelSheet;
        private System.Windows.Forms.ComboBox dropdown_productCategories;
        private System.Windows.Forms.Label lbl_dropdown;
        private System.Windows.Forms.Button btn_checkAll;
        private System.Windows.Forms.Button buttonDeleteItems;
        public System.Windows.Forms.CheckedListBox checkBox_possibleProducts;
    }
}

