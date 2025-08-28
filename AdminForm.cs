using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            LoadAttendanceData(); // Form açıldığında devamsızlık verilerini yükle
        }

        // Devamsızlık verilerini veritabanından çekip DataGridView'e yükler
        private void LoadAttendanceData()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Seçili tarihe göre devamsızlık verilerini ve çalışan bilgilerini getir
                    string query = @"SELECT e.FirstName, e.LastName, a.AttendanceDate, a.Status 
                                   FROM Attendance a 
                                   INNER JOIN Employees e ON a.EmployeeID = e.EmployeeID 
                                   WHERE a.AttendanceDate = @selectedDate
                                   ORDER BY a.AttendanceDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Tarih parametresini ekle
                        cmd.Parameters.AddWithValue("@selectedDate", dtpDate.Value.Date);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Sonuçları DataGridView'e ata
                        dgvAttendance.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya mesaj göster
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // Tarih seçici değiştiğinde verileri güncelle
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }

        // Yenile butonuna basıldığında verileri tekrar yükle
        private void btnReflesh_Click(object sender, EventArgs e)
        {
            LoadAttendanceData();
        }
    }
}