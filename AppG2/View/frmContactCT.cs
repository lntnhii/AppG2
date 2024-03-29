﻿using AppG2.Controller;
using AppG2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppG2.View
{
    public partial class frmContactCT : Form
    {
        Contacts contact;
        User user;
        public frmContactCT(User user, Contacts contact = null)
        {
            InitializeComponent();
            this.contact = contact;
            this.user = user;
            if (contact != null)
            {
                //chỉnh sửa
                this.Text = "Chỉnh sửa";
                txtName.Text = contact.Name;
                txtPhone.Text = contact.Phone;
                txtEmail.Text = contact.Email;
            }
            else
            {
                //Thêm mới
                this.Text = "Thêm mới";
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (contact != null)
            {
                //cap nhat
                contact.Name = txtName.Text;
                contact.Email = txtEmail.Text;
                contact.Phone = txtPhone.Text;
                ContactService.EditContactDB(contact);
            }
            else
            {
                //them moi 
                Contacts cont = new Contacts();
                cont.IDContact = Guid.NewGuid().ToString();
                cont.Name = txtName.Text;
                cont.Email = txtEmail.Text;
                cont.Phone = txtPhone.Text;
                cont.Username = user.Username;
                ContactService.AddContactDB(cont);
            }
            MessageBox.Show("Đã cập nhật thành công");
            DialogResult = DialogResult.OK; // đóng form
        }
    }
}
