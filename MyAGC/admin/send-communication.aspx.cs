using MyAGC.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace MyAGC.admin
{
    public partial class send_communication : System.Web.UI.Page
    {
        readonly LookUp lp = new LookUp("con");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtID.Value = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (drpMessageType.SelectedValue == "1")
                {
                    WarningAlert("Please select a valid message type");
                    return;
                }
                if (drpMessageType.SelectedItem.Text.Contains("Email"))
                {
                    if (string.IsNullOrEmpty(txtHeader.Text) || txtHeader.Text.Length <= 2)
                    {
                        WarningAlert("Please enter a valid Email Subject");
                        return;
                    }
                }
                if (drpTarget.SelectedValue == "1")
                {
                    WarningAlert("Please select a valid target");
                    return;
                }

                BroadcastMessagesList b = new BroadcastMessagesList("con");
                b.ID = int.Parse(txtID.Value);
                b.StatusID = 1;
                b.BroadcastMessgeTitle = txtHeader.Text;
                b.MessageType = drpMessageType.SelectedItem.Text;
                if (b.Save())
                {
                    txtID.Value = b.ID.ToString();
                    //We get all pensioners not yet assigned to the created list
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);
                    getassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);
                    //SuccessAlert("Broadcast Message Created, add contacts to the list below and send out your message");
                }
                else
                {
                    WarningAlert(b.MsgFlg);
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }
        protected void getUnassignedContactstoTheMessage(int BroadcastList, string TargetType)
        {
            try
            {
                BroadcastMessagesList b = new BroadcastMessagesList("con");


                if (TargetType == "2")//system colleges
                {
                    if (b.getUnassignedSystemUsers(BroadcastList,2) != null)
                    {
                        lstUnassigned.DataSource = b.getUnassignedSystemUsers(BroadcastList,2);
                        lstUnassigned.DataValueField = "ID";
                        lstUnassigned.DataTextField = "Name";
                        lstUnassigned.DataBind();

                    }
                    else
                    {
                        lstUnassigned.Items.Clear();
                    }
                }
                if (TargetType == "3") //students
                {
                   
                    if (b.getUnassignedSystemUsers(BroadcastList, 3) != null)
                    {
                        lstUnassigned.DataSource = b.getUnassignedSystemUsers(BroadcastList, 3);
                        lstUnassigned.DataValueField = "ID";
                        lstUnassigned.DataTextField = "Name";
                        lstUnassigned.DataBind();

                    }
                    else
                    {
                        lstUnassigned.Items.Clear();
                    }
                }
                if (TargetType == "4")//system agents
                {
                    if (b.getUnassignedSystemUsers(BroadcastList, 4) != null)
                    {
                        lstUnassigned.DataSource = b.getUnassignedSystemUsers(BroadcastList, 4);
                        lstUnassigned.DataValueField = "ID";
                        lstUnassigned.DataTextField = "Name";
                        lstUnassigned.DataBind();

                    }
                    else
                    {
                        lstUnassigned.Items.Clear();
                    }
                }
                if (TargetType == "5")//system consultants
                {
                    if (b.getUnassignedSystemUsers(BroadcastList, 5) != null)
                    {
                        lstUnassigned.DataSource = b.getUnassignedSystemUsers(BroadcastList, 5);
                        lstUnassigned.DataValueField = "ID";
                        lstUnassigned.DataTextField = "Name";
                        lstUnassigned.DataBind();

                    }
                    else
                    {
                        lstUnassigned.Items.Clear();
                    }
                }
                

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }

        protected void getassignedContactstoTheMessage(int BroadcastList, string TargetType)
        {
            try
            {
                BroadcastMessagesList b = new BroadcastMessagesList("con");

                if (TargetType == "2")//select colleges
                {
                    if (b.getassignedSystemUsers(BroadcastList,2) != null)
                    {
                        lstMailingList.DataSource = b.getassignedSystemUsers(BroadcastList,2);
                        lstMailingList.DataValueField = "ID";
                        lstMailingList.DataTextField = "Name";
                        lstMailingList.DataBind();

                    }
                    else
                    {
                        lstMailingList.Items.Clear();
                    }
                }
                if (TargetType == "3")//select students
                {

                    
                    if (b.getassignedSystemUsers(BroadcastList,3) != null)
                    {
                        lstMailingList.DataSource = b.getassignedSystemUsers(BroadcastList,3);
                        lstMailingList.DataValueField = "ID";
                        lstMailingList.DataTextField = "Name";
                        lstMailingList.DataBind();

                    }
                    else
                    {
                        lstMailingList.Items.Clear();
                    }
                }
                if (TargetType == "4")//select agents
                {

                    
                    if (b.getassignedSystemUsers(BroadcastList, 4) != null)
                    {
                        lstMailingList.DataSource = b.getassignedSystemUsers(BroadcastList, 4);
                        lstMailingList.DataValueField = "ID";
                        lstMailingList.DataTextField = "Name";
                        lstMailingList.DataBind();

                    }
                    else
                    {
                        lstMailingList.Items.Clear();
                    }
                }
                if (TargetType == "5")//select consultants
                {

                    
                    if (b.getassignedSystemUsers(BroadcastList, 5) != null)
                    {
                        lstMailingList.DataSource = b.getassignedSystemUsers(BroadcastList, 5);
                        lstMailingList.DataValueField = "ID";
                        lstMailingList.DataTextField = "Name";
                        lstMailingList.DataBind();

                    }
                    else
                    {
                        lstMailingList.Items.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }
        protected void DangerAlert(string Err)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>error('" + Err + "')</script>", false);
        }
        protected void SuccessAlert(string message)
        {

            string script = $"SuccessToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        protected void WarningAlert(string message)
        {
            string script = $"WarningToastr('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastScript", script, true);
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                BroadcastContacts b = new BroadcastContacts("con");
                if (int.Parse(txtID.Value) > 0)
                {
                    List<int> lipen = new List<int>();
                    foreach (ListItem item in lstMailingList.Items)
                    {
                        if (item.Selected == true)
                        {
                            if (drpMessageType.SelectedValue == "1")//Email
                            {
                                b.ID = 0;
                                b.BroadcastListID = int.Parse(txtID.Value);
                                b.PensionNo = int.Parse(item.Value);
                                b.EmailAddress = item.Text;
                                b.MobileNo = item.Text;
                                b.StatusID = 1;
                                b.Remove();
                            }
                            else
                            {
                                //sms

                            }

                        }
                    }
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);
                    getassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);

                    //SuccessAlert("Contacts added to the sending list");
                }
                else
                {
                    WarningAlert("Save a valid broadcast message first to enable the adding of pensioners to messaging list");
                    return;

                }
            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }

        protected void btnAllRemove_Click(object sender, EventArgs e)
        {
            try
            {
                BroadcastContacts b = new BroadcastContacts("con");
                if (int.Parse(txtID.Value) > 0)
                {
                    List<int> lipen = new List<int>();
                    foreach (ListItem item in lstMailingList.Items)
                    {
                        if (drpMessageType.SelectedValue == "2")//Email
                        {
                            item.Selected = true;
                            b.ID = 0;
                            b.BroadcastListID = int.Parse(txtID.Value);
                            b.PensionNo = int.Parse(item.Value);
                            b.EmailAddress = item.Text;
                            b.MobileNo = item.Text;
                            b.StatusID = 1;
                            b.Remove();
                        }
                        else
                        {
                            //sms
                        }

                    }
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);
                    getassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);

                    //SuccessAlert("Contacts added to the sending list");
                }
                else
                {
                    WarningAlert("Save a valid broadcast message first to enable the adding of pensioners to messaging list");
                    return;

                }
            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BroadcastContacts b = new BroadcastContacts("con");
                if (int.Parse(txtID.Value) > 0)
                {
                    List<int> lipen = new List<int>();
                    foreach (ListItem item in lstUnassigned.Items)
                    {

                        if (item.Selected == true)
                        {
                            if (drpMessageType.SelectedValue == "2")//Email
                            {
                                b.ID = 0;
                                b.BroadcastListID = int.Parse(txtID.Value);
                                b.PensionNo = int.Parse(item.Value);
                                b.EmailAddress = item.Text;
                                b.MobileNo = item.Text;
                                b.StatusID = 1;
                                b.Save();
                            }
                            else
                            {
                                //SMS


                            }
                        }

                    }
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);
                    getassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);


                }
                else
                {
                    WarningAlert("Save a valid broadcast message first to enable the adding of pensioners to messaging list");
                    return;

                }
            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }

        protected void btnAllAdd_Click(object sender, EventArgs e)
        {
            try
            {
                BroadcastContacts b = new BroadcastContacts("con");
                if (int.Parse(txtID.Value) > 0)
                {
                    List<int> lipen = new List<int>();
                    foreach (ListItem item in lstUnassigned.Items)
                    {
                        if (drpMessageType.SelectedValue == "2")//Email
                        {
                            item.Selected = true;
                            b.ID = 0;
                            b.BroadcastListID = int.Parse(txtID.Value);
                            b.PensionNo = int.Parse(item.Value);
                            b.EmailAddress = item.Text;
                            b.MobileNo = item.Text;
                            b.StatusID = 1;
                            b.Save();
                        }
                        else
                        {
                            //SMS

                        }

                    }
                    getUnassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);
                    getassignedContactstoTheMessage(int.Parse(txtID.Value), drpTarget.SelectedValue);

                    //SuccessAlert("Contacts added to the sending list");
                }
                else
                {
                    WarningAlert("Save a valid broadcast message first to enable the adding of pensioners to messaging list");
                    return;

                }
            }
            catch (Exception ex)
            {
                WarningAlert(ex.Message);
            }
        }
        private void Clear()
        {
            txtDate.Text = string.Empty;
            txtMsgBody.Text = string.Empty;
            txtHeader.Text = string.Empty;
            drpMessageType.SelectedValue = "1";
            drpTarget.SelectedValue = "1";
            //lstMailingList.ClearSelection();
            //lstUnassigned.ClearSelection();
        }
        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {

                //check if email settings saved
                LookUp look = new LookUp("con");
                DataSet emails = look.getAllEmailSettings();
               

                if (drpMessageType.SelectedValue == "2")//email
                {
                    if (emails != null)
                    {
                        BroadcastContacts b = new BroadcastContacts("con");
                        if (b.getBroadCastContactDetails(int.Parse(txtID.Value), int.Parse(drpTarget.SelectedValue)) != null)
                        {
                            foreach (DataRow rw in b.getBroadCastContactDetails(int.Parse(txtID.Value), int.Parse(drpTarget.SelectedValue)).Tables[0].Rows)
                            {

                                string msgbdy = string.Empty;

                                lp.SaveEmailList(Convert.ToDateTime(txtDate.Text), rw["Email"].ToString(), txtHeader.Text, drpTarget.SelectedItem.Text, 1, txtMsgBody.Text);
                            }
                            SuccessAlert("Message successfully sent");
                            Clear();

                        }
                    }
                    else
                    {
                        WarningAlert("No email settings found");
                        return;
                    }
                 
                }
                else if(drpMessageType.SelectedValue == "3") 
                {
                    lp.SaveSmsList(int.Parse(txtID.Value),1);
                    SuccessAlert("Message schedule created and ready to send");
                    Clear();
                }
                else
                {
                    WarningAlert("Please fill in the details above to proceed");
                    return;
                }
            }
            catch (Exception)
            {
                WarningAlert("An error occurred while saving data");
            }
        }
    }
}