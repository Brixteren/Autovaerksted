using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp15
{
    class Program
    {
        public static void sqlConnection(string t, string c, string[] p)
        {
            try {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString= "Server = localhost; Database = Auto; Trusted_Connection = True";
                    conn.Open();

                    string stringComm;
                    SqlCommand command = new SqlCommand();

                    if (t == "k") // Kunder
                    {
                        if (c == "v") // Vis kunder
                        {
                            if (p[0] != "") // Vis kunder med parametre
                            {
                                stringComm = "SELECT * FROM Kunder WHERE '%@1%' IN (kundeID, kundeFornavn, kundeEfternavn, kundeAdresse)";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                sqlReader(command);

                            }
                            else // Vis alle kunder
                            {
                                command = new SqlCommand("SELECT * FROM Kunder", conn);
                                sqlReader(command);
                            }
                        }
                        else if (c == "o") // Opret kunder
                        {
                            if (p[0] != "")
                            {
                                stringComm = "INSERT INTO Kunde(kundeFornavn, kundeEfternavn, kundeAdresse) values ('@1', '@2', '@3')";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                command.Parameters.Add(new SqlParameter("2", p[1]));
                                command.Parameters.Add(new SqlParameter("3", p[2]));

                                sqlReader(command);
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                        else if (c == "s") // Slet kunde
                        {
                            if (p[0] != "")
                            {
                                stringComm = "DELETE Kunde WHERE kundeID = @1";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                        else if (c == "u") // Opdater kunde
                        {
                            if (p[0] != "")
                            {
                                stringComm = "UPDATE Kunde SET @1 = @2 WHERE kundeID = @3";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                command.Parameters.Add(new SqlParameter("2", p[1]));
                                command.Parameters.Add(new SqlParameter("3", p[2]));
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                    }

                    if (t == "b") // Biler
                    {
                        if (c == "v") // Vis biler
                        {
                            if (p[0] != "") // Vis biler med parametre
                            {
                                stringComm = "SELECT * FROM Biler WHERE '%@1%' IN (bilID, kundeID, bilRegNr, bilMærke, bilModel, bilAargang, bilKm, bilBraendstof)";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                sqlReader(command);

                            }
                            else // Vis alle biler
                            {
                                command = new SqlCommand("SELECT * FROM Biler", conn);
                                sqlReader(command);
                            }
                        }
                        else if (c == "o") // Opret bil
                        {
                            if (p[0] != "")
                            {
                                stringComm = "INSERT INTO Biler(kundeID, bilRegNr, bilMærke, bilModel, bilAargang, bilKm, bilBraendstof) values ('@1', '@2', '@3', '@4', @5, @6, '@7')";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                command.Parameters.Add(new SqlParameter("2", p[1]));
                                command.Parameters.Add(new SqlParameter("3", p[2]));
                                command.Parameters.Add(new SqlParameter("4", p[3]));
                                command.Parameters.Add(new SqlParameter("5", p[4]));
                                command.Parameters.Add(new SqlParameter("6", p[5]));
                                command.Parameters.Add(new SqlParameter("7", p[6]));

                                sqlReader(command);
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                        else if (c == "s") // Slet bil
                        {
                            if (p[0] != "")
                            {
                                stringComm = "DELETE Biler WHERE bilID = @1";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                        else if (c == "u") // Opdater bil
                        {
                            if (p[0] != "")
                            {
                                stringComm = "UPDATE Biler SET @1 = @2 WHERE bilID = @3";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                command.Parameters.Add(new SqlParameter("2", p[1]));
                                command.Parameters.Add(new SqlParameter("3", p[2]));
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                    }

                    if (t == "o") // Værkstedsbesøg
                    {
                        if (c == "v") // Vis værkstedsbesøg
                        {
                            if (p[0] != "") // Vis værkstedsbesøg med parametre
                            {
                                stringComm = "SELECT * FROM Ordre WHERE '%@1%' IN (ordreID, kundeID, bilID, problem, dato)";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                sqlReader(command);

                            }
                            else // Vis alle værkstedsbesøg
                            {
                                command = new SqlCommand("SELECT * FROM Ordre", conn);
                                sqlReader(command);
                            }
                        }
                        else if (c == "o") // Opret værkstedsbesøg
                        {
                            if (p[0] != "")
                            {
                                stringComm = "INSERT INTO Ordre(kundeID, bilID, problem, dato) values ('@1', '@2', '@3', GETDATE())";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                command.Parameters.Add(new SqlParameter("2", p[1]));
                                command.Parameters.Add(new SqlParameter("3", p[2]));

                                sqlReader(command);
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                        else if (c == "s") // Slet værkstedsbesøg
                        {
                            if (p[0] != "")
                            {
                                stringComm = "DELETE Ordre WHERE ordreID = @1";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                        else if (c == "u") // Opdater værkstedsbesøg
                        {
                            if (p[0] != "")
                            {
                                stringComm = "UPDATE Ordre SET @1 = @2 WHERE ordreID = @3";
                                command = new SqlCommand(stringComm, conn);
                                command.Parameters.Add(new SqlParameter("1", p[0]));
                                command.Parameters.Add(new SqlParameter("2", p[1]));
                                command.Parameters.Add(new SqlParameter("3", p[2]));
                            }
                            else
                            {
                                Console.WriteLine("Du har ikke sendt nogle parametre med");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static DataTable sqlReader(SqlCommand i)
        {
            DataTable output = new DataTable();
            using (SqlDataReader reader = i.ExecuteReader())
            {
                while (reader.Read())
                {
                    output.Load(reader);
                }
            }

            return output;
        }

        static void Main(string[] args)
        {
        }
    }
}
