using System;
using System.Data;
using System.Windows.Forms;

namespace TAL_Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Auto-generated for automatic functions control for DataGridView
        private void CUSTOMERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cUSTOMERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tALDataSet);

        }

        //Auto-generated for automatic functions control for DataGridView
        private void CUSTOMERBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.cUSTOMERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tALDataSet);

        }

        //Auto-generated for automatic functions control for DataGridView
        private void CUSTOMERBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.cUSTOMERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tALDataSet);

        }

        //Auto-generated to fill the DataGridViews on form load
        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'tALDataSet.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter.Fill(this.tALDataSet.ORDERS);
            // TODO: This line of code loads data into the 'tALDataSet.ITEM' table. You can move, or remove it, as needed.
            this.iTEMTableAdapter.Fill(this.tALDataSet.ITEM);
            // TODO: This line of code loads data into the 'tALDataSet.REP' table. You can move, or remove it, as needed.
            this.rEPTableAdapter.Fill(this.tALDataSet.REP);
            // TODO: This line of code loads data into the 'tALDataSet.CUSTOMER' table. You can move, or remove it, as needed.
            this.cUSTOMERTableAdapter.Fill(this.tALDataSet.CUSTOMER);

        }

        //Auto-generated for automatic functions control for DataGridView
        private void CUSTOMERBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        //The only code I wrote myself for this.  When clicking on a row in the "orders"
        //table on the "orders" tab (left-hand table), it displays the order-line records
        //associated with that order number, with an item description picked up via "join"
        //command from the Item table.
        
        private void oRDERSDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            string orderNum = "";

            //If clicking on a pre-existing order, this gets the order number from
            //the DataGridView--does not query the database itself, just takes from
            //the data container, which was auto-filled on form load.
            try
            { 
                orderNum = oRDERSDataGridView[0, oRDERSDataGridView.SelectedRows[0].Index].Value.ToString();
            }
            //If the order number fails to load for any reason, the order number is set
            //to a string literal of "0"
            catch
            {
                orderNum = "0";
            }

            //Build your SQL command on the table adapter for one of the tables you're
            //joining FIRST.  This auto-generates a behind-the-scenes method for getting
            //the data you want from the database.  Be sure, when building the query, to
            //select "return a data table" on the last step before the code is generated,
            //and you can leave off the "fill a data table" box.
            //Next, declare a DataTable variable with the variable name of your choice.
            //In this case, "ByOrderNumber" was what I chose because it went with the SQL
            //script name on the TableAdapter.  Then, set the DataTable equal to the results
            //of the SQL script.
            DataTable ByOrderNumber = this.oRDER_LINETableAdapter.GetDataByOrderNumber(orderNum);

            //On your form, create a DataGridView, ListBox, or other container you want to fill.
            //Here, programattically bind that control to the DataTable you generated above.
            //In this case, it is a DataGridView "OrderItems."
            OrderItems.DataSource = ByOrderNumber;
            //Tell that DataGridView to generate columns from your query automatically.
            OrderItems.AutoGenerateColumns = true;

            //As a last step, in your form, select the DataGrid View and right-click.
            //You can create unbound columns, then individually bind them to the results
            //by selecting the DataGridView, right-clicking, and selecting "Edit Columns..."
            //Then, under "Data," in the "Data Property Name" field, type in the name
            //of the column you want there.

        }
    }
}
