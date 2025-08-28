using Microsoft.Data.SqlClient;

namespace PersonelTakip
{
    public partial class EmployeeForm : Form
    {
        private int employeeId;
        private string firstName;
        private string lastName;

        // Formun yapıcı metodu, çalışan bilgilerini alır ve hoşgeldiniz mesajı gösterir
        public EmployeeForm(int id, string first, string last)
        {
            InitializeComponent();
            employeeId = id;
            firstName = first;
            lastName = last;
            lblWelcome.Text = $"Hoşgeldiniz, {firstName} {lastName}";
            CheckTodayAttendance(); // Giriş yapan çalışanın bugünkü yoklama durumunu kontrol et
        }

        // Çalışanın bugünkü yoklama durumunu kontrol eder
        private void CheckTodayAttendance()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Status FROM Attendance WHERE EmployeeID = @id AND AttendanceDate = CAST(GETDATE() AS DATE)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string status = result.ToString();
                            if (status == "geldi")
                            {
                                btnCheckIn.Enabled = false;
                                btnCheckIn.Text = "Bugün geldi";
                                btnNotCame.Enabled = false;
                            }
                            else if (status == "gelmedi")
                            {
                                btnCheckIn.Enabled = false;
                                btnNotCame.Enabled = false;
                                btnNotCame.Text = "Bugün gelmedi";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Giriş yap butonuna tıklandığında çalışır, yoklama kaydı ekler
        private void btnCheckIn_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Attendance (EmployeeID, AttendanceDate, Status) VALUES (@id, CAST(GETDATE() AS DATE), 'geldi')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Kayıt başarılıysa kullanıcıya bilgi ver ve butonu pasif yap
                            MessageBox.Show("Giriş kaydınız oluşturuldu.");
                            btnCheckIn.Enabled = false;
                            btnCheckIn.Text = "Bugün geldi";
                            btnNotCame.Enabled = false;
                        }
                    }
                }
                // Aynı gün ikinci kez giriş yapılmaya çalışılırsa hata mesajı göster
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    MessageBox.Show("Bugün zaten giriş yapmışsınız.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnNotCame_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Önce bugün için kayıt var mı kontrol et
                    string checkQuery = "SELECT COUNT(*) FROM Attendance WHERE EmployeeID = @id AND AttendanceDate = CAST(GETDATE() AS DATE)";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", employeeId);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // Kayıt varsa güncelle
                            string updateQuery = "UPDATE Attendance SET Status = 'gelmedi' WHERE EmployeeID = @id AND AttendanceDate = CAST(GETDATE() AS DATE)";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@id", employeeId);
                                int rowsAffected = updateCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Durumunuz 'gelmedi' olarak güncellendi.");
                                    btnNotCame.Enabled = false;
                                    btnNotCame.Text = "Bugün gelmedi";
                                    btnCheckIn.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            // Kayıt yoksa yeni kayıt ekle
                            string insertQuery = "INSERT INTO Attendance (EmployeeID, AttendanceDate, Status) VALUES (@id, CAST(GETDATE() AS DATE), 'gelmedi')";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@id", employeeId);
                                int rowsAffected = insertCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Durumunuz 'gelmedi' olarak kaydedildi.");
                                    btnNotCame.Enabled = false;
                                    btnNotCame.Text = "Bugün gelmedi";
                                    btnCheckIn.Enabled = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Çıkış yap butonuna tıklandığında çalışır, giriş ekranına döner
        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}