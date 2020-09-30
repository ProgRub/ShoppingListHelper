using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Reflection;
using ClosedXML.Excel;

namespace ShoppingListHelper
{
    public partial class Form1 : Form
    {
        private string filename;
        private string directory;
        private string filePath;
        private XDocument xmlProducts;
        private bool checkAll;
        public Form1()
        {
            InitializeComponent();
            this.checkAll = false;
            var heightField = typeof(CheckedListBox).GetField("scaledListItemBordersHeight", BindingFlags.NonPublic | BindingFlags.Instance);
            var addedHeight = 5; // Some appropriate value, greater than the field's default of 2
            heightField.SetValue(this.checkBox_possibleProducts, addedHeight); // Where "clb" is your CheckedListBox
            this.filename = "Produtos.xml";
            this.directory = Directory.GetCurrentDirectory();
            this.filePath = Path.Combine(directory, filename);
            this.xmlProducts = XDocument.Load(this.filePath);
            try
            {
                //this.xmlProducts.Load(filePath);
                var products = this.xmlProducts.Root.Elements("Product").ToList();
                for (int index = 0; index < products.Count; index++)
                {
                    Console.WriteLine(products[index].Value);
                    var productName = products[index].Value;
                    if (Convert.ToInt32(products[index].Attribute("forWho").Value) == 1)
                    {
                        productName += " R";
                    }
                    else if (Convert.ToInt32(products[index].Attribute("forWho").Value) == 2)
                    {
                        productName += " Mãe";
                    }
                    else if (Convert.ToInt32(products[index].Attribute("forWho").Value) == 3)
                    {
                        productName += " L";
                    }
                    else if (Convert.ToInt32(products[index].Attribute("forWho").Value) == 4)
                    {
                        productName += " J";
                    }
                    int indexOfProduct = this.checkBox_possibleProducts.Items.Add(productName);
                    if (Convert.ToBoolean(products[index].Attribute("selected").Value))
                    {
                        this.checkBox_possibleProducts.SetItemChecked(indexOfProduct, true);
                    }
                    else
                    {
                        this.checkBox_possibleProducts.SetItemChecked(indexOfProduct, false);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                File.Create(filePath).Close();
                this.xmlProducts = new XDocument(new XElement("Root"));
                this.xmlProducts.Save(this.filePath);
                this.xmlProducts = XDocument.Load(this.filePath);
            }
        }

        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            string product = this.entry_product.Text.Trim();
            if (product.Length != 0)
            {
                XElement productNode = new XElement("Product");
                productNode.Value = product;
                if (this.dropdown_productCategories.Text == "Rúben")
                {
                    product += " R";
                    productNode.SetAttributeValue("forWho", "1");
                }
                else if (this.dropdown_productCategories.Text == "Mãe")
                {
                    product += " Mãe";
                    productNode.SetAttributeValue("forWho", "2");
                }
                else if (this.dropdown_productCategories.Text == "Lígia")
                {
                    product += " L";
                    productNode.SetAttributeValue("forWho", "3");
                }
                else if (this.dropdown_productCategories.Text == "José")
                {
                    product += " J";
                    productNode.SetAttributeValue("forWho", "4");
                }
                else
                {
                    productNode.SetAttributeValue("forWho", "0");
                }
                productNode.SetAttributeValue("selected", true.ToString());
                this.xmlProducts.Root.Add(productNode);
                int index = this.checkBox_possibleProducts.Items.Add(product);
                this.checkBox_possibleProducts.SetItemChecked(index, true);
            }
            this.entry_product.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var productsList = xmlProducts.Root.Elements().OrderBy(element => element.Value).ThenByDescending(element=>element.Attribute("forWho").Value).ToList();
            //Console.WriteLine(productsList.ToString());
            xmlProducts.Root.Descendants().Remove();
            //Console.WriteLine("HERE");
            //foreach (XElement product in xmlProducts.Root.Descendants())
            //    Console.WriteLine(product.Value);
            for (int index = 0; index < productsList.Count; index++)
            {
                productsList[index].Attribute("selected").Value = this.checkBox_possibleProducts.GetItemChecked(index).ToString();
            }
            xmlProducts.Root.Add(productsList);
            this.xmlProducts.Save(filePath);
        }

        private void btn_makeExcelSheet_Click(object sender, EventArgs e)
        {
            File.Delete(Path.Combine(this.directory, "Lista De Compras.xlsx"));
            using (var workbook = new XLWorkbook())
            {
                Dictionary<string, int> cellsLetters_numberOfProducts = new Dictionary<string, int>();
                List<string> productsNotForMom = new List<string>();
                List<string> productsForMom = new List<string>();
                var products = this.xmlProducts.Root.Elements().ToList();
                for (int index = 0; index < products.Count; index++)
                {
                    if (this.checkBox_possibleProducts.GetItemChecked(index))
                    {
                        if (products[index].Attribute("forWho").Value == "2")
                        {
                            productsForMom.Add(products[index].Value);
                        }
                        else
                        {
                            if (products[index].Attribute("forWho").Value == "3")
                            {
                                productsNotForMom.Add(products[index].Value + " L");
                            }
                            else if (products[index].Attribute("forWho").Value == "4")
                            {
                                productsNotForMom.Add(products[index].Value + " J");
                            }
                            else if (products[index].Attribute("forWho").Value == "1")
                            {
                                productsNotForMom.Add(products[index].Value + " R");
                            }
                            else
                            {
                                productsNotForMom.Add(products[index].Value);
                            }
                        }
                    }
                }
                var worksheet = workbook.Worksheets.Add("Lista De Compras");
                int columnWidth = 20;
                worksheet.Column("B").Width = 1;
                worksheet.Column("D").Width = 1;
                worksheet.Column("F").Width = 1;
                worksheet.Style.Font.FontName = "Arial";
                worksheet.Style.Font.FontSize = 12;
                if (productsNotForMom.Count > 30)
                {
                    var minimumPerColumn = productsNotForMom.Count / 3;
                    if (productsNotForMom.Count % 3 == 2)
                    {
                        cellsLetters_numberOfProducts.Add("A", minimumPerColumn + 1);
                        cellsLetters_numberOfProducts.Add("C", minimumPerColumn + 1);
                        cellsLetters_numberOfProducts.Add("E", minimumPerColumn);
                    }
                    else if (productsNotForMom.Count % 3 == 1)
                    {
                        cellsLetters_numberOfProducts.Add("A", minimumPerColumn + 1);
                        cellsLetters_numberOfProducts.Add("C", minimumPerColumn);
                        cellsLetters_numberOfProducts.Add("E", minimumPerColumn);
                    }
                    else
                    {
                        cellsLetters_numberOfProducts.Add("A", minimumPerColumn);
                        cellsLetters_numberOfProducts.Add("C", minimumPerColumn);
                        cellsLetters_numberOfProducts.Add("E", minimumPerColumn);
                    }
                    if (productsForMom.Count > 0)
                    {
                        worksheet.Cell("G1").Value = "MÃE";
                        worksheet.Cell("G1").Style.Font.Bold = true;
                        worksheet.Column("G").Width = columnWidth;
                        for (int index = 0; index < productsForMom.Count; index++)
                        {
                            worksheet.Cell("G" + (index + 2).ToString()).Value = productsForMom[index];
                        }
                    }
                }
                else if (productsNotForMom.Count > 10)
                {
                    var minimumPerColumn = productsNotForMom.Count / 2;
                    cellsLetters_numberOfProducts.Add("A", minimumPerColumn + productsNotForMom.Count % 2);
                    cellsLetters_numberOfProducts.Add("C", minimumPerColumn);
                    if (productsForMom.Count > 0)
                    {
                        worksheet.Cell("E1").Value = "MÃE";
                        worksheet.Cell("E1").Style.Font.Bold = true;
                        worksheet.Column("E").Width = columnWidth;
                        for (int index = 0; index < productsForMom.Count; index++)
                        {
                            worksheet.Cell("E" + (index + 2).ToString()).Value = productsForMom[index];
                        }
                    }
                }
                else
                {
                    cellsLetters_numberOfProducts.Add("A", productsNotForMom.Count);
                    if (productsForMom.Count > 0)
                    {
                        worksheet.Cell("C1").Value = "MÃE";
                        worksheet.Cell("C1").Style.Font.Bold = true;
                        worksheet.Column("C").Width = columnWidth;
                        for (int index = 0; index < productsForMom.Count; index++)
                        {
                            worksheet.Cell("C" + (index + 2).ToString()).Value = productsForMom[index];
                        }
                    }
                }
                var listIndex = 0;
                foreach (var cellLetter in cellsLetters_numberOfProducts.Keys)
                {
                    worksheet.Column(cellLetter).Width = columnWidth;
                    for (int columnIndex = 0; columnIndex < cellsLetters_numberOfProducts[cellLetter]; columnIndex++)
                    {
                        worksheet.Cell(cellLetter + (columnIndex + 1).ToString()).Value = productsNotForMom[listIndex];
                        listIndex++;
                    }
                }
                var excelFilePath = Path.Combine(this.directory, "Lista De Compras.xlsx");
                workbook.SaveAs(excelFilePath);
            }
        }

        private void btn_checkAll_Click(object sender, EventArgs e)
        {
            this.checkAll = !this.checkAll;
            for (int index = 0; index < this.checkBox_possibleProducts.Items.Count; index++)
            {
                this.checkBox_possibleProducts.SetItemChecked(index, this.checkAll);
            }
        }
    }
}
