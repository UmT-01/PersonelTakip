using Microsoft.Data.SqlClient;

namespace PersonelTakip
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Giri� butonuna t�kland���nda �al���r
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            int employeeId;
            // Kullan�c�dan al�nan ID'nin ge�erli bir say� olup olmad���n� kontrol et
            if (!int.TryParse(txtEmployeeID.Text, out employeeId))
            {
                lblMessage.Text = "Ge�erli bir ID giriniz.";
                return;
            }

            string password = txtPassword.Text;

            // Veritaban� ba�lant�s� olu�tur
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Kullan�c�y� ve �ifresini kontrol eden sorgu
                    string query = "SELECT EmployeeID, FirstName, LastName, IsAdmin FROM Employees WHERE EmployeeID = @id AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kullan�c� bilgilerini oku
                                int id = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                bool isAdmin = reader.GetBoolean(3);

                                this.Hide();

                                // Kullan�c� admin ise AdminForm'u a�
                                if (isAdmin)
                                {
                                    AdminForm adminForm = new AdminForm();
                                    adminForm.Show();
                                }
                                // De�ilse EmployeeForm'u a�
                                else
                                {
                                    EmployeeForm employeeForm = new EmployeeForm(id, firstName, lastName);
                                    employeeForm.Show();
                                }
                            }
                            else
                            {
                                // Hatal� giri�te mesaj g�ster
                                lblMessage.Text = "ID veya �ifre hatal�!";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Ba�lant� hatas� durumunda kullan�c�ya mesaj g�ster
                    MessageBox.Show("Ba�lant� hatas�: " + ex.Message);
                }
            }
        }

        // Temizle butonuna t�kland���nda �al���r
        private void btnDel_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtPassword.Clear();
        }
    }
}