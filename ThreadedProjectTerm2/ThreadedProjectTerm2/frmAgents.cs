using DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsClasses;

namespace ThreadedProjectTerm2
{
    public partial class frmAgents : Form
    {
        /**
        * Threaded project 2 - Team 1
        * Purpose: Form for the supplier data to be built into
        * Made by: Brent Ward
        * Date: March 19th 2019
        * **/

        //holder variables
        List<Agent> agents = null;
        Agent agt;
        Agent tempAgent = new Agent(); //holder for updating

        public frmMain activeFrmMain;
        public frmAgents()
        {
            InitializeComponent();
        }

        //builds the datagrid on load
        private void frmAgents_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            agents = AgentDB.GetAgents();
            agentDataGridView.DataSource = agents;
        }

        private void frmAgents_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this == activeFrmMain.activeFrmAgents)
                activeFrmMain.activeFrmPackages = null;
        }

        //adds an agent
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                agt = new Agent();
                //cant use build agent here since an Id wont be input, it will be auto assign
                agt.AgtFirstName = agtFirstNameTextBox.Text;
                agt.AgtLastName = agtLastNameTextBox.Text;
                agt.AgtMiddleInitial = agtMiddleInitialTextBox.Text;
                agt.AgtBusPhone = agtBusPhoneTextBox.Text;
                agt.AgtEmail = agtEmailTextBox.Text;
                agt.AgtPosition = agtPositionTextBox.Text;
                agt.AgencyID = Convert.ToInt32(agencyIDTextBox.Text);

                try
                {
                    AgentDB.AddAgent(agt);
                    MessageBox.Show("Agent added successfully.", "Success");
                    ClearContent();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().ToString()); ClearContent(); }
            }
        }

        //updates information for agents
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (isValid())//checks there is an object first
            {
                agt = new Agent();
                BuildAgent(agt);//builds the new agent,now we use TempAgent to check the changes

                if (AgentDB.UpdateAgent(tempAgent, agt))
                {
                    MessageBox.Show("Agent successfully updated.", "Success");
                    ClearContent();
                }
                else {MessageBox.Show("There was an error updating, please try again."); ClearContent(); }
            }
        }

        //deletes an agent
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (isValid())//checks there is a value selected
            {
                agt = new Agent();
                BuildAgent(agt);
                //confirmation window
                DialogResult result = MessageBox.Show("Delete " + agt.AgtLastName + ", "+ agt.AgtFirstName + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (!AgentDB.DeleteAgent(agt))//failed
                        {
                            MessageBox.Show("Another user has updated or deleted that supplier.", "Database Error");
                            ClearContent();
                        }
                        else//success
                        {
                            MessageBox.Show("Delete Successful.");
                            ClearContent();
                        }

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message, ex.GetType().ToString()); }
                }
            }
            else { MessageBox.Show("Data fields are empty.", "Input Error"); }
        }

        //clears all the datafields
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearContent();
        }

        //loads the datagrid row into the datafields
        private void agentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool built = false;

            do
            {
                agentIDTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                agtFirstNameTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                agtLastNameTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                agtMiddleInitialTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                agtBusPhoneTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                agtEmailTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                agtPositionTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                agencyIDTextBox.Text = agentDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();

                built = true;//stops the do after 1 loop
            } while (!built);

            if (built)
            {
                BuildAgent(tempAgent);
            }
            
        }

        //checks the datafields are valid
        private bool isValid()
        {
            return true;
        }

        //builds the agent
        private void BuildAgent(Agent agt)
        {
            agt.AgentID = Convert.ToInt32(agentIDTextBox.Text);
            agt.AgtFirstName = agtFirstNameTextBox.Text;
            agt.AgtLastName = agtLastNameTextBox.Text;
            agt.AgtMiddleInitial = agtMiddleInitialTextBox.Text;
            agt.AgtBusPhone = agtBusPhoneTextBox.Text;
            agt.AgtEmail = agtEmailTextBox.Text;
            agt.AgtPosition = agtPositionTextBox.Text;
            agt.AgencyID = Convert.ToInt32(agencyIDTextBox.Text);
        }

        //clears the content (useful for updating datagrid after add/delete)
        private void ClearContent()
        {
            agentIDTextBox.Clear();
            agtFirstNameTextBox.Clear();
            agtLastNameTextBox.Clear();
            agtMiddleInitialTextBox.Clear();
            agtBusPhoneTextBox.Clear();
            agtEmailTextBox.Clear();
            agtPositionTextBox.Clear();
            agencyIDTextBox.Clear();

            //resets the datagrid
            agents = AgentDB.GetAgents();
            agentDataGridView.DataSource = agents;
        }
       
    }
}
