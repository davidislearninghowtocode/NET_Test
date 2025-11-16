namespace SanPhamWinform
{

        private void LoadData()
        {
            using (var context = new ProductDbContext())
            {
                var list = context.Products.ToList();
                dtgData.DataSource = list;
            }
        }


        private void ClearData()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtTotal.Text = "";
            dtpOrder.Value = DateTime.Now;
            if (cbState.Items.Count > 0)
                cbState.SelectedIndex = 0;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ProductDbContext())
                {
                    var product = new Product
                    {
                        Name = txtName.Text,
                        Statement = cbState.SelectedItem.ToString(),
                        Total = decimal.Parse(txtTotal.Text),
                        OrderDate = dtpOrder.Value
                    };
                    context.Products.Add(product);
                    int ret = context.SaveChanges();
                    if (ret != 0)
                    {
                        MessageBox.Show("Data added successfully");
                        LoadData();
                        ClearData();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Added data failed.");
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ProductDbContext())
                {
                    int id = int.Parse(txtID.Text);
                    //lay ra san pham dau tien trong bang co ID bang gia tri id, neu khong co tra ve null
                    var product = context.Products.FirstOrDefault(p => p.ID == id);

                    if (product != null)
                    {
                        context.Products.Remove(product); //xoa doi tuong product trong set Products
                        context.SaveChanges();
                        MessageBox.Show("Delete data successfully");
                        LoadData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("No id matched");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ProductDbContext())
                {
                    int id = int.Parse(txtID.Text);
                    var product = context.Products.FirstOrDefault(p => p.ID == id);
                    if (product != null)
                    {
                        product.Name = txtName.Text;
                        product.Statement = cbState.SelectedItem.ToString();
                        product.Total = decimal.Parse(txtTotal.Text);
                        product.OrderDate = dtpOrder.Value;

                        context.SaveChanges();
                        MessageBox.Show("Update product successfully");
                        LoadData();
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("No matches ID");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
        }




        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            using (var context = new ProductDbContext())
            {
                var result = context.Products.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
                dtgData.DataSource = null;
                dtgData.DataSource = result;
            }
        }



        private void dtgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgData.Rows[e.RowIndex].Cells[0].Value != null)
            {
                txtID.Text = dtgData.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtName.Text = dtgData.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtTotal.Text = dtgData.Rows[e.RowIndex].Cells["Total"].Value.ToString();
                string status = dtgData.Rows[e.RowIndex].Cells["Statement"].Value.ToString();
                dtpOrder.Value = (DateTime)dtgData.Rows[e.RowIndex].Cells["OrderDate"].Value;
            }
        }



        private void dtgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtgData.Rows[e.RowIndex].Cells[0].Value != null)
            {
                txtID.Text = dtgData.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                txtName.Text = dtgData.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtTotal.Text = dtgData.Rows[e.RowIndex].Cells["Total"].Value.ToString();
                string status = dtgData.Rows[e.RowIndex].Cells["Statement"].Value.ToString();
                dtpOrder.Value = (DateTime)dtgData.Rows[e.RowIndex].Cells["OrderDate"].Value;
            }
        }
    }
}
