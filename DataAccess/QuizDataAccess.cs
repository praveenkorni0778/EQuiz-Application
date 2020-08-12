using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using EQuiz.Models;
using System.Web;


namespace Quiz.Api.DataAccess
{
    public class QuizDataAccess
    {
        string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];

        public DataTable Get()
        {
            string queryString = "SELECT * FROM dbo.tbl_quiz;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataAdapter adp = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }
        }

        public string Post(QuizModel obj)
        {
            string msg = "";
            string queryString = "INSERT INTO tbl_quiz values('" + obj.q_name + "','" + obj.q_instruction + "','" + obj.q_duration + "'," + obj.q_status + "," + obj.q_tag + ",2)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }

                return msg;
            }
        }

        public string Put(QuizModel obj)
        {
            string qTagText = "";
            if (obj.q_tag == -1)
            {
                qTagText = "NULL";
            }
            else
            {
                qTagText = obj.q_tag.ToString();
            }
            string msg = "";
            string queryString = @"UPDATE tbl_quiz SET q_name = " + obj.q_name + ",q_instruction =" + obj.q_instruction + "" +
                ",q_duration ='" + obj.q_duration + "',q_status =" + obj.q_status + ",q_tag =" + qTagText + "" +
                ",q_adder =" + obj.q_adder + " WHERE q_id ="+obj.q_id+"";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }

                return msg;
            }
        }

        public string Delete(int id)
        {
            string msg = "";
            string queryString = "DELETE FROM tbl_quiz WHERE q_id =" + id + "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }

                return msg;
            }
        }


    }
    public class QuestionDataAccess
    {
        string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];

        public DataTable Get(int id)
        {
            string queryString = "SELECT * FROM tbl_question WHERE q_quiz = " + id + ";";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataAdapter adp = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }
        }

        public string Post(QuestionModel obj)
        {
            string msg = "";
            string queryString = "INSERT INTO tbl_question values(" + obj.q_quiz + ",'" + obj.q_question + "'," + obj.q_status + ")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }
                
                return msg;
            }
        }
        public string Put(QuestionModel obj)
        {
            string msg = "";
            string queryString = "UPDATE tbl_question SET q_quiz =" + obj.q_quiz + ",q_question ='" + obj.q_question + "',q_status =" + obj.q_status + "WHERE q_id ="+obj.q_id+"";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }

                return msg;
            }
        }

        public string Delete(int id)
        {
            string msg = "";
            string queryString = "DELETE FROM tbl_question WHERE q_id =" +id + "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }

                return msg;
            }
        }
    }
}