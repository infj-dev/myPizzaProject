using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace myPizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            resetForm();
            UpdateOrderSummary();
        }

        private void UpdatePrice()
        {
            lblPrice.Text = CalculateTotalCost() + "$";
        }

        private Single CalculatezSizeCost()
        {
            Single cost = 0;
            if (rbSmall.Checked)
            {
                cost = Convert.ToSingle(rbSmall.Tag);
            }
            else if (rbMedium.Checked)
            {
                cost = Convert.ToSingle(rbMedium.Tag); ;
            }
            else if (rbLarge.Checked)
            {
                cost = Convert.ToSingle(rbLarge.Tag); ;
            }
            return cost;
        }

        private Single CalculateToppingCost()
        {
            Single cost = 0;
            if (cbCheese.Checked)
            {
                cost += Convert.ToSingle(cbCheese.Tag);
            }
            if (cbMushrooms.Checked)
            {
                cost += Convert.ToSingle(cbMushrooms.Tag);
            }
            if (cbOnion.Checked)
            {
                cost += Convert.ToSingle(cbOnion.Tag);
            }
            if (cbOlives.Checked)
            {
                cost += Convert.ToSingle(cbOlives.Tag);
            }
            if (cbPeppers.Checked)
            {
                cost += Convert.ToSingle(cbPeppers.Tag);
            }
            if (cbTomatoes.Checked)
            {
                cost += Convert.ToSingle(cbTomatoes.Tag);
            }
            return cost;
        }

        private Single CalculateCrustCost()
        {
            Single cost = 0;
            if (rbThin.Checked)
            {
                cost = Convert.ToSingle(rbThin.Tag);
            }
            else if (rbThick.Checked)
            {
                cost = Convert.ToSingle(rbThick.Tag);
            }
            return cost;
        }

        private Single CalculateTotalCost()
        {
            Single sizeCost = CalculatezSizeCost();
            Single toppingCost = CalculateToppingCost();
            Single crustCost = CalculateCrustCost();
            return sizeCost + toppingCost + crustCost;

        }


        //Update Summary labels when the user selects any option
        private void UpdateSize()
        {
            lblSize.Text = rbSmall.Checked ? "Small" : rbMedium.Checked ? "Medium" : "Large";
            UpdatePrice();
        }

        private void UpdateToppings()
        {
            List<string> selectedToppings = new List<string>();
            if (cbCheese.Checked) selectedToppings.Add("Cheese");
            if (cbMushrooms.Checked) selectedToppings.Add("Mushrooms");
            if (cbOnion.Checked) selectedToppings.Add("Onion");
            if (cbOlives.Checked) selectedToppings.Add("Olives");
            if (cbPeppers.Checked) selectedToppings.Add("Peppers");
            if (cbTomatoes.Checked) selectedToppings.Add("Tomatoes");
            lblToppings.Text = selectedToppings.Count() != 0 ? string.Join(", ", selectedToppings) : "No Toppings";
            UpdatePrice();
        }

        private void UpdateCrust()
        {
            lblCrustType.Text = (rbThin.Checked ? "Thin" : "Thick") + " Crust";
            UpdatePrice();
        }






        // Event handlers for the radio buttons and checkboxes for size selection
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }



        // Event handlers for the checkboxes for toppings selection
        private void cbCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
        private void cbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }



        // Event handlers for the radio buttons for crust selection




        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        // Event handlers for the radio buttons for Location selection
        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Eat In";
            UpdatePrice();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Take Out";
            UpdatePrice();
        }



        // Event handler for the Order button and its functionality 
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to place the order?",
                "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string orderSummary = $"Order Summary:\n" +
                                      $"Size: {lblSize.Text}\n" +
                                      $"Toppings: {lblToppings.Text}\n" +
                                      $"Crust: {lblCrustType.Text}\n" +
                                      $"Location: {lblWhereToEat.Text}\n" +
                                      $"Total Price: {lblPrice.Text}";
                MessageBox.Show(orderSummary, "Order Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Disble all controls after placing the order
                SizeGroup.Enabled = false;
                toppingsGroup.Enabled = false;
                CrustGroup.Enabled = false;
                locationGroup.Enabled = false;
                btnOrder.Enabled = false;

            }
            else
            {
                MessageBox.Show("Order cancelled.", "Order Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            lblWhereToEat.Text = rbEatIn.Checked ? "Eat In" : "Take Out";
            UpdatePrice();

        }

        private void resetForm()
        {
            SizeGroup.Enabled = true;
            toppingsGroup.Enabled = true;
            CrustGroup.Enabled = true;
            locationGroup.Enabled = true;
            rbEatIn.Checked = true;
            rbSmall.Checked = true;
            cbCheese.Checked = false;
            cbMushrooms.Checked = false;
            cbOnion.Checked = false;
            cbOlives.Checked = false;
            cbPeppers.Checked = false;
            cbTomatoes.Checked = false;
            rbThin.Checked = true;
            UpdateOrderSummary();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
