using Microsoft.Data.SqlClient;

namespace PersonelTakip
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // Giriþ butonuna týklandýðýnda çalýþýr
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            int employeeId;
            // Kullanýcýdan alýnan ID'nin geçerli bir sayý olup olmadýðýný kontrol et
            if (!int.TryParse(txtEmployeeID.Text, out employeeId))
            {
                lblMessage.Text = "Geçerli bir ID giriniz.";
                return;
            }

            string password = txtPassword.Text;

            // Veritabaný baðlantýsý oluþtur
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Kullanýcýyý ve þifresini kontrol eden sorgu
                    string query = "SELECT EmployeeID, FirstName, LastName, IsAdmin FROM Employees WHERE EmployeeID = @id AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kullanýcý bilgilerini oku
                                int id = reader.GetInt32(0);
                                string firstName = reader.GetString(1);
                                string lastName = reader.GetString(2);
                                bool isAdmin = reader.GetBoolean(3);

                                this.Hide();

                                // Kullanýcý admin ise AdminForm'u aç
                                if (isAdmin)
                                {
                                    AdminForm adminForm = new AdminForm();
                                    adminForm.Show();
                                }
                                // Deðilse EmployeeForm'u aç
                                else
                                {
                                    EmployeeForm employeeForm = new EmployeeForm(id, firstName, lastName);
                                    employeeForm.Show();
                                }
                            }
                            else
                            {
                                // Hatalý giriþte mesaj göster
                                lblMessage.Text = "ID veya þifre hatalý!";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Baðlantý hatasý durumunda kullanýcýya mesaj göster
                    MessageBox.Show("Baðlantý hatasý: " + ex.Message);
                }
            }
        }

        // Temizle butonuna týklandýðýnda çalýþýr
        private void btnDel_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtPassword.Clear();
        }
    }
}