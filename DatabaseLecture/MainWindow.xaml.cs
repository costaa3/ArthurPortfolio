using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseLecture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseLecture.Properties.Settings.ZooManagerConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            showZoos();
            showAllAnimals();
        }

        private void showZoos()
        {
            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();
                    sqlDataAdapter.Fill(zooTable);

                    listOfZoos.DisplayMemberPath = "Location";
                    listOfZoos.SelectedValuePath = "Id";
                    listOfZoos.ItemsSource = zooTable.DefaultView; ;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void showAnimals()
        {
            try
            {
                string query = "select * from Animal a inner join ZooAnimal za on a.Id = za.AnimalId where za.ZooId = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listOfZoos.SelectedValue);
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    listOfAnimals.DisplayMemberPath = "Name";
                    listOfAnimals.SelectedValuePath = "Id";
                    listOfAnimals.ItemsSource = animalTable.DefaultView; ;
                }
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.ToString());
            }

        }


        private void showAllAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable allAnimalsTable = new DataTable();
                    sqlDataAdapter.Fill(allAnimalsTable);
                    listOfAllAnimals.DisplayMemberPath = "Name";
                    listOfAllAnimals.SelectedValuePath = "Id"; // set to the correct column name
                    listOfAllAnimals.ItemsSource = allAnimalsTable.DefaultView;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void listOfZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(listOfZoos.SelectedValue.ToString()) ;
            showAnimals();
            ShowSelectedZoo();
        }

        private void ShowSelectedZoo()
        {
            try
            {
                string query = "Select Location from Zoo where Id  = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdaptersqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdaptersqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", listOfZoos.SelectedValue);
                    DataTable dataTable = new DataTable();
                    sqlDataAdaptersqlDataAdapter.Fill(dataTable);
                    MyTextBox.Text = dataTable.Rows[0]["Location"].ToString();
                }
            }
            catch (Exception)
            {


            }

        }
        //public void ShowSelectedAnimal()
        //{
        //    try
        //    {
        //        string selectedId = listOfAllAnimals.SelectedValue?.ToString();

        //        if (!string.IsNullOrEmpty(selectedId))
        //        {
        //            string query = "SELECT Name FROM Animal WHERE Id = @Id";
        //            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //            sqlCommand.Parameters.AddWithValue("@Id", selectedId);

        //            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
        //            {
        //                DataTable data = new DataTable();
        //                sqlDataAdapter.Fill(data);
        //                if (data.Rows.Count > 0)
        //                {
        //                    MyTextBox.Text = data.Rows[0]["Name"].ToString();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        showAllAnimals();
        //    }
        //}

        public void ShowSelectedAnimal()
        {
            string selectedId = listOfAllAnimals.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(selectedId)) { return; }
            try
            {
                string query = "SELECT Name FROM Animal WHERE Id=@Id";
                using (SqlCommand sql = new SqlCommand(query, sqlConnection))
                {
                    sql.Parameters.AddWithValue("@Id", selectedId);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count > 0)
                        {
                            MyTextBox.Text = dataTable.Rows[0]["Name"].ToString();
                        }
                    }
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();

            }

        }

        

        public void UpdateZooClick(object sender, RoutedEventArgs e)
        {
            string userInput = MyTextBox.Text;
            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Text Box is empty, please insert the zoo Name");
                return;
            }
            try
            {
                string query = "UPDATE Zoo SET Location = @Location WHERE Id = @Id ";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Location", userInput);
                    sqlCommand.Parameters.AddWithValue("@Id", listOfZoos.SelectedValue);

                    sqlCommand.ExecuteScalar();



                }
            }
            catch (Exception)
            {

                MessageBox.Show("err");
            }
            finally
            {
                sqlConnection.Close();
                showZoos();
            }


        }
        public void UpdateZooClick()
        {
            string userInput = MyTextBox.Text;
            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Text Box is empty, please insert the zoo Name");
                return;
            }
            try
            {
                string query = "UPDATE Zoo SET Location = @Location WHERE Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Location", userInput);
                    sqlCommand.Parameters.AddWithValue("@Id", listOfZoos.SelectedValue);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Zoo updated successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update zoo");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showZoos();
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteZoo(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show(listOfZoos.SelectedValue.ToString());
                string query = "delete from Zoo where Id = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listOfZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
                showZoos();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        private void AddZoo(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Zoo values (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", MyTextBox.Text);
                sqlCommand.ExecuteScalar();
                showZoos();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void AddAnimalToZoo(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into ZooAnimal values (@ZooId, @AnimalId) ";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooID", (int)listOfZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", (int)listOfAllAnimals.SelectedValue);

                var outcome = sqlCommand.ExecuteScalar();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAnimals();
            }


        }


        private void RemoveAnimalFromZoo(object sender, RoutedEventArgs e)
        {
            try
            {

                string query = "delete from zooAnimal where ZooID = @ZooId and AnimalId = @AnimalId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listOfZoos.SelectedValue);

                sqlCommand.Parameters.AddWithValue("@AnimalId", listOfAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAnimals();
            }
        }


        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Animal values (@Name)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();



                sqlCommand.Parameters.AddWithValue("@Name", MyTextBox.Text);
                sqlCommand.ExecuteScalar();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                sqlConnection.Close();
                showAllAnimals();
            }
        }

        private void UpdateAnimal(object sender, RoutedEventArgs e)
        {
            string userInput = MyTextBox.Text;
            string SelectedItem = listOfAllAnimals.SelectedValue?.ToString();
            if(string.IsNullOrEmpty(userInput)|| string.IsNullOrEmpty(SelectedItem))
            {
                MessageBox.Show("Make sure an Animal is selected and the name it's correct");
                return;
            }
            try
            {
                string query = "UPDATE Animal SET Name = @Name WHERE Id = @Id";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Name", userInput);
                    sqlCommand.Parameters.AddWithValue("@Id", SelectedItem);
                    sqlCommand.ExecuteScalar();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                showAllAnimals();
                sqlConnection.Close();
            }
        }

        private void DeleteAnimal(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Animal where Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", listOfAllAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
                showAllAnimals();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void listOfAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimal();
        }
    }
}
