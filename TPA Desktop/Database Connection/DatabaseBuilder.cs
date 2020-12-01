using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPA_Desktop.Database_Connection
{
    public class DatabaseBuilder
    {

        SqlConnection sqlCon;

        public DatabaseBuilder()
        {
            sqlCon = DbConnection.getInstance();
        }

        #region Validate


        public int validateEmployeeID(String query, String employeeID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);

                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }


        public int validateCreditCardTransaction(String query, String customerAccountID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);

                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int validateCardInCreditCard(String query, String customerAccountID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);

                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int validateEmployeeID(String query, String employeeID, String password)
        {

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count=-1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeePassword", password);

                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();

               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int validateCustomerID(String query, string customerAccountID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);

                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;

        }

        public int validateCreditCard(String query, String creditCardID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@creditCardID", creditCardID);



                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }


        #endregion


        #region Insert

        public void insertFiredEmployee(String query, String employeeID, String employeeName)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeeName", employeeName);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertRequestFiring(String query, String employeeID, String employeeName)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeeName", employeeName);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertEmployeeResignList(String query, String employeeID, String employeeName)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeeName", employeeName);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertRequestEmployeeSalary(String query, String employeeID, String employeeUpdatedMoney)
        {

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeeUpdatedMoney", employeeUpdatedMoney);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }



        }



        public void insertRequestExpenses(String query, String requestExpensesID, String requestExpensesName, int requestExpensesMoney)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@requestExpensesID", requestExpensesID);
                sqlCmd.Parameters.AddWithValue("@requestExpensesName", requestExpensesName);
                sqlCmd.Parameters.AddWithValue("@requestExpensesMoney", requestExpensesMoney);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public void insertEmployee(String query, String employeeID, String employeeName, String employeePassword, String employeeEmail, String employeePhoneNumber)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeeName", employeeName);
                sqlCmd.Parameters.AddWithValue("@employeePassword", employeePassword);
                sqlCmd.Parameters.AddWithValue("@employeeEmail", employeeEmail);
                sqlCmd.Parameters.AddWithValue("@employeePhoneNumber", employeePhoneNumber);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }



        public void insertEmployeeRecruitment(String query, String employeeCandidateID, String employeeCandidateName, String employeeCandidateEmail, String employeeCandidatePhoneNumber)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeCandidateID", employeeCandidateID);
                sqlCmd.Parameters.AddWithValue("@employeeCandidateName", employeeCandidateName);
                sqlCmd.Parameters.AddWithValue("@employeeCandidateEmail", employeeCandidateEmail);
                sqlCmd.Parameters.AddWithValue("@employeeCandidatePhoneNumber", employeeCandidatePhoneNumber);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertBrokenItem(String query, String brokenItemID, String brokenItemName, String brokenItemLocation)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@brokenItemID", brokenItemID);
                sqlCmd.Parameters.AddWithValue("@brokenItemName", brokenItemName);
                sqlCmd.Parameters.AddWithValue("@brokenItemLocation", brokenItemLocation);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertQueue(String query, String queueNumber, String queueName)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@queueNumber", queueNumber);
                sqlCmd.Parameters.AddWithValue("@queueName", queueName);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertHOC(String query, String HOCID, String customerAccountID, String grossIncomeDocumentID, String HOCTypes)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@HOCID", HOCID);
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@grossIncomeDocumentID", grossIncomeDocumentID);
                sqlCmd.Parameters.AddWithValue("@HOCTypes", HOCTypes);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertCreditCard(String query, String customerAccountID, String creditCardID, String creditCardType)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@creditCardID", creditCardID);
                sqlCmd.Parameters.AddWithValue("@creditCardType", creditCardType);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertRequestCreditCardRequest(String query, String customerAccountID, String reqeustCreditCardID, String familyCardID, String identityCardID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@requestCreditCardID", reqeustCreditCardID);
                sqlCmd.Parameters.AddWithValue("@familyCardID", familyCardID);
                sqlCmd.Parameters.AddWithValue("@identityCardID", identityCardID);
               
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertCustomer(String query, int customerID, String customerName, String customerEmail, String customerPhoneNumber, String customerAddress, String customerAccountID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@customerID", customerID);
                sqlCmd.Parameters.AddWithValue("@customerName", customerName);
                sqlCmd.Parameters.AddWithValue("@customerEmail", customerEmail);
                sqlCmd.Parameters.AddWithValue("@customerPhoneNumber", customerPhoneNumber);
                sqlCmd.Parameters.AddWithValue("@customerAddress", customerAddress);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void insertTransactionCustomer(String query, String customerAccountID, String typeTransaction, int amountMoney)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@transaction", typeTransaction);
                sqlCmd.Parameters.AddWithValue("@amountMoney", amountMoney);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void insertCustomerRegularAccount(String query, String customerAccountID, String customerAccountName, String customerAccountBalanceInquiry, 
            String customerAccountType)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@customerAccountName", customerAccountName);
                sqlCmd.Parameters.AddWithValue("@customerAccountBalanceInquiry", customerAccountBalanceInquiry);
                sqlCmd.Parameters.AddWithValue("@customerAccountType", customerAccountType);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertCustomerStudentAccount(String query, String customerAccountID, String customerAccountName, String customerAccountBalanceInquiry,
            String customerAccountType, String linkAccount)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@customerAccountName", customerAccountName);
                sqlCmd.Parameters.AddWithValue("@customerAccountBalanceInquiry", customerAccountBalanceInquiry);
                sqlCmd.Parameters.AddWithValue("@customerAccountType", customerAccountType);
                sqlCmd.Parameters.AddWithValue("@linkAccount", linkAccount);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertVirtualAccount(String query, String virtualAccountID, String customerAccountID, String virtualAccountName, String virtualAccountNumber)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@virtualAccountID", virtualAccountID);
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
                sqlCmd.Parameters.AddWithValue("@virtualAccountName", virtualAccountName);
                sqlCmd.Parameters.AddWithValue("@virtualAccountNumber", virtualAccountNumber);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void insertLoans(String query, String loansID, String customerId, String guaranteeDocument, String reason, String typeLoan, String loansMoney)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@loansID", loansID);
                sqlCmd.Parameters.AddWithValue("@customerAccountId", customerId);
                sqlCmd.Parameters.AddWithValue("@guaranteeDocument", guaranteeDocument);
                sqlCmd.Parameters.AddWithValue("@reason", reason);
                sqlCmd.Parameters.AddWithValue("@typeLoan", typeLoan);
                sqlCmd.Parameters.AddWithValue("@loansMoney", loansMoney);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }




        #endregion


        #region Update

        public int updateFiringStatus(String query, String employeeID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int updateRequestExpenses(String query, String requestExpensesID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@requestExpensesID", requestExpensesID);

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int updatePermitStatus(String query, int leavingPermitNumber)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@leavingPermitNumber", leavingPermitNumber);

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int updateSalary(String query, String employeeID, int employeeSalary)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeeSalary", employeeSalary);

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int updateVirtualAccountBalanceInquiry(String query, String virtualAccountID, int amountOfMoney)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@amountOfMoney", amountOfMoney);
                sqlCmd.Parameters.AddWithValue("@virtualAccountID", virtualAccountID);

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }


        public int updateRequestCreditCard(String query, String requestCreditCardID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@requestCreditCardID", requestCreditCardID);
                
                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int updatePosition(String query, String employeeID, String employeePassword, String staffEmployeeID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
                sqlCmd.Parameters.AddWithValue("@employeePassword", employeePassword);
                sqlCmd.Parameters.AddWithValue("@staffEmployeeID", staffEmployeeID);


                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }


        public int updateMoneyTeller(String query, String customerID, int depositMoney)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerID);
                sqlCmd.Parameters.AddWithValue("@depositMoney", depositMoney);


                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;

        }

        public int updateMoneyTellerPayments(String query, String customerID, String paymentsType, int depositMoney)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerID);
                sqlCmd.Parameters.AddWithValue("@paymentsType", paymentsType);
                sqlCmd.Parameters.AddWithValue("@depositMoney", depositMoney);


                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;

        }

        public void setActiveAccount(String query, string customerAccountID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
              
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        public int creditCardPayments(String query, int amountMoney, String creditCardPaymentsID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@amountMoney", amountMoney);
                sqlCmd.Parameters.AddWithValue("@creditCardPaymentsID", creditCardPaymentsID);               

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }

        public int creditCardPaymentsTransfer(String query, int amountMoney, String creditCardID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = -1;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@amountOfMoney", amountMoney);
                sqlCmd.Parameters.AddWithValue("@creditCardID", creditCardID);

                count = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }


   
        #endregion


        #region Delete

       
        public void deleteEmployee(String query, String employeeID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void softDeleteNewEmployee(String query, String employeeCandidateID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@employeeCandidateID", employeeCandidateID);


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }


        public void softDeleteBrokenItem(String query, String brokenItemID)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@brokenItemID", brokenItemID);


                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void softDeleteDataWhenTheValueIsZero(String query)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void softDeleteDataWhenTheValueIsZero(String query, String x)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@requestCreditCardID", x);

                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        #endregion

        #region View


        public DataTable viewCustomerAccountDataSpecific(String query, String customerAccountID)
        {
            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }


        public DataTable viewCustomerAccountData(String query)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            
            
           
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();
 

            return dt;
        }

        public DataTable viewCustomerAccountData(String query, String customerAccountID)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@customerAccountID", customerAccountID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }

      

        public DataTable viewEmployeeData(String query, String employeeID)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@employeeID", employeeID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }

        public DataTable viewEmployeeCandidateData(String query, String employeeID)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@employeeCandidateID", employeeID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }


        public DataTable viewNewEmployeeData(String query, String newEmployeeID)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@employeeCandidateID", newEmployeeID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }



        public DataTable viewCreditCardID(String query, String creditCardID)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@creditCardID", creditCardID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }

        public DataTable viewRequestCreditCard(String query, String customerAccountID)
        {

            //MessageBox.Show("tING TIONG");

            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@requestCreditCardID", customerAccountID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;
        }


        public DataTable viewCustomerAccountID(String query, String creditCardID)
        {
            DataTable dt;

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@creditCardID", creditCardID);
            dt = new DataTable();

            SqlDataReader sdr = sqlCmd.ExecuteReader();
            dt.Load(sdr);
            sqlCon.Close();


            return dt;

        }



        #endregion


        #region Count

        public int selectCount(String query)
        {

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            int count = 0;
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
             
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return count;
        }




        #endregion










    }
}
